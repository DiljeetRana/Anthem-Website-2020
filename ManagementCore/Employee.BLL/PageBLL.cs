using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using System.Data;

namespace Employee.BLL
{
   public class PageBLL
    {
       IPage IPage;
       public PageBLL()
       {
           IPage = new SQLEmployee.DLL.DataAccess.SQLPage();
       }

      
       public int AddPage(EmployeeEntity.Page page)
       {
           return IPage.AddPage(page);
       }

    public EmployeeEntity.Page  GetPages()
       {
           return IPage.GetPages();
       }

    public DataTable GetPageByStatus()
    {
        return IPage.GetPageByStatus();
    }

    public EmployeeEntity.Page GetPageContent(string pagetitle)
    {
        return IPage.GetPageContent(pagetitle);
    }
      
    }
}
