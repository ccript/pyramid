using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectLayer
{

    public class SubscriptionBO
    {

        public string Id { get;set;}
        public string SubscriberUserId { get; set; }
        public string PublisherUserId { get; set; }

    }
}
