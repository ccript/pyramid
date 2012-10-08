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
/// <summary>
/// Summary description for Class1
/// </summary>
namespace DataLayer
{
    //my comment added for test
    //komment added way osman
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
            /*
                        using (DataClassesDataContext context = new DataClassesDataContext())
                        {
                            var userResults = from c in context.c_User
                                              where (c.Email.Equals(Email)
                                              &&
                                              c.Password.Equals(Password)
                                              &&
                                              c.UserStatus.Equals('0'))
                                              select c;
                            return Enumerable.Count(userResults) > 0;

                        }
                        */
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
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var nameResults = from c in context.c_User
                                  where (c.Email.Equals(Email)
                                  )
                                  select c;
                return Enumerable.Count(nameResults) > 0;

            }
             */

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
            //bool isMisspelt = LoginBLL.IsMisspelt(txtUserName.Text);
            /* using (DataClassesDataContext context = new DataClassesDataContext())
             {
                 var User = from c in context.c_User
                            where (c.Email.Contains(Email)
                                ||
                                c.Email.Substring(0, 3) == Email.Substring(0, 3)
                                //||
                                //c.Email.Substring(2, 5) == Email.Substring(2, 5)

                            )
                            select c;
                 LoginBO objUser = new LoginBO();
                 if (Enumerable.Count(User) > 0)
                 {


                     //objUser.UserId = Convert.ToInt32(User.FirstOrDefault().UserId);

                     objUser.Email = User.FirstOrDefault().Email.ToString();
                     objUser.FirstName = User.FirstOrDefault().FirstName.ToString();
                     objUser.LastName = User.FirstOrDefault().LastName.ToString();
                     objUser.PhoneNumber = User.FirstOrDefault().PhoneNumber.ToString();
                 }

                 else
                     objUser.Email = "";

                 return objUser.Email;

             }*/



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
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var passwordResults = from c in context.c_User
                                      where (
                                      c.Password.Equals(Password))
                                      select c;
                return Enumerable.Count(passwordResults) > 0;

            }
             */

        }
        public static bool resetPassword(string Email, string Password)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            // var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Password", Password);

            var result = objCollection.FindAndModify(query, sortBy, update);
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                //get user id against that email
                var User = from c in context.c_User
                           where c.Email == Email
                           select c;
                int UserId = Convert.ToInt32(User.FirstOrDefault().UserId);

                c_User user = context.c_User.Single(s => s.UserId == UserId);
                user.Password = Password;

                context.SubmitChanges();

            }
             */
            return true;

        }

        public static void saveCode(string Email, string randomCode)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            // var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("PasswordResetCode", randomCode);

            var result = objCollection.FindAndModify(query, sortBy, update);
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var User = from c in context.c_User
                           where c.Email == Email
                           select c;
                int UserId = Convert.ToInt32(User.FirstOrDefault().UserId);


                c_User user = context.c_User.Single(s => s.UserId == UserId);
                user.PasswordResetCode = randomCode;

                context.SubmitChanges();

            }

            */
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
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {

                c_IdentifyAccount Account = new c_IdentifyAccount
                {
                    //IdentifyAccountID = Convert.ToInt32(""),
                    ActiveAccountEmail = ActiveEmail,
                    LostAccountEmail = txtAccountEmail,
                    AccountUserName = txtAccountUserName,
                    MobilePhoneNumber = txtMobileNumber,
                    AccountAssociatedEmailAdress = txtAccountLinkedEmailAddress

                };

                context.c_IdentifyAccounts.InsertOnSubmit(Account);
                context.SubmitChanges();


            }*/


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
            /*
            
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var userResults = from c in context.c_User
                                  where (c.Email.Equals(Email)
                                  &&
                                  c.PasswordResetCode.Equals(resetCode))
                                  select c;
                return Enumerable.Count(userResults) > 0;

            }
            */

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
                //objClass.Id = item._id.ToString();
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

            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var User = from c in context.c_User
                           where c.PhoneNumber == Phone
                           select c;
                LoginBO objUser = new LoginBO();
                if (Enumerable.Count(User) > 0)
                {

                   // objUser.UserId = Convert.ToInt32(User.FirstOrDefault().UserId);
                    objUser.Email = User.FirstOrDefault().Email.ToString();
                    objUser.FirstName = User.FirstOrDefault().FirstName.ToString();
                    objUser.LastName = User.FirstOrDefault().LastName.ToString();
                   // objUser.PhoneNumber = User.FirstOrDefault().PhoneNumber.ToString();
                }
                else

                    objUser = null;

                return objUser;
            }*/
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
                //objClass.Id = item._id.ToString();
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
            /*
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var User = from c in context.c_User
                           where c.Email == Email
                           select c;
                LoginBO objUser = new LoginBO();
                if (Enumerable.Count(User) > 0)
                {

                    objUser.UserId = Convert.ToInt32(User.FirstOrDefault().UserId);
                    objUser.Email = User.FirstOrDefault().Email.ToString();
                    objUser.FirstName = User.FirstOrDefault().FirstName.ToString();
                    objUser.LastName = User.FirstOrDefault().LastName.ToString();
                   // objUser.PhoneNumber = User.FirstOrDefault().PhoneNumber.ToString();

                }
                else

                    objUser = null;

                return objUser;


            }*/
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