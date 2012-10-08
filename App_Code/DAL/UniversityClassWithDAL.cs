using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for UniversityClassWithDAL
/// </summary>
/// 

namespace DataLayer
{
    public class UniversityClassWithDAL
    {
        
        public UniversityClassWithDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
       /* public static void insertUniversityClassWith(UniversityClassWithBO objUniversityClassWith)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                

                    c_UniversityClassWith UniversityClassWiths = new c_UniversityClassWith
                    {
                        UserId = Convert.ToInt32(objUniversityClassWith.UserId),
                        UniversityClassWithId = Convert.ToInt32(objUniversityClassWith.UniversityClassWithId),
                        FriendUserId = Convert.ToInt32(objUniversityClassWith.FriendUserId),
                        UniversityId = Convert.ToInt32(objUniversityClassWith.UniversityId),
                        
                        
                    };

                    context.c_UniversityClassWiths.InsertOnSubmit(UniversityClassWiths);
                    context.SubmitChanges();

                  
            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateUniversityClassWith(UniversityClassWithBO objUniversityClassWith,int UniversityClassWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                c_UniversityClassWith UniversityClassWiths = context.c_UniversityClassWiths.Single(s => s.UniversityClassWithId == UniversityClassWithId);
                UniversityClassWiths.UserId = Convert.ToInt32(objUniversityClassWith.UserId);
                UniversityClassWiths.UniversityClassWithId = Convert.ToInt32(objUniversityClassWith.UniversityClassWithId);
                UniversityClassWiths.UniversityId = Convert.ToInt32(objUniversityClassWith.UniversityId);
                UniversityClassWiths.FriendUserId = Convert.ToInt32(objUniversityClassWith.UniversityClassWithId);
                
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteUniversityClassWith(int UniversityClassWithId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  var UniversityClassWiths = context.c_UniversityClassWiths.Single(s => s.UniversityClassWithId == UniversityClassWithId);
                  context.c_UniversityClassWiths.DeleteOnSubmit(UniversityClassWiths);
                  context.SubmitChanges();
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<c_UniversityClassWith> getAllUniversityClassWithList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var c_UniversityClassWiths = from c in context.c_UniversityClassWiths
                               select c;
                return c_UniversityClassWiths.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static UniversityClassWithBO getUniversityClassWithByUniversityClassWithId(int UniversityClassWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var UniversityClassWiths = from c in context.c_UniversityClassWiths
                              where c.UniversityClassWithId == UniversityClassWithId
                              select c;
                UniversityClassWithBO objUniversityClassWith = new UniversityClassWithBO();
                objUniversityClassWith.UniversityClassWithId = Convert.ToInt32(UniversityClassWiths.FirstOrDefault().UniversityClassWithId);
                objUniversityClassWith.UserId = Convert.ToInt32(UniversityClassWiths.FirstOrDefault().UserId);
                objUniversityClassWith.FriendUserId = Convert.ToInt32(UniversityClassWiths.FirstOrDefault().FriendUserId);
                objUniversityClassWith.UniversityId = Convert.ToInt32(UniversityClassWiths.FirstOrDefault().UniversityId);
                
                return objUniversityClassWith;
            }
           
        }

       */

    }
}