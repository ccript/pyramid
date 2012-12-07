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

namespace DataLayer
{
    public class EntertainmentDAL : BaseClass
    {
        
        public EntertainmentDAL()
        {
        }
 

        public static void insertEntertainment(EntertainmentBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Entertainment");

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
                        { "Type", objClass.Type },
                        { "Image",objClass.Image }
        
                        };

                objCollection.Insert(doc);

            }
    
        }

        public static void updateEntertainment(EntertainmentBO objClass)
        {

            MongoCollection<Entertainment> objCollection = db.GetCollection<Entertainment>("c_Entertainment");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)
                                .Set("Type", objClass.Type)
                                .Set("Image", objClass.Image)
                     
                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);
        }

        public static void deleteEntertainment(string Id)
          {

              MongoCollection<Entertainment> objCollection = db.GetCollection<Entertainment>("c_Entertainment");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));
          }
     
        public static List<Entertainment> getAllEntertainmentList()
        {
            List<Entertainment> lst = new List<Entertainment>();

            MongoCollection<Entertainment> objCollection = db.GetCollection<Entertainment>("c_Entertainment");

            foreach (Entertainment item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
     
        public static EntertainmentBO getEntertainmentByEntertainmentId(string Id)
        {
          
            MongoCollection<Entertainment> objCollection = db.GetCollection<Entertainment>("c_Entertainment");

            EntertainmentBO objClass = new EntertainmentBO();
            foreach (Entertainment item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Name = item.Name;
                objClass.Type = item.Type;
                objClass.Image = item.Image;
                break;
            }
            return objClass;
        }

        public static List<Entertainment> getEntertainmentTop5(string Type, string UserId)
        {
            

            List<Entertainment> lst = new List<Entertainment>();

            MongoCollection<Entertainment> objCollection = db.GetCollection<Entertainment>("c_Entertainment");
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

#region Entertainment
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Entertainment
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Image { get; set; }

}
#endregion