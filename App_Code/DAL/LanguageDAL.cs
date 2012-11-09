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
/// Summary description for LanguageDAL
/// </summary>
/// 

namespace DataLayer
{
    public class LanguageDAL : BaseClass, TemplateInfoDAL
    {

        public LanguageDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
    
        public void insert(TemplateBO objClass)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Language");

            var query = Query.And(
                    Query.EQ("Name", objClass.Name),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Name" , objClass.Name },
  
        
                        };

                var rt = objCollection.Insert(doc);



            }
        }

        ///////////////////////////////////////////////////////////////
        //                       UPDATE
        //////////////////////////////////////////////////////////////
        public void update(TemplateBO objClass)
        {

            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public void delete(string Id)
        {
            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
            SortBy.Ascending("_id"));  
        }

        public List<Employer> SelectList()
        {
            throw new NotImplementedException();
        }

        public List<Language> SelectListLanguages()
        {
            List<Language> lst = new List<Language>();
            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            foreach (Language item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public List<Language> SelectLanguageByid(string UserId)
        {
            List<Language> lst = new List<Language>();

            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            var query = Query.EQ("UserId", ObjectId.Parse(UserId));
            var cursor = objCollection.Find(query);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        public EmployerBO SelectEmployerByUserId(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Employer> SelectEmployerTop5(string Id)
        {
            throw new NotImplementedException();
        }

/////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static void insertLanguage(LanguageBO objClass)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Language");

            var query = Query.And(
                    Query.EQ("Name", objClass.Name),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Name" , objClass.Name },
  
        
                        };

                var rt = objCollection.Insert(doc);

               

            }
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateLanguage(LanguageBO objClass)
        {

            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)
              

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteLanguage(string Id)
          {
              MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Language> getAllLanguageList()
        {
            List<Language> lst = new List<Language>();

            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            foreach (Language item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static LanguageBO getLanguageByLanguageId(string Id)
        {
            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            LanguageBO objClass = new LanguageBO();
            foreach (Language item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.Name = item.Name;
                break;
            }
            return objClass;
           
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Language> getLanguage(string UserId)
        {
            List<Language> lst = new List<Language>();

            MongoCollection<Language> objCollection = db.GetCollection<Language>("c_Language");

            var query =  Query.EQ("UserId", ObjectId.Parse(UserId));
            var cursor = objCollection.Find(query);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }




    }
}

#region Language
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Language
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Name { get; set; }

}
#endregion