using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class MediaBO
    {

        public string Id { get;set;}

        public string UserId { get; set; }

        public string AlbumId { get; set; }

        public string Name { get; set; }
       
        public string Caption { get; set;}

        public string Description { get;set;}

        public string Location { get; set; }

        public DateTime AddedDate { get;set;}

        public int Type { get; set; }

        public bool isFollow { get; set; }

    }
}
