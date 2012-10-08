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
    public class ActivityBLL
    {
        public ActivityBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertActivity(ActivityBO objActivity)
        {
            if (!objActivity.Name.Equals(""))

                return ActivityDAL.insertActivity(objActivity);
            else
                return null;
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteActivity(string ActivityId)
        {
            ActivityDAL.deleteActivity(ActivityId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateActivity(ActivityBO objActivity)
        {
            ActivityDAL.updateActivity(objActivity);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Activity> getAllActivityList()
        {
            return ActivityDAL.getAllActivityList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ActivityBO getActivityByActivityId(string ActivityId)
        {
            return ActivityDAL.getActivityByActivityId(ActivityId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Activity> getActivityTop5(string Type, string UserId)
        {
            return ActivityDAL.getActivityTop5( Type,  UserId);
        }
    }
     
}