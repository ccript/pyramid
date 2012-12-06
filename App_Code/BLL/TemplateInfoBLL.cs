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

        public static void insert(TemplateBO obj, TemplateInfoDAL baseobj)
        {
                baseobj.insert(obj);
        }


        public static void update(TemplateBO obj,TemplateInfoDAL baseobj)
        {
            baseobj.insert(obj);
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


        public static EmployerBO SelectEmployerByUserId(TemplateInfoDAL baseobj,string UserId)
        {
            return baseobj.SelectEmployerByUserId(UserId);
        }

        public static List<Employer> SelectEmployerTop5(TemplateInfoDAL baseobj,string UserId)
        {
            return baseobj.SelectEmployerTop5(UserId);
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