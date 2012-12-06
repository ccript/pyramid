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
    public class EmployerBLL
    {
        public EmployerBLL()
        {
        }


        public static void insertEmployer(EmployerBO objEmployer)
        {
           
            if(!objEmployer.Organization.Equals(""))
            EmployerDAL.insertEmployer(objEmployer);
        }

        public static void deleteEmployer(string EmployerId)
        {
            EmployerDAL.deleteEmployer(EmployerId);
        }
        
        
        public static void updateEmployer(EmployerBO objEmployer)
        {
            EmployerDAL.updateEmployer(objEmployer);
        }
    

        public static List<Employer> getAllEmployerList()
        {
            return EmployerDAL.getAllEmployerList();
        }

        public static EmployerBO getEmployerByUserId(string UserId)
        {
            return EmployerDAL.getEmployerByUserId(UserId);
        }
        
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