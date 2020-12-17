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
    class MemberDB
    {
        private static string GetConnectionString()
        {
            string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_Schulte;User Id=schulte;Password=schulte;";
            return connectionString;
        }
        public static List<Member> GetMembers()
        {
            List<Member> memberList = new List<Member>();
            string connectionString = GetConnectionString();
            string sqlString = "select member_status, member_number, joindate, firstname, lastname, zipcode, cell_phone, username, password, email from Member";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    memberList = db.Query<Member>(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return memberList;
        }
        public static Member GetMember(int MemberNumber)
        {
            Member myMember;

            string connectionString = GetConnectionString();
            string sqlString = "select member_status, member_number, joindate, firstname, lastname, zipcode, cell_phone, username, password, email from Member where member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_number", MemberNumber, DbType.Int32, ParameterDirection.Input);
                    myMember = db.QuerySingleOrDefault<Member>(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myMember;
        }
        public static bool AddMember(Member objMember)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "insert into Member values (@member_status, @member_number, @joindate, @firstname, @lastname, @zipcode, @cell_phone, @username, @password, @email)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_status", objMember.member_status, DbType.String, ParameterDirection.Input);
                    parameters.Add("@member_number", objMember.member_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@joindate", objMember.joindate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@firstname", objMember.firstname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@lastname", objMember.lastname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@zipcode", objMember.zipcode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@cell_phone", objMember.cell_phone, DbType.String, ParameterDirection.Input);
                    parameters.Add("@username", objMember.username, DbType.String, ParameterDirection.Input);
                    parameters.Add("@password", objMember.password, DbType.String, ParameterDirection.Input);
                    parameters.Add("@email", objMember.email, DbType.String, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0;
            return returnStatus;
        }
        public static bool UpdateMember(Member objMember)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "update member " +
                               "set member_status = @member_status, joindate = @joindate, " + 
                               "firstname = @firstname, lastname = @lastname, " + 
                               "zipcode = @zipcode, cell_phone = @cell_phone, username = @username, " + 
                               "password = @password, email = @email " +
                               "where member_number = @member_number ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_status", objMember.member_status, DbType.String, ParameterDirection.Input);
                    parameters.Add("@member_number", objMember.member_number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@joindate", objMember.joindate, DbType.String, ParameterDirection.Input);
                    parameters.Add("@firstname", objMember.firstname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@lastname", objMember.lastname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@zipcode", objMember.zipcode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@cell_phone", objMember.cell_phone, DbType.String, ParameterDirection.Input);
                    parameters.Add("@username", objMember.username, DbType.String, ParameterDirection.Input);
                    parameters.Add("@password", objMember.password, DbType.String, ParameterDirection.Input);
                    parameters.Add("@email", objMember.email, DbType.String, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0;
            return returnStatus;
        }
        public static bool DeleteMember(Member objMember)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "delete Member where member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_number", objMember.member_number, DbType.Int32, ParameterDirection.Input);
                    rowsAffected = db.Execute(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            returnStatus = rowsAffected > 0;
            return returnStatus;
        }
        public static Member LoginMember(string memberUsername, string memberPassword)
        {
            Member myMember;
            string connectionString = GetConnectionString();
            string sqlString = "select member_status, member_number, joindate, firstname, lastname, zipcode, cell_phone, username, password, email from Member WHERE username = @username AND password = @password";
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@username", memberUsername, DbType.String, ParameterDirection.Input);
                    parameters.Add("@password", memberPassword, DbType.String, ParameterDirection.Input);
                    myMember = db.QuerySingleOrDefault<Member>(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myMember;
        }
    }
}

