using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for InterestsWithDAL
/// </summary>
/// 

namespace DataLayer
{
    public class InterestsWithDAL
    {
        
        public InterestsWithDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
       /* public static void insertInterestsWith(InterestsWithBO objInterestsWith)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                

                    c_InterestsWith InterestsWiths = new c_InterestsWith
                    {
                        UserId = Convert.ToInt32(objInterestsWith.UserId),
                        InterestsWithId = Convert.ToInt32(objInterestsWith.InterestsWithId),
                        FriendUserId = Convert.ToInt32(objInterestsWith.FriendUserId),
                        InterestsId = Convert.ToInt32(objInterestsWith.InterestsId),
                        
                        
                        
                    };

                    context.c_InterestsWiths.InsertOnSubmit(InterestsWiths);
                    context.SubmitChanges();
                

            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateInterestsWith(InterestsWithBO objInterestsWith,int InterestsWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                c_InterestsWith InterestsWiths = context.c_InterestsWiths.Single(s => s.InterestsWithId == InterestsWithId);
                InterestsWiths.UserId = Convert.ToInt32(objInterestsWith.UserId);
                InterestsWiths.InterestsWithId = Convert.ToInt32(objInterestsWith.InterestsWithId);
                InterestsWiths.FriendUserId = Convert.ToInt32(objInterestsWith.FriendUserId);
                InterestsWiths.InterestsId = Convert.ToInt32(objInterestsWith.InterestsId);
                
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteInterestsWith(int InterestsWithId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  var InterestsWiths = context.c_InterestsWiths.Single(s => s.InterestsWithId == InterestsWithId);
                  context.c_InterestsWiths.DeleteOnSubmit(InterestsWiths);
                  context.SubmitChanges();
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<c_InterestsWith> getAllInterestsWithList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var c_InterestsWiths = from c in context.c_InterestsWiths
                               select c;
                return c_InterestsWiths.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static InterestsWithBO getInterestsWithByInterestsWithId(int InterestsWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var InterestsWiths = from c in context.c_InterestsWiths
                              where c.InterestsWithId == InterestsWithId
                              select c;
                InterestsWithBO objInterestsWith = new InterestsWithBO();
                objInterestsWith.InterestsWithId = Convert.ToInt32(InterestsWiths.FirstOrDefault().InterestsWithId);
                objInterestsWith.UserId = Convert.ToInt32(InterestsWiths.FirstOrDefault().UserId);
                objInterestsWith.InterestsWithId = Convert.ToInt32(InterestsWiths.FirstOrDefault().InterestsWithId);
                objInterestsWith.FriendUserId = Convert.ToInt32(InterestsWiths.FirstOrDefault().FriendUserId);
                
                return objInterestsWith;
            }
           
        }
        */
       

    }
}