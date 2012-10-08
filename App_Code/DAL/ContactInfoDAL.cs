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
/// Summary description for ContactInfoDAL
/// </summary>
/// 

namespace DataLayer
{
    public class ContactInfoDAL : BaseClass
    {
        
        public ContactInfoDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static void insertContactInfo(ContactInfoBO objClass)
        {
            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_ContactInfo");

            var query = Query.And(
                    Query.EQ("Type", objClass.Type),
                    Query.EQ("Name", objClass.Name),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {
                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "Name" , objClass.Name },
                        { "Type", objClass.Type },
        
                        };

                var rt = objCollection.Insert(doc);

              

            }
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateContactInfo(ContactInfoBO objClass)
        {
            MongoCollection<ContactInfo> objCollection = db.GetCollection<ContactInfo>("c_ContactInfo");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("Name", objClass.Name)
                                .Set("Type", objClass.Type)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);


        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteContactInfo(string Id)
          {
              MongoCollection<ContactInfo> objCollection = db.GetCollection<ContactInfo>("c_ContactInfo");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));   
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<ContactInfo> getAllContactInfoList()
        {
            List<ContactInfo> lst = new List<ContactInfo>();

            MongoCollection<ContactInfo> objCollection = db.GetCollection<ContactInfo>("c_ContactInfo");

            foreach (ContactInfo item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ContactInfoBO getContactInfoByContactInfoId(string UserId)
        {
            MongoCollection<ContactInfo> objCollection = db.GetCollection<ContactInfo>("c_ContactInfo");

            ContactInfoBO objClass = new ContactInfoBO();
            foreach (ContactInfo item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(UserId))))
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
        public static List<ContactInfo> getContactInfo(string Type, string UserId)
        {
            List<ContactInfo> lst = new List<ContactInfo>();

            MongoCollection<ContactInfo> objCollection = db.GetCollection<ContactInfo>("c_ContactInfo");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("UserId", ObjectId.Parse(UserId)));
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

#region ContactInfo
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class ContactInfo
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

}
#endregion