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
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class FriendsBLL
    {
        public FriendsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertFriends(FriendsBO objFriends)
        {


            return FriendsDAL.insertFriends(objFriends);

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteFriends(string FriendsId)
        {
            FriendsDAL.deleteFriends(FriendsId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFriends(FriendsBO objFriends)
        {
            FriendsDAL.updateFriends(objFriends);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Friends> getAllFriendsList()
        {
            return FriendsDAL.getAllFriendsList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static FriendsBO getFriendsByFriendsId(string FriendsId)
        {
            return FriendsDAL.getFriendsByFriendsId(FriendsId);
        }
        public static List<UserFriendsBO> getBirthdayAlertFriends(string UserId)
        {

            return FriendsDAL.getBirthdayAlertFriends(UserId);
        }

        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
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
            //get suggestions and mutual friends
            List<UserFriendsBO> list= FriendsDAL.getAllSuggestions(UserId);
            //get the education,hometown and employer of people in list
            foreach (UserFriendsBO Useritem in list)
            {
                BasicInfoBO info = BasicInfoDAL.getBasicInfoByUserId(Useritem.FriendUserId);
                Useritem.Hometown = info.HomeTown;
                Useritem.Location=info.CurrentCity;
                EmployerBO emp = EmployerDAL.getEmployerByUserId(Useritem.FriendUserId);

               // Useritem.Employers = new ArrayList();

                //foreach (string item in emp)
                //
                    Useritem.Employer=emp.Organization;
                //}
               
                UniversityBO uni = UniversityDAL.getUniversityByUniversityId(Useritem.FriendUserId);
                Useritem.Education = uni.UniversityName;
            }
            return list;
        }
        public static List<UserFriendsBO> RecommendationScoring(List<UserFriendsBO> list,string UserId)
        {
            int threshold = 2;
            string uGender;
            string uHomeTown;
            ArrayList uInterests;
            ArrayList uEmployers;
            ArrayList uUniversity;

            string sGender;
            string sHomeTown;
            ArrayList sInterests;
            ArrayList sEmployers;
            ArrayList sUniversity;



            List<UserFriendsBO> scoredlist = new List<UserFriendsBO>();
            
            //first get the info of the userid user i.e the person for whom suggestions being shown
            BasicInfoBO info = BasicInfoDAL.getBasicInfoByUserId(UserId);
                uHomeTown = info.HomeTown;
            UserBO uinfo = UserDAL.getUserByUserId(UserId);  
                uGender=uinfo.Gender;
                uEmployers = EmployerDAL.getEmployersByUserId(UserId);
                uUniversity = UniversityDAL.getUnisByUserId(UserId);
                uInterests = ActivityDAL.getActivitiesByUserId(UserId);
                
              
               // Useritem.Employers = new ArrayList();

                //foreach (string item in emp)
                //
                //    Useritem.Employer=emp.Organization;
                //}
               
                //UniversityBO uni = UniversityDAL.getUniversityByUniversityId(Useritem.FriendUserId);
                //Useritem.Education = uni.UniversityName;
            foreach (UserFriendsBO item in list)
            {
                item.Score = 0;
                //get gender,hometown,employers of suggested item
                BasicInfoBO sinfo = BasicInfoDAL.getBasicInfoByUserId(item.FriendUserId);
                sHomeTown = sinfo.HomeTown;
                UserBO suinfo = UserDAL.getUserByUserId(item.FriendUserId);
                sGender = suinfo.Gender;
                sEmployers = EmployerDAL.getEmployersByUserId(item.FriendUserId);
                sUniversity = UniversityDAL.getUnisByUserId(item.FriendUserId);
                sInterests = ActivityDAL.getActivitiesByUserId(item.FriendUserId);
                //match userinfo with suggested item info
                //if a match occurs add to item score
                if (uGender.Equals(sGender))
                {
                    item.Score += 1 * Global.WEIGHT_GENDER;

                }
                if (uHomeTown.Equals(sHomeTown))
                {
                    item.Score += 1 * Global.WEIGHT_HOMETOWN;
                }
                foreach (string uemp in uEmployers)
                {
                    foreach (string semp in sEmployers)
                    {
                        if (uemp.Equals(semp))
                        {
                            item.Score += 1 * Global.WEIGHT_WORKPLACE;
 
                        }

                    }

 
                }
                foreach (string uUni in uUniversity)
                {
                    foreach (string sUni in sUniversity)
                    {
                        if (uUni.Equals(sUni))
                        {
                            item.Score += 1 * Global.WEIGHT_EDUCATION;

                        }

                    }


                }
                foreach (string uInterest in uInterests)
                {
                    foreach (string sInterest in sInterests)
                    {
                        if (uInterest.Equals(sInterest))
                        {
                            item.Score += 1 * Global.WEIGHT_INTERESTS;

                        }

                    }


                }

                item.Score += item.MutualFriendsCount * Global.WEIGHT_SHAREDFRIENDS;

                
            }
            //sort the list according to highest score at the top
            //scoredlist.Sort((x, y) => int.Compare(x.Score, y.Score));
            var result = from em in list
                         orderby em.Score descending
                         select em;
            foreach (var em in result)
            {
                if(em.Score>=threshold)
                scoredlist.Add(em);
            }

            return scoredlist;


        }
        public static List<UserFriendsBO> getMutualFriends(string UserId,string FriendId, string status)
        {

            return FriendsDAL.getMutualFriends(UserId,FriendId, status);
        }


        public static List<UserFriendsBO> getAllFriendRequests(string UserId, string status)
        {

            return FriendsDAL.getAllFriendRequests(UserId, status);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void confirmRequest(FriendsBO objClass)
        {

            FriendsDAL.confirmRequest(objClass);
            //send email to user that his request was acknowledged


            string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
            SmtpClient client = new SmtpClient(emailHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Host = emailHost;
            client.Port = 587;
            string myEmail = ConfigurationSettings.AppSettings["Email"];
            string Password = ConfigurationSettings.AppSettings["Password"];
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(myEmail, Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(myEmail);
            //Get email address of person whose request was accepted
           UserBO ub = UserDAL.getUserByUserId(objClass.FriendUserId);

            msg.To.Add(new MailAddress(ub.Email));

            msg.Subject = "Pyramid Plus Friend Request";
            msg.IsBodyHtml = true;

            msg.Body = "Dear Pyramid Plus user, Your friend request has been accepted. ";
            //Session["randomCode"] = randomCode;
            //generate the randomCode and place it in the c_User

            try
            {
                client.Send(msg);
                //Response.Redirect("CodesSent.aspx?UserEmail=" + lblEmail.Text);
                //lblResult.Text = "Your message has been successfully sent.";
                //txtSubject.Text = "";
                //FCKeditor1.Value = "";
            }
            catch (Exception ex)
            {
                // lblResult.ForeColor = Color.Red;
                //lblResult.Text = "Error occured while sending your message." + ex.Message + "with code " + randomCode;
            }
            
        }

        public static void delayRequest(FriendsBO objClass)
        {

            FriendsDAL.delayRequest(objClass);
            //send email to user that his request was acknowledged
        }
        ///////////////////////////////////////////////////////////////
        //                       send friend request FUNCTION
        //////////////////////////////////////////////////////////////
        public static void sendFriendRequest(string UserId, string FriendId)
        {

            FriendsDAL.sendFriendRequest(UserId, FriendId);
           
        }

        public static void sendFriendSuggestion(string UserId, string FriendId)
        {

            FriendsDAL.sendFriendSuggestion(UserId, FriendId);
            //send email to user telling hime he has been suggested to someone


            string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
            SmtpClient client = new SmtpClient(emailHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Host = emailHost;
            client.Port = 587;
            string myEmail = ConfigurationSettings.AppSettings["Email"];
            string Password = ConfigurationSettings.AppSettings["Password"];
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(myEmail, Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(myEmail);
            //Get email address of person whose request was accepted
            UserBO ub = UserDAL.getUserByUserId(UserId);
            UserBO ub2 = UserDAL.getUserByUserId(FriendId);

            msg.To.Add(new MailAddress(ub.Email));

            msg.Subject = "Pyramid Plus Friend Suggestion";
            msg.IsBodyHtml = true;

            msg.Body = "Dear Pyramid Plus user, Your have been introduced by your friend to "+ ub2.FirstName+" "+ub2.LastName +". ";
            //Session["randomCode"] = randomCode;
            //generate the randomCode and place it in the c_User

            try
            {
                client.Send(msg);
                //Response.Redirect("CodesSent.aspx?UserEmail=" + lblEmail.Text);
                //lblResult.Text = "Your message has been successfully sent.";
                //txtSubject.Text = "";
                //FCKeditor1.Value = "";
            }
            catch (Exception ex)
            {
                // lblResult.ForeColor = Color.Red;
                //lblResult.Text = "Error occured while sending your message." + ex.Message + "with code " + randomCode;
            }
        }
        ///////////////////////////////////////////////////////////////
        //                       cancel friend request FUNCTION
        //////////////////////////////////////////////////////////////
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