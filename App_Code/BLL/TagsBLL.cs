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

    public class TagsBLL
    {
        public TagsBLL()
        {
        }

        public static string insertTags(TagsBO objTags)
        {
           

                return TagsDAL.insertTags(objTags);
          
        }
        
        public static void deleteTags(string TagsId)
        {
            TagsDAL.deleteTags(TagsId);
        }
        
        public static void updateTags(TagsBO objTags)
        {
            TagsDAL.updateTags(objTags);
        }
        
        public static List<Tags> getAllTagsList()
        {
            return TagsDAL.getAllTagsList();
        }
        
        public static TagsBO getTagsByTagsId(string TagsId)
        {
            return TagsDAL.getTagsByTagsId(TagsId);
        }
        
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
        
        public static List<Tags> getTagsByUserId(string UserId)
        {
            return TagsDAL.getTagsByUserId(UserId);
        }
    }
     
}