using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DriveMe.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Route", action = "Get", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Driver",
               url: "api/driver/{controller}/{action}/{id}",
               defaults: new { controller = "Driver", action = "Get", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Passenger",
               url: "api/passenger/{controller}/{action}/{id}",
               defaults: new { controller = "Passenger", action = "Get", id = UrlParameter.Optional }
           );
        }
    }
}
