using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;
using System.Collections;
using Pramyid;
using MongoDB.Bson;

/// <summary>
/// Summary description for DeviceBLL
/// </summary>
public class BasicInfoBLL : DataWorker
{
    public BasicInfoBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void insertBasicInfo(BasicInfoBO objBasicInfo)
    {
        //BasicInfoDAL.insertBasicInfo(objBasicInfo);
        database.insert(objBasicInfo, "c_BasicInfo");
    }

    public static void updateBasicInfo(BasicInfoBO objBasicInfo)
    {
        database.update(objBasicInfo, "_Id", objBasicInfo.Id, "c_BasicInfo");
        //BasicInfoDAL.updateBasicInfo(objBasicInfo);
    }

    public static void updateBasicInfoPage(BasicInfoBO objBasicInfo)
    {
        ArrayList lst = database.getByParam("UserId", objBasicInfo.UserId, "c_BasicInfo");
        if (lst.Count > 0)
        {
            database.update(objBasicInfo, "UserId", objBasicInfo.UserId, "c_BasicInfo");
        }
        else
        {
            database.insert(objBasicInfo, "c_BasicInfo");
        }

    }

    public static void updateFamilyPage(BasicInfoBO objBasicInfo)
    {
        BasicInfoBLL.updateFamilyPage(objBasicInfo);
    }

    public static void updateContactInfoPage(BasicInfoBO objBasicInfo)
    {
        BasicInfoBLL.updateBasicInfoPage(objBasicInfo);
    }

    public static BasicInfoBO getBasicInfoByUserId(string UserId)
    {
        BasicInfoBO obj = new BasicInfoBO();
        ArrayList lst = database.getByParam("UserId", UserId, "c_BasicInfo");
        foreach (Object _o in lst)
        {
            obj = BasicInfoBLL.getConvertedObject(_o);
            break;
        }

        return obj;
        //return BasicInfoDAL.getBasicInfoByUserId(UserId);
    }

    private static BasicInfoBO getConvertedObject(Object _o)
    {
        BasicInfoBO obj = new BasicInfoBO();
        if (_o.GetType().Name == "BsonDocument")
        {
            BsonDocument bson = (BsonDocument)_o;

            obj.Address = Convert.ToString(bson.GetElement("Address").Value);
            obj.CurrentCity = Convert.ToString(bson.GetElement("CurrentCity").Value);
            obj.HomeTown = Convert.ToString(bson.GetElement("HomeTown").Value);
            obj.CityTown = Convert.ToString(bson.GetElement("CityTown").Value);
            obj.ZipCode = Convert.ToString(bson.GetElement("ZipCode").Value);
            obj.Neighbourhood = Convert.ToString(bson.GetElement("Neighbourhood").Value);
            obj.RelationshipStatus = Convert.ToString(bson.GetElement("RelationshipStatus").Value);

            obj.Id = bson.GetElement("_id").Value.ToString();
            obj.UserId = bson.GetElement("UserId").ToString();
        }
        return obj;
    }

}