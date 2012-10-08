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
    public class MediaAlbumBLL
    {
        public MediaAlbumBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertMediaAlbum(MediaAlbumBO objMediaAlbum)
        {
           

                return MediaAlbumDAL.insertMediaAlbum(objMediaAlbum);
     
        }

        public static string insertDefaultAlbum(MediaAlbumBO objClass)
        {

            return MediaAlbumDAL.insertDefaultAlbum(objClass);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteMediaAlbum(string MediaAlbumId)
        {
            MediaAlbumDAL.deleteMediaAlbum(MediaAlbumId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateMediaAlbum(MediaAlbumBO objMediaAlbum)
        {
            MediaAlbumDAL.updateMediaAlbum(objMediaAlbum);
        }
        public static void EditAlbum(MediaAlbumBO objMediaAlbum)
        {
            MediaAlbumDAL.EditAlbum(objMediaAlbum);
        }
        public static void EditFollowAlbum(MediaAlbumBO objClass)
        {
            MediaAlbumDAL.EditFollowAlbum(objClass);
        }
        public static void UpdateCoverPicture(MediaAlbumBO objClass)
        {

            MediaAlbumDAL.UpdateCoverPicture(objClass);

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<MediaAlbum> getAllMediaAlbumList()
        {
            return MediaAlbumDAL.getAllMediaAlbumList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static MediaAlbumBO getMediaAlbumByMediaAlbumId(string MediaAlbumId)
        {
            return MediaAlbumDAL.getMediaAlbumByMediaAlbumId(MediaAlbumId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<MediaAlbum> getMediaAlbumTop6(string UserId, int Type)
        {
            return MediaAlbumDAL.getMediaAlbumTop6(UserId, Type);
        }
        public static List<MediaAlbum> getAllMediaAlbum(string UserId, int Type)
        {
            return MediaAlbumDAL.getAllMediaAlbum(UserId, Type);
        }
    }
     
}