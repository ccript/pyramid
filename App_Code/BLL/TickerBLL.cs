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
    public class TickerBLL
    {
        public TickerBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertTicker(TickerBO objTicker)
        {
           

                return TickerDAL.insertTicker(objTicker);
       
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteTicker(string TickerId)
        {
            TickerDAL.deleteTicker(TickerId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateTicker(TickerBO objTicker)
        {
            TickerDAL.updateTicker(objTicker);
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getAllTickerList()
        {
            return TickerDAL.getAllTickerList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static TickerBO getTickerByTickerId(string TickerId)
        {
            return TickerDAL.getTickerByTickerId(TickerId);
        }
        public static void updateLiteral(string Tickerid, string postval,string embedval)
        {
            TickerDAL.updateLiteral(Tickerid, postval, embedval);
        }

        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getTickerByUserId(string UserId,int top)
        {
            return TickerDAL.getTickerByUserId(UserId,top);
        }

        public static List<Ticker> getSeeFriendShipTicker(string FUserId, string UserId, int top)
        {
            return TickerDAL.getSeeFriendShipTicker(FUserId, UserId, top);

        }

        public static List<Ticker> getTickerByUserIdAndFriendID(string UserId, string FriendID, int top)
        {
            return TickerDAL.getTickerByUserIdAndFriendID(UserId, FriendID, top);
        }

        public static void InsertBulkTickerData(WallBO objWall, string status)
        {            
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(SessionClass.getUserId());

            objWall.FirstName = objUser.FirstName;
            objWall.LastName = objUser.LastName;
            objWall.Post = status;
            objWall.EmbedPost = SessionClass.getEmbedPost();
            objWall.AddedDate = DateTime.Now;
            objWall.Type = SessionClass.getPostType();
            string wid = WallBLL.insertWall(objWall);

            List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(SessionClass.getUserId(), Global.CONFIRMED);
            //get the education,hometown and employer of people in list
            foreach (UserFriendsBO Useritem in listtag)
            {
                TickerBO objTicker = new TickerBO();
                objTicker.PostedByUserId = objWall.PostedByUserId;
                objTicker.TickerOwnerUserId = Useritem.FriendUserId;
                objTicker.FirstName = objWall.FirstName;
                objTicker.LastName = objWall.LastName;
                objTicker.Post = objWall.Post;
                objTicker.Title = Global.SHARE_A_POST;
                objTicker.AddedDate = DateTime.UtcNow;
                objTicker.Type = objWall.Type;
                objTicker.EmbedPost = objWall.EmbedPost;
                objTicker.WallId = wid;
                TickerBLL.insertTicker(objTicker);

            }
            TickerBO objTickerUserTag = new TickerBO();

            objTickerUserTag.PostedByUserId = SessionClass.getUserId();
            objTickerUserTag.TickerOwnerUserId = SessionClass.getUserId();
            objTickerUserTag.FirstName = objUser.FirstName;
            objTickerUserTag.LastName = objUser.LastName;
            objTickerUserTag.Post = objWall.Post;
            objTickerUserTag.Title = Global.SHARE_A_POST;
            objTickerUserTag.AddedDate = DateTime.UtcNow;
            objTickerUserTag.Type = objWall.Type;
            objTickerUserTag.EmbedPost = objWall.EmbedPost;
            objTickerUserTag.WallId = wid;
            TickerBLL.insertTicker(objTickerUserTag);

        }
    }
     
}