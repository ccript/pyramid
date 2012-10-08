using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using System.Collections;

using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
/// <summary>
/// Summary description for UniversityDAL
/// </summary>
/// 

namespace DataLayer
{
    public class UniversityDAL : BaseClass
    {
        
        public UniversityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertUniversity(UniversityBO objClass)
        {
           

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_University");


            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "UniversityName" , objClass.UniversityName},
                        { "ClassYear", objClass.ClassYear },
                        { "Purpose" , objClass.Purpose  },
                        { "Degree", objClass.Degree },
                        { "AttendedFor" , objClass.AttendedFor },
                        { "Image",objClass.Image }
        
                        };

            var rt = objCollection.Insert(doc);

            return doc["_id"].ToString();
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateUniversity(UniversityBO objClass)
        {
            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                  .Set("UniversityName", objClass.UniversityName)
                        .Set("ClassYear", objClass.ClassYear)
                        .Set("Purpose", objClass.Purpose)
                       .Set("Degree", objClass.Degree)
                        .Set("AttendedFor", objClass.AttendedFor)
                       .Set("Image", objClass.Image)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteUniversity(string Id)
          {
              MongoCollection<University> objCollection = db.GetCollection<University>("c_University");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<University> getAllUniversityList()
        {
            List<University> lst = new List<University>();

            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");

            foreach (University item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static UniversityBO getUniversityByUniversityId(string Id)
        {


            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");

            UniversityBO objClass = new UniversityBO();
            foreach (University item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.UniversityName = item.UniversityName;
                objClass.Purpose = item.Purpose;
                objClass.ClassYear = item.ClassYear;
                objClass.Degree = item.Degree;
                objClass.AttendedFor = item.AttendedFor;
                objClass.Image = item.Image;
                break;
            }
            return objClass;
           
        }
        //////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER List of Emps
        //////////////////////////////////////////////////////////////
        public static ArrayList getUnisByUserId(string Id)
        {
            ArrayList Unis = new ArrayList();

            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");

            UniversityBO objClass = new UniversityBO();
            foreach (University item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                Unis.Add(item.UniversityName);


            }
            return Unis;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<University> getUniversityTop5(string Id)
        {
            List<University> lst = new List<University>();

            MongoCollection<University> objCollection = db.GetCollection<University>("c_University");
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

#region University
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class University
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string UniversityName { get; set; }
    public string Position { get; set; }
    public string Purpose { get; set; }
    public int ClassYear { get; set; }
    public string Degree { get; set; }
    public string AttendedFor { get; set; }
    public string Image { get; set; }

}
#endregion