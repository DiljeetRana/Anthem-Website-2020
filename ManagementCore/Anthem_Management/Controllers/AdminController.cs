using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.BLL;
using EmployeeEntity;
using Microsoft.AspNetCore.Mvc;
using Employee.BLL.Utility;
using System.Web;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Net;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Anthem_Management.Controllers
{
    public class AdminController : Controller
    {
        bool first = true;
        static int firstUpcomingHoliday = 0;
        bool pehla = true;
        int[] firstUpcomingoc1 = new int[400];
        static int firstUpcomingoc = 0;
        EmployeeBLL employeebll = new EmployeeBLL();
        EmployeeRegisterBLL employeeregisterbll = new EmployeeRegisterBLL();
        EmployeeEntity.EmployeeEntity employees = new EmployeeEntity.EmployeeEntity();
        ClientBLL clientbll = new ClientBLL();
        EmployeeEntity.Client client = new EmployeeEntity.Client();
        PageBLL pagebll = new PageBLL();
        EmployeeEntity.Page page = new EmployeeEntity.Page();
        EmployeeEntity.ClientDetails clients = new EmployeeEntity.ClientDetails();
        ClientDetailBLL cdetailbll = new ClientDetailBLL();


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string Username = "", string password = "")
        {

            EmployeeBLL eOj = new EmployeeBLL();
            string strpass = eOj.EncryptPassword(password);
            if (employeebll.CheckUsernameAndPassword(Username, strpass) == 1)
            {

                return RedirectToAction("Home");

            }
            else
            {
                Username = string.Empty;
                ViewBag.message = "Incorrect Credentials";

            }
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpcomingOccasions()
        {
            var occasionlist = employeebll.GetUpcomingBirthdayAndAnniversary();
            for (int i = 0; i < occasionlist.Count; i++)
            {
                if (pehla)
                {
                    if (Convert.ToDateTime(occasionlist[i].Date) >= DateTime.Now)
                    {
                        firstUpcomingoc = i;
                        pehla = false;
                    }
                }
            }
            ViewBag.occasionlist = occasionlist;
            return View();
        }

        [HttpGet]
        public IActionResult HolidayList()
        {
            EmployeeBLL empBLL = new EmployeeBLL();
            var list = empBLL.GetHolidaysList();
            for (int i = 0; i < list.Count; i++)
            {
                if (first)
                {
                    if (Convert.ToDateTime(list[i].FestivalDate) >= DateTime.Now)
                    {
                        firstUpcomingHoliday = i;
                        first = false;
                    }
                }
            }
            ViewBag.HolidayList = list;
            return View();
        }

        [HttpGet]
        public IActionResult OurTeam()
        {
            var Team = employeebll.OurTeam();
            ViewBag.Team = Team;
            return View();
        }

        [HttpGet]
        public IActionResult Portfolio()
        {
            string ProjectName = null;
            ProjectsBLL projectBLL = new ProjectsBLL();
            ViewBag.ProjectList = projectBLL.GetAllProjects(ProjectName);
            return View();
        }
        protected Boolean Check5(int Publish)
        {
            return Publish == 1;
        }

        protected Boolean Check4(int Publish)
        {
            return Publish == 2;
        }

        protected Boolean Null(int Publish)
        {
            return Publish == 0;
        }

        public IActionResult AddProject()
        {
            return View();
        }

        public IActionResult Clients()
        {
            ClientDetailBLL ObClientDetails = new ClientDetailBLL();
            var List = ObClientDetails.GetClientDetailsBLL();
            ViewBag.ClientList = List;
            return View();
        }

        public IActionResult AddNewClient()
        {
            return View();
        }

        public IActionResult ClientGSTDetail()
        {
            int ClientId = 0;
            ClientDetailBLL cdetailbll = new ClientDetailBLL();
            ClientBLL clientbll = new ClientBLL();
            var record = clientbll.GetAllGstRecords(Convert.ToInt32(ClientId));
            var List = cdetailbll.GetClientNameAndId();
            ViewBag.ClientList = List;
            ViewBag.RecordList = record;
            return View();
        }

        [HttpGet]
        public IActionResult GSTDetailView(int GstId = 0)
        {
            ClientBLL clientbll = new ClientBLL();
            var gstData = clientbll.GetClientGstById(GstId);
            ViewBag.GstId = GstId;
            ViewBag.ClientName = gstData.ClientName;
            ViewBag.GstNumber = gstData.GstNo;
            ViewBag.GstAddress = gstData.GstAddress;
            ViewBag.VendorCode = gstData.VendorCode;
            ViewBag.PONumber = gstData.PONumber;
            return View();
        }

        [HttpGet]
        public IActionResult CompanyLogoManagement()
        {
            var List = clientbll.GetClients();
            ViewBag.CompanyClientList = List;
            return View();
        }

        public IActionResult DocumentLibrary()
        {
            EmployeeBLL employeebll = new EmployeeBLL();
            var List = employeebll.GetDocuments();
            ViewBag.DocumentsList = List;
            return View();
        }

        public IActionResult AddNewDocument()
        {
            return View();
        }

        public IActionResult HolidayManagement()
        {
            var list = employeebll.GetHolidaysList();
            for (int i = 0; i < list.Count; i++)
            {
                if (first)
                {
                    if (Convert.ToDateTime(list[i].FestivalDate) >= DateTime.Now)
                    {
                        firstUpcomingHoliday = i;
                        first = false;

                    }

                }
            }
            var Years = employeebll.GetYearOfHoliday();
            ViewBag.HolidayList = list;
            return View();
        }

        public IActionResult AddHoliday()
        {
            return View();
        }

        public IActionResult LeavesforApproval()
        {

            return View();
        }

        [HttpPost]
        public IActionResult LeavesforApproval(int EmployeeId = 0, string Status = "0")
        {
            EmployeeEntity.EmployeeEntity employees = new EmployeeEntity.EmployeeEntity();
            EmployeeBLL employeebll = new EmployeeBLL();
            employees.EmployeeId = EmployeeId;
            employees.Status = Status;
            var List = employeebll.GetLeaveDetailsforadmin(employees);
            ViewBag.LeaveList = List;
            return View();
        }
        public IActionResult AnthemNews()
        {
            AnthemNewsBLL anthemNewsBLL = new AnthemNewsBLL();
            var NewsList = anthemNewsBLL.GetAnthemNewses();
            ViewBag.News = NewsList;
            return View();
        }

        public IActionResult ManageVacancies()
        {
            VacancyBLL vacancyBLL = new VacancyBLL();
            var VacancyList = vacancyBLL.GetAllVacancies();
            ViewBag.VacancyList = VacancyList;
            return View();
        }

        [HttpGet]
        public IActionResult ContentManagement()
        {
            var model = new EmployeeEntity.Page();
            model = pagebll.GetPages();
            return View(model);
        }

        [HttpGet]
        public IActionResult AMCDetail()
        {
            var AMCLIST = cdetailbll.GetAMCDetails();
            ViewBag.AMCDetail = AMCLIST;
            return View();
        }

        [HttpPost]
        public IActionResult AMCDetail(int Id = 0, string AMCTitle = "", string AMCStartDate = "", string AMCEndDate = "", string PaymentMode = "", string chkpayment = "")
        {
            return View();
        }
        public IActionResult CheckPayments()
        {
            var List = cdetailbll.CheckPaymentreceived();
            ViewBag.PR = List;
            return View();
        }

        public IActionResult CheckInvoiceSent()
        {
            var List = cdetailbll.CheckInvoicenotSent();
            ViewBag.IS = List;
            return View();
        }

        public IActionResult ManageClients()
        {
            return View();
        }

        public IActionResult Dynamic()
        {
            EmployeeProjectBLL ObjEmployeeProject = new EmployeeProjectBLL();
            var List = ObjEmployeeProject.GetPages();
            ViewBag.PageList = List;
            return View();
        }

        [HttpGet]
        public IActionResult DynamicPage()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult DynamicPage(string PageName = "" , string Description = "")
        //{
        //    EmployeeProjectBLL ObjPage = new EmployeeProjectBLL();
        //    EmployeeProjectEntity Model = new EmployeeProjectEntity();
        //    return View();
        //}

        [HttpGet]
        public IActionResult AddGstDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGstDetail(string ddlName = "", string GstNo = "", string GstAddress = "", string VendorCode = "", string PONumber = "")
        {
            EmployeeEntity.Client gstClient = new EmployeeEntity.Client();
            gstClient.ClientName = ddlName;
            gstClient.GstNo = GstNo;
            gstClient.GstAddress = GstAddress;
            gstClient.VendorCode = VendorCode;
            gstClient.PONumber = PONumber;
            clientbll.AddGstDetail(gstClient);
            return RedirectToAction("ClientGSTDetail");
        }

        [HttpGet]
        public IActionResult MultipleMail()
        {
            MultipleMailsBLL Obj = new MultipleMailsBLL();
            var EList = Obj.GetEmployees();
            var CList = Obj.GetClients();
            ViewBag.EmpList = EList;
            ViewBag.ClientList = CList;
            return View();
        }

        [HttpPost]
        public bool MultipleMail(string To = "", string Subject = "", string Message = "")
        {
            string[] S1;
            var SendiD = To;
            MailMessage mm = new MailMessage();
            if (SendiD != "")
            {
                try
                {
                    var EmailId = SendiD.Split(';');

                    MailAddress fromAddress = new MailAddress("management@antheminfotech.net");
                    mm.From = fromAddress;

                    foreach (string IDs in EmailId)
                    {
                        if (IDs != "") { mm.To.Add(new MailAddress(IDs)); }

                    }
                    string htmlBody = "";
                    string headerText = "";
                    string startTable = "";
                    string emailText = "";
                    emailText += " " + Message + "";
                    string endTable = "";
                    htmlBody = headerText + startTable + emailText + endTable;
                    var datetimeshow = DateTime.Now.ToString("dd-MMM-yyyy");
                    mm.Subject = Subject + " " + datetimeshow;
                    mm.Body = htmlBody;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "rose.arvixe.com";
                    smtp.EnableSsl = false;
                    NetworkCredential NetworkCred = new NetworkCredential("emanagement@antheminfotech.net", "m@n@g3m3nt");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    mm.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        [HttpGet]
        public IActionResult AddVacancy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVacancy(string JobTitle = "", string Content = "", string IsActive = "true")
        {
            VacancyBLL vacancyBLL = new VacancyBLL();
            Vacancy vacancyData = new Vacancy();
            vacancyData.JobTitle = JobTitle;
            vacancyData.Content = Content;
            vacancyData.IsActive = Convert.ToBoolean(IsActive);
            vacancyBLL.AddNewVacancy(vacancyData);
            return RedirectToAction("ManageVacancies");
        }

        [HttpGet]
        public IActionResult EditVacancy(int vacancyId = 0)
        {
            VacancyBLL vacancyBLL = new VacancyBLL();
            var model = vacancyBLL.GetVacancyById(vacancyId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EmployeeReport()
        {
            EmployeeBLL employeeName = new EmployeeBLL();
            ViewBag.EmpList = employeeName.GetEmployeesNames();
            return View();
        }

        [HttpGet]
        public IActionResult ManauallyEmailSending()
        {
            var List = employeebll.GetEmployeesEmailId();
            ViewBag.EmpNameList = List;
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult settings()
        {
            ControlsBLL obj_Controls = new ControlsBLL();
            EmployeeBLL obj_Employee = new EmployeeBLL();
            ViewBag.To_Individual = !string.IsNullOrEmpty(obj_Controls.GetIndividualCheckoutEmail().To) ? obj_Controls.GetIndividualCheckoutEmail().To : "";
            ViewBag.CC_Individual = !string.IsNullOrEmpty(obj_Controls.GetIndividualCheckoutEmail().CC) ? obj_Controls.GetIndividualCheckoutEmail().CC : "";
            ViewBag.To_Combined = !string.IsNullOrEmpty(obj_Controls.GetCheckoutCombinedEmail().To) ? obj_Controls.GetCheckoutCombinedEmail().To : "";
            ViewBag.CC_Combined = !string.IsNullOrEmpty(obj_Controls.GetCheckoutCombinedEmail().CC) ? obj_Controls.GetCheckoutCombinedEmail().CC : "";
            ViewBag.CC_Birthday = !string.IsNullOrEmpty(obj_Controls.GetActiveEmails().CC) ? obj_Controls.GetActiveEmails().CC : "";
            ViewBag.Anniversary_CC = !string.IsNullOrEmpty(obj_Controls.GetAnniversaryEmails().CC) ? obj_Controls.GetAnniversaryEmails().CC : "";
            ViewBag.MonthlyAttendance_To = !string.IsNullOrEmpty(obj_Controls.GetMothlyAttendanceEmails().To) ? obj_Controls.GetMothlyAttendanceEmails().To : "";
            ViewBag.MonthlyAttendance_CC = !string.IsNullOrEmpty(obj_Controls.GetMothlyAttendanceEmails().CC) ? obj_Controls.GetMothlyAttendanceEmails().CC : "";
            return View();
        }
    }
}
