using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using System.Collections;

using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
/// <summary>
/// Summary description for ActivityDAL
/// </summary>
/// 

namespace DataLayer
{
    public class ActivityDAL : BaseClass
    {
        
        public ActivityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertActivity(ActivityBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Activities");

                 var query = Query.And(
                         Query.EQ("Type", objClass.Type),
                         Query.EQ("Name", objClass.Name),
                          Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
                 var result = objCollection.Find(query);
                 if (!result.Any())
                 {
                     BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Name" , objClass.Name },
                        { "Description" , objClass.Description },
                        { "Type", objClass.Type },
                        { "Image",objClass.Image }
        
                        };

                     var rt=objCollection.Insert(doc);

                     return doc["_id"].ToString();

                 }

                 else
                     return null;
        

           
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateActivity(ActivityBO objClass)
        {

            MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)
                                 .Set("Description", objClass.Description)
                                .Set("Type", objClass.Type)
                                .Set("Image", objClass.Image)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteActivity(string Id)
          {
              MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Activity> getAllActivityList()
        {
            List<Activity> lst = new List<Activity>();

            MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");

            foreach (Activity item in objCollection.FindAll())
            {
                lst.Add(item);
            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ActivityBO getActivityByActivityId(string Id)
        {
            MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");

            ActivityBO objClass = new ActivityBO();
            foreach (Activity item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Name = item.Name;
                objClass.Type = item.Type;
                objClass.Description= item.Description;
                objClass.Image = item.Image;
                break;
            }
            return objClass;
           
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ArrayList getActivitiesByUserId(string Id)
        {
            ArrayList Activities = new ArrayList();

            MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");

            ActivityBO objClass = new ActivityBO();
            foreach (Activity item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                Activities.Add(item.Name);
            }
            return Activities;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Activity> getActivityTop5(string Type, string UserId)
        {
            List<Activity> lst = new List<Activity>();

            MongoCollection<Activity> objCollection = db.GetCollection<Activity>("c_Activities");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("UserId", ObjectId.Parse(UserId)));
            var cursor = objCollection.Find(query);
            cursor.Limit = 5;
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
       

    }
}

#region Activity
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Activity
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Image { get; set; }

}
#endregion