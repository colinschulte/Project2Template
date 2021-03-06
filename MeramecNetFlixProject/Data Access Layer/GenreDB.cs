﻿using System;
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
    public static class GenreDB
    {
        private static string GetConnectionString()
        {
            string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_Schulte;User Id=schulte;Password=schulte;";
            return connectionString;
        }
        public static List<Genre> GetGenres()
        {
            List<Genre> genreList = new List<Genre>();
            string connectionString = GetConnectionString();
            string sqlString= "select id, name from Genre";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    genreList = db.Query<Genre>(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return genreList;
        }
        public static Genre GetGenre(int genreID)
        {
            Genre myGenre;

            string connectionString = GetConnectionString();
            string sqlString = "select id, name from genre where id = @genre_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", genreID, DbType.Int32, ParameterDirection.Input);
                    myGenre = db.QuerySingleOrDefault<Genre>(sqlString, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myGenre;
        }
        public static bool AddGenre(Genre objGenre)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "insert into Genre values (@genre_id, @genre_name)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_name", objGenre.name, DbType.String, ParameterDirection.Input);
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
        public static bool UpdateGenre(Genre objGenre)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "update Genre " +
                               " set name = @genre_name " +
                               " where id = @genre_id ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_name", objGenre.name, DbType.String, ParameterDirection.Input);
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
        public static bool DeleteGenre(Genre objGenre)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlString = "delete Genre where id = @genre_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);
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
