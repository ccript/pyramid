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
/// Summary description for WallDAL
/// </summary>
/// 

namespace DataLayer
{
    public class WallDAL : BaseClass
    {

        public WallDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertWall(WallBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Wall");


            BsonDocument doc = new BsonDocument {
                      { "PostedByUserId" , ObjectId.Parse(objClass.PostedByUserId) },
                      { "WallOwnerUserId", ObjectId.Parse(objClass.WallOwnerUserId) },
                          { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                        { "Post" , objClass.Post },
                        { "Type", objClass.Type },
                         { "AddedDate", objClass.AddedDate },
                         {"EmbedPost",objClass.EmbedPost}
                        };

            var rt = objCollection.Insert(doc);

            return doc["_id"].ToString();






        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateWall(WallBO objClass)
        {

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("PostedByUserId", ObjectId.Parse(objClass.PostedByUserId))
                                  .Set("WallOwnerUserId", ObjectId.Parse(objClass.WallOwnerUserId))
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

        public static void updateLiteral(string WallId, string postval, string embedval)
        {

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");

            var query = Query.EQ("_id", ObjectId.Parse(WallId));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Post", postval)
            .Set("EmbedPost", embedval);
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteWall(string Id)
        {
            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                SortBy.Ascending("_id"));
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Wall> getAllWallList()
        {
            List<Wall> lst = new List<Wall>();

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");

            foreach (Wall item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static WallBO getWallByWallId(string Id)
        {
            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");

            WallBO objClass = new WallBO();
            foreach (Wall item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.PostedByUserId = item.PostedByUserId.ToString();
                objClass.WallOwnerUserId = item.WallOwnerUserId.ToString();
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.Type = item.Type;
                objClass.Post = item.Post;
                objClass.EmbedPost = item.EmbedPost;
                objClass.AddedDate = item.AddedDate;
                break;
            }
            return objClass;

        }


        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Wall> getWallByUserId(string UserId, int top)
        {
            List<Wall> lst = new List<Wall>();

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");
            objCollection.EnsureIndex("Type");

            var query = Query.EQ("WallOwnerUserId", ObjectId.Parse(UserId));
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



        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Wall> getSeeFriendShipWall(string FUserId, string UserId, int top)
        {
            List<Wall> lst = new List<Wall>();

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");
            objCollection.EnsureIndex("Type");

            var query = Query.And(Query.EQ("PostedByUserId", ObjectId.Parse(UserId)), Query.EQ("WallOwnerUserId", ObjectId.Parse(FUserId)));
            var query2 = Query.And(Query.EQ("PostedByUserId", ObjectId.Parse(FUserId)), Query.EQ("WallOwnerUserId", ObjectId.Parse(UserId)));
            var query3 = Query.Or(query, query2);
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

        public static List<Wall> getWallByUserIdAndFriendID(string UserId, string FriendID, int top)
        {
            List<Wall> lst = new List<Wall>();

            MongoCollection<Wall> objCollection = db.GetCollection<Wall>("c_Wall");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                Query.EQ("WallOwnerUserId", ObjectId.Parse(FriendID)),
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




        public static List<Newsfeed> getNewsfeedByUserId(string UserId, int top)
        {
            List<Newsfeed> lstNewsfeed = new List<Newsfeed>();

            List<UserFriendsBO> lstfriends = new List<UserFriendsBO>();

            MongoCollection<Newsfeed> objCollection = db.GetCollection<Newsfeed>("c_Wall");
            MongoCollection<PostHidSpamStatus> objCollection2 = db.GetCollection<PostHidSpamStatus>("c_PostStatus");
            MongoCollection<PostOptions> objCollection3 = db.GetCollection<PostOptions>("c_PostOption");

            objCollection.EnsureIndex("Type");

            //get all friends
            lstfriends = FriendsDAL.getAllFriendsListName(UserId, Global.CONFIRMED);

            //against every friend
            foreach (UserFriendsBO friend in lstfriends)
            {
                ////get hidden posts or posts reported as spam
                var query1 = Query.And(
                Query.EQ("UserId", ObjectId.Parse(UserId)),
                Query.EQ("FriendId", ObjectId.Parse(friend.FriendUserId)),
                Query.Or(
                Query.EQ("PostStatus", 1),
                Query.EQ("PostStatus", 2))
                );

                var hiddenposts = objCollection2.Find(query1);

                //get all posts of a friend
                var query = Query.EQ("WallOwnerUserId", ObjectId.Parse(friend.FriendUserId));

                var cursor = objCollection.Find(query);
                cursor.Limit = top;
                var sortBy = SortBy.Descending("AddedDate");
                cursor.SetSortOrder(sortBy);

                //for every post of friend
                foreach (var item in cursor)
                {
                    //add post to list
                    lstNewsfeed.Add(item);
                }

                //against every hidden post
                foreach (var po in hiddenposts)
                {
                    //check friends posts in list
                    foreach (Newsfeed storyitem in lstNewsfeed.ToList())
                    {
                        //if hidden post id is equal to friends post id then remove it from list

                        if (po.PostId.ToString().Equals(storyitem._id.ToString()))
                            lstNewsfeed.Remove(storyitem);

                    }

                }

                // get updates type for a friend

                var querysub = Query.And(
                Query.EQ("UserId", ObjectId.Parse(UserId)),
                Query.EQ("FriendId", ObjectId.Parse(friend.FriendUserId))
                );

                var types = objCollection3.Find(querysub);

                if (types.Count() != 0)
                {
                    // int AllSub = 0;
                    int PhotoSub = 0;
                    int LinksSub = 0;
                    int VideoSub = 0;
                    int VideolinkSub = 0;
                    int StatusSub = 0;
                    int updatestype = 0;
                    PostOptions postoption = null;
                    foreach (PostOptions po in types)
                    {
                        updatestype = po.UpdatesType;
                        //  AllSub = po.SubscriptionAll;
                        PhotoSub = po.SubscriptionPhotos;
                        LinksSub = po.SubscriptionLinks;
                        VideoSub = po.SubscriptionVideos;
                        VideolinkSub = po.SubscriptionVideoLinks;
                        StatusSub = po.SubscriptionStatus;
                        postoption = po;
                        break;
                    }
                    if (PhotoSub == 1 && LinksSub == 1 && VideoSub == 1 && VideolinkSub == 1 && StatusSub == 1)
                    {
                        foreach (Newsfeed storyitem in lstNewsfeed.ToList())
                        {
                            //if hidden post id is equal to friends post id then remove it from list
                            if (friend.FriendUserId.Equals(storyitem.PostedByUserId.ToString()))
                            {
                                lstNewsfeed.Remove(storyitem);
                            }
                        }
                    }
                    else
                    {                        
                        //against every story of friend
                        foreach (Newsfeed storyitem in lstNewsfeed.ToList())
                        {
                            //if friend story type is different from updates type then remove it from list
                            switch (updatestype)
                            {
                                case 1://all updates


                                    break;

                                case 2:// most updates photos and status messages
                                    if (storyitem.Type == Global.TEXT_POST
                                        || storyitem.Type == Global.PHOTO
                                        || storyitem.Type == Global.TAG_PHOTO
                                        || storyitem.Type == Global.TAG_POST)
                                    { }
                                    else
                                    {
                                        lstNewsfeed.Remove(storyitem);
                                    }
                                    break;

                                case 3:// only important
                                    if (storyitem.Type == Global.PROFILE_CHANGE)
                                    { }
                                    else
                                    {
                                        lstNewsfeed.Remove(storyitem);
                                    }
                                    break;

                                default:
                                    break;
                            }
                            //below is logic for removing items that are unsubscribed
                            if (checkIfStorySubscribe(postoption, storyitem))
                            {
                                lstNewsfeed.Remove(storyitem);
                            }
                        }
                    }
                }
            }

            return lstNewsfeed;
        }

        private static bool checkIfStorySubscribe(PostOptions po, Newsfeed storyitem)
        {
            if ((po.SubscriptionPhotos == 1 && checkIfPhotoStoryItem(storyitem)) || 
                (po.SubscriptionLinks == 1 && storyitem.Type == Global.LINK) || 
                (po.SubscriptionStatus == 1 && storyitem.Type == Global.TEXT_POST) || 
                (po.SubscriptionVideos == 1 && checkIfVideoStoryItem(storyitem)) 
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool checkIfPhotoStoryItem(Newsfeed storyitem)
        {
            return (storyitem.Type == Global.PHOTO || storyitem.Type == Global.PHOTO_ALBUM || storyitem.Type == Global.POST_VIDEOLINK || storyitem.Type == Global.TAG_VIDEOLINK);            
        }

        private static bool checkIfVideoStoryItem(Newsfeed storyitem)
        {
            return (storyitem.Type == Global.VIDEO || storyitem.Type == Global.TAG_VIDEO || storyitem.Type == Global.TAG_PHOTO || storyitem.Type == Global.TAG_PHOTO_ALBUM);            
        }

        public static List<Newsfeed> getWallFeedByUserId(string UserId, int top)
        {
            List<Newsfeed> lstNewsfeed = new List<Newsfeed>();


            MongoCollection<Newsfeed> objCollection = db.GetCollection<Newsfeed>("c_Wall");
            objCollection.EnsureIndex("Type");

            var query2 = Query.EQ("WallOwnerUserId", ObjectId.Parse(UserId));
            var cursor2 = objCollection.Find(query2);
            cursor2.Limit = top;
            var sortBy2 = SortBy.Descending("AddedDate");
            cursor2.SetSortOrder(sortBy2);
            foreach (var item in cursor2)
            {
                lstNewsfeed.Add(item);

            }
            return lstNewsfeed;

        }
        public static int getUpdatesType(string userId, string FriendId)
        {
            int UpdateType = 0;
            MongoCollection<PostOptions> objCollection3 = db.GetCollection<PostOptions>("c_PostOption");
            var querytype = Query.And(
               Query.EQ("UserId", ObjectId.Parse(userId)),
               Query.EQ("FriendId", ObjectId.Parse(FriendId))
               );

            var types = objCollection3.Find(querytype);
            try
            {
                if (types.First() != null)
                {
                    PostOptions item = types.First();
                    UpdateType = item.UpdatesType;
                }
            }
            catch (Exception ex)
            {
                //PostOptions item = types.First();
                //UpdateType = item.UpdatesType;

            }
            return UpdateType;

            //   return WallDAL.getUpdatesType(userId, FriendId);

        }
        public static bool setPostStatus(string UserId, string PostedByUserId, string PostId, int Status)
        {
            bool done = false;
            MongoCollection<PostHidSpamStatus> objCollection = db.GetCollection<PostHidSpamStatus>("c_PostStatus");
            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(PostedByUserId) },
                        { "PostId" , ObjectId.Parse(PostId) },
                     { "PostStatus" , Status }
                     
                        };

            var rt = objCollection.Insert(doc);

            //return doc["_id"].ToString();
            return done;
        }
        public static bool setPostUpdatesType(string UserId, string FriendId, int Type)
        {
            bool done = false;
            MongoCollection<PostOptions> objCollection = db.GetCollection<PostOptions>("c_PostOption");
            var query = Query.And(
                          Query.EQ("UserId", ObjectId.Parse(UserId)),
                          Query.EQ("FriendId", ObjectId.Parse(FriendId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                     { "UpdatesType" , Type },
                     //{"SubscriptionAll",0},
                     {"SubscriptionStatus",0},
                     {"SubscriptionPhotos",0},
                     {"SubscriptionVideos",0},
                     {"SubscriptionLinks",0},
                     {"SubscriptionVideoLinks",0}
                        };

                var rt = objCollection.Insert(doc);
            }
            else
            {
                var update = Update.Set("UpdatesType", Type);
                var sortBy = SortBy.Descending("_id");
                var result2 = objCollection.FindAndModify(query, sortBy, update, true);

            }
            //return doc["_id"].ToString();
            return done;
        }
        public static SubscriptionsBO getSubscriptions(string UserId, string FriendId)
        {
            SubscriptionsBO sbo = new SubscriptionsBO();
            MongoCollection<PostOptions> objCollection = db.GetCollection<PostOptions>("c_PostOption");
            var query = Query.And(
                          Query.EQ("UserId", ObjectId.Parse(UserId)),
                          Query.EQ("FriendId", ObjectId.Parse(FriendId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                //sbo.All = 0;
                sbo.Links = 0;
                sbo.Photos = 0;
                sbo.Status = 0;
                sbo.VideoLinks = 0;
                sbo.Videos = 0;
            }
            else
            {
                foreach (PostOptions po in result)
                {
                    //updatestype = po.UpdatesType;
                    //sbo.All = po.SubscriptionAll;
                    sbo.Photos = po.SubscriptionPhotos;
                    sbo.Links = po.SubscriptionLinks;
                    sbo.Videos = po.SubscriptionVideos;
                    sbo.VideoLinks = po.SubscriptionVideoLinks;
                    sbo.Status = po.SubscriptionStatus;
                    break;
                }

            }

            return sbo;



        }

        public static void saveSubscriptions(string UserId, string FriendId, SubscriptionsBO sbo)
        {
            //SubscriptionsBO sbo = new SubscriptionsBO();
            MongoCollection<PostOptions> objCollection = db.GetCollection<PostOptions>("c_PostOption");
            var query = Query.And(
                          Query.EQ("UserId", ObjectId.Parse(UserId)),
                          Query.EQ("FriendId", ObjectId.Parse(FriendId)));
            var result = objCollection.Find(query);
            if (result.Any())
            {
                var update = Update
                                    .Set("SubscriptionStatus", sbo.Status)
                                    .Set("SubscriptionPhotos", sbo.Photos)
                                    .Set("SubscriptionVideos", sbo.Videos)

                                    .Set("SubscriptionLinks", sbo.Links)
                                    .Set("SubscriptionVideoLinks", sbo.VideoLinks)
                                        ;
                var sortBy = SortBy.Descending("_id");
                var result2 = objCollection.FindAndModify(query, sortBy, update, true);

            }

            // return sbo;



        }
        public static bool Unsubscribe(string UserId, string FriendId, string subtype)
        {
            bool done = true;
            MongoCollection<PostOptions> objCollection = db.GetCollection<PostOptions>("c_PostOption");
            var query = Query.And(
                          Query.EQ("UserId", ObjectId.Parse(UserId)),
                          Query.EQ("FriendId", ObjectId.Parse(FriendId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                if (subtype == "All")
                {
                    BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                      { "UpdatesType" , 0 },
                     //{"SubscriptionAll",1},
                     {"SubscriptionStatus",1},
                     {"SubscriptionPhotos",1},
                     {"SubscriptionVideos",1},
                     {"SubscriptionLinks",1},
                     {"SubscriptionVideoLinks",1}
                     
                        };

                    var rt = objCollection.Insert(doc);
                }

                else
                {
                    //string subtypefield = "Unknown";
                    switch (subtype)
                    {
                        case "15":
                            //name += "video links";
                            // subtypefield = "SubscriptionVideoLinks";
                            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                   
                        {"UpdatesType" , 0 },
                     //{"SubscriptionAll",0},
                     {"SubscriptionStatus",0},
                     {"SubscriptionPhotos",0},
                      {"SubscriptionLinks", 0},
                     {"SubscriptionVideos",0},
                     //{"SubscriptionLinks",0},
                     {"SubscriptionVideoLinks",1}
                     
                        };

                            var rt = objCollection.Insert(doc);
                            break;

                        case "16":
                            //name += "video links";
                            //    subtypefield = "SubscriptionLinks";
                            BsonDocument doc16 = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                   
                        {"UpdatesType" , 0 },
                     //{"SubscriptionAll",0},
                     {"SubscriptionStatus",0},
                     {"SubscriptionPhotos",0},
                      {"SubscriptionLinks", 1},
                     {"SubscriptionVideos",0},
                    
                     {"SubscriptionVideoLinks",0}
                     
                        };

                            var rt16 = objCollection.Insert(doc16);
                            break;
                        case "6":
                            //name += "text posts";
                            // subtypefield = "SubscriptionStatus";
                            BsonDocument doc2 = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                   
                        {"UpdatesType" , 0 },
                     //{"SubscriptionAll",0},
                     {"SubscriptionStatus",1},
                     //{"SubscriptionLinks", 0},
                     {"SubscriptionPhotos",0},
                     {"SubscriptionVideos",0},
                     {"SubscriptionLinks",0},
                     {"SubscriptionVideoLinks",1}
                     
                        };

                            var rt2 = objCollection.Insert(doc2);
                            break;
                        case "1":
                            //name += "photos";
                            //  subtypefield = "SubscriptionPhotos";
                            BsonDocument doc3 = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                   
                        {"UpdatesType" , 0 },
                     //{"SubscriptionAll",0},
                      {"SubscriptionLinks", 0},
                     {"SubscriptionStatus",0},
                     {"SubscriptionPhotos",1},
                     {"SubscriptionVideos",0},
                    // {"SubscriptionLinks",0},
                     {"SubscriptionVideoLinks",0}
                     
                        };

                            var rt3 = objCollection.Insert(doc3);
                            break;

                        case "2":
                            //name += "videos";
                            //   subtypefield = "SubscriptionVideos";
                            BsonDocument doc4 = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendId" , ObjectId.Parse(FriendId) },                      
                   
                        {"UpdatesType" , 0 },
                     //{"SubscriptionAll",0},
                     {"SubscriptionStatus",0},
                     //{"SubscriptionLinks", 0},
                     {"SubscriptionPhotos",0},
                     {"SubscriptionVideos",1},
                     {"SubscriptionLinks",0},
                     {"SubscriptionVideoLinks",0}
                     
                        };

                            var rt4 = objCollection.Insert(doc4);
                            break;
                        default:
                            break;

                    }

                    int i = 0;

                }
            }
            else
            {
                if (subtype == "All")
                {

                    var update = Update.Set("SubscriptionVideoLinks", 1)
                                        .Set("SubscriptionVideos", 1)
                                        .Set("SubscriptionLinks", 1)
                                        .Set("SubscriptionPhotos", 1)
                                        .Set("SubscriptionStatus", 1);
                    var sortBy = SortBy.Descending("_id");
                    var result2 = objCollection.FindAndModify(query, sortBy, update, true);

                }
                else
                {
                    string subtypefield = "Unknown";
                    switch (subtype)
                    {
                        case "15":
                            //name += "video links";
                            subtypefield = "SubscriptionVideoLinks";
                            var update = Update.Set(subtypefield, 1);
                            var sortBy = SortBy.Descending("_id");
                            var result2 = objCollection.FindAndModify(query, sortBy, update, true);
                            break;
                        case "16":
                            //name += "video links";
                            subtypefield = "SubscriptionLinks";
                            var update2 = Update.Set(subtypefield, 1);
                            var sortBy2 = SortBy.Descending("_id");
                            var result22 = objCollection.FindAndModify(query, sortBy2, update2, true);
                            break;

                        case "6":

                            //name += "text posts";
                            subtypefield = "SubscriptionStatus";
                            var update3 = Update.Set(subtypefield, 1);
                            var sortBy3 = SortBy.Descending("_id");
                            var result23 = objCollection.FindAndModify(query, sortBy3, update3, true);
                            break;
                        case "1":
                        case "3":
                            //name += "photos";
                            subtypefield = "SubscriptionPhotos";
                            var update4 = Update.Set(subtypefield, 1);
                            var sortBy4 = SortBy.Descending("_id");
                            var result24 = objCollection.FindAndModify(query, sortBy4, update4, true);
                            break;

                        case "2":
                            //name += "videos";
                            subtypefield = "SubscriptionVideos";
                            var update5 = Update.Set(subtypefield, 1);
                            var sortBy5 = SortBy.Descending("_id");
                            var result25 = objCollection.FindAndModify(query, sortBy5, update5, true);
                            break;
                        default:
                            break;

                    }


                }

            }

            return done;
        }
    }





}

#region Wall
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Wall
{
    public ObjectId _id { get; set; }
    public ObjectId PostedByUserId { get; set; }
    public ObjectId WallOwnerUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Post { get; set; }
    public string EmbedPost { get; set; }
    public int Type { get; set; }

    public DateTime AddedDate { get; set; }
}

public class Newsfeed
{
    public ObjectId _id { get; set; }
    public ObjectId PostedByUserId { get; set; }
    public ObjectId WallOwnerUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Post { get; set; }
    public string EmbedPost { get; set; }
    public int Type { get; set; }
    public DateTime AddedDate { get; set; }
    public int PostRank { get; set; }
    public int AffinityScore { get; set; }
    public int PostWeight { get; set; }
    public int TimeDecay { get; set; }
}

public class PostHidSpamStatus
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId FriendId { get; set; }
    public ObjectId PostId { get; set; }
    public int PostStatus { get; set; }
}

public class PostOptions
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId FriendId { get; set; }
    //public ObjectId PostId { get; set; }
    public int UpdatesType { get; set; }
    //  public int SubscriptionAll { get; set; }
    public int SubscriptionStatus { get; set; }
    public int SubscriptionPhotos { get; set; }
    public int SubscriptionVideos { get; set; }
    public int SubscriptionLinks { get; set; }
    public int SubscriptionVideoLinks { get; set; }
}
#endregion