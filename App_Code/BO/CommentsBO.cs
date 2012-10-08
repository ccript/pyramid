using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class CommentsBO
    {

        public string Id { get;set;}

        public string UserId { get; set; }

        public string AtId { get; set; }
        public int Type { get; set; }
        public string MyComments { get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
