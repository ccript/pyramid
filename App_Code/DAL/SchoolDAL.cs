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
/// Summary description for SchoolDAL
/// </summary>
/// 

namespace DataLayer
{
    public class SchoolDAL : BaseClass
    {
        
        public SchoolDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertSchool(SchoolBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_School");

            var query = Query.And(
                    Query.EQ("Name", objClass.Name),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Name" , objClass.Name },
                        { "Description" , objClass.Description },
         
                        { "Image",objClass.Image }
        
                        };

                var rt = objCollection.Insert(doc);

                return doc["_id"].ToString();

            }

            else
                return null;
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateSchool(SchoolBO objClass)
        {
            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)
                                 .Set("Description", objClass.Description)
                     
                                .Set("Image", objClass.Image)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static ArrayList getSchoolsByUserId(string Id)
        {
            ArrayList Schools = new ArrayList();

            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");

            SchoolBO objClass = new SchoolBO();
            foreach (School item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(Id))))
            {
                Schools.Add(item.Name);


            }
            return Schools;

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteSchool(string Id)
          {
              MongoCollection<School> objCollection = db.GetCollection<School>("c_School");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<School> getAllSchoolList()
        {
            List<School> lst = new List<School>();

            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");

            foreach (School item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static SchoolBO getSchoolBySchoolId(string Id)
        {
            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");

            SchoolBO objClass = new SchoolBO();
            foreach (School item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Name = item.Name;
                objClass.Image = item.Image;
                break;
            }
            return objClass;
           
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<School> getSchoolTop5(string Id)
        {
            List<School> lst = new List<School>();

            MongoCollection<School> objCollection = db.GetCollection<School>("c_School");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                         Query.EQ("UserId", ObjectId.Parse(Id)));
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

#region School
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class School
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

}
#endregion