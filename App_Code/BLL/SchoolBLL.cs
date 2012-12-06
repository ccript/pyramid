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

    public class SchoolBLL
    {
        public SchoolBLL()
        {
        }

        public static void insertSchool(SchoolBO objSchool)
        {
            if (!objSchool.Name.Equals(""))
            SchoolDAL.insertSchool(objSchool);
        }

        public static void deleteSchool(string SchoolId)
        {
            SchoolDAL.deleteSchool(SchoolId);
        }

        public static void updateSchool(SchoolBO objSchool)
        {
            SchoolDAL.updateSchool(objSchool);
        }

        public static List<School> getAllSchoolList()
        {
            return SchoolDAL.getAllSchoolList();
        }

        public static SchoolBO getSchoolBySchoolId(string SchoolId)
        {
            return SchoolDAL.getSchoolBySchoolId(SchoolId);
        }

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