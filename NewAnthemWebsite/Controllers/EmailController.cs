using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Routing;

namespace AnthemWebsite.Controllers
{
    //[RoutePrefix("Email")]
    public class EmailController : Controller
    {
        //
        // GET: /Email/

        public ActionResult Index()
        {
            return View("SendEmail");
        }

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



        //[Route("~/Karma423")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Anthem423(string contactemail, string contactmessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(contactemail) && !string.IsNullOrEmpty(contactmessage))
                {

                    SendContactUsEmail(contactemail, contactmessage);
                    //TempData["EmailSent"] = "You email has been Successfully sent.";
                }


            }
            catch (Exception ex)
            {
                //TempData["EmailSent"] = ex;
            }
            return RedirectToAction("Index", "Home");
        }

        private void SendContactUsEmail(string contactemail, string contactmessage)
        {
            string smptServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            string userName = ConfigurationManager.AppSettings["uname"].ToString();
            string userPassword = ConfigurationManager.AppSettings["upass"].ToString();
            int smtpPort = 587;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smptServer;
            smtp.Port = smtpPort;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(userName, userPassword);
            MailMessage mMailMessage = new MailMessage();
            mMailMessage.From = new MailAddress("support@antheminfotech.info");
            mMailMessage.To.Add("info@antheminfotech.com");
            mMailMessage.Subject = "Contact Us Mail";
            mMailMessage.Body = "Hi<br/>You have got message from " + contactemail + ". Please find the message below:<br/><br/>" + contactmessage + "<br/><br/>Thanks";
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
            smtp.Send(mMailMessage);
        }

    }
}
