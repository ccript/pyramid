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
    public class TemplateInfoBLL
    {
        public TemplateInfoBLL()
        {
        }

        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insert(TemplateBO obj, TemplateInfoDAL baseobj)
        {
            //if (!objEmployer.Organization.Equals(""))
            //    EmployerDAL.insertEmployer(obj);
                baseobj.insert(obj);
            
        }

        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void update(TemplateBO obj,TemplateInfoDAL baseobj)
        {
            baseobj.insert(obj);
            //EmployerDAL.updateEmployer(objEmployer);
        }


        public static void delete(TemplateInfoDAL baseobj, string Id)
        {
            baseobj.delete(Id);
        }

        public static List<Employer> SelectList(TemplateInfoDAL baseobj)
        {
            return baseobj.SelectList();
        }

        public static List<Language> SelectListLanguages(TemplateInfoDAL baseobj)
        {
            return baseobj.SelectListLanguages();
        }

        public static List<Language> SelectLanguageByid(TemplateInfoDAL baseobj, string UserId)
        {
            return baseobj.SelectLanguageByid(UserId);
        }

        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static EmployerBO SelectEmployerByUserId(TemplateInfoDAL baseobj,string UserId)
        {
            return baseobj.SelectEmployerByUserId(UserId);
        }

        public static List<Employer> SelectEmployerTop5(TemplateInfoDAL baseobj,string UserId)
        {
            return baseobj.SelectEmployerTop5(UserId);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

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