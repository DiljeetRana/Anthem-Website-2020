using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface IProjects
    {
        List<EmployeeEntity.Project> GetAllProjects(string projectName);
        string AddNewProject(EmployeeEntity.Project projectData); 
        string DeleteProject(int projectId);
        EmployeeEntity.Project GetProjectByProjectid(int projectId);
        string UpdateProjectByPorjectId(EmployeeEntity.Project projectData);
        int UnpublishProject(long projectid);
        int PublishProject(long projectid);
        List<EmployeeEntity.Project> GetSortedProjects(int selectedVal);
    }
}
