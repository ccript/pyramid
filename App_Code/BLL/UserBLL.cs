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
    public class UserBLL:notifier,subscriber
    {
        //////////////////////////////////////////////////////////////
        public static string insertUser(UserBO objUser)
        {
            return UserDAL.UserSignup(objUser);
        }

        public static string BLL_CheckUserEmail(string email)
        {
            return DataLayer.UserDAL.CheckUserEmail(email);
        }

        public static void UpdatePhoneNo(UserBO objUser)
        {
            DataLayer.UserDAL.UpdatePhoneNo(objUser);
        }

        public static string BLL_ConfirmUser(UserBO objUser)
        {
            return DataLayer.UserDAL.ConfirmUser(objUser);
        }


        public static void updateEmail(UserBO objUser)
        {
            DataLayer.UserDAL.updateEmail(objUser);
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static UserBO getUserByUserId(string UserId)
        {

            return UserDAL.getUserByUserId(UserId);
        }

        public static void updateBasicInfoPage(UserBO objUser)
        {

            UserDAL.updateBasicInfoPage(objUser);
        }

        public static List<User> getAllUserList()
        {

            return UserDAL.getAllUserList();
        }

        public static string BLL_UserId(string email)
        {
            return DataLayer.UserDAL.getUserID(email);
        }

        public static List<User> SearchUserList(string Name, bool top, string userid)
        {
            if(top)
            return UserDAL.SearchUserList(Name, userid).Take(3).ToList();
            else
                return UserDAL.SearchUserList(Name, userid);
        }

        public static List<User> SearchUserbyLocation(string Location, bool top)
        {
            if (top)
                return UserDAL.SearchUserbyLocation(Location).Take(3).ToList();
             else
                return  UserDAL.SearchUserbyLocation(Location);
        }

        public static List<User> SearchUserbyWorkSpace(string WorkSpace, bool top)
        {
            if (top)
                return UserDAL.SearchUserbyWorkSpace(WorkSpace).Take(3).ToList();
            else
            return UserDAL.SearchUserbyWorkSpace(WorkSpace);
        }

        public static List<User> SearchUserbyEducation(string Education, int year, bool top)
        {
            if (top)
                return UserDAL.SearchUserbyEducation(Education, year).Take(3).ToList();
            else
                return UserDAL.SearchUserbyEducation(Education, year);
        }


        public void update(string publisherId, string subscriberId, WallBO obj,string tagstatus,string twid)
        {
            TickerBO objTicker = new TickerBO();
            objTicker.PostedByUserId = publisherId;
            objTicker.TickerOwnerUserId = subscriberId;
            objTicker.FirstName = obj.FirstName;
            objTicker.LastName = obj.LastName;
            objTicker.Post = obj.Post;
            objTicker.Title = tagstatus;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = obj.Type;
            objTicker.EmbedPost = obj.EmbedPost;
            objTicker.WallId = twid;
            TickerBLL.insertTicker(objTicker);
        }

        public void registerSubscriber(string publisherId,string subscriberId)
        {
            SubscriptionBO subscriber_obj = new SubscriptionBO();
            subscriber_obj.PublisherUserId = publisherId;
            subscriber_obj.SubscriberUserId = subscriberId;
            SubscriptionBLL.insertSubscription(subscriber_obj);
        }

        public void removeSubscriber(string publisherId, string subscriberId)
        {
            SubscriptionBLL.deleteSubscription(publisherId, subscriberId);
        }

        public void notify_subscribers(string publisherId, WallBO obj, string tagstatus, string twid)
        {
            
            
            List<Subscription> subscribers = SubscriptionBLL.getSubscribers(publisherId);
            foreach (Subscription subscriber in subscribers)
            {
                UserBLL userbll = new UserBLL();
                userbll.update(publisherId, subscriber.SubscriberUserId.ToString(), obj, tagstatus,twid);

            }
        }
    }
}