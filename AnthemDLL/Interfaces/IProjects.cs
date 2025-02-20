using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.Interfaces
{
    public interface IProjects
    {
        List<AnthemEntites.Projects> GetAllProjects();
        //List<AnthemEntites.Projects> technology();
        List<AnthemEntites.Projects> GetAllProjectsByQuerystring(string s);
        AnthemEntites.Projects GetProjectDetailsByProjectName(string projectName);
        string InsertChatgptDetails(string IPAddress, string Question);

        List<AnthemEntites.Projects> GetProjectByCategory(string PCategory);
        List<AnthemEntites.ProjectImages> GetAllProjectImagesByProjectId(int projectId);
        List<AnthemEntites.Projects> GetAllEmployees();
        AnthemEntites.Projects GetViewPage(string PageName);
       
    }
}
