using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DataLayer
{
    public class SubscriptionDAL : BaseClass
    {

        public SubscriptionDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertSubscription(SubscriptionBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Subscription");
            BsonDocument doc = new BsonDocument {
                { "SubscriberUserId" , ObjectId.Parse(objClass.PublisherUserId) },
                { "PublisherUserId", ObjectId.Parse(objClass.SubscriberUserId) }
            };
            var rt = objCollection.Insert(doc);
            return doc["_id"].ToString();
        }
        public static List<Subscription> getSubscribtions(string PublisherId)
        {
            List<Subscription> lst = new List<Subscription>();
            MongoCollection<Subscription> objCollection = db.GetCollection<Subscription>("c_Subscription");

            foreach (Subscription item in objCollection.Find(Query.EQ("PublisherUserId", ObjectId.Parse(PublisherId))))
                {
                    lst.Add(item);
                }
            return lst.Distinct().ToList();

        }
        public static Boolean deleteSubscription(string publisherId, string subscriberId){
            MongoCollection<Subscription> objCollection = db.GetCollection<Subscription>("c_Subscription");
            var query = Query.And(
                    Query.Matches("PublisherUserId", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + publisherId + ""))),
                   Query.Matches("SubscriberUserId", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + subscriberId + ""))));
            var result = objCollection.FindAndRemove(query,
                  SortBy.Ascending("_id"));
            return true;
        }
    }
    
}
#region Subscription
public class Subscription
{
    public ObjectId _id { get; set; }
    public ObjectId SubscriberUserId { get; set; }
    public ObjectId PublisherUserId { get; set; }
}
#endregion