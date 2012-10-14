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
/// Summary description for StrategyConcreteVideoComment
/// </summary>
/// 
namespace DataLayer
{
    public class StrategyConcreteVideoComment : BaseClass, StrategyInterfacecomment
    {
        public StrategyConcreteVideoComment()
        {
        }

        public string insertComments(CommentsBO objClass)
        {

            MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>("c_Comments");

            BsonDocument doc = new BsonDocument {
                      { "UserId" , ObjectId.Parse(objClass.UserId) },
                        { "AtId" ,  ObjectId.Parse(objClass.AtId) },
                        { "MyComments" , objClass.MyComments },
                        { "Type", objClass.Type },
                        { "FirstName", objClass.FirstName },
                        { "LastName", objClass.LastName },
                             { "AddedDate", DateTime.Now },
                        };

            var rt = objCollection.Insert(doc);

            return doc["_id"].ToString();

        }

        public void updateComments(CommentsBO objClass)
        {

            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");

            var query = Query.EQ("_id", ObjectId.Parse(objClass.Id));
            var sortBy = SortBy.Descending("_id");
            var update = Update.Set("UserId", ObjectId.Parse(objClass.UserId))
                                .Set("AtId", ObjectId.Parse(objClass.AtId))
                                 .Set("MyComments", objClass.MyComments)
                                .Set("Type", objClass.Type)
                                .Set("FirstName", objClass.FirstName)
                                .Set("LastName", objClass.LastName)

                                ;
            var result = objCollection.FindAndModify(query, sortBy, update, true);

        }

        public List<Comments> getCommentsList(int Type, string AtId)
        {
            List<Comments> lst = new List<Comments>();

            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            foreach (Comments item in objCollection.Find(query))
            {
                lst.Add(item);

            }
            return lst;
        }

    }
}