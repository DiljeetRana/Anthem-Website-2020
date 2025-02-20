using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class ProjectImagesBLL
    {
        
          IProjectImages iProjectImages;

          public ProjectImagesBLL()
        {
            iProjectImages = new SQLEmployee.DLL.DataAccess.ProjectImages();
        }

          public string AddNewImageToPortfolio(EmployeeEntity.ProjectImages imageData)
        {
            return iProjectImages.AddNewImageToPortfolio(imageData);
        }
          public List<EmployeeEntity.ProjectImages> GetAllProjectImagesByProjectId(int projectId)
          {
              return iProjectImages.GetAllProjectImagesByProjectId(projectId);
          }
          public string DeleteImageByImageId(int imageId)
          {
              return iProjectImages.DeleteImageByImageId(imageId);
          }
    }
}
