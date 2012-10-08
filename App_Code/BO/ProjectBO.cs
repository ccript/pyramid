using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class ProjectBO
    {

        public string Id { get;set;}

        public string UserId { get; set; }

        public string EmployerId { get; set; }

        public string ProjectName { get;set;}

        public string Description { get; set; }

        public int StartYear { get; set; }

        public int StartMonth { get; set; }

        public int StartDay { get; set; }

        public int EndYear { get; set; }

        public int EndMonth { get; set; }

        public int EndDay { get; set; }

        public string Image { get; set; }
        
    }
}
