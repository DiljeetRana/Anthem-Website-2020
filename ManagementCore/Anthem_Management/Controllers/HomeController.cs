using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.BLL;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Anthem_Management.Controllers
{

    public class HomeController : Controller
    {
        bool first = true;
        static int firstUpcomingHoliday = 0;
        bool pehla = true;
        int[] firstUpcomingoc1 = new int[400];
        static int firstUpcomingoc = 0;

        [HttpGet]
        public IActionResult LoginNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginNew(string username = "", string password = "")
        {

            EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
            EmployeeBLL empBLL = new EmployeeBLL();
            var usermail = username;
            var userpass = password;
            var result = empBLL.GetLoginNew(usermail);
            if (userpass == result.password)
            {
                employee = empBLL.GetLoginNew(usermail);
                string name = employee.Name;
                int activeid = employee.ActiveId;
                long EmployeeId = employee.EmployeeId;
                return RedirectToAction("EmployeesHome");

            }
            else
            {
                ViewBag.message = "Incorrect Credentials.";
            }
            return View();
        }
        [HttpGet]
        public IActionResult EmployeesHome()
        {
            EmployeeBLL empBLL = new EmployeeBLL();
            var list = empBLL.GetHolidaysList();
            AnthemNewsBLL anthemNewsBLL = new AnthemNewsBLL();
            var newse = anthemNewsBLL.GetAnthemNewsestopFive();
            var occasionlist = empBLL.GetUpcomingBirthdayAndAnniversary();
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
            ViewBag.occasionlist = occasionlist;
            ViewBag.News = newse;
            ViewBag.HolidayList = list;
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            EmployeeBLL empBLL = new EmployeeBLL();
            var occasionlist = empBLL.GetUpcomingBirthdayAndAnniversary();
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
      

    }
}
