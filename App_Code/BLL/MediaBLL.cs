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
    public class MediaBLL
    {
        public MediaBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertMedia(MediaBO objMedia)
        {
           

                return MediaDAL.insertMedia(objMedia);
     
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteMedia(string MediaId)
        {
            MediaDAL.deleteMedia(MediaId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateMedia(MediaBO objMedia)
        {
            MediaDAL.updateMedia(objMedia);
        }
        public static void updateEditMedia(MediaBO objClass)
        {
            MediaDAL.updateEditMedia(objClass);
        }
        public static void updateEditVideoMedia(MediaBO objClass)
        {
            MediaDAL.updateEditVideoMedia(objClass);
        }
        public static void updateFollow(MediaBO objClass)
        {
            MediaDAL.updateFollow(objClass);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Media> getAllMediaList()
        {
            return MediaDAL.getAllMediaList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static MediaBO getMediaByMediaId(string MediaId)
        {
            return MediaDAL.getMediaByMediaId(MediaId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////

        public static List<Media> getMediaByAlbum(string AlbumId)
        {

            return MediaDAL.getMediaByAlbum(AlbumId);
        }
        public static List<Media> getMediaTop5( string UserId,int Type,string albumId)
        {
            return MediaDAL.getMediaTop5(UserId, Type, albumId);
        }

        public static List<Media> getMediaTop5(string UserId, int Type)
        {
            return MediaDAL.getMediaTop5(UserId, Type);
        }
    }
     
}