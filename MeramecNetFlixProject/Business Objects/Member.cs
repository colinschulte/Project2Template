using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    class Member
    {
        public string member_status { get; set; }
        public int member_number { get; set; }
        public DateTime joindate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string zipcode { get; set; }
        public string cell_phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
