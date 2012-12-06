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
/// Summary description for CommentsDAL
/// </summary>
/// 

namespace DataLayer
{
    public class CommentsDAL : BaseClass
    {
        
        public CommentsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        public static string insertComments(CommentsBO objClass)
        {

            if (objClass.Type == 1)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcretePhotoComment());
                return commentobject.insertComments(objClass);
            }
            else if (objClass.Type == 2)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteVideoComment());
                return commentobject.insertComments(objClass);
            }
            else
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteOtherComment());
                return commentobject.insertComments(objClass);
            }

    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateComments(CommentsBO objClass)
        {

            if (objClass.Type == 1)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcretePhotoComment());
                commentobject.updateComments(objClass);
            }
            else if (objClass.Type == 2)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteVideoComment());
                commentobject.updateComments(objClass);
            }
            else
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteOtherComment());
                commentobject.updateComments(objClass);
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteComments(string Id)
          {
              MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");
              var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Id)),
                  SortBy.Ascending("_id"));  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Comments> getAllCommentsList()
        {
            List<Comments> lst = new List<Comments>();

            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");

            foreach (Comments item in objCollection.FindAll())
            {
                lst.Add(item);

            }
            return lst;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<Comments> getCommentsList(int Type, string AtId)
        {
            if (Type == 1)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcretePhotoComment());
                return commentobject.getCommentsList(Type, AtId);
            }
            else if (Type == 2)
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteVideoComment());
                return commentobject.getCommentsList(Type, AtId);
            }
            else
            {
                StrategyContextComment commentobject = new StrategyContextComment(new StrategyConcreteOtherComment());
                return commentobject.getCommentsList(Type, AtId);
            }

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static List<string> getCommentsUserIdbyAtId(int Type, string AtId)
        {
            List<string> lst = new List<string>();
  
            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");
            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            foreach (Comments item in objCollection.Find(query))
            {

                lst.Add(item.UserId.ToString());



            }




            return lst.Distinct().ToList();

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static CommentsBO getCommentsByCommentsId(string Id)
        {
            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");

            CommentsBO objClass = new CommentsBO();
            foreach (Comments item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(Id))))
            {
                objClass.Id = item._id.ToString();
                objClass.UserId = item.UserId.ToString();
                objClass.AtId= item.AtId.ToString();
                objClass.Type = item.Type;
                objClass.MyComments = item.MyComments;
                objClass.FirstName = item.FirstName;
                objClass.LastName = item.LastName;
                break;
            }
            return objClass;
           
        }

        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
        public static long countComment(string AtId, int Type)
        {
            List<CommentsBO> lst = new List<CommentsBO>();
            long count = 0;
            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");
            var query = Query.And(
                   Query.EQ("Type", Type), //Query.Or(
                   Query.EQ("AtId", ObjectId.Parse(AtId))//, Query.EQ("UserId", UserId))
                  );
            var result = objCollection.Find(query);
            count += result.Count();

            return count;

        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Comments> getCommentsTop(int Type, string AtId, int top)
        {
            List<Comments> lst = new List<Comments>();

            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            var cursor = objCollection.Find(query);
            cursor.Limit = top;
            var sortBy = SortBy.Descending("AddedDate");
            cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Comments> getComments(int Type, string AtId)
        {
            List<Comments> lst = new List<Comments>();

            MongoCollection<Comments> objCollection = db.GetCollection<Comments>("c_Comments");
            objCollection.EnsureIndex("Type");

            var query = Query.And(
                        Query.EQ("Type", Type),
                         Query.EQ("AtId", ObjectId.Parse(AtId)));
            var cursor = objCollection.Find(query);
           // cursor.Limit = 5;
            var sortBy = SortBy.Descending("AddedDate");
            cursor.SetSortOrder(sortBy);
            foreach (var item in cursor)
            {
                lst.Add(item);

            }


            return lst;
        }
       

    }
}

#region Comments
/// <summary>
/// Department represents a single item(record) stored in Employees collection.
/// </summary>
public class Comments
{
    public ObjectId _id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId AtId { get; set; }
    public string MyComments { get; set; }
    public int Type { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime AddedDate { get; set; }
}
#endregion

public class CommentsComparer : IEqualityComparer<Comments>
{
    public bool Equals(Comments x, Comments y)
    {
        return x._id == y._id;
    }

    public int GetHashCode(Comments obj)
    {
        return obj._id.GetHashCode();
    }
}