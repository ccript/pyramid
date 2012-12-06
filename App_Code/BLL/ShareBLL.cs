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

    public class ShareBLL
    {
        public ShareBLL()
        {
        }

        public static void insertShare(ShareBO objShare)
        {
            ShareDAL.insertShare(objShare);
        }


        public static void deleteShare(string ShareId)
        {
            ShareDAL.deleteShare(ShareId);
        }

        public static void updateShare(ShareBO objShare)
        {
            ShareDAL.updateShare(objShare);
        }

        public static void unShare(ShareBO objClass)
        {

            ShareDAL.unShare(objClass);
        }

        public static bool youShare(ShareBO objClass)
        {
            return ShareDAL.youShare(objClass);

        }

        public static List<Share> getAllShareList()
        {
            return ShareDAL.getAllShareList();
        }

        public static ShareBO getShareByShareId(string ShareId)
        {
            return ShareDAL.getShareByShareId(ShareId);
        }
        
        public static List<Share> getShareTop(int Type, string AtId)
        {
            return ShareDAL.getShareTop(Type, AtId);
        }
        
        public static long countPost(string Atid, int type)
        {

            return ShareDAL.countPost(Atid, type);
        }
        public static List<Share> getShareHistory(int Type, string AtId)
        {
            return ShareDAL.getShareHistory(Type, AtId);
        }
    }

}