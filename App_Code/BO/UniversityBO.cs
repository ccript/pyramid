using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class UniversityBO
    {

        public string Id { get;set;}

        public string UserId { get; set; }

        public string UniversityName { get;set;}

        public int ClassYear { get; set; }

        public string Purpose { get; set; }

        public string Degree { get; set; }

        public string AttendedFor { get; set; }

        public string Image { get; set; }
        
    }
}
