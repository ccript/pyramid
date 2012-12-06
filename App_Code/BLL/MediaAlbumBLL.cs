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
    public class MediaAlbumBLL
    {
        public MediaAlbumBLL()
        {
        }
        
        public static string insertMediaAlbum(MediaAlbumBO objMediaAlbum)
        {
            return MediaAlbumDAL.insertMediaAlbum(objMediaAlbum);
        }

        public static string insertDefaultAlbum(MediaAlbumBO objClass)
        {
            return MediaAlbumDAL.insertDefaultAlbum(objClass);
        }

        public static void deleteMediaAlbum(string MediaAlbumId)
        {
            MediaAlbumDAL.deleteMediaAlbum(MediaAlbumId);
        }
        
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
        
        public static List<MediaAlbum> getAllMediaAlbumList()
        {
            return MediaAlbumDAL.getAllMediaAlbumList();
        }
        
        public static MediaAlbumBO getMediaAlbumByMediaAlbumId(string MediaAlbumId)
        {
            return MediaAlbumDAL.getMediaAlbumByMediaAlbumId(MediaAlbumId);
        }

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