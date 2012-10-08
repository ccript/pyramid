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
/// Summary description for FollowPostDAL
/// </summary>
namespace DataLayer
{
    public class FollowPostDAL : BaseClass
    {
        public FollowPostDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertFollowPost(FollowPostBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_FollowPost");

            //var query = Query.And(
            //   Query.EQ("Type", objClass.Type),
            //   Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
            //    Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            //var result = objCollection.Find(query);
            //if (!result.Any())
            //{
            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AtId" ,  ObjectId.Parse(objClass.AtId) },
                        { "Type", objClass.Type },
                        { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                        { "AddedDate", DateTime.Now },
                        };

            var rt = objCollection.Insert(doc);


            //}





        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static bool youFollowPost(FollowPostBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_FollowPost");

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
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFollowPost(FollowPostBO objClass)
        {

            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");

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

        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void unFollowPost(FollowPostBO objClass)
        {
            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");
            var query = Query.And(
                    Query.EQ("Type", objClass.Type),
                    Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.FindAndRemove(query,
                SortBy.Ascending("_id"));
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteFollowPost(string Id)
        {
            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                SortBy.Ascending("_id"));
        }

        /////

        public static void delUnFollowPost(string Id,String UserId)
        {
            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");
            var query = Query.And(
                    Query.EQ("AtId", ObjectId.Parse(Id)),
                    Query.EQ("UserId", ObjectId.Parse(UserId)));
            var result = objCollection.FindAndRemove(query,
                SortBy.Ascending("_id"));
        }


        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<FollowPost> getAllFollowPostList()
        {
            List<FollowPost> lst = new List<FollowPost>();

            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");

            foreach (FollowPost item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static FollowPostBO getFollowPostByFollowPostId(string Id)
        {
            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");

            FollowPostBO objClass = new FollowPostBO();
            foreach (FollowPost item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.AtId = item.AtId.ToString();
                objClass.Type = item.Type;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                break;
            }
            return objClass;

        }
        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
        public static long countPost(string AtId, int Type)
        {
            List<FollowPostBO> lst = new List<FollowPostBO>();
            long count = 0;
            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");
            var query = Query.And(
                   Query.EQ("Type", Type), //Query.Or(
                   Query.EQ("AtId", ObjectId.Parse(AtId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            count += result.Count();

            return count;

        }

        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<FollowPost> getFollowPostTop(int Type, string AtId)
        {
            List<FollowPost> lst = new List<FollowPost>();

            MongoCollection<FollowPost> objCollection = db.GetCollection<FollowPost>("c_FollowPost");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            var cursor = objCollection.Find(query);
            //cursor.Limit = 3;
            // var sortBy = SortBy.Descending("_id");
            // cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
    }
}

#region FollowPost
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class FollowPost
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