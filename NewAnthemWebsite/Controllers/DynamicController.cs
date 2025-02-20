using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthemProjectBLL;

namespace AnthemWebsite.Controllers
{
    public class DynamicController : Controller
    {
        

        [HttpGet]
        //[ValidateInput(false)]
        [Route("{url}")]

        public ActionResult DynamicPage(string url)
        {
            
            ProjectBLL projectBLL = new ProjectBLL();
            var data = projectBLL.GetViewPage(url);

            VacancyBLL vacancyBLL = new VacancyBLL();
            Session["ActiveVacanciesCount"] = vacancyBLL.GetActiveVacanciesCount();

            return View(data);

        }
        
    }
        
}