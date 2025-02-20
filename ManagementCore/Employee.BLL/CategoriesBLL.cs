using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class CategoriesBLL
    {
        ICategories ICategories;
        public CategoriesBLL()
        {
            ICategories = new SQLEmployee.DLL.DataAccess.Catrgoires();
        }

        public List<EmployeeEntity.Categories> GetAllCategoires()
        {
            return ICategories.GetAllCategories();
        }

        public List<EmployeeEntity.Categories> GetAllSubCategories()
        {
            return ICategories.GetAllSubCategories();
        }
        public List<EmployeeEntity.Categories> getTemplates(string occ)
        {
            return ICategories.getTemplates(occ);
        }
        public bool insertUsedTemplate(int TempId,string occ,string MediaType)
        {
            return ICategories.insertUsedTemplate(TempId, occ, MediaType);
        }
    }
}
