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
    public class EmployerBLL
    {
        public EmployerBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertEmployer(EmployerBO objEmployer)
        {
           
            if(!objEmployer.Organization.Equals(""))
            EmployerDAL.insertEmployer(objEmployer);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteEmployer(string EmployerId)
        {
            EmployerDAL.deleteEmployer(EmployerId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateEmployer(EmployerBO objEmployer)
        {
            EmployerDAL.updateEmployer(objEmployer);
        }
    
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Employer> getAllEmployerList()
        {
            return EmployerDAL.getAllEmployerList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static EmployerBO getEmployerByUserId(string UserId)
        {
            return EmployerDAL.getEmployerByUserId(UserId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////

        public static List<Employer> getEmployerTop5(string UserId)
        {
            return EmployerDAL.getEmployerTop5(UserId);
        }
        public static ArrayList getEmployersByUserId(string Id)
        {
            return EmployerDAL.getEmployersByUserId(Id);
        }
    }
     
}