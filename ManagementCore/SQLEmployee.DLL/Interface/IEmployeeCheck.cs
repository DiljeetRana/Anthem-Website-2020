using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using System.Data;

namespace SQLEmployee.DLL.Interface
{
    public interface IEmployeeCheck
    {
        void EmployeeCheckIn(EmployeeCheckEntity CheckIn);
        int EmployeeCheckConfirm(int employeeid);
        void EmployeeCheckOut(EmployeeCheckEntity CheckOut);
        List<EmployeeCheckEntity> GetCurrentMonthCheckOfEmployee(int imployeeid);
        string GetEmployeeOfficeEmailById(int employeeid);
        EmployeeCheckEntity GetTodayCheckInAndOutOfEmployee(int employeeid);
        int MarkOnLeave(EmployeeCheckEntity Check);
        List<EmployeeCheckEntity> GetEmployeeLeaveAndCheckStatus(int employeeId);
        EmployeeCheckEntity GetLeavedetailofEmployee(int checkid);
        string UpdateEmployeeLeaveDetail(EmployeeCheckEntity check);
        string DeleteEmployeeleaveDetail(int checkid);
        List<EmployeeCheckEntity> GetDateOfleave(int employeeid);
        DataTable SendWorkReportEmail();
        List<EmployeeCheckEntity> GetEmployeeNotCheckInMail();
      
        List<EmployeeCheckEntity> GetWorkStatusList(int employeeid, int year, int month,int day );
        //List<EmployeeCheckEntity> GetDailyInformationOfEmployee();
        List<EmployeeCheckEntity> GetActiveEmployeeNames();
        DataSet GetAttendanceOfLastThirtyDays(string starttime, string endtime);
        DataSet GetMonthlyAttendanceReport(string starttime, string endtime);
        string GetWorkingHourOfEmployee(int employeeid, string date);
        EmployeeCheckEntity GetCheckinDetailOfEmployeeeBasedOnGivenDate(int employeeid, string date);
        List<EmployeeCheckEntity> GetFestivalDetail();
        List<EmployeeCheckEntity> GetDetails();


    }

}
