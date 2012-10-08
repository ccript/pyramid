using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for FamilyDAL
/// </summary>
/// 

namespace DataLayer
{
    public class FamilyDAL
    {
        
        public FamilyDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
       /* public static void insertFamily(FamilyBO objFamily)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                

                    c_Family Familys = new c_Family
                    {
                        UserId = Convert.ToInt32(objFamily.UserId),
                        FamilyId = Convert.ToInt32(objFamily.FamilyId),
                        FriendUserId = Convert.ToInt32(objFamily.FriendUserId),
                        Relation = objFamily.Relation,
                        AcceptStatus = Convert.ToBoolean(objFamily.AcceptStatus),
                        
                        
                    };

                    context.c_Families.InsertOnSubmit(Familys);
                    context.SubmitChanges();
                

            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateFamily(FamilyBO objFamily,int FamilyId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                c_Family Familys = context.c_Families.Single(s => s.FamilyId == FamilyId);
                Familys.UserId = Convert.ToInt32(objFamily.UserId);
                Familys.FamilyId = Convert.ToInt32(objFamily.FamilyId);
                Familys.FriendUserId = Convert.ToInt32(objFamily.FriendUserId);
                Familys.Relation = objFamily.Relation;
                Familys.AcceptStatus= Convert.ToBoolean(objFamily.AcceptStatus);
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteFamily(int FamilyId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  var Familys = context.c_Families.Single(s => s.FamilyId == FamilyId);
                  context.c_Families.DeleteOnSubmit(Familys);
                  context.SubmitChanges();
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<c_Family> getAllFamilyList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var c_Familys = from c in context.c_Families
                               select c;
                return c_Familys.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static FamilyBO getFamilyByFamilyId(int FamilyId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var Familys = from c in context.c_Families
                              where c.FamilyId == FamilyId
                              select c;
                FamilyBO objFamily = new FamilyBO();
                objFamily.FamilyId = Convert.ToInt32(Familys.FirstOrDefault().FamilyId);
                objFamily.UserId = Convert.ToInt32(Familys.FirstOrDefault().UserId);
                objFamily.FamilyId = Convert.ToInt32(Familys.FirstOrDefault().FamilyId);
                objFamily.FriendUserId = Convert.ToInt32(Familys.FirstOrDefault().FriendUserId);
                
                return objFamily;
            }
           
        }
        */
       

    }
}