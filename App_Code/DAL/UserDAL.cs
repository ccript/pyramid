using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
/// <summary>
/// Summary description for BasicInfoDAL
/// </summary>
/// 

namespace DataLayer
{
    public class UserDAL : BaseClass
    {

        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string UserSignup(UserBO objClass)
        {



            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_User");


            BsonDocument doc = new BsonDocument {
                      { "Email" , objClass.Email},
                      { "UserName" , objClass.UserName},
                       { "Password" , objClass.Password },
                       { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName  },
                        { "Gender", objClass.Gender },
                         { "PhoneNumber", objClass.PhoneNumber },
                        { "DateOfBirth", objClass. DateOfBirth },
                        { "PasswordResetCode", objClass.PasswordResetCode },
                        { "UserStatus" , objClass.UserStatus },
                         { "IsMobileAlert" , objClass.IsMobileAlert },
                   
        
                        };

            var rt = objCollection.Insert(doc);
            return doc["_id"].ToString();
        }


        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateBasicInfoPage(UserBO objClass)
        {


            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("DateOfBirth", objClass.DateOfBirth)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateEmail(UserBO objClass)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("Email", objClass.Email)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }


        /* public static int ConfirmUser(UserBO objUser)
         {

             string query = "UPDATE c_User SET UserStatus ='0' WHERE Email = @email AND PasswordResetCode=@code";
             SqlCommand sqlCommand = new SqlCommand(query);
             sqlCommand.Parameters.Add(new SqlParameter("@email", objUser.Email));
             sqlCommand.Parameters.Add(new SqlParameter("@code", objUser.PasswordResetCode));
             return update(sqlCommand);

         }*/


        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<User> getAllUserList()
        {
            List<User> lst = new List<User>();

            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            foreach (User item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<User> SearchUserList(string Name,string userid)
        {
            List<User> lst = new List<User>();

            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            string[] words = Name.Split(' ');

            foreach (string word in words)
            {
                var query = Query.Or(
                    Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + word + ""))),
                   Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + word + ""))),

           Query.Matches("Email", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Name + ""))));
          
           
           var query2 = Query.And(query,Query.NE("_id", ObjectId.Parse(userid)));
           


                foreach (User item in objCollection.Find(query2).Distinct())
                {
                    lst.Add(item);

                }
            }
            return lst.Distinct().ToList();

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<User> SearchUserbyLocation(string Location)
        {
            List<User> lst = new List<User>();

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");


            var query = Query.Matches("CurrentCity", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Location + "")));



            foreach (BasicInfo item in objCollection.Find(query))
                {
                    MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                    UserBO objClass = new UserBO();

                    foreach (User Useritem in objUserCollection.Find(Query.EQ("_id", item.UserId)))
                    {
                        lst.Add(Useritem);
                        break;
                    }
                   

                }
         
            return lst.ToList();

        }


        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<User> SearchUserbyWorkSpace(string WorkSpace)
        {
            List<User> lst = new List<User>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");


            var query = Query.Matches("Organization", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + WorkSpace + "")));



            foreach (Employer item in objCollection.Find(query))
            {
                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                UserBO objClass = new UserBO();

                foreach (User Useritem in objUserCollection.Find(Query.EQ("_id", item.UserId)))
                {
                    lst.Add(Useritem);
                    break;
                }


            }

            return lst.ToList();

        }


        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<User> SearchUserbyEducation(string Education,int year)
        {
            List<User> lst = new List<User>();

            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");


            var query = Query.Or(
                 Query.Matches("UniversityName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + Education + ""))),
                Query.EQ("ClassYear", year));



            foreach (University item in objCollection.Find(query))
            {
                MongoCollection<User> objUserCollection = db.GetCollection<User>("c_User");

                UserBO objClass = new UserBO();

                foreach (User Useritem in objUserCollection.Find(Query.EQ("_id", item.UserId)))
                {
                    lst.Add(Useritem);
                    break;
                }


            }

            return lst.ToList();

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static UserBO getUserByUserId(string Id)
        {


            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            UserBO objClass = new UserBO();
            foreach (User item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.Email = item.Email.ToString();
                objClass.UserName = item.UserName;
                objClass.Password = item.Password;
                objClass.FirstName = item.FirstName;
                objClass.DateOfBirth = item.DateOfBirth;
                objClass.LastName = item.LastName;
                objClass.PhoneNumber = item.PhoneNumber;
                objClass.PasswordResetCode = item.PasswordResetCode;
                objClass.IsMobileAlert = item.IsMobileAlert;
                objClass.PhoneNumber = item.PhoneNumber;
                objClass.Gender = item.Gender;
                objClass.UserStatus = item.UserStatus;
                break;
            }
            return objClass;

        }


        public static string getUserID(string Email)
        {
            string UserId = "";
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            foreach (User item in objCollection.Find(query))
            {

                UserId = item._id.ToString();
                break;
            }
            return UserId;

        }

        public static string CheckUserEmail(string Email)
        {

            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");
            var query = Query.EQ("Email", Email);
            string found = "No";
            foreach (User item in objCollection.Find(query))
            {
                found = "Yes";
                //UserId = item._id.ToString();
                break;
            }
            return found;

        }

        //UPDATE PHONE NO
        public static void UpdatePhoneNo(UserBO objClass)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("PhoneNumber", objClass.PhoneNumber);

            
            var result = objCollection.FindAndModify(query, sortBy, update, true);
        }

        //Confirm User Account
        public static string ConfirmUser(UserBO objClass)
        {
            MongoCollection<User> objCollection = db.GetCollection<User>("c_User");

            bool found = true;
            var query = Query.And(
              Query.EQ("PasswordResetCode", objClass.PasswordResetCode),
              Query.EQ("_id", ObjectId.Parse(objClass.Id)));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserStatus", found);

            var result = objCollection.FindAndModify(query, sortBy, update, true);
            string found_ok = "No";
            foreach (User item in objCollection.Find(query))
            {
                found_ok = "Yes";
                //UserId = item._id.ToString();
                break;
            }
            return found_ok;


        }
    }
}


#region User
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class User
{
    public ObjectId _id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsMobileAlert { get; set; }
    public string PasswordResetCode { get; set; }
    public bool UserStatus { get; set; }
 

}
#endregion