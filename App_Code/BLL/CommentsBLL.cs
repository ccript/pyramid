using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

namespace BuinessLayer
{
    public class CommentsBLL
    {
        public CommentsBLL()
        {
           
        }
  
        public static string insertComments(CommentsBO objComments)
        {
            if (!objComments.MyComments.Equals(""))

                return CommentsDAL.insertComments(objComments);
            else
                return null;
        }
        
        public static void deleteComments(string CommentsId)
        {
            CommentsDAL.deleteComments(CommentsId);
        }
        
        public static void updateComments(CommentsBO objComments)
        {
            CommentsDAL.updateComments(objComments);
        }
        
        public static List<Comments> getAllCommentsList()
        {
            return CommentsDAL.getAllCommentsList();
        }

        public static List<Comments> getCommentsList(int Type, string AtId)
        {
            return CommentsDAL.getCommentsList( Type,AtId);
        }
        
        public static CommentsBO getCommentsByCommentsId(string CommentsId)
        {
            return CommentsDAL.getCommentsByCommentsId(CommentsId);
        }

        public static List<string> getCommentsUserIdbyAtId(int Type, string AtId)
        {
            return CommentsDAL.getCommentsUserIdbyAtId(Type, AtId);
        }
        
        public static List<Comments> getCommentsTop(int Type, string AtId, int top)
        {
            return CommentsDAL.getCommentsTop(Type, AtId, top);
        }

        public static long countComments(string Atid, int type)
        {

            return CommentsDAL.countComment(Atid, type);
        }

        public static List<Comments> getComments(int Type, string AtId)
        {
            return CommentsDAL.getComments( Type,  AtId);
        }
    }
     
}