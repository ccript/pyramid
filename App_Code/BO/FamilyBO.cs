using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class FamilyBO
    {

        public int FamilyId { get; set; }

        public int UserId { get; set; }
       
        public int FriendUserId { get; set; }

        public string Relation { get; set; }

        public bool AcceptStatus { get; set; }

    }
}
