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
    public class SchoolBLL
    {
        public SchoolBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertSchool(SchoolBO objSchool)
        {
            if (!objSchool.Name.Equals(""))
            SchoolDAL.insertSchool(objSchool);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteSchool(string SchoolId)
        {
            SchoolDAL.deleteSchool(SchoolId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateSchool(SchoolBO objSchool)
        {
            SchoolDAL.updateSchool(objSchool);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<School> getAllSchoolList()
        {
            return SchoolDAL.getAllSchoolList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static SchoolBO getSchoolBySchoolId(string SchoolId)
        {
            return SchoolDAL.getSchoolBySchoolId(SchoolId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<School> getSchoolTop5(string UserId)
        {
            return SchoolDAL.getSchoolTop5(UserId);
        }
        public static ArrayList getSchoolsByUserId(string Id)
        {
            return SchoolDAL.getSchoolsByUserId(Id);
        }
    }
     
}