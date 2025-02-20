using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.DataAccess;
using SQLEmployee.DLL.Interface;
using System.Data;

namespace Employee.BLL
{
   public class LeaveBLL
    {
       ILeave ileave;
       public LeaveBLL()
       {
           ileave = new SQLEmployee.DLL.DataAccess.Leave();
       }

       public int AddLeave(EmployeeEntity.Leave leave)
       {
           return ileave.AddLeave(leave);
       }

       public List<EmployeeEntity.Leave> GetLeavesByEmployeeId(long employeeid)
       {
           return ileave.GetLeavesByEmployeeId(employeeid);
       }

       public int CancelLeaveByLeaveId(int leave)
       {
           return ileave.CancelLeaveByLeaveId(leave);
       }

       public DataTable GetEmployeeEmailByEmployeeId(long employeeid)
       {
           return ileave.GetEmployeeEmailByEmployeeId(employeeid);
       }

       public DataTable GetDetailsOfCancelsLeavesByLeaveId(int leaveid)
       {
           return ileave.GetDetailsOfCancelsLeavesByLeaveId(leaveid);
       }

    }
}
