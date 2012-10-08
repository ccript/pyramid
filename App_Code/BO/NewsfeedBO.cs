using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{
    public class NewsfeedBO
    {

        public string Id { get; set; }
        public string WallOwnerUserId { get; set; }
        public string PostedByUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public string Post { get; set; }
        public string EmbedPost { get; set; }
        public DateTime AddedDate { get; set; }
        
        public int PostRank { get; set; }
        public int AffinityScore { get; set; }
        public int PostWeight { get; set; }
        public int TimeDecay { get; set; }



    }
}