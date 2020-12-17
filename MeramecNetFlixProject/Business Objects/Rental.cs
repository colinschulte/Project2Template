using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    class Rental
    {
        public int movie_number { get; set; }
        public int member_number { get; set; }
        public DateTime media_purchase_date { get; set; }
        public DateTime media_streaming_start_date { get; set; }
        public DateTime media_return_date { get; set; }
    }
}
