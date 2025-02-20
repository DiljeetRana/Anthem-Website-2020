using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using System.Data;

namespace Employee.BLL
{
   public class AttendanceBLL
    {
       IAttendance IAttendance;
       public AttendanceBLL()
       {
           IAttendance = new SQLEmployee.DLL.DataAccess.SQLAttendance();
       }

       public List<EmployeeEntity.Attendance> GetAttendance(long employeeid)
       {
           return IAttendance.GetAttendance(employeeid);
       }

       public int AddAttendance(EmployeeEntity.Attendance attendance)
       {
           return IAttendance.AddAttendance(attendance);
       }

       public int OutTimeAttendance(EmployeeEntity.Attendance attendance)
       {
           return IAttendance.OutTimeAttendance(attendance);
       }

       public int AddMissingAttendance(EmployeeEntity.Attendance attendance)
       {
           return IAttendance.AddMissingAttendance(attendance);
       }

       public int CheckTodayAttendance(long employeeid)
       {
           return IAttendance.CheckTodayAttendance(employeeid);
       }

       public DataTable GetEmployeesWhoSkipAttendance()
       {
           return IAttendance.GetEmployeesWhoSkipAttendance();
       }

       public List<EmployeeEntity.EmployeeEntity> GetEmployeesDetailsWhoSkipAttendanceFrom5Days()
       {
           return IAttendance.GetEmployeesDetailsWhoSkipAttendanceFrom5Days();
       }
    }
}
