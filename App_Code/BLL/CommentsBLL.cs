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
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class CommentsBLL
    {
        public CommentsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertComments(CommentsBO objComments)
        {
            if (!objComments.MyComments.Equals(""))

                return CommentsDAL.insertComments(objComments);
            else
                return null;
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteComments(string CommentsId)
        {
            CommentsDAL.deleteComments(CommentsId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateComments(CommentsBO objComments)
        {
            CommentsDAL.updateComments(objComments);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Comments> getAllCommentsList()
        {
            return CommentsDAL.getAllCommentsList();
        }
        public static List<Comments> getCommentsList(int Type, string AtId)
        {
            return CommentsDAL.getCommentsList( Type,AtId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static CommentsBO getCommentsByCommentsId(string CommentsId)
        {
            return CommentsDAL.getCommentsByCommentsId(CommentsId);
        }
        public static List<string> getCommentsUserIdbyAtId(int Type, string AtId)
        {
            return CommentsDAL.getCommentsUserIdbyAtId(Type, AtId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Comments> getCommentsTop(int Type, string AtId, int top)
        {
            return CommentsDAL.getCommentsTop(Type, AtId, top);
        }

        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
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