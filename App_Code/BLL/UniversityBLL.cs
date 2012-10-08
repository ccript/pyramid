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

namespace BuinessLayer
{
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class UniversityBLL
    {
        public UniversityBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertUniversity(UniversityBO objUniversity)
        {
            if (!objUniversity.UniversityName.Equals(""))
                return UniversityDAL.insertUniversity(objUniversity);
            else
                return null;
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteUniversity(string UniversityId)
        {
            UniversityDAL.deleteUniversity(UniversityId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateUniversity(UniversityBO objUniversity)
        {
            UniversityDAL.updateUniversity(objUniversity);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<University> getAllUniversityList()
        {
            return UniversityDAL.getAllUniversityList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static UniversityBO getUniversityByUniversityId(string UniversityId)
        {
            return UniversityDAL.getUniversityByUniversityId(UniversityId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////

        public static List<University> getUniversityTop5(string UserId)
        {
            return UniversityDAL.getUniversityTop5(UserId);
        }
        public static ArrayList getUnisByUserId(string Id)
        {
            return UniversityDAL.getUnisByUserId(Id);
        }
    }
     
}