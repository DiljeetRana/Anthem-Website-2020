using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using EmployeeEntity;
using System.Data;

namespace Employee.BLL
{
    public class EmployeeCheckBLL
    {
        IEmployeeCheck Iemployeecheck;
        public EmployeeCheckBLL()
        {
            Iemployeecheck = new SQLEmployee.DLL.DataAccess.EmployeeCheck();
        }
        public void EmployeeCheckIn(EmployeeCheckEntity CheckIn)
        {
            Iemployeecheck.EmployeeCheckIn(CheckIn);
        }
        public int EmployeeCheckConfirm(int employeeid)
        {
            return Iemployeecheck.EmployeeCheckConfirm(employeeid);
        }
        public void EmployeeCheckOut(EmployeeCheckEntity CheckOut)
        {
            Iemployeecheck.EmployeeCheckOut(CheckOut);
        }

        public List<EmployeeCheckEntity> GetCurrentMonthCheckOfEmployee(int imployeeid)
        {
           return Iemployeecheck.GetCurrentMonthCheckOfEmployee(imployeeid);
        }
        public string GetEmployeeOfficeEmailById(int employeeid)
        {
            return Iemployeecheck.GetEmployeeOfficeEmailById(employeeid);
        }
        public EmployeeCheckEntity GetTodayCheckInAndOutOfEmployee(int employeeid)
        {
            return Iemployeecheck.GetTodayCheckInAndOutOfEmployee(employeeid);
        }
        public int MarkOnLeave(EmployeeCheckEntity Check)
        {
            return Iemployeecheck.MarkOnLeave(Check);
        }

        public List<EmployeeCheckEntity> GetEmployeeLeaveAndCheckStatus(int employeeId)
        {
            return Iemployeecheck.GetEmployeeLeaveAndCheckStatus(employeeId);        
        }

        public EmployeeCheckEntity GetLeavedetailofEmployee(int checkid)
        {
            return Iemployeecheck.GetLeavedetailofEmployee(checkid);
        }

        public string UpdateEmployeeLeaveDetail(EmployeeCheckEntity check)
        {
            return Iemployeecheck.UpdateEmployeeLeaveDetail(check);
        }

        public string DeleteEmployeeleaveDetail(int checkid)
        {
            return Iemployeecheck.DeleteEmployeeleaveDetail(checkid);
        }

        public List<EmployeeCheckEntity> GetDateOfleave(int employeeid)
        {
            return Iemployeecheck.GetDateOfleave(employeeid);
        }
        public DataTable SendWorkReportEmail()
        {
            return Iemployeecheck.SendWorkReportEmail();
        }
        public List<EmployeeCheckEntity> GetSendMailEmplyeeNotCheckIn()
        {
            return Iemployeecheck.GetEmployeeNotCheckInMail();
        }
      
        public List<EmployeeCheckEntity> GetWorkStatusList(int employeeid, int year, int month, int day )
        {
            return Iemployeecheck.GetWorkStatusList(employeeid, year, month, day);
        }
        public List<EmployeeCheckEntity> GetActiveEmployeeNames()
        {
            return Iemployeecheck.GetActiveEmployeeNames(); 
        }

        public DataSet GetAttendanceOfLastThirtyDays(string starttime, string endtime)
        {
            return Iemployeecheck.GetAttendanceOfLastThirtyDays(starttime,endtime);
        }

        public DataSet GetMonthlyAttendanceReport(string starttime, string endtime)
        {
            return Iemployeecheck.GetMonthlyAttendanceReport(starttime, endtime);
        }

        public string sp_GetWorkingHourOfEmployee(int employeeid, string date)
        {
            return Iemployeecheck.GetWorkingHourOfEmployee(employeeid, date);
        }


        public EmployeeCheckEntity GetCheckinDetailOfEmployeeeBasedOnGivenDate(int employeeid, string date)
        {
            return Iemployeecheck.GetCheckinDetailOfEmployeeeBasedOnGivenDate(employeeid, date);
        }
        public List<EmployeeCheckEntity> GetFestivalDetail()
        {
            return Iemployeecheck.GetFestivalDetail();
        }
        public List<EmployeeCheckEntity> GetDetails()
        {
            return Iemployeecheck.GetDetails();
        }


    }
}
