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
    public class ContactInfoBLL
    {
        public ContactInfoBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertContactInfo(ContactInfoBO objContactInfo)
        {
            ContactInfoDAL.insertContactInfo(objContactInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteContactInfo(string ContactInfoId)
        {
            ContactInfoDAL.deleteContactInfo(ContactInfoId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateContactInfo(ContactInfoBO objContactInfo)
        {
            ContactInfoDAL.updateContactInfo(objContactInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<ContactInfo> getAllContactInfoList()
        {
            return ContactInfoDAL.getAllContactInfoList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ContactInfoBO getContactInfoByContactInfoId(string ContactInfoId)
        {
            return ContactInfoDAL.getContactInfoByContactInfoId(ContactInfoId);
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<ContactInfo> getContactInfo(string Type, string UserId)
         {
           
             return ContactInfoDAL.getContactInfo(Type, UserId);
         }
    }
     
}