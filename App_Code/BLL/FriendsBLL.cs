using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Net;

namespace BuinessLayer
{
    public class FriendsBLL
    {
        public FriendsBLL()
        {
        }
        
        public static string insertFriends(FriendsBO objFriends)
        {
            return FriendsDAL.insertFriends(objFriends);
        }

        public static void deleteFriends(string FriendsId)
        {
            FriendsDAL.deleteFriends(FriendsId);
        }

        public static void updateFriends(FriendsBO objFriends)
        {
            FriendsDAL.updateFriends(objFriends);
        }

        public static List<Friends> getAllFriendsList()
        {
            return FriendsDAL.getAllFriendsList();
        }
        
        public static FriendsBO getFriendsByFriendsId(string FriendsId)
        {
            return FriendsDAL.getFriendsByFriendsId(FriendsId);
        }
        public static List<UserFriendsBO> getBirthdayAlertFriends(string UserId)
        {

            return FriendsDAL.getBirthdayAlertFriends(UserId);
        }

        public static List<UserFriendsBO> getAllFriendsListName(string UserId, string status)
        {

            return FriendsDAL.getAllFriendsListName(UserId, status);
        }
        public static List<UserFriendsBO> getAllFriendsFilterByList(string UserId, string status,string FilterByListName)
        {
            return FriendsDAL.getAllFriendsFilterByList(UserId, status,FilterByListName);
        }

        public static List<UserFriendsBO> getPSFriends(string UserId)
        {

            return FriendsDAL.getPSFriends(UserId);
        }

        public static List<UserFriendsBO> getAllSuggestions(string UserId)
        {
            List<UserFriendsBO> list= FriendsDAL.getAllSuggestions(UserId);
         
            foreach (UserFriendsBO Useritem in list)
            {
                BasicInfoBO info = BasicInfoDAL.getBasicInfoByUserId(Useritem.FriendUserId);
                Useritem.Hometown = info.HomeTown;
                Useritem.Location=info.CurrentCity;
                EmployerBO emp = EmployerDAL.getEmployerByUserId(Useritem.FriendUserId);

                Useritem.Employer=emp.Organization;
                
                UniversityBO uni = UniversityDAL.getUniversityByUniversityId(Useritem.FriendUserId);
                Useritem.Education = uni.UniversityName;
            }
            return list;
        }
        public static int calculateGenderRecomendationScore(string userId,string friendsId)
        {
            UserBO userInfo = UserDAL.getUserByUserId(userId);
            UserBO FriendsInfo = UserDAL.getUserByUserId(friendsId);
            if (userInfo.Gender.Equals(FriendsInfo.Gender))
            {
                return 1 * Global.WEIGHT_GENDER;

            }
            return 0;
        }
        public static int calculateHomeTownRecomendationScore(string userId, string friendsId)
        {
            BasicInfoBO userInfo = BasicInfoDAL.getBasicInfoByUserId(userId);
            BasicInfoBO friendsInfo = BasicInfoDAL.getBasicInfoByUserId(friendsId);
            if (userInfo.HomeTown.Equals(friendsInfo.HomeTown))
            {
                return 1 * Global.WEIGHT_HOMETOWN;

            }
            return 0;
        }

        public static int calculateEmployersRecomendationScore(string userId, string friendsId)
        {
            ArrayList userEmployers = EmployerDAL.getEmployersByUserId(userId);
            ArrayList friendsEmployers = EmployerDAL.getEmployersByUserId(friendsId);
            int Score = 0;
            foreach (string userEmploy in userEmployers)
            {
                foreach (string friendsEmploy in friendsEmployers)
                {
                    if (userEmploy.Equals(friendsEmploy))
                    {
                        Score += 1 * Global.WEIGHT_WORKPLACE;

                    }
                }
            }
            return Score;
        }
        public static int calculateUniversityRecomendationScore(string userId, string friendsId)
        {
            ArrayList userUniversity = UniversityDAL.getUnisByUserId(userId);
            ArrayList friendsUniversity = UniversityDAL.getUnisByUserId(friendsId);
            int Score = 0;
            foreach (string uUni in userUniversity)
            {
                foreach (string sUni in friendsUniversity)
                {
                    if (uUni.Equals(sUni))
                    {
                        Score += 1 * Global.WEIGHT_EDUCATION;

                    }

                }
            }
            return Score;
        }
        public static int calculateInterestRecomendationScore(string userId, string friendsId)
        {
            ArrayList userInterests = ActivityDAL.getActivitiesByUserId(userId);
            ArrayList friendsInterests = ActivityDAL.getActivitiesByUserId(friendsId); ;
            int Score = 0;
            foreach (string uInterest in userInterests)
            {
                foreach (string friendInterest in friendsInterests)
                {
                    if (uInterest.Equals(friendInterest))
                    {
                        Score += 1 * Global.WEIGHT_INTERESTS;
                    }
                }
            }
            return Score;
        }
        public static List<UserFriendsBO> getSortedScoredList(List<UserFriendsBO> FriendList)
        {
            List<UserFriendsBO> scoredlist = new List<UserFriendsBO>();
            var sortedList = from em in FriendList
                         orderby em.Score descending
                         select em;
            foreach (var friend in sortedList)
            {
                if (friend.Score >= Global.SUGGESTIONS_MINIMUM_SCORE)
                    scoredlist.Add(friend);
            }

            return scoredlist;

        }

        public static List<UserFriendsBO> RecommendationScoring(List<UserFriendsBO> FriendList,string UserId)
        {

            foreach (UserFriendsBO Friend in FriendList)
            {
                Friend.Score = 0;
                Friend.Score += calculateGenderRecomendationScore(UserId, Friend.FriendUserId);
                Friend.Score += calculateHomeTownRecomendationScore(UserId, Friend.FriendUserId);
                Friend.Score += calculateUniversityRecomendationScore(UserId, Friend.FriendUserId);
                Friend.Score += calculateInterestRecomendationScore(UserId, Friend.FriendUserId);
                Friend.Score += Friend.MutualFriendsCount * Global.WEIGHT_SHAREDFRIENDS;
            }
            return getSortedScoredList(FriendList);
           
        }
        public static List<UserFriendsBO> getMutualFriends(string UserId,string FriendId, string status)
        {

            return FriendsDAL.getMutualFriends(UserId,FriendId, status);
        }


        public static List<UserFriendsBO> getAllFriendRequests(string UserId, string status)
        {

            return FriendsDAL.getAllFriendRequests(UserId, status);
        }


        public static void confirmRequest(FriendsBO objClass)
        {

            FriendsDAL.confirmRequest(objClass);

            string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
            SmtpClient client = new SmtpClient(emailHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Host = emailHost;
            client.Port = 587;
            string myEmail = ConfigurationSettings.AppSettings["Email"];
            string Password = ConfigurationSettings.AppSettings["Password"];

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(myEmail, Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(myEmail);
           UserBO ub = UserDAL.getUserByUserId(objClass.FriendUserId);

            msg.To.Add(new MailAddress(ub.Email));

            msg.Subject = "Pyramid Plus Friend Request";
            msg.IsBodyHtml = true;

            msg.Body = "Dear Pyramid Plus user, Your friend request has been accepted. ";
           
            try
            {
                client.Send(msg);
           }
            catch (Exception ex)
            {
            }
            
        }

        public static void delayRequest(FriendsBO objClass)
        {

            FriendsDAL.delayRequest(objClass);
        }

        
        public static void sendFriendRequest(string UserId, string FriendId)
        {

            FriendsDAL.sendFriendRequest(UserId, FriendId);
           
        }

        public static void sendFriendSuggestion(string UserId, string FriendId)
        {

            FriendsDAL.sendFriendSuggestion(UserId, FriendId);

            string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
            SmtpClient client = new SmtpClient(emailHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Host = emailHost;
            client.Port = 587;
            string myEmail = ConfigurationSettings.AppSettings["Email"];
            string Password = ConfigurationSettings.AppSettings["Password"];

            System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential(myEmail, Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(myEmail);
            UserBO ub = UserDAL.getUserByUserId(UserId);
            UserBO ub2 = UserDAL.getUserByUserId(FriendId);

            msg.To.Add(new MailAddress(ub.Email));
            msg.Subject = "Pyramid Plus Friend Suggestion";
            msg.IsBodyHtml = true;

            msg.Body = "Dear Pyramid Plus user, Your have been introduced by your friend to "+ ub2.FirstName+" "+ub2.LastName +". ";
            
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
            }
        }

        public static void cancelFriendRequest(string UserId, string FriendId)
        {

            FriendsDAL.cancelFriendRequest(UserId, FriendId);
        }

        public static List<UserFriendsBO> getFriendsListByName(string UserId, string value)
        {

            return FriendsDAL.getFriendsListByName(UserId, value);
        }

        public static List<UserFriendsBO> FindByListName(string UserId, string value, string status)
        {

            return FriendsDAL.FindUserListName(UserId, value, status);
        }

        public static List<UserFriendsBO> FindByListCurrent(string UserId, string value, string status)
        {

            return FriendsDAL.FindUserListCurrentCity(UserId, value, status);
        }

        public static List<UserFriendsBO> FindByListHomeTown(string UserId, string value, string status)
        {

            return FriendsDAL.FindUserListHomeTown(UserId, value, status);
        }

        public static List<UserFriendsBO> FindByListSchool(string UserId, string value, string status)
        {
            return FriendsDAL.FindUserListSchool(UserId, value, status);
        }

        public static List<UserFriendsBO> FindByListWorkPlace(string UserId, string value, string status)
        {
            return FriendsDAL.FindUserListWorkPlace(UserId, value, status);
        }

        public static bool isExistingFriend(string UserId, string FriendId)
        {
            return FriendsDAL.isExistingFriend(UserId, FriendId);
        }

        public static long countFriends(string UserId, string status)
        {

            return FriendsDAL.countFriends(UserId, status);
        }
        public static long countFriendRequests(string UserId, string status)
        {
            return FriendsDAL.countFriendRequests(UserId, status);
        }
    }

}