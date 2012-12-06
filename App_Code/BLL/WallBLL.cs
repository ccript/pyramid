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
     public class WallBLL
    {
        public WallBLL()
        {
        }
 
        public static string insertWall(WallBO objWall)
        {
            return WallDAL.insertWall(objWall);
        }

        public static void deleteWall(string WallId)
        {
            WallDAL.deleteWall(WallId);
        }

        public static void updateWall(WallBO objWall)
        {
            WallDAL.updateWall(objWall);
        }

        
        public static List<Wall> getAllWallList()
        {
            return WallDAL.getAllWallList();
        }
        
        public static WallBO getWallByWallId(string WallId)
        {
            return WallDAL.getWallByWallId(WallId);
        }
        public static void updateLiteral(string wallid, string postval, string embedval)
        {
            WallDAL.updateLiteral(wallid, postval, embedval);
        }

        public static List<Wall> getWallByUserId(string UserId, int top)
        {
            return WallDAL.getWallByUserId(UserId, top);
        }

        public static List<Wall> getSeeFriendShipWall(string FUserId, string UserId, int top)
        {
            return WallDAL.getSeeFriendShipWall(FUserId, UserId, top);

        }

        public static List<Wall> getWallByUserIdAndFriendID(string UserId, string FriendID, int top)
        {
            return WallDAL.getWallByUserIdAndFriendID(UserId, FriendID, top);
        }

        public static List<Newsfeed> getNewsfeedByUserId(string UserId, int top, int type)
        {
            List<Newsfeed> lstNewsfeed = new List<Newsfeed>();
            List<Newsfeed> lstWallfeed = new List<Newsfeed>();
            List<Newsfeed> lstNewsfeedSorted = new List<Newsfeed>();

            lstNewsfeed = WallDAL.getNewsfeedByUserId(UserId, top);
            if (type == 1)
            {
                lstNewsfeed = RankNewsFeed(lstNewsfeed);
            }


            lstWallfeed = WallDAL.getWallFeedByUserId(UserId, top);
            lstNewsfeed.AddRange(lstWallfeed);

            if (type == 1)//top stories
            {
                var result = from em in lstNewsfeed
                             orderby em.AddedDate descending
                             orderby em.PostRank descending
                             select em;
                foreach (var em in result)
                {

                    lstNewsfeedSorted.Add(em);
                }
            }
            else
            {
                var result = from em in lstNewsfeed
                             orderby em.AddedDate descending

                             select em;
                foreach (var em in result)
                {

                    lstNewsfeedSorted.Add(em);
                }

            }

            return lstNewsfeedSorted;
        }
        public static List<Newsfeed> RankNewsFeed(List<Newsfeed> lst)
        {
            foreach (var post in lst)
            {
                post.AffinityScore = 0;
                post.PostWeight = 0;

                if (post.Type == Global.PHOTO || post.Type == Global.TAG_PHOTO)
                {
                    post.PostWeight += Global.WEIGHT_PHOTO;
                }
                else
                    if (post.Type == Global.VIDEO || post.Type == Global.TAG_VIDEO)
                    {
                        post.PostWeight += Global.WEIGHT_VIDEO;
                    }
                    else
                        if (post.Type == Global.TAG_VIDEOLINK)
                        {
                            post.PostWeight += Global.WEIGHT_VIDEOLINK;
                        }
                        else
                            if (post.Type == Global.TEXT_POST)
                            {
                                post.PostWeight += Global.WEIGHT_TEXT;

                            }
                long likesCount = LikesDAL.countPost(post._id.ToString(), Global.WALL);

                long sharesCount = ShareDAL.countPost(post._id.ToString(), Global.WALL);
                long commentsCount = CommentsDAL.countComment(post._id.ToString(), Global.WALL);

                post.PostWeight += (int)likesCount;

                post.PostWeight += (int)sharesCount;
                post.PostWeight += (int)commentsCount;

                post.PostRank = post.PostWeight + post.AffinityScore;


            }
            return lst;
        }

        public static bool setPostStatus(string UserId, string PostedByUserId, string PostId, int Status)
        {
            return WallDAL.setPostStatus(UserId, PostedByUserId, PostId, Status);

        }
        public static bool setPostUpdatesType(string UserId, string FriendId,int Type)
        {
            return WallDAL.setPostUpdatesType(UserId, FriendId,Type);

        }
        public static int getUpdatesType(string userId,string FriendId)
        {
            return WallDAL.getUpdatesType(userId,FriendId);

        }
        public static bool Unsubscribe(string userid, string friendid,string type)
        {
            return WallDAL.Unsubscribe(userid, friendid, type);

        }
        public static SubscriptionsBO getSubscriptions(string UserId, string FriendId)
        {
            return WallDAL.getSubscriptions(UserId,FriendId);
        }
        public static void saveSubscriptions(string UserId, string FriendId, SubscriptionsBO sbo)
        {
            WallDAL.saveSubscriptions(UserId, FriendId,sbo);
        }
    }
     
}