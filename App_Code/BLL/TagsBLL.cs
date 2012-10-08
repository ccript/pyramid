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
    public class TagsBLL
    {
        public TagsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertTags(TagsBO objTags)
        {
           

                return TagsDAL.insertTags(objTags);
          
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteTags(string TagsId)
        {
            TagsDAL.deleteTags(TagsId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateTags(TagsBO objTags)
        {
            TagsDAL.updateTags(objTags);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Tags> getAllTagsList()
        {
            return TagsDAL.getAllTagsList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static TagsBO getTagsByTagsId(string TagsId)
        {
            return TagsDAL.getTagsByTagsId(TagsId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Tags> getTagsTop5(int Type, string AtId)
        {
            return TagsDAL.getTagsTop5( Type,  AtId);
        }

        public static List<Tags> getTagsList(int Type, string AtId)
        {
              return TagsDAL.getTagsList( Type,  AtId);
        }

        public static List<string> getTagsFriendId(int Type, string AtId)
        {
            return TagsDAL.getTagsFriendId(Type, AtId);
        }

        public static List<Tags> getTagsListbyFriendsId(int Type, string FriendId)
        {
            return TagsDAL.getTagsListbyFriendsId(Type,FriendId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Tags> getTagsByUserId(string UserId)
        {
            return TagsDAL.getTagsByUserId(UserId);
        }
    }
     
}