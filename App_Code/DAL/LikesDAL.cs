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
    public class LikesDAL : BaseClass
    {
        
        public LikesDAL()
        {
        }
 
        public static void insertLikes(LikesBO objClass)
        {
          
                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Likes");

                 var query = Query.And(
                    Query.EQ("Type", objClass.Type),
                    Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AtId" ,  ObjectId.Parse(objClass.AtId) },
                        { "Type", objClass.Type },
                        { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                        { "AddedDate", DateTime.Now },
                        };

                var rt = objCollection.Insert(doc);

                
            }
              
    
        }


        public static bool youLikes(LikesBO objClass)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Likes");

            var query = Query.And(
               Query.EQ("Type", objClass.Type),
               Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
                Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (result.Any())
                return true;
            else
                return false;
        }

        public static void updateLikes(LikesBO objClass)
        {

            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("AtId", ObjectId.Parse(objClass.AtId))
                                .Set("Type", objClass.Type)
                                .Set("FirstName", objClass.FirstName)
                                .Set("LastName", objClass.LastName)
                                       
                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }


        public static void unLikes(LikesBO objClass)
        {
            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");
            var query = Query.And(
                    Query.EQ("Type", objClass.Type),
                    Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.FindAndRemove(query,
                SortBy.Ascending("_id"));
        }

        public static void deleteLikes(string Id)
          {
              MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }

        public static List<Likes> getAllLikesList()
        {
            List<Likes> lst = new List<Likes>();

            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");

            foreach (Likes item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }


        public static LikesBO getLikesByLikesId(string Id)
        {
            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");

            LikesBO objClass = new LikesBO();
            foreach (Likes item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.AtId= item.AtId.ToString();
                objClass.Type = item.Type;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                break;
            }
            return objClass;
           
        }

        public static long countPost(string AtId, int Type)
        {
            List<LikesBO> lst = new List<LikesBO>();
            long count = 0;
            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");
            var query = Query.And(
                   Query.EQ("Type", Type), //Query.Or(
                   Query.EQ("AtId", ObjectId.Parse(AtId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            count += result.Count();

            return count;

        }


        public static List<Likes> getLikesTop(int Type, string AtId)
        {
            List<Likes> lst = new List<Likes>();

            MongoCollection<Likes> objCollection = db.GetCollection<Likes>("c_Likes");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            var cursor = objCollection.Find(query);

            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

    }
}

#region Likes
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Likes
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId AtId { get; set; }
    public int Type { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime AddedDate { get; set; }
}
#endregion