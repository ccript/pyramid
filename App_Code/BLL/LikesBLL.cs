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

    public class LikesBLL
    {
        public LikesBLL()
        {
        }


        public static void insertLikes(LikesBO objLikes)
        {
              LikesDAL.insertLikes(objLikes);
        }

        public static void deleteLikes(string LikesId)
        {
            LikesDAL.deleteLikes(LikesId);
        }

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

        public static List<Likes> getAllLikesList()
        {
            return LikesDAL.getAllLikesList();
        }
        
        public static LikesBO getLikesByLikesId(string LikesId)
        {
            return LikesDAL.getLikesByLikesId(LikesId);
        }

        public static List<Likes> getLikesTop(int Type, string AtId)
        {
            return LikesDAL.getLikesTop( Type,  AtId);
        }

        public static long countPost(string Atid, int type)
        {
            return LikesDAL.countPost(Atid, type);
        }
    }
     
}