using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using System.IO;
using System.Data;

namespace SQLEmployee.DLL.Interface
{
    public interface IEmployee
    {
        //string Encrypt(string plainText, string passPhrase);
        string EncryptPassword(string password);
        string DecryptPassword(string encryptpass);
        
        List<EmployeeEntity.EmployeeEntity> GetEmployees();
        List<EmployeeEntity.EmployeeEntity> GetFilteredEmployees();
         string AddEmployees(EmployeeEntity.EmployeeEntity employee);
        string updateemp(EmployeeEntity.EmployeeEntity employee); 
        string updateLeaveRequest(EmployeeEntity.EmployeeEntity employee);
        List<EmployeeEntity.EmployeeEntity> GetStatusIdAndName();
         List<EmployeeEntity.EmployeeEntity> GetGradeIdAndName();
        
        List<EmployeeEntity.EmployeeEntity> GetLeaveDetails(EmployeeEntity.EmployeeEntity employees); 
        List<EmployeeEntity.EmployeeEntity> checkforleaverequest(EmployeeEntity.EmployeeEntity employees);
        List<EmployeeEntity.EmployeeEntity> GetLeaveDetailsforadmin(EmployeeEntity.EmployeeEntity employees);
        List<EmployeeEntity.EmployeeEntity> Getnameforadmin(EmployeeEntity.EmployeeEntity employees);
        string InsertLeaveDetails(EmployeeEntity.EmployeeEntity employee); 
         EmployeeEntity.EmployeeEntity getOfficeEmail(int userId); 
        EmployeeEntity.EmployeeEntity getdetailstosendmail(EmployeeEntity.EmployeeEntity employees);

        string DeleteEmployee(long employeeid);
         EmployeeEntity.EmployeeEntity GetEmployeeDetailsById(long employeeid);
         EmployeeEntity.EmployeeEntity GetEmployeeById(long employeeid);
         int CheckUsernameAndPassword(string username, string password);
         Stream DisplayImage(long employeeid);
         string UpdateEmployee(EmployeeEntity.EmployeeEntity employeeentity);
         DataTable EmployeesReportInExcel();
        //DataTable GetUpcomingBirthdayAndAnniversary();
        List<EmployeeEntity.EmployeeEntity> GetUpcomingBirthdayAndAnniversary();
        List<HolidayEnitity> GetHolidaysList();
         List<HolidayEnitity> GetYearOfHoliday();
         List<HolidayEnitity> GetHolidaysByYear(string year);
         int DeleteHolidayById(int holidayid);
         string AddHolidays(HolidayEnitity holidayentity);
         HolidayEnitity GetFestivalNameAndDateById(int holidayid);
         string UpdateHoliday(HolidayEnitity holidayentity);
         List<EmployeeEntity.EmployeeEntity> TodayOccasions();
         List<EmployeeEntity.EmployeeEntity> OurTeam();
         DataTable SendEmailToTodayOccasions();
         List<EmployeeEntity.EmployeeEntity> GetEmployeesEmailId();
         EmployeeEntity.EmployeeEntity GetEmailIdByEmployeeId(long employeeid);
         int ChangeAdminPassword(EmployeeEntity.EmployeeEntity employee);
         List<EmployeeEntity.EmployeeEntity> EmployeesLoginDetails();
         EmployeeEntity.EmployeeEntity EmployeeForgotPassword(string username);
         int EmployeeChangePassword(EmployeeEntity.EmployeeEntity employee);
         string AddDoc(DocumentEntity DocumentEntity);
         List<EmployeeEntity.EmployeeEntity> GetDocuments();
         string UpdateDoc(DocumentEntity DocumentEntity);
         int DeleteDoc(int DocId);
         List<DocumentEntity> GetDocumentsById(int DocId);
         EmployeeEntity.EmployeeEntity GetEmployeeDetailByEmail(string email);
         void GenratePassword(EmployeeEntity.EmployeeEntity employee);
         EmployeeEntity.EmployeeEntity GetEmployeePassword(string officeemail);
         string UpdateUsedOTP(int employeeid,string otp);
         List<EmployeeEntity.EmployeeEntity> GetEmployeesNames();
         List<EmployeeEntity.EmployeeEntity> ActiveMembersEmail();
         EmployeeEntity.EmployeeEntity GetLoginNew(string Mail );
         bool InsertException(string ex, string uploadImage);
        DataTable GetWorkAnniversary(string currYear, string currMon);
    }
}
