using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MeramecNetFlixProject.Business_Objects;
using Dapper;
using System.Data;

namespace MeramecNetFlixProject.Data_Access_Layer
{
    class RentalDB
    {
        private static string GetConnectionString()
        {
            string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_Schulte;User Id=schulte;Password=schulte;";
            return connectionString;
        }

        public static List<Rental> GetRentals()
        {
            List<Rental> rentalList = new List<Rental>();
            string connectionString = GetConnectionString();
            string sqlString = "select movie_number, member_number, media_purchase_date, media_streaming_start_date, media_return_date from rental";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    rentalList = db.Query<Rental>(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rentalList;
        }
        public static Rental GetRental(int movieNumber, int memberNumber)
        {
            Rental myRental;

            string connectionString = GetConnectionString();
            string sqlString = "select movie_number, member_number, media_purchase_date, media_streaming_start_date, media_return_date from rental where movie_number = @movie_number AND member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", movieNumber, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@member_number", memberNumber, DbType.Int32, ParameterDirection.Input);
                    myRental = db.QuerySingleOrDefault<Rental>(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myRental;
        }
        public static bool AddRental(Rental objRental)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "insert into rental values (@movie_number, @member_number, @media_purchase_date, @media_streaming_start_date, @media_return_date)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", objRental.movie_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@member_number", objRental.member_number, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@media_purchase_date", objRental.media_purchase_date, DbType.String, ParameterDirection.Input);
                    parameters.Add("@media_streaming_start_date", objRental.media_streaming_start_date, DbType.String, ParameterDirection.Input);
                    parameters.Add("@media_return_date", objRental.media_return_date, DbType.String, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool UpdateRental(Rental objRental)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "update rental " +
                               " set media_purchase_date = @media_purchase_date, " + 
                               " media_streaming_start_date = @media_streaming_start_date, " + 
                               " media_return_date = @media_return_date " +
                               " where movie_number = @movie_number AND member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", objRental.movie_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@member_number", objRental.member_number, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@media_purchase_date", objRental.media_purchase_date, DbType.String, ParameterDirection.Input);
                    parameters.Add("@media_streaming_start_date", objRental.media_streaming_start_date, DbType.String, ParameterDirection.Input);
                    parameters.Add("@media_return_date", objRental.media_return_date, DbType.String, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool DeleteRental(Rental objRental)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "delete rental where movie_number = @movie_number AND member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", objRental.movie_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@member_number", objRental.member_number, DbType.Int32, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
    }
}
