using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


using System.IO;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Text;
/// <summary>
/// Summary description for EntertainmentWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class EntertainmentWebService : System.Web.Services.WebService {

    public EntertainmentWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public  string GetDynamicContent(string contextKey)
    {
        

        MongoCollection<User> objCollection = BaseClass.db.GetCollection<User>("c_User");

        UserBO objClass = new UserBO();
        foreach (User item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(contextKey))))
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
        MongoCollection<BasicInfo> objCollection2 = BaseClass.db.GetCollection<BasicInfo>("c_BasicInfo");

        BasicInfoBO objClassBasicInfo = new BasicInfoBO();
        foreach (BasicInfo item in objCollection2.Find(Query.EQ("UserId", ObjectId.Parse(contextKey))).SetLimit(1))
        {
            objClassBasicInfo.Id = item._id.ToString();
            objClassBasicInfo.UserId = item.UserId.ToString();
            objClassBasicInfo.CurrentCity = item.CurrentCity;
            objClassBasicInfo.HomeTown = item.HomeTown;
            objClassBasicInfo.Address = item.Address;
            objClassBasicInfo.CityTown = item.CityTown;
            objClassBasicInfo.ZipCode = item.ZipCode;
            objClassBasicInfo.Neighbourhood = item.Neighbourhood;
            objClassBasicInfo.RelationshipStatus = item.RelationshipStatus;
            break;
        }
        StringBuilder b = new StringBuilder();
        b.Append("<table ");
        b.Append("width:200px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");
                            
      //  b.Append("<tr><td colspan='3' style='background-color:#336699; color:white;'></td>View Post</tr>");
        b.Append("<tr><td><img src='../../Resources/ProfilePictures/" +contextKey+".jpg' width='50px'/> </td></tr>");
        b.Append("<tr><td><b>" + objClass.FirstName + " " + objClass.LastName + "</b> </td></tr>");
        b.Append("<tr><td>" + objClass.DateOfBirth.ToLongDateString() + " </td></tr>");
        b.Append("<tr><td>" + objClass.Gender + " </td></tr>");
        b.Append("<tr><td>" + objClassBasicInfo.CurrentCity + " </td></tr>");
        // b.Append("<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='../../Resources/CompressedVideo/play.png' Visible='<%# (((int)Eval("Type")) == Global.VIDEO)||(((int)Eval("Type")) == Global.TAG_VIDEOLINK)||(((int)Eval("Type")) == Global.TAG_VIDEO)||(((int)Eval("Type")) == Global.POST_VIDEOLINK)?true:false %>' CommandName="show" style='<%# "background:url(" +Eval("EmbedPost") + ")" %>'  />
     
             


       

        b.Append("</table>");

        return b.ToString();
    }
    [WebMethod]
    public string[] GetBooks(string prefixText, int count)
    {
      
        return GetEntertainmentDataFromDB(Global.BOOKS, prefixText, count);
       
    }
    [WebMethod]
    public string[] GetMusic(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB(Global.MUSIC, prefixText, count);


    }
    [WebMethod]
    public string[] GetMovie(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB(Global.MOVIE, prefixText, count);

    }
    [WebMethod]
    public string[] GetTelevision(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB(Global.TELEVISION, prefixText, count);


    }
    [WebMethod]
    public string[] GetGame(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB(Global.GAME, prefixText, count);
    }
    [WebMethod]
    public string[] GetSport(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB("Sport", prefixText, count);

    }
      [WebMethod]
    public string[] GetTeam(string prefixText, int count)
    {

        return GetEntertainmentDataFromDB(Global.TEAM, prefixText, count);

    }
      [WebMethod]
      public string[] GetAthelete(string prefixText, int count)
      {

          return GetEntertainmentDataFromDB(Global.ATHELETE, prefixText, count);

      }
      [WebMethod]
      public string[] GetEmployer(string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<Employer> objCollection = BaseClass.db.GetCollection<Employer>("c_Employer");
          objCollection.EnsureIndex("Organization");
          var query = Query.Matches("Organization", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.Organization);

          }


           return lst.Distinct().ToArray();

      }
      [WebMethod]
      public string[] GetProject(string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<Project> objCollection = BaseClass.db.GetCollection<Project>("c_Project");
          objCollection.EnsureIndex("ProjectName");
          var query = Query.Matches("ProjectName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.ProjectName);

          }


           return lst.Distinct().ToArray();

      }

      [WebMethod]
      public string[] GetUniversities(string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<University> objCollection = BaseClass.db.GetCollection<University>("c_University");
          objCollection.EnsureIndex("UniversityName");
          var query =  Query.Matches("UniversityName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.UniversityName);

          }


           return lst.Distinct().ToArray();
      }
      [WebMethod]
      public string[] GetSchool(string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<School> objCollection = BaseClass.db.GetCollection<School>("c_School");
          objCollection.EnsureIndex("Name");
          var query = Query.Matches("Name", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.Name);

          }


           return lst.Distinct().ToArray();

      }

      [WebMethod]
      public  string[] GetUser(string prefixText, int count)
      {
          List<string> lst = new List<string>();

          MongoCollection<User> objCollection = BaseClass.db.GetCollection<User>("c_User");

          var query = Query.Or(
                   Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                   Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
           Query.Matches("Email", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
           
          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              //lst.Add(item.FirstName + " " + item.LastName);
              lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(item.FirstName+" "+ item.LastName,item._id.ToString()));
          }


           return lst.Distinct().ToArray();

      }


      [WebMethod]
      public string[] GetActivity(string prefixText, int count)
      {

          return GetActivitiesDataFromDB(Global.ACTIVITIES, prefixText, count);

      }
      [WebMethod]
      public string[] GetLocationwithCount(string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<BasicInfo> objCollection = BaseClass.db.GetCollection<BasicInfo>("c_BasicInfo");
          var query = Query.Matches("HomeTown", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

          System.Globalization.TextInfo txtInfo = cultureInfo.TextInfo;
          foreach (var item in cursor)
          {



              MongoCollection<BasicInfo> objCollection2 = BaseClass.db.GetCollection<BasicInfo>("c_BasicInfo");
              var query2 = Query.EQ("HomeTown", item.HomeTown);
              var result = objCollection.Find(query);
              result.Count();
              lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(item.HomeTown, result.Count().ToString()));
              //lst.Add(txtInfo.ToTitleCase(item.HomeTown));
          }

          /* var query2 = Query.Matches("HomeTown", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

           var cursor2 = objCollection.Find(query2);
           cursor2.Limit = 5;
           foreach (var item in cursor)
           {
               lst.Add(item.HomeTown);

           }*/
          return lst.Distinct().Take(5).ToArray();
      }
    [WebMethod]
      public string[] GetLocation( string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<BasicInfo> objCollection = BaseClass.db.GetCollection<BasicInfo>("c_BasicInfo");
          var query = Query.Matches("HomeTown", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

          System.Globalization.TextInfo txtInfo = cultureInfo.TextInfo;
          foreach (var item in cursor)
          {

              lst.Add(txtInfo.ToTitleCase( item.HomeTown));
          }

         /* var query2 = Query.Matches("HomeTown", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + "")));

          var cursor2 = objCollection.Find(query2);
          cursor2.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.HomeTown);

          }*/
          return lst.Distinct().Take(5).ToArray();
      }
      [WebMethod]
      public string[] GetInterests(string prefixText, int count)
      {

          return GetActivitiesDataFromDB(Global.INTERESTS, prefixText, count);

      }


     [WebMethod(EnableSession = true)]
      public string[] GetFriendsName(string prefixText, int count)
      {
          List<string> lst = new List<string>();
          string uid = Session["UserId"].ToString();
          MongoCollection<Friends> objCollection = BaseClass.db.GetCollection<Friends>("c_Friends");
          var query = Query.And(
                 Query.EQ("Status", Global.CONFIRMED), //Query.Or(
                 Query.EQ("UserId", ObjectId.Parse(uid))//, Query.EQ("UserId", UserId))
                );
          var query2 = Query.And(
                  Query.EQ("Status", Global.CONFIRMED), //Query.Or(
                  Query.EQ("FriendUserId", ObjectId.Parse(uid))//, Query.EQ("UserId", UserId))
                 );
          var query3 = Query.Or(
                   query, //Query.Or(
                   query2//, Query.EQ("UserId", UserId))
                  );
          
               foreach (Friends item in objCollection.Find(query))
               {


                   MongoCollection<User> objUserCollection = BaseClass.db.GetCollection<User>("c_User");

                   UserFriendsBO objClass = new UserFriendsBO();
                   var Namequery = Query.Or(
                    Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                    Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
                   var queryid = Query.And(
                       Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString())))
                       ;
                   var queryu = Query.And(Namequery, queryid);
                   foreach (User Useritem in objUserCollection.Find(queryid))
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
                   //lst.Add(objClass.FirstName + " " + objClass.LastName);
                   lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(objClass.FirstName + " " + objClass.LastName, objClass.UserId.ToString()));

               }
               foreach (Friends item in objCollection.Find(query2))
               {


                   MongoCollection<User> objUserCollection = BaseClass.db.GetCollection<User>("c_User");

                   UserFriendsBO objClass = new UserFriendsBO();
                   var Namequery = Query.Or(
                    Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                    Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
                   var queryid= Query.And(
                       Query.EQ("_id", ObjectId.Parse(item.UserId.ToString())))
                       ;

                   var queryu=Query.And(Namequery,queryid);
                   foreach (User Useritem in objUserCollection.Find(queryid))
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
                   //lst.Add(objClass.FirstName + " " + objClass.LastName);
                   lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(objClass.FirstName + " " + objClass.LastName, objClass.FriendUserId.ToString()));

               }
           /*var result = objCollection.Find(query2);
           if (!result.Any())
           {
         
           }*/
          /* var result = objCollection.Find(query);
           if (!result.Any())
           {

               ////////////////////////////////////////////////////
               query = Query.And(
                  Query.EQ("Status", Global.CONFIRMED), //Query.Or(
                  Query.EQ("FriendUserId", ObjectId.Parse(uid))//, Query.EQ("UserId", UserId))
                 );
               foreach (Friends item in objCollection.Find(query))
               {


                   MongoCollection<User> objUserCollection = BaseClass.db.GetCollection<User>("c_User");

                   UserFriendsBO objClass = new UserFriendsBO();
                   var Namequery = Query.Or(
                    Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                    Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
                   var query2 = Query.And(
                       Query.EQ("_id", ObjectId.Parse(item.UserId.ToString())), Namequery)
                       ;
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
                   //lst.Add(objClass.FirstName + " " + objClass.LastName);
                   lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(objClass.FirstName + " " + objClass.LastName, objClass.FriendUserId.ToString()));
              
               }
           }
           else
           {
               foreach (Friends item in objCollection.Find(query))
               {


                   MongoCollection<User> objUserCollection = BaseClass.db.GetCollection<User>("c_User");

                   UserFriendsBO objClass = new UserFriendsBO();
                   var Namequery = Query.Or(
                   Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                   Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
                 
                   var query2 = Query.And(
                       Query.EQ("_id", ObjectId.Parse(item.FriendUserId.ToString())), Namequery 
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
                   //lst.Add(objClass.FirstName + " " + objClass.LastName);
                   lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(objClass.FirstName + " " + objClass.LastName, objClass.FriendUserId.ToString()));
              

               }
               ///////////////////////////////////////////
               query = Query.And(
             Query.EQ("Status", Global.CONFIRMED), //Query.Or(
             Query.EQ("FriendUserId", ObjectId.Parse(uid))//, Query.EQ("UserId", UserId))
            );
               foreach (Friends item2 in objCollection.Find(query))
               {


                   MongoCollection<User> objUserCollection2 = BaseClass.db.GetCollection<User>("c_User");

                   UserFriendsBO objClass2 = new UserFriendsBO();
                   var Namequery = Query.Or(
                   Query.Matches("FirstName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))),
                   Query.Matches("LastName", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));
                 
                   var query22 = Query.And(
                       Query.EQ("_id", ObjectId.Parse(item2.UserId.ToString())), Namequery 
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
                   //lst.Add(objClass2.FirstName +" " +objClass2.LastName);
                   lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(objClass2.FirstName + " " + objClass2.LastName, objClass2.FriendUserId.ToString()));
               }
           }*/
          return lst.Distinct().Take(10).ToArray();
      }
      protected string[] GetEntertainmentDataFromDB(string Type, string prefixText, int count)
      {
          
          List<string> lst = new List<string>();

          MongoCollection<Entertainment> objCollection = BaseClass.db.GetCollection<Entertainment>("c_Entertainment");
          objCollection.EnsureIndex("Type");
          objCollection.EnsureIndex("Name");
          var query = Query.And(
                      Query.EQ("Type", Type),
                      Query.Matches("Name", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText+""))));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.Name);

          }


           return lst.Distinct().ToArray();
      }
  
      protected string[] GetActivitiesDataFromDB(string Type, string prefixText, int count)
      {

          List<string> lst = new List<string>();

          MongoCollection<Activity> objCollection = BaseClass.db.GetCollection<Activity>("c_Activities");
          objCollection.EnsureIndex("Type");
          objCollection.EnsureIndex("Name");
          var query = Query.And(
                      Query.EQ("Type", Type),
                      Query.Matches("Name", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex("^(?i)" + prefixText + ""))));

          var cursor = objCollection.Find(query);
          cursor.Limit = 5;
          foreach (var item in cursor)
          {
              lst.Add(item.Name);

          }

          
           return lst.Distinct().ToArray();
      }

   
   
  

    [WebMethod]
    public List<string> GetCountries(string prefixText)
    {

        List<string> CountryNames = new List<string>();
        CountryNames.Add("aaa");
        CountryNames.Add("aaaaaaa");
        CountryNames.Add("aaaaaa");
        CountryNames.Add("aaaaaa");
        CountryNames.Add("aaaaa");
        return CountryNames;
    }
}
