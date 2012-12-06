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

    public class EntertainmentBLL
    {
        public EntertainmentBLL()
        {
        }


        public static void insertEntertainment(EntertainmentBO objEntertainment)
        {
            EntertainmentDAL.insertEntertainment(objEntertainment);
        }
        
        public static void deleteEntertainment(string EntertainmentId)
        {
            EntertainmentDAL.deleteEntertainment(EntertainmentId);
        }
        
        public static void updateEntertainment(EntertainmentBO objEntertainment)
        {
            EntertainmentDAL.updateEntertainment(objEntertainment);
        }

        public static List<Entertainment> getAllEntertainmentList()
        {
            return EntertainmentDAL.getAllEntertainmentList();
        }

        public static EntertainmentBO getEntertainmentByEntertainmentId(string EntertainmentId)
        {
            return EntertainmentDAL.getEntertainmentByEntertainmentId(EntertainmentId);
        }

        public static List<Entertainment> getEntertainmentTop(string Type, string UserId)
         {
           
             return EntertainmentDAL.getEntertainmentTop5(Type, UserId);
         }
    }
     
}