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
/// Summary description for TagsDAL
/// </summary>
/// 

namespace DataLayer
{
    public class TagsDAL : BaseClass
    {
        
        public TagsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertTags(TagsBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Tags");

                     var query = Query.And(
                    Query.EQ("Type", objClass.Type),
                    Query.EQ("AtId", ObjectId.Parse(objClass.AtId)),
                     Query.EQ("FriendId", ObjectId.Parse(objClass.FriendId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AtId" ,  ObjectId.Parse(objClass.AtId) },
                          { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                       
                        { "Type", objClass.Type },
                         { "FriendId" ,  ObjectId.Parse(objClass.FriendId) },
                        { "FriendFName", objClass.FriendFName },
                        { "FriendLName", objClass.FriendLName },
                        };

                var rt = objCollection.Insert(doc);

                return doc["_id"].ToString();

            }
            else
                return null;
        

           
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateTags(TagsBO objClass)
        {

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                 .Set("FirstName", objClass.FirstName)
                                .Set("LastName", objClass.LastName)
                                .Set("AtId", ObjectId.Parse(objClass.AtId))
                                
                                .Set("Type", objClass.Type)
                                .Set("FriendId", ObjectId.Parse(objClass.AtId))
                                .Set("FriendFName", objClass.FirstName)
                                .Set("FriendLName", objClass.LastName)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteTags(string Id)
          {
              MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Tags> getAllTagsList()
        {
            List<Tags> lst = new List<Tags>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");

            foreach (Tags item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static TagsBO getTagsByTagsId(string Id)
        {
            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");

            TagsBO objClass = new TagsBO();
            foreach (Tags item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.AtId= item.AtId.ToString();
                objClass.FriendId = item.AtId.ToString();
                objClass.Type = item.Type;
               
                objClass.FriendFName = item.FirstName;
                objClass.FriendLName = item.LastName;
                break;
            }
            return objClass;
           
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Tags> getTagsTop5(int Type, string AtId)
        {
            List<Tags> lst = new List<Tags>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
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
        public static List<Tags> getTagsList(int Type, string AtId)
        {
            List<Tags> lst = new List<Tags>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            foreach (Tags item in objCollection.Find(query))
            {
                lst.Add(item);

            }
            return lst;


       
        }
        public static List<Tags> getTagsListbyFriendsId(int Type, string FriendId)
        {
            List<Tags> lst = new List<Tags>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
            

                   var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("FriendId", ObjectId.Parse(FriendId)));

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
        public static List<string> getTagsFriendId(int Type, string AtId)
        {
            List<string> lst = new List<string>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            foreach (Tags item in objCollection.FindAll())
            {
                lst.Add(item.FriendId.ToString());

            }
            return lst.Distinct().ToList();



        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Tags> getTagsByUserId(string UserId)
        {
            List<Tags> lst = new List<Tags>();

            MongoCollection<Tags> objCollection = db.GetCollection<Tags>("c_Tags");
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

#region Tags
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Tags
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ObjectId AtId { get; set; }
    public int Type { get; set; }
    public ObjectId FriendId { get; set; }
    public string FriendFName { get; set; }
    public string FriendLName { get; set; }

}
#endregion