using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;
using Pramyid;
using System.Collections;
using MongoDB.Bson;

namespace BuinessLayer
{
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class ActivityBLL : DataWorker
    {
        private static string _tableName = "c_Activities"; 
        public ActivityBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string insertActivity(ActivityBO objActivity)
        {
            if (!String.IsNullOrEmpty(objActivity.Name))
            {
                return database.insert(objActivity, _tableName);
            }

            return null;

        }
        
        public static void deleteActivity(string ActivityId)
        {
            database.delete(ActivityId, _tableName);
            //ActivityDAL.deleteActivity(ActivityId);
        }
        
        public static List<Activity> getActivityTop5(string Type, string UserId)
        {
            ArrayList lst = database.getByParam("UserId", UserId, _tableName);
            Activity obj = new Activity();
            List<Activity> retList = new List<Activity>();
            int index = 0;
            foreach (Object _o in lst)
            {
                obj = ActivityBLL.getConvertedObject(_o);
                if (obj.Type == Type)
                {
                    retList.Add(obj);
                    index++;
                }                
                if (index == 5) {
                    break;
                }
            }

            return retList;

            //return ActivityDAL.getActivityTop5(Type, UserId);
        }

        private static Activity getConvertedObject(Object _o)
        {
            Activity obj = new Activity();
            if (_o.GetType().Name == "BsonDocument")
            {
                BsonDocument bson = (BsonDocument)_o;

                obj.Name = Convert.ToString(bson.GetElement("Name").Value);
                obj.Description = Convert.ToString(bson.GetElement("Description").Value);
                obj.Type = Convert.ToString(bson.GetElement("Type").Value);
                obj.Image = Convert.ToString(bson.GetElement("Image").Value);                

                obj._id = ObjectId.Parse(bson.GetElement("_id").Value.ToString());
                obj.UserId = ObjectId.Parse(bson.GetElement("UserId").Value.ToString());
            }
            return obj;
        }
    }

}