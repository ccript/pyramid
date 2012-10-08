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
/// Summary description for ProjectDAL
/// </summary>
/// 

namespace DataLayer
{
    public class ProjectDAL : BaseClass
    {
        
        public ProjectDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertProject(ProjectBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Project");


            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                       { "EmployerId" , ObjectId.Parse(objClass.EmployerId) },
                           { "ProjectName", objClass.ProjectName },
                        { "Description", objClass.Description },
                        { "StartDay", objClass.StartDay },
                        { "StartMonth" , objClass.StartMonth },
                        { "StartYear", objClass.StartYear },
                        { "EndDay", objClass.EndDay },
                        { "EndMonth" , objClass.EndMonth },
                        { "EndYear", objClass.EndYear },
                        { "Image",objClass.Image }
        
                        };

            var rt = objCollection.Insert(doc);

            return doc["_id"].ToString();
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateProject(ProjectBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Project");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                  .Set("EmployerId", ObjectId.Parse(objClass.EmployerId))
                                   .Set("ProjectName", objClass.ProjectName)
                       .Set("Description", objClass.Description)
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
        public static void deleteProject(string Id)
          {
              MongoCollection<Employer> objCollection = db.GetCollection<Employer>("c_Project");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id")); 
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Project> getAllProjectList()
        {
            List<Project> lst = new List<Project>();

            MongoCollection<Project> objCollection = db.GetCollection<Project>("c_Project");

            foreach (Project item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ProjectBO getProjectByProjectId(string Id)
        {

            MongoCollection<Project> objCollection = db.GetCollection<Project>("c_Project");

            ProjectBO objClass = new ProjectBO();
            foreach (Project item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.EmployerId = item.EmployerId.ToString();
                objClass.ProjectName = item.ProjectName;
                objClass.Description = item.Description;
                objClass.EndYear = Convert.ToInt32(item.EndYear);
                objClass.EndMonth = Convert.ToInt32(item.EndMonth);
                objClass.EndDay = Convert.ToInt32(item.EndDay);
                objClass.StartDay = Convert.ToInt32(item.StartDay);
                objClass.StartMonth = Convert.ToInt32(item.StartMonth);
                objClass.StartYear = Convert.ToInt32(item.StartYear);
                objClass.Image = item.Image;
                break;
            }
            return objClass;
           
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Project> getProjectTop5(string Id)
        {
            List<Project> lst = new List<Project>();

            MongoCollection<Project> objCollection = db.GetCollection<Project>("c_Project");
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

    }
}

#region Project
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Project
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId EmployerId { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public int StartYear { get; set; }
    public int StartMonth { get; set; }
    public int StartDay { get; set; }
    public int EndYear { get; set; }
    public int EndMonth { get; set; }
    public int EndDay { get; set; }
    public string Image { get; set; }

}
#endregion