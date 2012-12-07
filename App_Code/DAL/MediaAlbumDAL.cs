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
    public class MediaAlbumDAL : BaseClass
    {
        
        public MediaAlbumDAL()
        {
        }
 

        public static string insertMediaAlbum(MediaAlbumBO objClass)
        {
                 MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_MediaAlbum");

                
                     BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "CoverPictureId" , ObjectId.Parse(objClass.CoverPictureId) },
                        { "Name" , objClass.Name},
                        { "Description" , objClass.Description },
                        { "Type" , objClass.Type },
                      { "isFollow" , objClass.isFollow },
                        };

                     var rt=objCollection.Insert(doc);

                     return doc["_id"].ToString();


           
    
        }


        public static string insertDefaultAlbum(MediaAlbumBO objClass)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_MediaAlbum");
              var query = Query.And(
                    Query.EQ("Name", objClass.Name),
                     Query.EQ("UserId", ObjectId.Parse(objClass.UserId)));
            var result = objCollection.Find(query);
            if (!result.Any())
            {

                BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "CoverPictureId" , ObjectId.Parse("0000000000000b0000000900") },
                        { "Name" , objClass.Name},
                        { "Description" , "" },
                         { "Type" , objClass.Type },
                           { "isFollow" , objClass.isFollow }, 
                        };

                var rt = objCollection.Insert(doc);

                return doc["_id"].ToString();
            }
            else
            {
                string pid = "";
                MongoCollection<MediaAlbum> objCollection2 = db.GetCollection<MediaAlbum>("c_MediaAlbum");
                foreach (MediaAlbum item in objCollection2.Find(query))
                {
                    pid= item._id.ToString();

                }
                return pid;
            }



        }

        public static void updateMediaAlbum(MediaAlbumBO objClass)
        {

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                 .Set("CoverPictureId", ObjectId.Parse(objClass.CoverPictureId))
                                .Set("Name", objClass.Name)
                                .Set("Description", objClass.Description)
                               .Set("Type", objClass.Type)
                             .Set("isFollow", objClass.isFollow)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }


        public static void EditAlbum(MediaAlbumBO objClass)
        {

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                .Set("Name", objClass.Name)
                                .Set("Description", objClass.Description)
                          


                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }
        public static void UpdateCoverPicture(MediaAlbumBO objClass)
        {

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                .Set("CoverPictureId", ObjectId.Parse(objClass.CoverPictureId))



                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public static void EditFollowAlbum(MediaAlbumBO objClass)
        {

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update
                                .Set("isFollow", objClass.isFollow)
                             



                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public static void deleteMediaAlbum(string Id)
          {
              MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }

        public static List<MediaAlbum> getAllMediaAlbumList()
        {
            List<MediaAlbum> lst = new List<MediaAlbum>();

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            foreach (MediaAlbum item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }

        public static MediaAlbumBO getMediaAlbumByMediaAlbumId(string Id)
        {
            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            MediaAlbumBO objClass = new MediaAlbumBO();
            foreach (MediaAlbum item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.CoverPictureId = item.CoverPictureId.ToString();
                objClass.Name = item.Name;
                objClass.Description= item.Description;
                objClass.Type = item.Type;
                objClass.isFollow = item.isFollow;
                break;
            }
            return objClass;
           
        }

        public static List<MediaAlbum> getMediaAlbumTop6( string UserId,int Type)
        {
            List<MediaAlbum> lst = new List<MediaAlbum>();

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.And(
                   Query.EQ("Type", Type), Query.EQ("UserId", ObjectId.Parse(UserId)));
            var cursor = objCollection.Find(query);
            cursor.Limit = 6;
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        public static List<MediaAlbum> getAllMediaAlbum(string UserId, int Type)
        {
            List<MediaAlbum> lst = new List<MediaAlbum>();

            MongoCollection<MediaAlbum> objCollection = db.GetCollection<MediaAlbum>("c_MediaAlbum");

            var query = Query.And(
                   Query.EQ("Type", Type), Query.EQ("UserId", ObjectId.Parse(UserId)));
     
            foreach (MediaAlbum item in objCollection.Find(query))
            {
                lst.Add(item);

            }
            return lst;
        }

    }
}

#region MediaAlbum
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class MediaAlbum
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId CoverPictureId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Type { get; set; }
    public bool isFollow { get; set; }


}
#endregion