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

/// <summary>
/// Summary description for ReenterDAL
/// </summary>
public class ReenterDAL:BaseClass
{
	public ReenterDAL()
	{
		//
		// TODO: Add constructor logic here
		//
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
        /*
        using (DataClassesDataContext context2 = new DataClassesDataContext())
        {
            var uResults = from c in context2.c_User
                              where (c.Email.Equals(UserName)
                              )
                              select c;
            string firstName= uResults.FirstOrDefault().FirstName;
            string lastName = uResults.FirstOrDefault().LastName;
            //myDB.Users.Single(u, u.UserName=>userName);

            string fullname = firstName + " " + lastName;
            return fullname;

        }
        */
    }
}