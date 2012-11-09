using System;
using System.Collections;
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
/// Summary description for EmployerDAL
/// </summary>
/// 

namespace DataLayer
{
    public class EmployerDAL : BaseClass, TemplateInfoDAL
    {
        
        public EmployerDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        ///////////////////////////////////////////////////////////////
        //                       INSERT
        //////////////////////////////////////////////////////////////
        public void insert(TemplateBO objClass)
        {


            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Employer");


            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Organization" , objClass.Organization },
                        { "Position", objClass.Position },
                        { "Town" , objClass.Town  },
                        { "Description", objClass.Description },
                        { "IsCurrentlyWork" , objClass.IsCurrentlyWork },
                        { "StartDay", objClass.StartDay },
                        { "StartMonth" , objClass.StartMonth },
                        { "StartYear", objClass.StartYear },
                        { "EndDay", objClass.EndDay },
                        { "EndMonth" , objClass.EndMonth },
                        { "EndYear", objClass.EndYear },
                        { "Image",objClass.Image }
        
                        };

            objCollection.Insert(doc);



        }


        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public void update(TemplateBO objClass)
        {

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                  .Set("Organization", objClass.Organization)
                        .Set("Position", objClass.Position)
                        .Set("Town", objClass.Town)
                       .Set("Description", objClass.Description)
                        .Set("IsCurrentlyWork", objClass.IsCurrentlyWork)
                       .Set("StartDay", objClass.StartDay)
                       .Set("StartMonth", objClass.StartMonth)
                       .Set("StartYear", objClass.StartYear)
                       .Set("EndDay", objClass.EndDay)
                        .Set("EndMonth", objClass.EndMonth)
                       .Set("EndYear", objClass.EndYear)
                       .Set("Image", objClass.Image)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);
        }


        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public void delete(string Id)
        {
            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                SortBy.Ascending("_id"));
        }


        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public List<Employer> SelectList()
        {
            List<Employer> lst = new List<Employer>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            foreach (Employer item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public EmployerBO SelectEmployerByUserId(string Id)
        {

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            EmployerBO objClass = new EmployerBO();
            foreach (Employer item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Organization = item.Organization;
                objClass.Position = item.Position;
                objClass.Town = item.Town;
                objClass.Description = item.Description;
                objClass.EndYear = Convert.ToInt32(item.EndYear);
                objClass.EndMonth = Convert.ToInt32(item.EndMonth);
                objClass.EndDay = Convert.ToInt32(item.EndDay);
                objClass.StartDay = Convert.ToInt32(item.StartDay);
                objClass.StartMonth = Convert.ToInt32(item.StartMonth);
                objClass.StartYear = Convert.ToInt32(item.StartYear);
                objClass.IsCurrentlyWork = Convert.ToBoolean(item.IsCurrentlyWork);
                objClass.Image = item.Image;
                break;
            }
            return objClass;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public List<Employer> SelectEmployerTop5(string Id)
        {
            List<Employer> lst = new List<Employer>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");
            objCollection.EnsureIndex("_Id");

            var query = Query.EQ("UserId", ObjectId.Parse(Id));
            var cursor = objCollection.Find(query);
            cursor.Limit = 5;
            foreach (var item in cursor)
            {
                lst.Add(item);

            }
            return lst;
        }


        /************************          888888                     *************************/

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static void insertEmployer(EmployerBO objClass)
        {


            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Employer");

           
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Organization" , objClass.Organization },
                        { "Position", objClass.Position },
                        { "Town" , objClass.Town  },
                        { "Description", objClass.Description },
                        { "IsCurrentlyWork" , objClass.IsCurrentlyWork },
                        { "StartDay", objClass.StartDay },
                        { "StartMonth" , objClass.StartMonth },
                        { "StartYear", objClass.StartYear },
                        { "EndDay", objClass.EndDay },
                        { "EndMonth" , objClass.EndMonth },
                        { "EndYear", objClass.EndYear },
                        { "Image",objClass.Image }
        
                        };

                objCollection.Insert(doc);

    
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateEmployer(EmployerBO objClass)
        {
           
            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                  .Set( "Organization" , objClass.Organization )
                        .Set("Position", objClass.Position )
                        .Set( "Town" , objClass.Town  )
                       .Set( "Description", objClass.Description )
                        .Set( "IsCurrentlyWork" , objClass.IsCurrentlyWork )
                       .Set( "StartDay", objClass.StartDay)
                       .Set( "StartMonth" , objClass.StartMonth )
                       .Set( "StartYear", objClass.StartYear )
                       .Set( "EndDay", objClass.EndDay )
                        .Set( "EndMonth" , objClass.EndMonth)
                       .Set( "EndYear", objClass.EndYear )
                       .Set( "Image",objClass.Image )

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);
        }


        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteEmployer(string Id)
          {
              MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Employer> getAllEmployerList()
        {
            List<Employer> lst = new List<Employer>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            foreach (Employer item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static EmployerBO getEmployerByUserId(string Id)
        {
       

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            EmployerBO objClass = new EmployerBO();
            foreach (Employer item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Organization = item.Organization;
                objClass.Position = item.Position;
                objClass.Town = item.Town;
                objClass.Description = item.Description;
                objClass.EndYear = Convert.ToInt32(item.EndYear);
                objClass.EndMonth = Convert.ToInt32(item.EndMonth);
                objClass.EndDay = Convert.ToInt32(item.EndDay);
                objClass.StartDay = Convert.ToInt32(item.StartDay);
                objClass.StartMonth = Convert.ToInt32(item.StartMonth);
                objClass.StartYear = Convert.ToInt32(item.StartYear);
                objClass.IsCurrentlyWork = Convert.ToBoolean(item.IsCurrentlyWork);
                objClass.Image = item.Image;
                break;
            }
            return objClass;
           
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER List of Emps
        //////////////////////////////////////////////////////////////
        public static ArrayList getEmployersByUserId(string Id)
        {
            ArrayList Employers = new ArrayList();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");

            EmployerBO objClass = new EmployerBO();
            foreach (Employer item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                Employers.Add(item.Organization);

               
            }
            return Employers;

        }

       
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Employer> getEmployerTop5( string Id)
        {
            List<Employer> lst = new List<Employer>();

            MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Employer");
            objCollection.EnsureIndex("_Id");

            var query =Query.EQ("UserId", ObjectId.Parse(Id));
            var cursor = objCollection.Find(query);
            cursor.Limit = 5;
            foreach (var item in cursor)
            {
                lst.Add(item);

            }
            return lst;
        }


        public List<Language> SelectListLanguages()
        {
            throw new NotImplementedException();
        }

        public List<Language> SelectLanguageByid(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}

#region Employer
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Employer
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Organization { get; set; }
    public string Position { get; set; }
    public string Town { get; set; }
    public string Description { get; set; }
    public bool IsCurrentlyWork { get; set; }
    public int StartYear { get; set; }
    public int StartMonth { get; set; }
    public int StartDay { get; set; }
    public int EndYear { get; set; }
    public int EndMonth { get; set; }
    public int EndDay { get; set; }
    public string Image { get; set; }

}
#endregion