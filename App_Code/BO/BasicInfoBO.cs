using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class BasicInfoBO
    {

        public string Id { get;set;}

        public string UserId{ get; set; }

        public string CurrentCity { get;set;}

        public string HomeTown { get; set; }

        public string CityTown { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Neighbourhood { get; set; }

        public string RelationshipStatus { get; set; }
        
    }
}
