using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;

namespace SQLEmployee.DLL.DataAccess
{
  public partial class SQLEmployeesWork:SQLBase,IEmployeeWork
    {
      public SQLEmployeesWork()
          : base()
      {

      }
    }
}
