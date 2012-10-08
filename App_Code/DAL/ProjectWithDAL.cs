using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for ProjectWithDAL
/// </summary>
/// 

namespace DataLayer
{
    public class ProjectWithDAL
    {
        
        public ProjectWithDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
        /*public static void insertProjectWith(ProjectWithBO objProjectWith)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                

                    c_ProjectWith ProjectWiths = new c_ProjectWith
                    {
                        UserId = Convert.ToInt32(objProjectWith.UserId),
       
                        ProjectId = objProjectWith.ProjectId,
                        FriendUserId= objProjectWith.FriendUserId,
                                                
                    };

                    context.c_ProjectWiths.InsertOnSubmit(ProjectWiths);
                    context.SubmitChanges();
                

            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateProjectWith(ProjectWithBO objProjectWith,int ProjectWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                c_ProjectWith ProjectWiths = context.c_ProjectWiths.Single(s => s.ProjectWithId == ProjectWithId);
                ProjectWiths.UserId = Convert.ToInt32(objProjectWith.UserId);
    
                ProjectWiths.FriendUserId = objProjectWith.FriendUserId;
                ProjectWiths.ProjectId = objProjectWith.ProjectId;
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteProjectWith(int ProjectWithId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  var ProjectWiths = context.c_ProjectWiths.Single(s => s.ProjectWithId == ProjectWithId);
                  context.c_ProjectWiths.DeleteOnSubmit(ProjectWiths);
                  context.SubmitChanges();
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<c_ProjectWith> getAllProjectWithList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var c_ProjectWiths = from c in context.c_ProjectWiths
                               select c;
                return c_ProjectWiths.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ProjectWithBO getProjectWithByProjectWithId(int ProjectWithId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var ProjectWiths = from c in context.c_ProjectWiths
                              where c.ProjectWithId == ProjectWithId
                              select c;
                ProjectWithBO objProjectWith = new ProjectWithBO();
                objProjectWith.ProjectWithId = Convert.ToInt32(ProjectWiths.FirstOrDefault().ProjectWithId);
                objProjectWith.UserId = Convert.ToInt32(ProjectWiths.FirstOrDefault().UserId);
                objProjectWith.ProjectId = Convert.ToInt32(ProjectWiths.FirstOrDefault().ProjectId);

                objProjectWith.FriendUserId = ProjectWiths.FirstOrDefault().FriendUserId;
                               
                return objProjectWith;
            }
           
        }
        */
       

    }
}