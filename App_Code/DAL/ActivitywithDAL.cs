using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for ActivityWithDAL
/// </summary>
/// 

namespace DataLayer
{
    public class ActivityWithDAL
    {
        
        public ActivityWithDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
       /* public static void insertActivityWith(ActivityWithBO objActivityWith)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                

                    c_ActivityWith ActivityWiths = new c_ActivityWith
                    {
                        UserId = Convert.ToInt32(objActivityWith.UserId),
                        ActivityWithId = Convert.ToInt32(objActivityWith.ActivityWithId),
                        FriendUserId = Convert.ToInt32(objActivityWith.FriendUserId),
                        ActivityId = Convert.ToInt32(objActivityWith.ActivityId),
                        
                        
                        
                    };

                    context.c_ActivityWiths.InsertOnSubmit(ActivityWiths);
                    context.SubmitChanges();
                

            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateActivityWith(ActivityWithBO objActivityWith,int ActivityWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                c_ActivityWith ActivityWiths = context.c_ActivityWiths.Single(s => s.ActivityWithId == ActivityWithId);
                ActivityWiths.UserId = Convert.ToInt32(objActivityWith.UserId);
                ActivityWiths.ActivityWithId = Convert.ToInt32(objActivityWith.ActivityWithId);
                ActivityWiths.FriendUserId = Convert.ToInt32(objActivityWith.FriendUserId);
                ActivityWiths.ActivityId = Convert.ToInt32(objActivityWith.ActivityId);
                
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteActivityWith(int ActivityWithId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  var ActivityWiths = context.c_ActivityWiths.Single(s => s.ActivityWithId == ActivityWithId);
                  context.c_ActivityWiths.DeleteOnSubmit(ActivityWiths);
                  context.SubmitChanges();
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<c_ActivityWith> getAllActivityWithList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var c_ActivityWiths = from c in context.c_ActivityWiths
                               select c;
                return c_ActivityWiths.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ActivityWithBO getActivityWithByActivityWithId(int ActivityWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var ActivityWiths = from c in context.c_ActivityWiths
                              where c.ActivityWithId == ActivityWithId
                              select c;
                ActivityWithBO objActivityWith = new ActivityWithBO();
                objActivityWith.ActivityWithId = Convert.ToInt32(ActivityWiths.FirstOrDefault().ActivityWithId);
                objActivityWith.UserId = Convert.ToInt32(ActivityWiths.FirstOrDefault().UserId);
                objActivityWith.ActivityWithId = Convert.ToInt32(ActivityWiths.FirstOrDefault().ActivityWithId);
                objActivityWith.FriendUserId = Convert.ToInt32(ActivityWiths.FirstOrDefault().FriendUserId);
                
                return objActivityWith;
            }
           
        }

       */

    }
}