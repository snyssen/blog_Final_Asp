using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog_final_Asp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new[] { "Blog_final_Asp.Controllers" }
            );

            // Route attrappe-tout, redirige sur la première page de l'accueil
            routes.MapRoute(
                 name: "CatchAll",
                 url: "",
                 defaults: new { controller = "Home", action = "Index", id = 1 }
            );
        }
    }
}
