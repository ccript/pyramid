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
/// Summary description for FriendsDAL
/// </summary>
/// 

namespace DataLayer
{
    public class FriendsDAL : BaseClass
    {
        
        public FriendsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertFriends(FriendsBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

                 var query = Query.And(
                          Query.EQ("FriendUserId", ObjectId.Parse(objClass.FriendUserId)),
                          Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
                 var result = objCollection.Find(query);
                 if (!result.Any())
                 {
                     BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "FriendUserId" , ObjectId.Parse(objClass.FriendUserId) },
                     { "Status" , objClass.Status },
                      { "BelongsTo" , objClass.BelongsTo },
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
        public static void updateFriends(FriendsBO objClass)
        {

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("FriendUserId", objClass.FriendUserId)
                                 .Set("Status", objClass.Status)
                              .Set("BelongsTo", objClass.BelongsTo)
                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void confirmRequest(FriendsBO objClass)
        {

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                 .Set("Status", objClass.Status)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public static void delayRequest(FriendsBO objClass)
        {

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                 .Set("Status", objClass.Status)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        ///////////////////////////////////////////////////////////////
        //                       send Request  FUNCTION
        //////////////////////////////////////////////////////////////
        public static void sendFriendRequest(string UserId, string FriendId)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

            var query = Query.And(
                           Query.EQ("FriendUserId", ObjectId.Parse(FriendId)),
                           Query.EQ("UserId", ObjectId.Parse(UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendUserId" , ObjectId.Parse(FriendId) },
                     { "Status" , Global.PENDING },
                        { "BelongsTo" , "Default" },
                        };

                var rt = objCollection.Insert(doc);



            }
            else
            {
                var sortBy = SortBy.Descending("_id");
                var update = Update
                                     .Set("Status", Global.PENDING)
                                      .Set("BelongsTo", "Default")
                                    ;

                var res = objCollection.FindAndModify(query, sortBy, update, true);
            }

        }

        ///////////////////////////////////////////////////////////////
        //                       send Suggestion  FUNCTION
        //////////////////////////////////////////////////////////////
        public static void sendFriendSuggestion(string UserId, string FriendId)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

            var query = Query.And(
                           Query.EQ("FriendUserId", ObjectId.Parse(FriendId)),
                           Query.EQ("UserId", ObjectId.Parse(UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(UserId) },
                        { "FriendUserId" , ObjectId.Parse(FriendId) },
                     { "Status" , Global.SUGGESTED },
                        { "BelongsTo" , "Default" },
                        };

                var rt = objCollection.Insert(doc);



            }
            else
            {
                var sortBy = SortBy.Descending("_id");
                var update = Update
                                     .Set("Status", Global.SUGGESTED)
                                      .Set("BelongsTo", "Default")
                                    ;

                var res = objCollection.FindAndModify(query, sortBy, update, true);
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       is Existing Friend
        //////////////////////////////////////////////////////////////
        public static bool isExistingFriend(string UserId, string FriendId)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

            var queryrev = Query.And(
                         Query.EQ("FriendUserId", ObjectId.Parse(UserId)),
                         Query.EQ("UserId", ObjectId.Parse(FriendId)),
                         Query.EQ("Status", Global.CONFIRMED));
            var query = Query.And(
                           Query.EQ("FriendUserId", ObjectId.Parse(FriendId)),
                           Query.EQ("UserId", ObjectId.Parse(UserId)),
                           Query.EQ("Status", Global.CONFIRMED));
            var queryComb = Query.Or(queryrev, query);
            var result = objCollection.Find(queryComb);
            if (result.Any()) 
               return true;
            else
               return false;
            

        }
        ///////////////////////////////////////////////////////////////
        //                       is Existing Friend with any status
        //////////////////////////////////////////////////////////////
        public static bool isExistingFriendAnyStatus(string UserId, string FriendId)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

            var queryrev = Query.And(
                         Query.EQ("FriendUserId", ObjectId.Parse(UserId)),
                         Query.EQ("UserId", ObjectId.Parse(FriendId)),
                         Query.NE("Status", "Cancelled")
                        );
            var query = Query.And(
                           Query.EQ("FriendUserId", ObjectId.Parse(FriendId)),
                           Query.EQ("UserId", ObjectId.Parse(UserId)),
                         Query.NE("Status", "Cancelled")
                           );
            var queryComb = Query.Or(queryrev, query);
            var result = objCollection.Find(queryComb);
            if (result.Any())
                return true;
            else
                return false;


        }
        ///////////////////////////////////////////////////////////////
        //                       cancel Request  FUNCTION
        //////////////////////////////////////////////////////////////
        public static void cancelFriendRequest(string UserId, string FriendId)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Friends");

            var query = Query.And(
                           Query.EQ("FriendUserId", ObjectId.Parse(FriendId)),
                           Query.EQ("UserId", ObjectId.Parse(UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                var query2 = Query.And(
                           Query.EQ("UserId", ObjectId.Parse(FriendId)),
                           Query.EQ("FriendUserId", ObjectId.Parse(UserId)));
                var result2 = objCollection.Find(query2);
                if (result2.Any())
                {
                    var sortBy = SortBy.Descending("_id");
                    var update = Update
                                         .Set("Status", "Cancelled")

                                        ;

                    var res = objCollection.FindAndModify(query2, sortBy, update, true);
 
                }

            }
            //else
            {
                var sortBy = SortBy.Descending("_id");
                var update = Update
                                     .Set("Status", "Cancelled")

                                    ;

                var res = objCollection.FindAndModify(query, sortBy, update, true);
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteFriends(string Id)
          {
              MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Friends> getAllFriendsList()
        {
            List<Friends> lst = new List<Friends>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

            foreach (Friends item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
          public static long countFriends(string UserId, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();
            long count = 0;
            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("UserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            count += result.Count();

            MongoCollection<Friends> objCollection2 = db.GetCollection<Friends>("c_Friends");
            var query2 = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
            var result2 = objCollection.Find(query2);
            count += result2.Count();
            return count;

          }

          public static long countFriendRequests(string UserId, string status)
          {
              List<UserFriendsBO> lst = new List<UserFriendsBO>();
             
              MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
              var query = Query.And(
                     Query.EQ("Status", status), //Query.Or(
                     Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                    );
              var result = objCollection.Find(query);
              return result.Count();

             

          }
        public static List<UserFriendsBO> getAllFriendsListName(string UserId, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("UserId",ObjectId.Parse( UserId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            if (!result.Any())
            {

                ////////////////////////////////////////////////////
                query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.UserId.ToString();
                        objClass.UserId = item.FriendUserId.ToString();
                        objClass.Status = item.Status;
                        //objClass.BelongsTo = Useritem.BelongsTo;
                        break;
                    }
                    lst.Add(objClass);
                }
            }
            else
            {
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.FriendUserId.ToString();
                        objClass.UserId = item.UserId.ToString();
                        objClass.Status = item.Status;
                        break;
                    }
                    lst.Add(objClass);

                }
                ///////////////////////////////////////////
                query = Query.And(
              Query.EQ("Status", status), //Query.Or(
              Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
             );
                foreach (Friends item2 in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection2 = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass2 = new UserFriendsBO();
                    var query22 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item2.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection2.Find(query22))
                    {
                        objClass2.Id = item2._id.ToString();
                        objClass2.FirstName = Useritem.FirstName;
                        objClass2.LastName = Useritem.LastName;
                        objClass2.FriendUserId = item2.UserId.ToString();
                        objClass2.UserId = item2.FriendUserId.ToString();
                        objClass2.Status = item2.Status;
                        break;
                    }
                    lst.Add(objClass2);
                }
            }
            return lst;
        }

        public static List<UserFriendsBO> getAllFriendsFilterByList(string UserId, string status,string FilterByListName)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("UserId", ObjectId.Parse(UserId)),
                   Query.EQ("BelongsTo",FilterByListName)//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            if (!result.Any())
            {

                ////////////////////////////////////////////////////
                query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("FriendUserId", ObjectId.Parse(UserId)),
                   Query.EQ("BelongsTo", FilterByListName)//, Query.EQ("UserId", UserId))
                  );
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.UserId.ToString();
                        objClass.UserId = item.FriendUserId.ToString();
                        objClass.Status = item.Status;
                        //objClass.BelongsTo = Useritem.BelongsTo;
                        break;
                    }
                    lst.Add(objClass);
                }
            }
            else
            {
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.FriendUserId.ToString();
                        objClass.UserId = item.UserId.ToString();
                        objClass.Status = item.Status;
                        break;
                    }
                    lst.Add(objClass);

                }
                ///////////////////////////////////////////
                query = Query.And(
              Query.EQ("Status", status), //Query.Or(
              Query.EQ("FriendUserId", ObjectId.Parse(UserId)),
              Query.EQ("BelongsTo", FilterByListName)//, Query.EQ("UserId", UserId))
             );
                foreach (Friends item2 in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection2 = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass2 = new UserFriendsBO();
                    var query22 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item2.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection2.Find(query22))
                    {
                        objClass2.Id = item2._id.ToString();
                        objClass2.FirstName = Useritem.FirstName;
                        objClass2.LastName = Useritem.LastName;
                        objClass2.FriendUserId = item2.UserId.ToString();
                        objClass2.UserId = item2.FriendUserId.ToString();
                        objClass2.Status = item2.Status;
                        break;
                    }
                    lst.Add(objClass2);
                }
            }
            return lst;
        }

        public static List<UserFriendsBO> getPSFriends(string UserId)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(Query.Or(
                   Query.EQ("Status",Global.SUGGESTED),
                   Query.EQ("Status", Global.PENDING)),//Query.Or(
                   Query.EQ("UserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            if (!result.Any())
            {

                ////////////////////////////////////////////////////
                query = Query.And(Query.Or(
                   Query.EQ("Status",Global.SUGGESTED),
                   Query.EQ("Status", Global.PENDING)),
                   Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.UserId.ToString();
                        objClass.UserId = item.FriendUserId.ToString();
                        objClass.Status = item.Status;
                        //objClass.BelongsTo = Useritem.BelongsTo;
                        break;
                    }
                    lst.Add(objClass);
                }
            }
            else
            {
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.FriendUserId.ToString();
                        objClass.UserId = item.UserId.ToString();
                        objClass.Status = item.Status;
                        break;
                    }
                    lst.Add(objClass);

                }
                ///////////////////////////////////////////
                query = Query.And(Query.Or(
                   Query.EQ("Status",Global.SUGGESTED),
                   Query.EQ("Status", Global.PENDING)),
              Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
             );
                foreach (Friends item2 in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection2 = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass2 = new UserFriendsBO();
                    var query22 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item2.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection2.Find(query22))
                    {
                        objClass2.Id = item2._id.ToString();
                        objClass2.FirstName = Useritem.FirstName;
                        objClass2.LastName = Useritem.LastName;
                        objClass2.FriendUserId = item2.UserId.ToString();
                        objClass2.UserId = item2.FriendUserId.ToString();
                        objClass2.Status = item2.Status;
                        break;
                    }
                    lst.Add(objClass2);
                }
            }
            return lst;
        }
        public static List<UserFriendsBO> getAllSuggestions(string UserId)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();
            List<UserFriendsBO> lstfof = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                    Query.EQ("Status", Global.CONFIRMED),
                    Query.EQ("FriendUserId", ObjectId.Parse(UserId))
                         );
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                MongoCollection<Friends> objCollectionf = db.GetCollection<Friends>("c_Friends");
                var queryf = Query.And(
                    Query.EQ("Status", Global.CONFIRMED),
                        Query.EQ("UserId", ObjectId.Parse(UserId))
                                      );
                var resultf = objCollectionf.Find(queryf);

                if (resultf.Any())
                {
                    foreach (Friends itemf in resultf)
                    {


                        //CASE 1                  
                        MongoCollection<Friends> objCollectionf2 = db.GetCollection<Friends>("c_Friends");
                        var queryf2 = Query.And(
                            Query.EQ("Status", Global.CONFIRMED),
                             Query.NE("FriendUserId", ObjectId.Parse(itemf.UserId.ToString())),
                            //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                            //Query.Or(
                            Query.EQ("UserId", ObjectId.Parse(itemf.FriendUserId.ToString())) //Query.Or(
                            //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                            //)

                              );
                        var resultf2 = objCollectionf2.Find(queryf2);

                        if (resultf2.Any())
                        {
                            foreach (Friends itemf2 in resultf2)
                            {


                                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                                UserFriendsBO objClass = new UserFriendsBO();
                                var query2 = Query.And(
                                    Query.EQ("_id", ObjectId.Parse(itemf2.FriendUserId.ToString()))
                                    );
                                foreach (User Useritem in objUserCollection.Find(query2))
                                {
                                    objClass.Id = itemf2._id.ToString();
                                    objClass.FirstName = Useritem.FirstName;
                                    objClass.LastName = Useritem.LastName;
                                    objClass.FriendUserId = itemf2.FriendUserId.ToString();
                                    objClass.UserId = itemf2.UserId.ToString();
                                    objClass.Status = itemf2.Status;
                                    break;
                                }
                                lst.Add(objClass);
                            }
                        }
                        //CASE 2
                        MongoCollection<Friends> objCollectionf3 = db.GetCollection<Friends>("c_Friends");
                        var queryf3 = Query.And(
                            Query.EQ("Status", Global.CONFIRMED),
                             Query.NE("UserId", ObjectId.Parse(itemf.UserId.ToString())),
                            //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                            //Query.Or(
                            Query.EQ("FriendUserId", ObjectId.Parse(itemf.FriendUserId.ToString())) //Query.Or(
                            //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                            //)

                              );
                        var resultf3 = objCollectionf3.Find(queryf3);

                        if (resultf3.Any())
                        {
                            foreach (Friends itemf3 in resultf3)
                            {


                                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                                UserFriendsBO objClass = new UserFriendsBO();
                                var query2 = Query.And(
                                    Query.EQ("_id", ObjectId.Parse(itemf3.UserId.ToString()))
                                    );
                                foreach (User Useritem in objUserCollection.Find(query2))
                                {
                                    objClass.Id = itemf3._id.ToString();
                                    objClass.FirstName = Useritem.FirstName;
                                    objClass.LastName = Useritem.LastName;
                                    objClass.FriendUserId = itemf3.UserId.ToString();
                                    objClass.UserId = itemf3.FriendUserId.ToString();
                                    objClass.Status = itemf3.Status;
                                    break;
                                }
                                lst.Add(objClass);
                            }


                        }
                    }

                }

            }
            else
            {
                foreach (Friends item in result)
                {
                    //CASE 1                  
                    MongoCollection<Friends> objCollectionf2 = db.GetCollection<Friends>("c_Friends");
                    var queryf2 = Query.And(
                        Query.EQ("Status", Global.CONFIRMED),
                         Query.NE("FriendUserId", ObjectId.Parse(item.FriendUserId.ToString())),
                        //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                        //Query.Or(
                        Query.EQ("UserId", ObjectId.Parse(item.UserId.ToString())) //Query.Or(
                        //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                        //)

                          );
                    var resultf2 = objCollectionf2.Find(queryf2);

                    if (resultf2.Any())
                    {
                        foreach (Friends itemf2 in resultf2)
                        {


                            MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                            UserFriendsBO objClass = new UserFriendsBO();
                            var query2 = Query.And(
                                Query.EQ("_id", ObjectId.Parse(itemf2.FriendUserId.ToString()))
                                );
                            foreach (User Useritem in objUserCollection.Find(query2))
                            {
                                objClass.Id = itemf2._id.ToString();
                                objClass.FirstName = Useritem.FirstName;
                                objClass.LastName = Useritem.LastName;
                                objClass.FriendUserId = itemf2.FriendUserId.ToString();
                                objClass.UserId = itemf2.UserId.ToString();
                                objClass.Status = itemf2.Status;
                                break;
                            }
                            lst.Add(objClass);
                        }
                    }
                        //CASE 2
                        MongoCollection<Friends> objCollectionf3 = db.GetCollection<Friends>("c_Friends");
                        var queryf3 = Query.And(
                            Query.EQ("Status", Global.CONFIRMED),
                             Query.NE("UserId", ObjectId.Parse(item.FriendUserId.ToString())),
                            //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                            //Query.Or(
                            Query.EQ("FriendUserId", ObjectId.Parse(item.UserId.ToString())) //Query.Or(
                            //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                            //)

                              );
                        var resultf3 = objCollectionf3.Find(queryf3);

                        if (resultf3.Any())
                        {
                            foreach (Friends itemf3 in resultf3)
                            {


                                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                                UserFriendsBO objClass = new UserFriendsBO();
                                var query2 = Query.And(
                                    Query.EQ("_id", ObjectId.Parse(itemf3.UserId.ToString()))
                                    );
                                foreach (User Useritem in objUserCollection.Find(query2))
                                {
                                    objClass.Id = itemf3._id.ToString();
                                    objClass.FirstName = Useritem.FirstName;
                                    objClass.LastName = Useritem.LastName;
                                    objClass.FriendUserId = itemf3.UserId.ToString();
                                    objClass.UserId = itemf3.FriendUserId.ToString();
                                    objClass.Status = itemf3.Status;
                                    break;
                                }
                                lst.Add(objClass);
                            }


                        }


                    }
                //Also do the other way around-- repeating
                MongoCollection<Friends> objCollectionf = db.GetCollection<Friends>("c_Friends");
                var queryf = Query.And(
                    Query.EQ("Status", Global.CONFIRMED),
                        Query.EQ("UserId", ObjectId.Parse(UserId))
                                      );
                var resultf = objCollectionf.Find(queryf);

                if (resultf.Any())
                {
                    foreach (Friends itemf in resultf)
                    {


                        //CASE 1                  
                        MongoCollection<Friends> objCollectionf2 = db.GetCollection<Friends>("c_Friends");
                        var queryf2 = Query.And(
                            Query.EQ("Status", Global.CONFIRMED),
                             Query.NE("FriendUserId", ObjectId.Parse(itemf.UserId.ToString())),
                            //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                            //Query.Or(
                            Query.EQ("UserId", ObjectId.Parse(itemf.FriendUserId.ToString())) //Query.Or(
                            //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                            //)

                              );
                        var resultf2 = objCollectionf2.Find(queryf2);

                        if (resultf2.Any())
                        {
                            foreach (Friends itemf2 in resultf2)
                            {


                                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                                UserFriendsBO objClass = new UserFriendsBO();
                                var query2 = Query.And(
                                    Query.EQ("_id", ObjectId.Parse(itemf2.FriendUserId.ToString()))
                                    );
                                foreach (User Useritem in objUserCollection.Find(query2))
                                {
                                    objClass.Id = itemf2._id.ToString();
                                    objClass.FirstName = Useritem.FirstName;
                                    objClass.LastName = Useritem.LastName;
                                    objClass.FriendUserId = itemf2.FriendUserId.ToString();
                                    objClass.UserId = itemf2.UserId.ToString();
                                    objClass.Status = itemf2.Status;
                                    break;
                                }
                                lst.Add(objClass);
                            }
                        }
                        //CASE 2
                        MongoCollection<Friends> objCollectionf3 = db.GetCollection<Friends>("c_Friends");
                        var queryf3 = Query.And(
                            Query.EQ("Status", Global.CONFIRMED),
                             Query.NE("UserId", ObjectId.Parse(itemf.UserId.ToString())),
                            //    Query.NE("UserId", ObjectId.Parse(item.UserId.ToString())),
                            //Query.Or(
                            Query.EQ("FriendUserId", ObjectId.Parse(itemf.FriendUserId.ToString())) //Query.Or(
                            //   Query.EQ("UserId", ObjectId.Parse(item.FriendUserId.ToString()))//, Query.EQ("UserId", UserId))
                            //)

                              );
                        var resultf3 = objCollectionf3.Find(queryf3);

                        if (resultf3.Any())
                        {
                            foreach (Friends itemf3 in resultf3)
                            {


                                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                                UserFriendsBO objClass = new UserFriendsBO();
                                var query2 = Query.And(
                                    Query.EQ("_id", ObjectId.Parse(itemf3.UserId.ToString()))
                                    );
                                foreach (User Useritem in objUserCollection.Find(query2))
                                {
                                    objClass.Id = itemf3._id.ToString();
                                    objClass.FirstName = Useritem.FirstName;
                                    objClass.LastName = Useritem.LastName;
                                    objClass.FriendUserId = itemf3.UserId.ToString();
                                    objClass.UserId = itemf3.FriendUserId.ToString();
                                    objClass.Status = itemf3.Status;
                                    break;
                                }
                                lst.Add(objClass);
                            }


                        }
                    }

                }
                }

            List<UserFriendsBO> lst1 = new List<UserFriendsBO>();
            
            //get all friends of UserID
            lst1 = getAllFriendsListName(UserId, Global.CONFIRMED);
            //take difference of the two lists: items in lst that are not in lst1
            IEqualityComparer<UserFriendsBO> comparer = new UserFriendsComparer();

            List<UserFriendsBO> l3 = lst.Except(lst1, comparer).ToList();
            List<UserFriendsBO> l3new=new List<UserFriendsBO>();
            //To Get Mutual friends name and count
            foreach (UserFriendsBO Useritem in l3)
            {
                //check if a suggested user is a friend of the user with any status
                if(isExistingFriendAnyStatus(UserId,Useritem.FriendUserId))
                {
                //Useritem.Status="AF";//already friends
                    
                }
                else
                {
                    l3new.Add(Useritem);
                    List<UserFriendsBO> lm= getMutualFriends(Useritem.FriendUserId, UserId, Global.CONFIRMED);
                    Useritem.MutualFriendName = lm.First().FirstName + " " + lm.First().LastName;
                    Useritem.MutualFriendsCount=lm.Count;
                }
              
            }

            return l3new;
            }

        public class UserFriendsComparer : IEqualityComparer<UserFriendsBO>
        {
            public bool Equals(UserFriendsBO x, UserFriendsBO y)
            {
                return x.FriendUserId == y.FriendUserId;
            }

            public int GetHashCode(UserFriendsBO obj)
            {
                return obj.FriendUserId.GetHashCode();
            }
        }

        public class UserFriendsBOComparer : IEqualityComparer<UserFriendsBO>
        {
            public bool Equals(UserFriendsBO x, UserFriendsBO y)
            {
                return x.FriendUserId == y.FriendUserId;
            }

            public int GetHashCode(UserFriendsBO obj)
            {
                return obj.FriendUserId.GetHashCode();
            }
        }
        
        public static List<UserFriendsBO> getMutualFriends(string UserId,string FriendUserId, string status)
        {
            List<UserFriendsBO> lst1 = new List<UserFriendsBO>();
            List<UserFriendsBO> lst2 = new List<UserFriendsBO>();
            

            //get all friends of UserID
             lst1=getAllFriendsListName(UserId,status);
            //get all friends of FriendUserID
            lst2= getAllFriendsListName(FriendUserId,status);

            //take intersection of the two lists
            

            IEqualityComparer<UserFriendsBO> comparer = new UserFriendsBOComparer();

            List<UserFriendsBO> l3 = lst2.Intersect(lst1, comparer).ToList();
          //  l3.OrderBy(p => p.FirstName);
            l3.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
            //l3.Sort(scomparer);

            return l3;
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<UserFriendsBO> getAllFriendRequests(string UserId, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                   Query.EQ("Status", status),
                    Query.EQ("FriendUserId",ObjectId.Parse( UserId)));
            foreach (Friends item in objCollection.Find(query))
            {


                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                UserFriendsBO objClass = new UserFriendsBO();

                foreach (User Useritem in objUserCollection.Find(Query.EQ("_id", ObjectId.Parse(item.UserId.ToString()))))
                {
                    objClass.Id = item._id.ToString();
                    objClass.FirstName = Useritem.FirstName;
                    objClass.LastName = Useritem.LastName;
                    objClass.FriendUserId = item.UserId.ToString();
                    objClass.UserId = item.FriendUserId.ToString();
                    objClass.Status = item.Status;
                    break;
                }
                lst.Add(objClass);
            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<UserFriendsBO> getFriendsListByName(string UserId, string value)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
          //  var query = Query.And(
           //        Query.EQ("Status", status),
          //         Query.EQ("UserId", ObjectId.Parse(UserId)));
            var query = Query.EQ("UserId", ObjectId.Parse(UserId));
            foreach (Friends item in objCollection.Find(query))
            {


                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");
                var query3 = Query.Or(
                Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + value + ""))),
                Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + value + ""))));
                  var query2 = Query.And(
                     Query.EQ("FirstName", value),
                         Query.EQ("_Id", ObjectId.Parse(item.FriendUserId.ToString())));
                UserFriendsBO objClass = new UserFriendsBO();
                foreach (User Useritem in objUserCollection.Find(query2))
                {

                
                    objClass.Id = item._id.ToString();
                    objClass.FirstName = Useritem.FirstName;
                    objClass.LastName = Useritem.LastName;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;
                    lst.Add(objClass);
                    break;
                }

           
            }
            return lst;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static FriendsBO getFriendsByFriendsId(string Id)
        {
            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

            FriendsBO objClass = new FriendsBO();
            foreach (Friends item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.FriendUserId = item.FriendUserId.ToString();
                objClass.Status = item.Status;
                break;
            }
            return objClass;
           
        }

        public static List<UserFriendsBO> getBirthdayAlertFriends(string UserId)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();
            string status = Global.CONFIRMED;
            DateTime dt = DateTime.Now;
            DateTime d = dt.Date;

            string d2 = d.ToShortDateString();
            int day = dt.Day;
            int month = dt.Month;

            MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");
            var query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("UserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            if (!result.Any())
            {

                ////////////////////////////////////////////////////
                query = Query.And(
                   Query.EQ("Status", status), //Query.Or(
                   Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
                  );
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.UserId.ToString()))
                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.UserId.ToString();
                        objClass.UserId = item.FriendUserId.ToString();
                        objClass.Status = item.Status;
                        objClass.DateOfBirth = Useritem.DateOfBirth.ToString();
                        //objClass.BelongsTo = Useritem.BelongsTo;
                        break;
                    }
                    string fdate = objClass.DateOfBirth;
                    string fm = fdate.Substring(0, fdate.IndexOf('/'));
                    int fmonth = Int32.Parse(fm);
                    int length = fdate.LastIndexOf('/') - fdate.IndexOf('/') - 1;
                    int fday = Int32.Parse(fdate.Substring(fdate.IndexOf('/') + 1, length)) + 1;
                    if (fmonth == month && fday == day)
                    {
                        lst.Add(objClass);
                    }
                }
            }
            else
            {
                foreach (Friends item in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass = new UserFriendsBO();
                    var query2 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString()))

                        );
                    foreach (User Useritem in objUserCollection.Find(query2))
                    {
                        objClass.Id = item._id.ToString();
                        objClass.FirstName = Useritem.FirstName;
                        objClass.LastName = Useritem.LastName;
                        objClass.FriendUserId = item.FriendUserId.ToString();
                        objClass.UserId = item.UserId.ToString();
                        objClass.Status = item.Status;
                        objClass.DateOfBirth = Useritem.DateOfBirth.ToString();
                        break;
                    }
                    string fdate = objClass.DateOfBirth;
                    string fm = fdate.Substring(0, fdate.IndexOf('/'));
                    int fmonth = Int32.Parse(fm);
                    int length = fdate.LastIndexOf('/') - fdate.IndexOf('/') - 1;
                    int fday = Int32.Parse(fdate.Substring(fdate.IndexOf('/') + 1, length)) + 1;
                    if (fmonth == month && fday == day)
                    {
                        lst.Add(objClass);
                    }
                    // lst.Add(objClass);

                }
                ///////////////////////////////////////////
                query = Query.And(
              Query.EQ("Status", status), //Query.Or(
              Query.EQ("FriendUserId", ObjectId.Parse(UserId))//, Query.EQ("UserId", UserId))
             );
                foreach (Friends item2 in objCollection.Find(query))
                {


                    MongoCollection<User> objUserCollection2 = db.GetCollection<User>("c_User");

                    UserFriendsBO objClass2 = new UserFriendsBO();
                    var query22 = Query.And(
                        Query.EQ("_id", ObjectId.Parse(item2.UserId.ToString()))

                        );
                    foreach (User Useritem in objUserCollection2.Find(query22))
                    {
                        objClass2.Id = item2._id.ToString();
                        objClass2.FirstName = Useritem.FirstName;
                        objClass2.LastName = Useritem.LastName;
                        objClass2.FriendUserId = item2.UserId.ToString();
                        objClass2.UserId = item2.FriendUserId.ToString();
                        objClass2.Status = item2.Status;
                        objClass2.DateOfBirth = Useritem.DateOfBirth.ToString();
                        break;
                    }
                    string fdate = objClass2.DateOfBirth;
                    string fm = fdate.Substring(0, fdate.IndexOf('/'));
                    int fmonth = Int32.Parse(fm);
                    int length = fdate.LastIndexOf('/') - fdate.IndexOf('/') - 1;
                    int fday = Int32.Parse(fdate.Substring(fdate.IndexOf('/') + 1, length)) + 1;
                    if (fmonth == month && fday == day)
                    {
                        lst.Add(objClass2);
                    }
                    //lst.Add(objClass2);
                }
            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        /************    Find Freind With User    ********************/
        public static List<UserFriendsBO> FindUserListName(string UserId, string Name, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");


            var query = Query.Or(
                 Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));


            foreach (User Useritem in objCollection.Find(query))
            {
                MongoCollection<Friends> objCollection1 = db.GetCollection<Friends>("c_Friends");
                UserFriendsBO objClass = new UserFriendsBO();

                foreach (Friends item in objCollection1.Find(Query.And(
                    Query.EQ("UserId", ObjectId.Parse(UserId)),
                    Query.EQ("Status", (status)),
                    Query.EQ("FriendUserId", ObjectId.Parse(Useritem._id.ToString())
                    ))))
                {
                    objClass.Id = item._id.ToString();
                    objClass.FirstName = Useritem.FirstName;
                    objClass.LastName = Useritem.LastName;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;

                    lst.Add(objClass);
                }

            }
            return lst.ToList();
        }

        /************    Find Friend With Current City    ********************/
        public static List<UserFriendsBO> FindUserListCurrentCity(string UserId, string Name, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");


            var query = Query.Or(
                 Query.Matches("CurrentCity", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));


            foreach (BasicInfo Useritem in objCollection.Find(query))
            {

                MongoCollection<Friends> objCollection1 = db.GetCollection<Friends>("c_Friends");
                UserFriendsBO objClass = new UserFriendsBO();


                foreach (Friends item in objCollection1.Find(Query.And(
                    Query.EQ("UserId", ObjectId.Parse(UserId)),
                    Query.EQ("Status", (status)),
                    Query.EQ("FriendUserId", ObjectId.Parse(Useritem.UserId.ToString())
                    ))))
                {
                    objClass.Id = item._id.ToString();
                    // objClass.FirstName = Useritem.CurrentCity;
                    //objClass.LastName = Useritem.CurrentCity;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;

                    MongoCollection<User> objCollection2 = db.GetCollection<User>("c_User");
                    foreach (User item3 in objCollection2.Find(
                        Query.EQ("_id", ObjectId.Parse(objClass.FriendUserId))
                        ))
                    {

                        objClass.FirstName = item3.FirstName;
                        objClass.LastName = item3.LastName;

                    }

                    lst.Add(objClass);
                }

            }
            return lst.ToList();
        }
        /************    Find Friend With HomeTown   ********************/
        public static List<UserFriendsBO> FindUserListHomeTown(string UserId, string Name, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");


            var query = Query.Or(
                 Query.Matches("HomeTown", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));


            foreach (BasicInfo Useritem in objCollection.Find(query))
            {

                MongoCollection<Friends> objCollection1 = db.GetCollection<Friends>("c_Friends");
                UserFriendsBO objClass = new UserFriendsBO();


                foreach (Friends item in objCollection1.Find(Query.And(
                    Query.EQ("UserId", ObjectId.Parse(UserId)),
                    Query.EQ("Status", (status)),
                    Query.EQ("FriendUserId", ObjectId.Parse(Useritem.UserId.ToString())
                    ))))
                {
                    objClass.Id = item._id.ToString();
                    //objClass.FirstName = Useritem.HomeTown;
                    //objClass.LastName = Useritem.HomeTown;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;

                    MongoCollection<User> objCollection2 = db.GetCollection<User>("c_User");
                    foreach (User item3 in objCollection2.Find(
                        Query.EQ("_id", ObjectId.Parse(objClass.FriendUserId))
                        ))
                    {

                        objClass.FirstName = item3.FirstName;
                        objClass.LastName = item3.LastName;

                    }

                    lst.Add(objClass);
                }

            }
            return lst.ToList();
        }
        /************    Find Friend With School   ********************/
        public static List<UserFriendsBO> FindUserListSchool(string UserId, string Name, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");


            var query = Query.Or(
                 Query.Matches("Name", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));


            foreach (School Useritem in objCollection.Find(query))
            {

                MongoCollection<Friends> objCollection1 = db.GetCollection<Friends>("c_Friends");
                UserFriendsBO objClass = new UserFriendsBO();


                foreach (Friends item in objCollection1.Find(Query.And(
                    Query.EQ("UserId", ObjectId.Parse(UserId)),
                    Query.EQ("Status", (status)),
                    Query.EQ("FriendUserId", ObjectId.Parse(Useritem.UserId.ToString())
                    ))))
                {
                    objClass.Id = item._id.ToString();
                    //objClass.FirstName = Useritem.Name;
                    //objClass.LastName = Useritem.HomeTown;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;

                    MongoCollection<User> objCollection2 = db.GetCollection<User>("c_User");
                    foreach (User item3 in objCollection2.Find(
                        Query.EQ("_id", ObjectId.Parse(objClass.FriendUserId))
                        ))
                    {

                        objClass.FirstName = item3.FirstName;
                        objClass.LastName = item3.LastName;

                    }

                    lst.Add(objClass);
                }

            }
            return lst.ToList();
        }

        /************    Find Friend With WorkPlace   ********************/
        public static List<UserFriendsBO> FindUserListWorkPlace(string UserId, string Name, string status)
        {
            List<UserFriendsBO> lst = new List<UserFriendsBO>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");


            var query = Query.Or(
                 Query.Matches("Organization", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));


            foreach (Employer Useritem in objCollection.Find(query))
            {

                MongoCollection<Friends> objCollection1 = db.GetCollection<Friends>("c_Friends");
                UserFriendsBO objClass = new UserFriendsBO();


                foreach (Friends item in objCollection1.Find(Query.And(
                    Query.EQ("UserId", ObjectId.Parse(UserId)),
                    Query.EQ("Status", (status)),
                    Query.EQ("FriendUserId", ObjectId.Parse(Useritem.UserId.ToString())
                    ))))
                {
                    objClass.Id = item._id.ToString();
                    //objClass.FirstName = Useritem.Organization;
                    //objClass.LastName = Useritem.HomeTown;
                    objClass.FriendUserId = item.FriendUserId.ToString();
                    objClass.UserId = item.UserId.ToString();
                    objClass.Status = item.Status;

                    MongoCollection<User> objCollection2 = db.GetCollection<User>("c_User");
                    foreach (User item3 in objCollection2.Find(
                        Query.EQ("_id", ObjectId.Parse(objClass.FriendUserId))
                        ))
                    {

                        objClass.FirstName = item3.FirstName;
                        objClass.LastName = item3.LastName;

                    }

                    lst.Add(objClass);
                }

            }
            return lst.ToList();
        }
       

    }
}

#region Friends
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Friends
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId FriendUserId { get; set; }
    public string Status { get; set; }
    public string BelongsTo { get; set; }
}
#endregion