using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MonPanier
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "RegionMap",
                url: "Region",
                defaults: new { controller = "Commander", action = "Index" }
            );

            routes.MapRoute(
                name: "RegionSelect",
                url: "Region/{idRegion}/{action}/{id}",
                defaults: new { controller = "Commander", action = "Index", id = UrlParameter.Optional },
                constraints: new { idRegion = @"\d+" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
