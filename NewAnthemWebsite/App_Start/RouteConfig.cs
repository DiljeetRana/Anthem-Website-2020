using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewAnthemWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
               name: "OurWork",
               url: "OurWork/{id}",
               defaults: new { controller = "OurWork", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Career",
               url: "Career/{id}",
               defaults: new { controller = "Career", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}
