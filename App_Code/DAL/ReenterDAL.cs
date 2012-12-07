using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using ObjectLayer;
using System.Data;

using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


public class ReenterDAL:BaseClass
{
	public ReenterDAL()
	{
	}
    public static string getFullUserName(string UserName)
    {
        string FullName = "";
        MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
        var query = Query.EQ("Email", UserName);

        foreach (User item in objCollection.Find(query))
        {

            FullName = item.FirstName.ToString() + " " +item.LastName.ToString();
            break;
        }
        return FullName;
        
    }
}