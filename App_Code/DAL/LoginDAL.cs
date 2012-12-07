using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using BuinessLayer;
using System.Data;

using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DataLayer
{

    public class LoginDAL : BaseClass
    {
        public static bool IsValidLogin(string Email, string Password)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.And(
    Query.EQ("Email", Email),
    Query.EQ("Password", Password),
     Query.EQ("UserStatus", true));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                return false;
            }

            else
                return true;
            
        }

        public static bool IsValidUserName(string Email)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);

            if (objCollection.Find(query).Count() == 1)
            {
                return true;

            }
            else
                return false;
           

        }
        public static string spellingSuggestion(string Email)
        {
            bool userfound = false;
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.Or(
    Query.EQ("Email", Email),
    Query.GT("Email", Email),
     Query.LT("Email", Email));
            LoginBO objClass = new LoginBO();
            foreach (User item in objCollection.Find(query))
            {
                userfound = true;
                //objClass.Id = item._id.ToString();
                objClass.UserId = item._id.ToString();
                objClass.Email = item.Email;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                break;
            }
            if (userfound)
            {
                return objClass.Email;
            }
            else
            {
                return "";
            }

        }


        public static bool IsValidPassword(string Password)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Password", Password);
            if (objCollection.Find(query).Count() >= 1)
            {
                return true;

            }
            else
                return false;
            
        }
        public static bool resetPassword(string Email, string Password)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Password", Password);

            var result = objCollection.FindAndModify(query, sortBy, update);
            
            return true;

        }

        public static void saveCode(string Email, string randomCode)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("PasswordResetCode", randomCode);

            var result = objCollection.FindAndModify(query, sortBy, update);
            
        }
        public static void saveIdentifyAccountInfo(string ActiveEmail, string txtAccountEmail, string txtAccountUserName, string txtMobileNumber, string txtAccountLinkedEmailAddress)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_IdentifyAccount");
            BsonDocument LostAccount = new BsonDocument {
    { "ActiveAccountEmail", ActiveEmail },
    { "LostAccountEmail", txtAccountEmail},
    {  "AccountUserName", txtAccountUserName},
    {  "MobilePhoneNumber", txtMobileNumber},
    {  "AccountAssociatedEmailAdress", txtAccountLinkedEmailAddress}
            };
            objCollection.Insert(LostAccount);
            

        }
        public static bool validateCode(string Email, string resetCode)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.And(
    Query.EQ("Email", Email),
    Query.EQ("PasswordResetCode", resetCode));
            if (objCollection.Find(query).Count() == 1)
            {
                return true;

            }
            else
                return false;
   
        }
        public static LoginBO getUserbyPhone(string Phone)
        {
            bool userfound = false;
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("PhoneNumber", Phone);
            LoginBO objClass = new LoginBO();
            foreach (User item in objCollection.Find(query))
            {
                userfound = true;
                objClass.UserId = item._id.ToString();
                objClass.Email = item.Email;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.PhoneNumber = Phone;
                break;
            }
            if (userfound)
                return objClass;
            else
                return null;

        }
        public static LoginBO getUserbyEmail(string Email)
        {
            bool userfound = false;
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            LoginBO objClass = new LoginBO();
            foreach (User item in objCollection.Find(query))
            {
                userfound = true;
                objClass.UserId = item._id.ToString();
                objClass.Email = item.Email;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                objClass.PhoneNumber = item.PhoneNumber;
                break;
            }
            if (userfound)
                return objClass;
            else
                return null;
            
        }

    }
}
#region LoginInfo
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class LoginInfo
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserStatus { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }
    public string PasswordResetCode { get; set; }

}
#endregion