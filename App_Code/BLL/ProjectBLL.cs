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

    public class ProjectBLL
    {
        public ProjectBLL()
        {
        }

        public static string  insertProject(ProjectBO objProject)
        {
            if (!objProject.ProjectName.Equals(""))
                return ProjectDAL.insertProject(objProject);
            else
                return null;
        }

        public static void deleteProject(string ProjectId)
        {
            ProjectDAL.deleteProject(ProjectId);
        }

        public static void updateProject(ProjectBO objProject)
        {
            ProjectDAL.updateProject(objProject);
        }

        public static List<Project> getAllProjectList()
        {
            return ProjectDAL.getAllProjectList();
        }

        public static ProjectBO getProjectByProjectId(string ProjectId)
        {
            return ProjectDAL.getProjectByProjectId(ProjectId);
        }

        public static List<Project> getProjectTop5(string UserId)
        {
            return ProjectDAL.getProjectTop5(UserId);
        }
    }
     
}