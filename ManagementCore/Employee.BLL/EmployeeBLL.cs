using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using SQLEmployee.DLL.Interface;
using SQLEmployee.DLL.DataAccess;
using System.IO;
using System.Data;

namespace Employee.BLL
{
    public class EmployeeBLL
    {
        IEmployee Iemployee;

        public EmployeeBLL()
        {
            Iemployee = new SQLEmployee.DLL.DataAccess.SQLEmployee();
        }
      

        public string EncryptPassword(string password)
        {

            return Iemployee.EncryptPassword(password);
        }
        public string DecryptPassword(string password)
        {

            return Iemployee.DecryptPassword(password);
        }
       
        public List<EmployeeEntity.EmployeeEntity> GetEmployees()
        {
            return Iemployee.GetEmployees();
        }

        public List<EmployeeEntity.EmployeeEntity> GetFilteredEmployee()
        {
            return Iemployee.GetFilteredEmployees();
        }
        public string AddEmployees(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.AddEmployees(employee);
        }
        public string updateemp(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.updateemp(employee);
        }
        public string updateLeaveRequest(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.updateLeaveRequest(employee);
        }
        public string InsertLeaveDetails(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.InsertLeaveDetails(employee);
        }
      

        public List<EmployeeEntity.EmployeeEntity> GetStatusIdAndName()
        {
            return Iemployee.GetStatusIdAndName();
        }

        
        public List<EmployeeEntity.EmployeeEntity> GetGradeIdAndName()
        {
            return Iemployee.GetGradeIdAndName();
        }
        public List<EmployeeEntity.EmployeeEntity> GetLeaveDetails(EmployeeEntity.EmployeeEntity employees)
        {
            return Iemployee.GetLeaveDetails(employees);
        }
        public List<EmployeeEntity.EmployeeEntity> checkforleaverequest(EmployeeEntity.EmployeeEntity employees)
        {
            return Iemployee.checkforleaverequest(employees);
        }
        
        public List<EmployeeEntity.EmployeeEntity> GetLeaveDetailsforadmin(EmployeeEntity.EmployeeEntity employees)
        {
            return Iemployee.GetLeaveDetailsforadmin(employees);
        }
        public List<EmployeeEntity.EmployeeEntity> Getnameforadmin(EmployeeEntity.EmployeeEntity employees)
        {
            return Iemployee.Getnameforadmin(employees);
        }
        public EmployeeEntity.EmployeeEntity getOfficeEmail(int userId)
        {
            return Iemployee.getOfficeEmail(userId);
        }
        
        public EmployeeEntity.EmployeeEntity getdetailstosendmail(EmployeeEntity.EmployeeEntity employees)
        {
            return Iemployee.getdetailstosendmail(employees);
        }

        public string DeleteEmployee(long employeeid)
        {
            return Iemployee.DeleteEmployee(employeeid);
        }

        public EmployeeEntity.EmployeeEntity GetEmployeeDetailsById(long employeeid)
        {
            return Iemployee.GetEmployeeDetailsById(employeeid);
        }

        public EmployeeEntity.EmployeeEntity GetEmployeeById(long employeeid)
        {
            return Iemployee.GetEmployeeById(employeeid);
        }

        public int CheckUsernameAndPassword(string username, string password)
        {
            return Iemployee.CheckUsernameAndPassword(username, password);
        }

        public Stream DisplayImage(long employeeid)
        {
            return Iemployee.DisplayImage(employeeid);
        }

        public string UpdateEmployee(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.UpdateEmployee(employee);
        }

        public DataTable EmployeesReportInExcel()
        {
            return Iemployee.EmployeesReportInExcel();
        }

        //public DataTable GetUpcomingBirthdayAndAnniversary()
        //{
        //    return Iemployee.GetUpcomingBirthdayAndAnniversary();
        //}
        public List<EmployeeEntity.EmployeeEntity> GetUpcomingBirthdayAndAnniversary()
        {
            return Iemployee.GetUpcomingBirthdayAndAnniversary();
        }
        public List<HolidayEnitity> GetHolidaysList()
        {
            return Iemployee.GetHolidaysList();
        }

        public List<HolidayEnitity> GetYearOfHoliday()
        {
            return Iemployee.GetYearOfHoliday();
        }

        public List<HolidayEnitity> GetHolidaysByYear(string year)
        {
            return Iemployee.GetHolidaysByYear(year);
        }

        public int DeleteHolidayById(int holidayid)
        {
            return Iemployee.DeleteHolidayById(holidayid);
        }

        public string AddHolidays(HolidayEnitity holidayentity)
        {
            return Iemployee.AddHolidays(holidayentity);
        }

        public HolidayEnitity GetFestivalNameAndDateById(int holidayid)
        {
            return Iemployee.GetFestivalNameAndDateById(holidayid);
        }

        public string UpdateHoliday(HolidayEnitity holidayentity)
        {
            return Iemployee.UpdateHoliday(holidayentity);
        }

        public List<EmployeeEntity.EmployeeEntity> TodayOccasions()
        {
            return Iemployee.TodayOccasions();
        }

        public List<EmployeeEntity.EmployeeEntity> OurTeam()
        {
            return Iemployee.OurTeam();
        }

        public DataTable SendEmailToTodayOccasions()
        {
            return Iemployee.SendEmailToTodayOccasions();
        }

        public List<EmployeeEntity.EmployeeEntity> GetEmployeesEmailId()
        {
            return Iemployee.GetEmployeesEmailId();
        }

        public EmployeeEntity.EmployeeEntity GetEmailIdByEmployeeId(long employeeid)
        {
            return Iemployee.GetEmailIdByEmployeeId(employeeid);
        }

        public int ChangeAdminPassword(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.ChangeAdminPassword(employee);
        }

        public List<EmployeeEntity.EmployeeEntity> EmployeesLoginDetails()
        {
            return Iemployee.EmployeesLoginDetails();
        }

        public EmployeeEntity.EmployeeEntity EmployeeForgotPassword(string username)
        {
            return Iemployee.EmployeeForgotPassword(username);
        }

        public int EmployeeChangePassword(EmployeeEntity.EmployeeEntity employee)
        {
            return Iemployee.EmployeeChangePassword(employee);
        }
        //public string AddDoc(EmployeeEntity.DocumentEntity Name)
        //{
        //    return Iemployee.AddDoc(Name);
        //}

        public List<EmployeeEntity.EmployeeEntity> GetDocuments()
        {

            return Iemployee.GetDocuments();
        }


        //public List<DocumentEntity> GetDocumentsById(int DocId)
        //{

        //    return Iemployee.GetDocumentsById(DocId);
        //}

        //public string UpdateDoc(EmployeeEntity.DocumentEntity Name)
        //{

        //    return Iemployee.UpdateDoc(Name);
        //}
        public int DeleteDoc(int DocId)
        {
            return Iemployee.DeleteDoc(DocId);
        }
        public EmployeeEntity.EmployeeEntity GetEmployeeDetailByEmail(string email)
        {
            return Iemployee.GetEmployeeDetailByEmail(email);
        }
        public void GenratePassword(EmployeeEntity.EmployeeEntity employee)
        {
            Iemployee.GenratePassword(employee);
        }
         public EmployeeEntity.EmployeeEntity GetEmployeePassword(string officeemail)
        {
            return Iemployee.GetEmployeePassword(officeemail);
        }

         public string UpdateUsedOTP(int employeeid, string otp)
         {
             return Iemployee.UpdateUsedOTP(employeeid,otp);
         }
        public List<EmployeeEntity.EmployeeEntity> GetEmployeesNames()
        {
            return Iemployee.GetEmployeesNames();
        }
        //underdeveloped method
        public List<EmployeeEntity.EmployeeEntity> GetActiveEmails()
        {
            return Iemployee.ActiveMembersEmail();
        }
       public EmployeeEntity.EmployeeEntity GetLoginNew(string  Mail)
        {
            return Iemployee.GetLoginNew(Mail);
        }
        public bool InsertException(string ex,string uploadImage)
        {
            return Iemployee.InsertException(ex, uploadImage);
        }

        public DataTable GetWorkAnniversary(string currYear,string currMon)
        {
            return Iemployee.GetWorkAnniversary(currYear, currMon);
        }
    }
}



