using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class FriendsBO
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string FriendUserId { get; set; }
        public string Status { get; set; }
        public string BelongsTo { get; set; }      
    }
}
