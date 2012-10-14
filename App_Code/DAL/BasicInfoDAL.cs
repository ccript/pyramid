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
/// Summary description for BasicInfoDAL
/// </summary>
/// 

namespace DataLayer
{
    public class BasicInfoDAL : BaseClass
    {

        public BasicInfoDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertBasicInfo(BasicInfoBO objClass)
        {


            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_BasicInfo");


            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId)},
                       { "CurrentCity" , objClass.CurrentCity },
                       { "HomeTown", objClass.HomeTown },
                        { "Address", objClass.Address },
                        { "CityTown", objClass.CityTown },
                        { "ZipCode", objClass.ZipCode },
                        { "Neighbourhood", objClass.Neighbourhood },
                        { "RelationshipStatus" , objClass.RelationshipStatus }
                   
        
                        };

            var rt = objCollection.Insert(doc);

        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateBasicInfo(BasicInfoBO objClass)
        {

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("CurrentCity", objClass.CurrentCity)
                                 .Set("HomeTown", objClass.HomeTown)
                                 .Set("Address", objClass.Address)
                                .Set("CityTown", objClass.CityTown)
                                .Set("ZipCode", objClass.ZipCode)
                                 .Set("RelationshipStatus", objClass.RelationshipStatus)
                                .Set("Neighbourhood", objClass.Neighbourhood)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }



        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateBasicInfoPage(BasicInfoBO objClass)
        {
            MongoCollection<BsonDocument> objDocCollection = db.GetCollection<BsonDocument>("c_BasicInfo");

            var query = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
            var result = objDocCollection.Find(query);
            if (result.Any())
            {

                MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

                var equery = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
                var sortBy = SortBy.Descending("UserId");

                var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                               .Set("CurrentCity", objClass.CurrentCity)
                               .Set("HomeTown", objClass.HomeTown);

                var eresult = objCollection.FindAndModify(equery, sortBy, update, true);

            }
            else
            {

                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                       { "CurrentCity" , objClass.CurrentCity },
                       { "HomeTown", objClass.HomeTown },
                        { "Address", "" },
                        { "CityTown", "" },
                        { "ZipCode", "" },
                        { "Neighbourhood","" },
                        { "RelationshipStatus" ,"" }
                   
        
                        };

                var rt = objDocCollection.Insert(doc);

            }


        }

        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFamilyPage(BasicInfoBO objClass)
        {
            MongoCollection<BsonDocument> objDocCollection = db.GetCollection<BsonDocument>("c_BasicInfo");

            var query = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
            var result = objDocCollection.Find(query);
            if (result.Any())
            {

                MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

                var equery = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
                var sortBy = SortBy.Descending("UserId");
                var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                    .Set("RelationshipStatus", objClass.RelationshipStatus);
                var eresult = objCollection.FindAndModify(equery, sortBy, update, true);

            }
            else
            {

                BsonDocument doc = new BsonDocument {
                      { "UserId" ,ObjectId.Parse(objClass.UserId) },
                       { "CurrentCity" ,"" },
                       { "HomeTown", "" },
                        { "Address", "" },
                        { "CityTown", "" },
                        { "ZipCode", "" },
                        { "Neighbourhood","" },
                        { "RelationshipStatus" ,objClass.RelationshipStatus }
                   
        
                        };

                var rt = objDocCollection.Insert(doc);

            }

        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateContactInfoPage(BasicInfoBO objClass)
        {
            MongoCollection<BsonDocument> objDocCollection = db.GetCollection<BsonDocument>("c_BasicInfo");

            var query = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
            var result = objDocCollection.Find(query);
            if (result.Any())
            {

                MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

                var equery = Query.EQ("UserId", ObjectId.Parse(objClass.UserId));
                var sortBy = SortBy.Descending("UserId");
                var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))

                                 .Set("Address", objClass.Address)
                                .Set("CityTown", objClass.CityTown)
                                .Set("ZipCode", objClass.ZipCode)

                                .Set("Neighbourhood", objClass.Neighbourhood);
                var eresult = objCollection.FindAndModify(equery, sortBy, update, true);

            }
            else
            {

                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                       { "CurrentCity" , "" },
                           { "HomeTown", "" },
                         { "Address", objClass.Address },
                        { "CityTown", objClass.CityTown },
                        { "ZipCode", objClass.ZipCode },
                        { "Neighbourhood", objClass.Neighbourhood },
                        { "RelationshipStatus" , "" }
                   
        
                        };

                var rt = objDocCollection.Insert(doc);

            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteBasicInfo(string Id)
        {
            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");
            var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                SortBy.Ascending("_id"));
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<BasicInfo> getAllBasicInfoList()
        {
            List<BasicInfo> lst = new List<BasicInfo>();

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

            foreach (BasicInfo item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static BasicInfoBO getBasicInfoByUserId(string UserId)
        {

            MongoCollection<BasicInfo> objCollection = db.GetCollection<BasicInfo>("c_BasicInfo");

            BasicInfoBO objClass = new BasicInfoBO();
            foreach (BasicInfo item in objCollection.Find(Query.EQ("UserId", ObjectId.Parse(UserId))).SetLimit(1))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.CurrentCity = item.CurrentCity;
                objClass.HomeTown = item.HomeTown;
                objClass.Address = item.Address;
                objClass.CityTown = item.CityTown;
                objClass.ZipCode = item.ZipCode;
                objClass.Neighbourhood = item.Neighbourhood;
                objClass.RelationshipStatus = item.RelationshipStatus;
                break;
            }
            return objClass;
        }

    }




}

#region BasicInfo
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class BasicInfo
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public string CurrentCity { get; set; }
    public string HomeTown { get; set; }
    public string CityTown { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string Neighbourhood { get; set; }
    public string RelationshipStatus { get; set; }

}
#endregion