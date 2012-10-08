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
    public class EntertainmentBLL
    {
        public EntertainmentBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertEntertainment(EntertainmentBO objEntertainment)
        {
            EntertainmentDAL.insertEntertainment(objEntertainment);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteEntertainment(string EntertainmentId)
        {
            EntertainmentDAL.deleteEntertainment(EntertainmentId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateEntertainment(EntertainmentBO objEntertainment)
        {
            EntertainmentDAL.updateEntertainment(objEntertainment);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Entertainment> getAllEntertainmentList()
        {
            return EntertainmentDAL.getAllEntertainmentList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static EntertainmentBO getEntertainmentByEntertainmentId(string EntertainmentId)
        {
            return EntertainmentDAL.getEntertainmentByEntertainmentId(EntertainmentId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Entertainment> getEntertainmentTop(string Type, string UserId)
         {
           
             return EntertainmentDAL.getEntertainmentTop5(Type, UserId);
         }
    }
     
}