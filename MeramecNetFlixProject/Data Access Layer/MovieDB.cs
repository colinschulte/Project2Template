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
    public static class MovieDB
    {
        private static string GetConnectionString()
        {
            string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_Schulte;User Id=schulte;Password=schulte;";
            return connectionString;
        }
        public static List<Movie> GetMovies()
        {
            List<Movie> movieList = new List<Movie>();
            string connectionString = GetConnectionString();
            string sqlString = "select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, image, rental_duration, trailer from Movie";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    movieList = db.Query<Movie>(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return movieList;
        }
        public static Movie GetMovie(int movieNumber)
        {
            Movie myMovie;

            string connectionString = GetConnectionString();
            string sqlString = "select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, image, rental_duration, trailer from movie where movie_number = @movie_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", movieNumber, DbType.Int32, ParameterDirection.Input);
                    myMovie = db.QuerySingleOrDefault<Movie>(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myMovie;
        }
        public static bool AddMovie(Movie objMovie)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "insert into Movie values (@movie_number, @movie_title, @description, @movie_year_made, @genre_id, @movie_rating, @image, @rental_duration, @trailer)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", objMovie.movie_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_title", objMovie.movie_title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@description", objMovie.description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@movie_year_made", objMovie.movie_year_made, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_id", objMovie.genre_id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_rating", objMovie.movie_rating, DbType.String, ParameterDirection.Input);
                    parameters.Add("@image", objMovie.image, DbType.String, ParameterDirection.Input);
                    parameters.Add("@rental_duration", objMovie.rental_duration, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@trailer", objMovie.trailer, DbType.String, ParameterDirection.Input);
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
        public static bool UpdateMovie(Movie objMovie)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "update Movie " +
                               "set movie_title = @movie_title, description = @description, " +
                               "movie_year_made = @movie_year_made, genre_id = @genre_id, " +
                               "movie_rating = @movie_rating, image = @image, " + 
                               "rental_duration = @rental_duration, trailer = @trailer " +
                               "where movie_number = @movie_number ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", objMovie.movie_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_title", objMovie.movie_title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@description", objMovie.description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@movie_year_made", objMovie.movie_year_made, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_id", objMovie.genre_id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_rating", objMovie.movie_rating, DbType.String, ParameterDirection.Input);
                    parameters.Add("@image", objMovie.image, DbType.String, ParameterDirection.Input);
                    parameters.Add("@rental_duration", objMovie.rental_duration, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@trailer", objMovie.trailer, DbType.String, ParameterDirection.Input);
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
        public static bool DeleteMovie(Movie objMovie)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "delete Movie where movie_number = @Movie_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Movie_number", objMovie.movie_number, DbType.Int32, ParameterDirection.Input);
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
