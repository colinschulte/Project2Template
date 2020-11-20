using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Movie
    {
        public int movie_number { get; set; }
        public string movie_title { get; set; }
        public string description { get; set; }
        public int movie_year_made { get; set; }
        public int genre_id { get; set; }
        public string movie_rating { get; set; }
        public string image { get; set; }
        public int rental_duration { get; set; }
        public string trailer { get; set; }
    }
}
