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
    public class LikesBLL
    {
        public LikesBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertLikes(LikesBO objLikes)
        {
         

                 LikesDAL.insertLikes(objLikes);
        
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteLikes(string LikesId)
        {
            LikesDAL.deleteLikes(LikesId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateLikes(LikesBO objLikes)
        {
            LikesDAL.updateLikes(objLikes);
        }

        public static void unLikes(LikesBO objClass)
        {

            LikesDAL.unLikes(objClass);
        }

        public static bool youLikes(LikesBO objClass)
        {
            return LikesDAL.youLikes(objClass);

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Likes> getAllLikesList()
        {
            return LikesDAL.getAllLikesList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static LikesBO getLikesByLikesId(string LikesId)
        {
            return LikesDAL.getLikesByLikesId(LikesId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Likes> getLikesTop(int Type, string AtId)
        {
            return LikesDAL.getLikesTop( Type,  AtId);
        }
        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
        public static long countPost(string Atid, int type)
        {

            return LikesDAL.countPost(Atid, type);
        }
    }
     
}