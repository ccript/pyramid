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
/// Summary description for ShareBLL
/// </summary>

namespace BuinessLayer
{

    public class ShareBLL
    {
        public ShareBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertShare(ShareBO objShare)
        {


            ShareDAL.insertShare(objShare);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteShare(string ShareId)
        {
            ShareDAL.deleteShare(ShareId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
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
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Share> getAllShareList()
        {
            return ShareDAL.getAllShareList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ShareBO getShareByShareId(string ShareId)
        {
            return ShareDAL.getShareByShareId(ShareId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Share> getShareTop(int Type, string AtId)
        {
            return ShareDAL.getShareTop(Type, AtId);
        }
        // @@@@@@@@@@@@@@@@@@@@ by Nabeel
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