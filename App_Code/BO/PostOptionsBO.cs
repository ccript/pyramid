using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PostOptionsBO
/// </summary>
/// 

namespace ObjectLayer
{

    public class PostOptionsBO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string PostId { get; set; }
        public int PostStatus { get; set; }
    }
}