using SQLEmployee.DLL.ADO;
using SQLEmployee.DLL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
   public interface IMultipleMail
    {
       List<EmployeeEntity.MultipleMails> GetEmployess();
       List<EmployeeEntity.MultipleMails> GetClients();
    }
}
