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


public class ListViewDAL : BaseClass
{
	public ListViewDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    ///////////////////////////////////////////////////////////////
    //                       INSERT FUNCTION
    //////////////////////////////////////////////////////////////
    public static void insertListName(ListViewBO objClass)
    {



        MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_ListName");

        var query = 
                Query.EQ("ListName", objClass.ListName);
        var result = objCollection.Find(query);
        if (!result.Any())
        {
            BsonDocument doc = new BsonDocument {
                      { "ListName" , objClass.ListName }
                        };

            var rt = objCollection.Insert(doc);

           

        }






    }
    public static string getListName(string userid, string frienduserid)
    {
        string belongsto="";
        MongoCollection<Friends> objCollection2 = db.GetCollection<Friends>("c_Friends");

        var query = Query.And(
            Query.EQ("UserId",  ObjectId.Parse(userid)),
            Query.EQ("FriendUserId", ObjectId.Parse(frienduserid))
            );
        
        var result = objCollection2.Find(query);
        foreach (Friends f in result)
        {
            belongsto = f.BelongsTo;
            break;
 
        }
        return belongsto;
    }
    ///////////////////////////////////////////////////////////////
    //                       SELECT All Freind List 
    //////////////////////////////////////////////////////////////
    public static List<ListViewBO> getAllListView(string userid, string status)
    {
        List<ListViewBO> lst = new List<ListViewBO>();

        MongoCollection<Listview> objCollection = db.GetCollection<Listview>("c_ListName");
        
        foreach (Listview item in objCollection.FindAll())
        {
            MongoCollection<Friends> objUserCollection = db.GetCollection<Friends>("c_Friends");

            ListViewBO objClass = new ListViewBO();

            long c = objUserCollection.Find(Query.And(Query.EQ("UserId", ObjectId.Parse(userid)),
                        Query.EQ("Status", status),
                        Query.EQ("BelongsTo", item.ListName))).Count();
            long cf = objUserCollection.Find(Query.And(Query.EQ("FriendUserId", ObjectId.Parse(userid)),
                        Query.EQ("Status", status),
                        Query.EQ("BelongsTo", item.ListName))).Count();
            
            objClass.ListName = item.ListName;
            objClass.Counting = c+cf;

            lst.Add(objClass);
        }

       
        return lst;

    }

    ///////////////////////////////////////////////////////////////
    //                       SELECT All Freind List 
    //////////////////////////////////////////////////////////////
    public static List<ListViewBO> getDefaultListNames()
    {
        List<ListViewBO> lst = new List<ListViewBO>();

        MongoCollection<Listview> objCollection = db.GetCollection<Listview>("c_ListName");

        foreach (Listview item in objCollection.FindAll())
        {
            //MongoCollection<Friends> objUserCollection = db.GetCollection<Friends>("c_Friends");

            ListViewBO objClass = new ListViewBO();

           

            objClass.ListName = item.ListName;
            //objClass.Counting = c + cf;

            lst.Add(objClass);
        }


        return lst;

    }

    public static void UpdateListDAL(string oldListName, string newListName)
    {
        MongoCollection<User> objCollection = db.GetCollection<User>("c_ListName");

        var query = Query.EQ("ListName", oldListName);
        var sortBy = SortBy.Descending("ListName");
        var update = Update.Set("ListName", newListName)


                            ;
        var result = objCollection.FindAndModify(query, sortBy, update, true);

        MongoCollection<User> objCollection2 = db.GetCollection<User>("c_Friends");

        query = Query.EQ("BelongsTo", oldListName);
        sortBy = SortBy.Descending("BelongsTo");
        update = Update.Set("BelongsTo", newListName);
        
        result = objCollection2.FindAndModify(query, sortBy, update, true);
    }

    public static void UpdateFriendList(string userid, string newListName)
    {
        MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

        var query = Query.EQ("FriendUserId", ObjectId.Parse(userid));
        var sortBy = SortBy.Descending("FriendUserId");
        var update = Update.Set("BelongsTo", newListName);

        //rename the list itself
        var result = objCollection.FindAndModify(query, sortBy, update, true);
    }

    /***********        *********/
    public static void UpdateFriendListBySelect(string id, string newListName)
    {
        MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

        var query = Query.EQ("_id", ObjectId.Parse(id));
        var sortBy = SortBy.Descending("_id");
        var update = Update.Set("BelongsTo", newListName);

        //rename the list itself
        var result = objCollection.FindAndModify(query, sortBy, update, true);
    }

    ///////////////////////////////////////////////////////////////
    //                       SELECT BY PARAMETER
    //////////////////////////////////////////////////////////////
    public static List<UserFriendsBO> getFriendsByList(string Userid, string status, string listname)
    {
        MongoCollection<Friends> objCollection = db.GetCollection<Friends>("c_Friends");

        List<UserFriendsBO> lst = new List<UserFriendsBO>();

        foreach (Friends item in objCollection.Find(Query.And(Query.EQ("UserId", ObjectId.Parse(Userid)),
            (Query.EQ("Status", status)), (Query.EQ("BelongsTo", listname))
            )))
        {
            UserFriendsBO objClass = new UserFriendsBO();
            objClass.Id = item._id.ToString();
            objClass.UserId = item.UserId.ToString();
            objClass.FriendUserId = item.FriendUserId.ToString();
            objClass.Status = item.Status;
            objClass.BelongsTo = item.BelongsTo;

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

        foreach (Friends item in objCollection.Find(Query.And(Query.EQ("FriendUserId", ObjectId.Parse(Userid)),
          (Query.EQ("Status", status)), (Query.EQ("BelongsTo", listname))
          )))
        {
            UserFriendsBO objClass = new UserFriendsBO();
            objClass.Id = item._id.ToString();
            objClass.UserId = item.FriendUserId.ToString();
            objClass.FriendUserId = item.UserId.ToString();
            objClass.Status = item.Status;
            objClass.BelongsTo = item.BelongsTo;

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
        return lst;

    }
}

#region Listview
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Listview
{
    public ObjectId _id { get; set; }
    public string ListName { get; set; }

}
#endregion