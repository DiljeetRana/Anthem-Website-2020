using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface IProjectImages
    {
        string AddNewImageToPortfolio(EmployeeEntity.ProjectImages imageData);
        List<EmployeeEntity.ProjectImages> GetAllProjectImagesByProjectId(int projectId);
        string DeleteImageByImageId(int imageId);
    }
}
