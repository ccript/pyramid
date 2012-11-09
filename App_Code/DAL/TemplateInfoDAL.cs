using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;


namespace DataLayer
{
    public interface TemplateInfoDAL
    {
        void insert(TemplateBO obj);
        void update(TemplateBO obj);
        void delete(string Id);
        List<Employer> SelectList();
        EmployerBO SelectEmployerByUserId(string Id);
        List<Employer> SelectEmployerTop5(string Id);
        List<Language> SelectListLanguages();
        List<Language> SelectLanguageByid(string UserId);
    }
}