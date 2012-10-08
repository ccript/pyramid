using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class TickerBO
    {

        public string Id { get;set;}
        public string TickerOwnerUserId { get; set; }
        public string PostedByUserId { get; set; }
        public string WallId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
         public string EmbedPost { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
