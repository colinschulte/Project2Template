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
    public static class GenreDB
    {
        public static List<Genre> GetGenres()
        {
            List<Genre> genreList = new List<Genre>();
            string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_Schulte;User Id=schulte;Password=schulte;";
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
            Genre myGenre = new Genre();

            return myGenre;
        }
        public static bool AddGenre(Genre objGenre)
        {
            return true;
        }
        public static bool UpdateGenre(Genre objGenre)
        {
            return true;
        }
        public static bool DeleteGenre(Genre objGenre)
        {
            return true;
        }

    }
}
