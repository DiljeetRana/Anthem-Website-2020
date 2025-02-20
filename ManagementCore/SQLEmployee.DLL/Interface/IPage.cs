using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLEmployee.DLL.Interface
{
   public interface IPage
    {
       int AddPage(EmployeeEntity.Page page);
       EmployeeEntity.Page GetPages();
       //EmployeeEntity.Page GetPageByStatus();
       DataTable GetPageByStatus();
       EmployeeEntity.Page GetPageContent(string pagetitle);
      
    }
}
