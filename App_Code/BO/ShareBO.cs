using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShareBO
/// </summary>
namespace ObjectLayer
{
    public class ShareBO
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        
        public string AtId { get; set; }
        public int Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AddedDate { get; set; }
    }
}