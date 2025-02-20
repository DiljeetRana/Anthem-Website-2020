using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class ProjectsBLL
    {
          IProjects iprojects;

          public ProjectsBLL()
        {
            iprojects = new SQLEmployee.DLL.DataAccess.Projects();
        }
        
        public List<EmployeeEntity.Project> GetAllProjects(string projectName)
        {
            return iprojects.GetAllProjects(projectName);
        }
        public string AddNewProject(EmployeeEntity.Project projectData)
        {
            return iprojects.AddNewProject(projectData);
        }
        public string DeleteProject(int projectId)
        {
            return iprojects.DeleteProject(projectId);
        }
        public EmployeeEntity.Project GetProjectByProjectid(int projectId)
        {
            return iprojects.GetProjectByProjectid(projectId);
        }
        public string UpdateProjectByPorjectId(EmployeeEntity.Project projectData)
        {
            return iprojects.UpdateProjectByPorjectId(projectData);
        }
        public int UnpublishProject(long projectid)
        {
            return iprojects.UnpublishProject(projectid);
        }
        public int PublishProject(long projectid)
        {
            return iprojects.PublishProject(projectid);
        }
        public List<EmployeeEntity.Project> GetSortedProjects(int selectedVal)
        {
            return iprojects.GetSortedProjects(selectedVal);
        }
    }
}
