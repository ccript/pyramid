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
    public class BasicInfoBLL
    {
        public BasicInfoBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static void insertBasicInfo(BasicInfoBO objBasicInfo)
        {
            BasicInfoDAL.insertBasicInfo(objBasicInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteBasicInfo(string UserId)
        {
            BasicInfoDAL.deleteBasicInfo(UserId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateBasicInfo(BasicInfoBO objBasicInfo)
        {
            BasicInfoDAL.updateBasicInfo(objBasicInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateBasicInfoPage(BasicInfoBO objBasicInfo)
        {
            BasicInfoDAL.updateBasicInfoPage(objBasicInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFamilyPage(BasicInfoBO objBasicInfo)
        {

            BasicInfoDAL.updateFamilyPage(objBasicInfo);
        }
      
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateContactInfoPage(BasicInfoBO objBasicInfo)
        {
            BasicInfoDAL.updateContactInfoPage(objBasicInfo);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<BasicInfo> getAllBasicInfoList()
        {
            return BasicInfoDAL.getAllBasicInfoList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static BasicInfoBO getBasicInfoByUserId(string UserId)
        {
            return BasicInfoDAL.getBasicInfoByUserId(UserId);
        }
    }
     
}