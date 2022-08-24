using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebGISMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Web", action = "first" }
            );

            //routes.MapRoute(
            //    name: "sample",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Web", action = "MainPage" }
            //);
        }
    }
}
