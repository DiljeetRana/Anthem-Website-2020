using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
   public interface IAttendance
    {
       List<EmployeeEntity.Attendance> GetAttendance(long employeeid);
       int AddAttendance(EmployeeEntity.Attendance attendance);
       int OutTimeAttendance(EmployeeEntity.Attendance attendance);
       int AddMissingAttendance(EmployeeEntity.Attendance attendance);
       int CheckTodayAttendance(long employeeid);
       DataTable GetEmployeesWhoSkipAttendance();
       List<EmployeeEntity.EmployeeEntity> GetEmployeesDetailsWhoSkipAttendanceFrom5Days();
    }
}
