using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthemProjectBLL;
using AnthemEntites;

namespace AnthemWebsite.Controllers
{
   
    public class OurWorkController : Controller
    {
        // GET: OurWork
       // [Route("{url}")]
        public ActionResult Index(string s = "")
        {
            ProjectBLL projectBLL = new ProjectBLL();
            CategoriesBLL categoriesBLL = new CategoriesBLL();
            var list = projectBLL.GetAllProjectsByQuerystring(s);
            ViewBag.searchlist = s;
            ViewBag.AllProjects = projectBLL.GetAllProjects();
            ViewBag.Categories = categoriesBLL.GetAllCategories();
            ViewBag.Responsive = categoriesBLL.Responsive();
            ViewBag.ASPNetDevelopment = categoriesBLL.ASPNetDevelopment();
            ViewBag.MVC = categoriesBLL.MVC();
            ViewBag.WordPress = categoriesBLL.WordPress();
            ViewBag.HTML5 = categoriesBLL.HTML5();
            ViewBag.Mobile = categoriesBLL.Mobile();
            ViewBag.CSS = categoriesBLL.CSS();
            ViewBag.JQuery = categoriesBLL.JQuery();
            
            return View(list);
        }
        
    }
}
