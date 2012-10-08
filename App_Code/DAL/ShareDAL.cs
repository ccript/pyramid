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
/// Summary description for ShareDAL
/// </summary>
/// 
namespace DataLayer
{
    public class ShareDAL : BaseClass
    {
        public ShareDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertShare(ShareBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Share");

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

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static bool youShare(ShareBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Share");

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
        public static void updateShare(ShareBO objClass)
        {

            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");

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
        public static void unShare(ShareBO objClass)
        {
            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");
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
        public static void deleteShare(string Id)
        {
            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                SortBy.Ascending("_id"));
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Share> getAllShareList()
        {
            List<Share> lst = new List<Share>();

            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");

            foreach (Share item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ShareBO getShareByShareId(string Id)
        {
            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");

            ShareBO objClass = new ShareBO();
            foreach (Share item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
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
            List<ShareBO> lst = new List<ShareBO>();
            long count = 0;
            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");
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
        public static List<Share> getShareTop(int Type, string AtId)
        {
            List<Share> lst = new List<Share>();

            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");
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

        public static List<Share> getShareHistory(int Type, string AtId)
        {
            List<Share> lst = new List<Share>();

            MongoCollection<Share> objCollection = db.GetCollection<Share>("c_Share");
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


#region Share
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Share
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