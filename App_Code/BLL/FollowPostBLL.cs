using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

/// <summary>
/// Summary description for FollowPostBLL
/// </summary>
/// 
 
namespace BuinessLayer
{
    public class FollowPostBLL
    {
        public FollowPostBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertFollowPost(FollowPostBO objFollowPost)
        {

            FollowPostDAL.insertFollowPost(objFollowPost);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteFollowPost(string FollowPostId)
        {
            FollowPostDAL.deleteFollowPost(FollowPostId);
        }

        public static void delUnFollowPost(string FollowPostId, string UserId)
        {
            FollowPostDAL.delUnFollowPost(FollowPostId,UserId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFollowPost(FollowPostBO objFollowPost)
        {
            FollowPostDAL.updateFollowPost(objFollowPost);
        }

        public static void unFollowPost(FollowPostBO objClass)
        {

            FollowPostDAL.unFollowPost(objClass);
        }

        public static bool youFollowPost(FollowPostBO objClass)
        {
            return FollowPostDAL.youFollowPost(objClass);

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<FollowPost> getAllFollowPostList()
        {
            return FollowPostDAL.getAllFollowPostList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static FollowPostBO getFollowPostByFollowPostId(string FollowPostId)
        {
            return FollowPostDAL.getFollowPostByFollowPostId(FollowPostId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<FollowPost> getFollowPostTop(int Type, string AtId)
        {
            return FollowPostDAL.getFollowPostTop(Type, AtId);
        }
        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
        public static long countPost(string Atid, int type)
        {

            return FollowPostDAL.countPost(Atid, type);
        }
    }
}