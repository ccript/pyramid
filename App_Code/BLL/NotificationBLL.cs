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
    public class NotificationBLL
    {
        public NotificationBLL()
        {
        }

        public static string insertNotification(NotificationBO objNotification)
        {
            if (!objNotification.MyNotification.Equals(""))

                return NotificationDAL.insertNotification(objNotification);
            else
                return null;
        }
        
        public static void deleteNotification(string NotificationId)
        {
            NotificationDAL.deleteNotification(NotificationId);
        }
        
        public static void updateNotification(NotificationBO objNotification)
        {
            NotificationDAL.updateNotification(objNotification);
        }
        
        public static void updateNotificationStatus(string userid)
        {
            NotificationDAL.updateNotificationStatus(userid);
        }
        
        public static long countNotification(string UserId)
        {
           return NotificationDAL.countNotification( UserId);
        }
        
        public static List<Notification> getAllNotificationList()
        {
            return NotificationDAL.getAllNotificationList();
        }
        
        public static NotificationBO getNotificationByNotificationId(string NotificationId)
        {
            return NotificationDAL.getNotificationByNotificationId(NotificationId);
        }
        
        public static List<Notification> getNotificationTop5(int Type, string AtId)
        {
            return NotificationDAL.getNotificationTop5( Type,  AtId);
        }
        
        public static List<Notification> getNotificationByUserId(string UserId)
        {
            return NotificationDAL.getNotificationByUserId(UserId);
        }
    }
     
}