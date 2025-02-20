using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.DataAccess;
using System.Data;

namespace SQLEmployee.DLL.Interface
{
   public interface ILeave
    {
       int AddLeave(EmployeeEntity.Leave leave);
       List<EmployeeEntity.Leave> GetLeavesByEmployeeId(long employeeid);
       int CancelLeaveByLeaveId(int leave);
       DataTable GetEmployeeEmailByEmployeeId(long employeeid);
       DataTable GetDetailsOfCancelsLeavesByLeaveId(int leaveid);
    }
}
