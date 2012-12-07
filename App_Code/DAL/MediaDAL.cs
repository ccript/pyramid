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

namespace DataLayer
{
    public class MediaDAL : BaseClass
    {
        
        public MediaDAL()
        {
        }
 
        public static string insertMedia(MediaBO objClass)
        {
          


                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Media");

                
                     BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AlbumId" , ObjectId.Parse(objClass.AlbumId) },
                         { "Name" , objClass.Name},
                        { "Caption" , objClass.Caption},
                        { "Description" , objClass.Description },
                        { "AddedDate", objClass.AddedDate },
                        { "Location",objClass.Location },
                        { "Type",objClass.Type},
                         { "isFollow",objClass.isFollow},
                        };

                     var rt=objCollection.Insert(doc);

                     return doc["_id"].ToString();


           
    
        }
 
        public static void updateMedia(MediaBO objClass)
        {

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                 .Set("AlbumId", ObjectId.Parse(objClass.AlbumId))
                                 .Set("Name", objClass.Name)
                                .Set("Caption", objClass.Caption)
                                 .Set("Location", objClass.Location)
                                .Set("Description", objClass.Description)
                                .Set("AddedDate", objClass.AddedDate)
                                 .Set("Type", objClass.Type)
                                  .Set("isFollow", objClass.isFollow)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static void updateEditVideoMedia(MediaBO objClass)
        {

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                .Set("Caption", objClass.Caption)
                                 .Set("Location", objClass.Location)
                                 .Set("Name", objClass.Name)
                                   .Set("Description", objClass.Description)
                                 .Set("AddedDate", objClass.AddedDate)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static void updateEditMedia(MediaBO objClass)
        {

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                .Set("Caption", objClass.Caption)
                                 .Set("Location", objClass.Location)
                  .Set("AddedDate", objClass.AddedDate)
                                

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static void updateFollow(MediaBO objClass)
        {

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("isFollow", objClass.isFollow)


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public static void deleteMedia(string Id)
          {
              MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }

        public static List<Media> getAllMediaList()
        {
            List<Media> lst = new List<Media>();

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            foreach (Media item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }

        public static MediaBO getMediaByMediaId(string Id)
        {
            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");

            MediaBO objClass = new MediaBO();
            foreach (Media item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.AlbumId = item.AlbumId.ToString();
                objClass.Name = item.Name;
                objClass.Caption = item.Caption;
                objClass.Location = item.Location;
                objClass.Description= item.Description;
                objClass.AddedDate = item.AddedDate;
                objClass.Type = item.Type;
                objClass.isFollow = item.isFollow;
                break;
            }
            return objClass;
           
        }


        public static List<Media> getMediaByAlbum(string AlbumId)
        {
            List<Media> lst = new List<Media>();

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");


            var query = Query.EQ("AlbumId", ObjectId.Parse(AlbumId));
            var cursor = objCollection.Find(query);
            
            var sortBy = SortBy.Descending("_id");
            cursor.SetSortOrder(sortBy);
            foreach (Media item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        public static List<Media> getMediaTop5( string UserId,int Type,string AlbumId)
        {
            List<Media> lst = new List<Media>();

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");


            var query = Query.And(
                    Query.EQ("Type", Type), Query.EQ("UserId", ObjectId.Parse(UserId)), Query.EQ("AlbumId", ObjectId.Parse(AlbumId)));
            var cursor = objCollection.Find(query);
           
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        public static List<Media> getMediaTop5(string UserId, int Type)
        {
            List<Media> lst = new List<Media>();

            MongoCollection<Media> objCollection = db.GetCollection<Media>("c_Media");


            var query = Query.And(
                    Query.EQ("Type", Type), Query.EQ("UserId", ObjectId.Parse(UserId)));
            var cursor = objCollection.Find(query);

            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

    }
}

#region Media
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Media
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId AlbumId { get; set; }
    public string Name { get; set; }
    public string Caption { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime AddedDate { get; set; }
    public int Type { get; set; }
    public bool isFollow { get; set; }

}
#endregion