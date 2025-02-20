#region Name Spaces

using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AnthemProjectBLL
{
    public class ProjectBLL
    {

        #region Members

        IProjects iProjects;

        #endregion

        #region Methods

        public ProjectBLL()
        {
            iProjects = new AnthemDLL.DataAccess.Project();
        }

        public List<AnthemEntites.Projects> GetAllProjects()
        {
            return iProjects.GetAllProjects();
        }
        //public List<AnthemEntites.Projects> technology()
        //{
        //    return iProjects.technology();
        //}
        public List<AnthemEntites.Projects> GetAllProjectsByQuerystring( string s)
        {
            return iProjects.GetAllProjectsByQuerystring(s);
        }

        public AnthemEntites.Projects GetProjectDetailsByProjectName(string projectName)
        {
            return iProjects.GetProjectDetailsByProjectName(projectName);
        }

        public string InsertChatgptDetails(string IPAddress,string Question)
        {
            return iProjects.InsertChatgptDetails(IPAddress, Question);
        }
        public List<AnthemEntites.Projects> GetProjectByCategory(string PCategory)
        {
            return iProjects.GetProjectByCategory(PCategory);
        }

        public List<AnthemEntites.ProjectImages> GetAllProjectImagesByProjectId(int projectId)
        {
            return iProjects.GetAllProjectImagesByProjectId(projectId);
        }

        public AnthemEntites.Projects GetViewPage(string PageName)
        {
            return iProjects.GetViewPage(PageName);
        }
        public List<AnthemEntites.Projects> GetAllEmployees()
        {
            return iProjects.GetAllEmployees();
        }
       

        #endregion

    }
}
