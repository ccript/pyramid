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
    public class ProjectBLL
    {
        public ProjectBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string  insertProject(ProjectBO objProject)
        {
            if (!objProject.ProjectName.Equals(""))
                return ProjectDAL.insertProject(objProject);
            else
                return null;
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteProject(string ProjectId)
        {
            ProjectDAL.deleteProject(ProjectId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateProject(ProjectBO objProject)
        {
            ProjectDAL.updateProject(objProject);
        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Project> getAllProjectList()
        {
            return ProjectDAL.getAllProjectList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static ProjectBO getProjectByProjectId(string ProjectId)
        {
            return ProjectDAL.getProjectByProjectId(ProjectId);
        }
         ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Project> getProjectTop5(string UserId)
        {
            return ProjectDAL.getProjectTop5(UserId);
        }
    }
     
}