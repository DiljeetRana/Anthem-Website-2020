using AnthemProjectBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Routing;
using System.IO;
using Newtonsoft.Json.Linq;
using hbehr.recaptcha;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Net.Http;

namespace NewAnthemWebsite.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            var list = projectBLL.GetAllProjects().AsQueryable<AnthemEntites.Projects>();
            ViewBag.TopEight = list.Take(9).AsEnumerable().Reverse().Skip(1).ToList();
            ViewBag.Mobile = list.Where(x => x.ProjectCategory.ToUpper() == "MOBILE").Take(8).ToList();
            ViewBag.Website = list.Where(x => x.ProjectCategory.ToUpper() == "WEBSITE").Take(8).ToList();
            ViewBag.Technology = list;
            VacancyBLL vacancyBLL = new VacancyBLL();

            Session["ActiveVacanciesCount"] = vacancyBLL.GetActiveVacanciesCount();
            return View();
        }
        public ActionResult _Header()
        {
            return PartialView("_Header");
        }

        public ActionResult _Footer()
        {
            return PartialView("_Footer");
        }

        public ActionResult AboutUs()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            var photo = projectBLL.GetAllEmployees();
            ClientBLL clientBLL = new ClientBLL();
            ViewBag.Clients = clientBLL.GetAllClients();
            foreach (var item in photo)
            {
                byte[] ar = new byte[50000000];
                ar = (byte[])(item.Picture);
                string imreBase64Data = Convert.ToBase64String(ar);
                string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                item.Image = imgDataURL;
                /*byteArrayToImage(ar);*/
            }
            ViewBag.TeamList = photo;
            return View();
        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
        //    ms.Seek(0, SeekOrigin.Begin);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        public ActionResult AspDotnetApplication()
        {
            return View();
        }

        public ActionResult SoftwareDevelopment()
        {
            return View();
        }

        public ActionResult SoftwareMaintenance()
        {
            return View();
        }

        public ActionResult SearchEngineOptimization()
        {
            return View();
        }

        public ActionResult MobileAppDevelopment()
        {
            return View();
        }

        public ActionResult WebsiteDesigningService()
        {
            return View();
        }  
        public ActionResult ChatBot()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ViewProject(string projectname)
        {
            ProjectBLL projectBLL = new ProjectBLL();
            string[] ProjectSubCategory = projectname.Split(',');
            string actualprojectname = ProjectSubCategory[0];
            string PName = actualprojectname.Replace('-', ' ');
            string PCategory = ProjectSubCategory[1];
            var data = projectBLL.GetProjectDetailsByProjectName(PName);
            ViewBag.ProjectCategory = projectBLL.GetProjectByCategory(PCategory);
            if (data.ProjectID > 0)
            {
                ViewBag.ProjectImages = projectBLL.GetAllProjectImagesByProjectId(data.ProjectID);

                VacancyBLL vacancyBLL = new VacancyBLL();
                Session["ActiveVacanciesCount"] = vacancyBLL.GetActiveVacanciesCount();

                return View(data);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OurServices()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string response)
        {
            RECaptcha recaptcha = new RECaptcha();
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptcha.Secret + "&response=" + response;
            recaptcha.Response = (new WebClient()).DownloadString(url);
            return Json(recaptcha);
        }
        [HttpPost]
        public JsonResult AjaxMethod1(string response)
        {
            RECaptcha1 recaptcha1 = new RECaptcha1();
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptcha1.Secret + "&response=" + response;
            recaptcha1.Response = (new WebClient()).DownloadString(url);
            return Json(recaptcha1);
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
                MailAddress fromAddress = new MailAddress("support@antheminfotech.info  ");
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

        public ActionResult Industries()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            if (Session["SaveMsg"] != null)
            {
                ViewBag.SaveMsg = Session["SaveMsg"].ToString();
                Session["SaveMsg"] = null;
            }
            return View();
        }

       
        //public ActionResult ContactUs(string Name = "", string Email = "", string Phone = "", string Message = "")
        //{
        //    SendEmailforContactUs(Name, Email, Phone, Message);
        //    return View();
        //}
        [HttpPost]
        public ActionResult SendEmailforContactUs(string Name="", string Email="", string Phone="", string Message="")
        {

            string htmlBody = "";
            string headerText = "Hi,";
            string startTable = "<table>";
            string emailText = "<tr><td><br/>Someone Contact You With below details.</br></br></td></tr>";
            emailText += "<tr><td>Name:<b> " + Name + "</b></td></tr>";
            emailText += "<tr><td>Email address:<b> " + Email + "</b></td></tr>";
            emailText += "<tr><td>Contact number:<b> " + Phone + "</b></td></tr>";
            emailText += "<tr><td>Message:<b> " + Message + "</b></td></tr>";
            string endTable = "<br/></table> </br> </br> Thanks";
            htmlBody = headerText + startTable + emailText + endTable;
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("support@antheminfotech.info");
                message.From = fromAddress;
                message.To.Add("info@antheminfotech.com");
                message.Subject = "Contact Us";
                message.IsBodyHtml = true;
                message.Body = htmlBody;
                //smtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();   // We use gmail as our smtp client
                smtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["uname"].ToString(), ConfigurationManager.AppSettings["upass"].ToString());
                smtpClient.Send(message);
                Session["SaveMsg"] = "Thanks for contacting us! We will be in touch with you shortly.";
                return RedirectToAction("ContactUs", "Home");
            }
            catch(Exception ex)
            {
                //ViewBag.MailReplyMsg = "Mail not sent";
                //return RedirectToAction("Index", "Home");
                Session["SaveMsg"] = ex.Message;
                Console.WriteLine(ex.Message);
                return RedirectToAction("ContactUs", "Home");
               
            }

        }



        //ChatGpt response save 
        [HttpPost]
        public ActionResult SendEmailforChatgpt(string IPAddress = "", string Question = "")
        {

            ProjectBLL projectBLL = new ProjectBLL();
            try
            { 

              projectBLL.InsertChatgptDetails(IPAddress, Question);
             return RedirectToAction("Index", "Home");

            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //[HttpPost]
        //public ActionResult UploadImage(string customName)
        //{
        //    try
        //    {
        //        var file = Request.Files[0];

        //        if (file == null || file.ContentLength == 0)
        //        {
        //            return Json("No files were uploaded.");
        //        }

        //        // Process and save the image with the custom name
        //        string uniqueFileName = string.IsNullOrEmpty(customName)
        //            ? Guid.NewGuid().ToString() + Path.GetExtension(file.FileName)
        //            : customName + Path.GetExtension(file.FileName);

        //        string imagePath = Path.Combine(Server.MapPath("~/PortfolioImages"), uniqueFileName);

        //        file.SaveAs(imagePath);

        //        return Json("Image uploaded successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("An error occurred during image upload: " + ex.Message);
        //    }
        //}

        [HttpGet]
        public JsonResult GetMessage()
        {
            var message = new { Message = "Hello" };
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult TechnologyStack()
        {
            return View();
        }

    }
}

public class CaptchaResponse
{
    [Newtonsoft.Json.JsonProperty("success")]
    public Boolean Success { get; set; }
    [Newtonsoft.Json.JsonProperty("error-codes")]
    public List<string> ErrorCodes { get; set; }
}
//public class RECaptcha
//{
//    public string Key = "6Ld8Gs8ZAAAAAK2BaZ2nS23_PdUnXhUFyxJuLXNn";
//    public string Secret = "6Ld8Gs8ZAAAAALX5r_V5jkx0qykc848wj53QU2V1";
//    public string Response { get; set; }
//}
public class RECaptcha
{
    public string Key = "6Ld8Gs8ZAAAAAK2BaZ2nS23_PdUnXhUFyxJuLXNn";
    public string Secret = "6Ld8Gs8ZAAAAALX5r_V5jkx0qykc848wj53QU2V1";
    public string Response { get; set; }
}
public class RECaptcha1
{
    //public string Key = "6Ld8Gs8ZAAAAAK2BaZ2nS23_PdUnXhUFyxJuLXNn";
    public string Secret = "6Ld2yKopAAAAANosiTb0oIYHAhsMXshj5Lgf4zlB";
    public string Response { get; set; }
}