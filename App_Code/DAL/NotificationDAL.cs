using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;


using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
/// <summary>
/// Summary description for NotificationDAL
/// </summary>
/// 

namespace DataLayer
{
    public class NotificationDAL : BaseClass
    {
        
        public NotificationDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertNotification(NotificationBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Notification");

                 
                     BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AtId" ,  ObjectId.Parse(objClass.AtId) },
                          { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                        { "MyNotification" , objClass.MyNotification },
                        { "Type", objClass.Type },
                         { "FriendId" ,  ObjectId.Parse(objClass.FriendId) },
                        { "FriendFName", objClass.FirstName },
                        { "FriendLName", objClass.LastName },
                         { "Status", objClass.Status },
                          { "AddedDate", DateTime.Now },
                        };

                     var rt=objCollection.Insert(doc);

                     return doc["_id"].ToString();

              
        

           
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateNotification(NotificationBO objClass)
        {

            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                 .Set("FirstName", objClass.FirstName)
                                .Set("LastName", objClass.LastName)
                                .Set("AtId", ObjectId.Parse(objClass.AtId))
                                 .Set("MyNotification", objClass.MyNotification)
                                .Set("Type", objClass.Type)
                                .Set("FriendId", ObjectId.Parse(objClass.AtId))
                                .Set("FriendFName", objClass.FirstName)
                                .Set("FriendLName", objClass.LastName)
                                .Set("Status", objClass.Status)
                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static void updateNotificationStatus(string userid)
        {
            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");

            var query = Query.And(
                      Query.EQ("Status", false),
                       Query.EQ("UserId", ObjectId.Parse(userid)));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Status", true);
            var result = objCollection.Update(query,  update,UpdateFlags.Multi);
        }

        public static long countNotification(string UserId)
        {
            

            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");
            var query = Query.And(
                   Query.EQ("Status", false), 
                   Query.EQ("UserId", ObjectId.Parse(UserId))
                  );
            var result = objCollection.Find(query);
            return result.Count();



        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteNotification(string Id)
          {
              MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Notification> getAllNotificationList()
        {
            List<Notification> lst = new List<Notification>();

            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");

            foreach (Notification item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static NotificationBO getNotificationByNotificationId(string Id)
        {
            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");

            NotificationBO objClass = new NotificationBO();
            foreach (Notification item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.AtId= item.AtId.ToString();
                objClass.FriendId = item.AtId.ToString();
                objClass.Type = item.Type;
                objClass.MyNotification = item.MyNotification;
                objClass.FriendFName = item.FirstName;
                objClass.FriendLName = item.LastName;
                objClass.Status = item.Status;
                objClass.AddedDate = item.AddedDate;
                break;
            }
            return objClass;
           
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Notification> getNotificationTop5(int Type, string AtId)
        {
            List<Notification> lst = new List<Notification>();

            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            var cursor = objCollection.Find(query);
           // cursor.Limit = 5;
           // var sortBy = SortBy.Descending("_id");
           // cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Notification> getNotificationByUserId(string UserId)
        {
            List<Notification> lst = new List<Notification>();

            MongoCollection<Notification> objCollection = db.GetCollection<Notification>("c_Notification");
            objCollection.EnsureIndex("Type");

            var query =
                         Query.EQ("UserId", ObjectId.Parse(UserId));
            var cursor = objCollection.Find(query);
            // cursor.Limit = 5;
             var sortBy = SortBy.Descending("_id");
             cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
    }
}

#region Notification
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Notification
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ObjectId AtId { get; set; }
    public string MyNotification { get; set; }
    public int Type { get; set; }
    public ObjectId FriendId { get; set; }
    public string FriendFName { get; set; }
    public string FriendLName { get; set; }
    public bool Status { get; set; }
    public DateTime AddedDate { get; set; }

}
#endregion