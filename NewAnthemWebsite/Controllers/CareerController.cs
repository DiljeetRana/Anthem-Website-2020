#region NameSpaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthemProjectBLL;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Web.Routing;
using System.IO;
using Newtonsoft.Json.Linq;
using hbehr.recaptcha;

#endregion


namespace AnthemWebsite.Controllers
{
   
    #region Class

    public class CareerController : Controller
    {
        #region Methods

        public ActionResult Index1()
        {
            VacancyBLL vacancyBLL = new VacancyBLL();
            var vacancyList = vacancyBLL.GetAllActiveVacancies();
            Session["ActiveVacanciesCount"] = vacancyBLL.GetActiveVacanciesCount();
            return View(vacancyList);
        }

        public ActionResult Index()
        {
            return View();
        }
        #endregion

        [HttpGet]
        public ActionResult SendEmail()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SendEmail(string name, string email, string number, string LastEmployedAt, string expYears, string expMonth, string postApply, string SelectJoining, string textArea, HttpPostedFileBase File)
        {
            
            string htmlBody = "";
            string headerText = "Hi,";
            string startTable = "<table>";
            string emailText = "<tr><td><br/>I am interested to work in your company. Please find my resume attached with this message and details about me below.</br></br></td></tr>";
            emailText += "<tr><td>Name:<b> " + name + "</b></td></tr>";
            emailText += "<tr><td>Email address:<b> " + email + "</b></td></tr>";
            emailText += "<tr><td>Contact number:<b> " + number + "</b></td></tr>";
            emailText += "<tr><td>Post applying for:<b> " + postApply + "</b></td></tr>";
            if (expMonth == "null" && expYears == "null")
            {
                emailText += "<tr><td>Experience :<b> " + "Fresher " + "</b></td></tr>";
            }
            else if (expMonth == "null" && expYears == "0")
            {
                emailText += "<tr><td>Experience :<b> " + "Fresher " + "</b></td></tr>";
            }
            else
            {
                emailText += "<tr><td>Experience :<b> " + expYears + "Year " + expMonth + "Month" + "</b></td></tr>";
            }

            emailText += "<tr><td>Currently working at:<b> " + LastEmployedAt + "</b></td></tr>";
            emailText += "<tr><td>Joining period:<b> " + SelectJoining + "</b></td></tr>";
            emailText += "<tr><td>Cover Letter:<b> " + textArea + "</b></td></tr>";
            emailText += "<tr><td>" + GetBrowserVersion() + "</td></tr>";
            string endTable = "<br/></table> </br> </br> Thanks";
            htmlBody = headerText + startTable + emailText + endTable;



            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("support@antheminfotech.info");
                message.From = fromAddress;
                message.To.Add("jobs@antheminfotech.com");
                message.Subject = "Job Application For " + postApply;
                message.IsBodyHtml = true;
                message.Body = htmlBody;


                MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(File.FileName));
                Attachment myAttachment = new Attachment(Request.Files[0].InputStream, Request.Files[0].FileName);
                Attachment attachment = new Attachment(stream, "document.docx");
                message.Attachments.Add(myAttachment);
                smtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["uname"].ToString(), ConfigurationManager.AppSettings["upass"].ToString());

                smtpClient.Send(message);
                ViewBag.ShowMessage = "Success";
            }
            catch (Exception ex)
            {
                ViewBag.ShowMessage = "Error";
            }
            return View();
        }


        public string GetBrowserVersion()
        {
            HttpBrowserCapabilities browser = System.Web.HttpContext.Current.Request.Browser;
            string s = " Browsed In: " + browser.Type + ","
                + " Name: " + browser.Browser + ","
                + " Version: " + browser.Version;

            return s;
        }
    }
    #endregion
}


