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
    public class LanguageBLL
    {
        public LanguageBLL()
        {
        }

        public static void insertLanguage(LanguageBO objLanguage)
        {
            LanguageDAL.insertLanguage(objLanguage);
        }

        public static void deleteLanguage(string LanguageId)
        {
            LanguageDAL.deleteLanguage(LanguageId);
        }
        
        public static void updateLanguage(LanguageBO objLanguage)
        {
            LanguageDAL.updateLanguage(objLanguage);
        }
        
        public static List<Language> getAllLanguageList()
        {
            return LanguageDAL.getAllLanguageList();
        }
        
        public static LanguageBO getLanguageByLanguageId(string LanguageId)
        {
            return LanguageDAL.getLanguageByLanguageId(LanguageId);
        }
        
        public static List<Language> getLanguages(string UserId)
        {

            return LanguageDAL.getLanguage(UserId);
        }
    }
     
}