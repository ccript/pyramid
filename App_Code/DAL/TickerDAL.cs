using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Wrappers;
using MongoDB.Driver.Builders;
/// <summary>
/// Summary description for TickerDAL
/// </summary>
/// 

namespace DataLayer
{
    public class TickerDAL : BaseClass
    {
        
        public TickerDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertTicker(TickerBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Ticker");

                 
                     BsonDocument doc = new BsonDocument {
                      { "PostedByUserId" , ObjectId.Parse(objClass.PostedByUserId) },
                      { "TickerOwnerUserId", ObjectId.Parse(objClass.TickerOwnerUserId) },
                           { "WallId", ObjectId.Parse(objClass.WallId) },
                          { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                          { "Title" , objClass.Title },
                        { "Post" , objClass.Post },
                        { "Type", objClass.Type },
                         { "AddedDate", objClass.AddedDate },
                         {"EmbedPost",objClass.EmbedPost}
                        };

                     var rt=objCollection.Insert(doc);

                     return doc["_id"].ToString();

              
        

           
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateTicker(TickerBO objClass)
        {

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("PostedByUserId", ObjectId.Parse(objClass.PostedByUserId))
                                  .Set("TickerOwnerUserId", ObjectId.Parse(objClass.TickerOwnerUserId))
                                .Set("FirstName", objClass.FirstName)
                                .Set("LastName", objClass.LastName)
                                 .Set("Post", objClass.Post)
                                .Set("Type", objClass.Type)
                                .Set("AddedDate", objClass.AddedDate)
                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
           ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////

        public static void updateLiteral(string TickerId, string postval, string embedval)
        {

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");

            var query = Query.EQ("_id", ObjectId.Parse(TickerId));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Post", postval)
            .Set("EmbedPost", embedval);
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
     
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteTicker(string Id)
          {
              MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getAllTickerList()
        {
            List<Ticker> lst = new List<Ticker>();

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");

            foreach (Ticker item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static TickerBO getTickerByTickerId(string Id)
        {
            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");

            TickerBO objClass = new TickerBO();
            foreach (Ticker item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.PostedByUserId = item.PostedByUserId.ToString();
                objClass.TickerOwnerUserId = item.TickerOwnerUserId.ToString();
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.Title = item.Title;
                objClass.Type = item.Type;
                objClass.Post = item.Post;
                objClass.EmbedPost = item.EmbedPost;
                objClass.AddedDate= item.AddedDate;
                objClass.WallId = item.WallId.ToString();
                break;
            }
            return objClass;
           
        }
     

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getTickerByUserId(string UserId,int top)
        {
            List<Ticker> lst = new List<Ticker>();

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");
            objCollection.EnsureIndex("Type");

            var query = Query.EQ("TickerOwnerUserId", ObjectId.Parse(UserId));
            DateTime dt = DateTime.Now.AddHours(-48);
            var query2 = Query.GTE("AddedDate", dt);


            var query3 = Query.And(query, query2);
            var cursor = objCollection.Find(query3);
            cursor.Limit = top;
             var sortBy = SortBy.Descending("AddedDate");
             cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
    

    
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getSeeFriendShipTicker(string FUserId,string UserId,int top)
        {
            List<Ticker> lst = new List<Ticker>();

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");
            objCollection.EnsureIndex("Type");

            var query = Query.And(Query.EQ("PostedByUserId", ObjectId.Parse(UserId)), Query.EQ("TickerOwnerUserId", ObjectId.Parse(FUserId)));
            var query2= Query.And(Query.EQ("PostedByUserId", ObjectId.Parse(FUserId)), Query.EQ("TickerOwnerUserId", ObjectId.Parse(UserId)));
            var query3 = Query.Or(query, query2);
            var cursor = objCollection.Find(query3);
            cursor.Limit = top;
             var sortBy = SortBy.Descending("AddedDate");
             cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            /*var query2 = Query.And(Query.EQ("PostedByUserId", ObjectId.Parse(FUserId)), Query.EQ("TickerOwnerUserId", ObjectId.Parse(UserId)));
            var cursor2 = objCollection.Find(query2);
            cursor.Limit = top;
            var sortBy2 = SortBy.Descending("AddedDate");
            cursor.SetSortOrder(sortBy2);
            foreach (var item2 in cursor2)
            {
                lst.Add(item2);

            }*/

            return lst;
        }

        public static List<Ticker> getTickerByUserIdAndFriendID(string UserId, string FriendID, int top)
        {
            List<Ticker> lst = new List<Ticker>();

            MongoCollection<Ticker> objCollection = db.GetCollection<Ticker>("c_Ticker");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                Query.EQ("TickerOwnerUserId", ObjectId.Parse(FriendID)),
                Query.EQ("PostedByUserId", ObjectId.Parse(UserId))
                );

            var cursor = objCollection.Find(query);
            cursor.Limit = top;
            var sortBy = SortBy.Descending("AddedDate");
            cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
    }
}

#region Ticker
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Ticker
{
    public ObjectId _id { get; set; }
    public ObjectId PostedByUserId { get; set; }
    public ObjectId TickerOwnerUserId { get; set; }
    public ObjectId WallId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string Post{ get; set; }
    public string EmbedPost { get; set; }
    public int Type { get; set; }

    public DateTime AddedDate { get; set; }
}
#endregion