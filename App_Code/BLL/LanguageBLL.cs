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
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class LanguageBLL
    {
        public LanguageBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertLanguage(LanguageBO objLanguage)
        {
            LanguageDAL.insertLanguage(objLanguage);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteLanguage(string LanguageId)
        {
            LanguageDAL.deleteLanguage(LanguageId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateLanguage(LanguageBO objLanguage)
        {
            LanguageDAL.updateLanguage(objLanguage);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Language> getAllLanguageList()
        {
            return LanguageDAL.getAllLanguageList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static LanguageBO getLanguageByLanguageId(string LanguageId)
        {
            return LanguageDAL.getLanguageByLanguageId(LanguageId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////

        public static List<Language> getLanguages(string UserId)
        {

            return LanguageDAL.getLanguage(UserId);
        }
    }
     
}