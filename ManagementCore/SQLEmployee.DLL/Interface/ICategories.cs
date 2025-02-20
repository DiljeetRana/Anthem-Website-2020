using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface ICategories
    {
        List<EmployeeEntity.Categories> GetAllCategories();
        List<EmployeeEntity.Categories> GetAllSubCategories();
        List<EmployeeEntity.Categories> getTemplates(string occ);
        bool insertUsedTemplate(int TempId, string occ, string MediaType);
    }
}
