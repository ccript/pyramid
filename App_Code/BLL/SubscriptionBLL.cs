﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

namespace BuinessLayer
{

    public class SubscriptionBLL
    {
        public SubscriptionBLL()
        {
        }
        
        public static string insertSubscription(SubscriptionBO objTicker)
        {
            return SubscriptionDAL.insertSubscription(objTicker);
        }
        public static Boolean deleteSubscription(string publisherId, string subscriberId)
        {
            return SubscriptionDAL.deleteSubscription(publisherId, subscriberId);
        }
        public static List<Subscription> getSubscribers(string PublisherId)
        {
            return SubscriptionDAL.getSubscribtions(PublisherId);
        }
    }
     
}