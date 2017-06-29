using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cinemania
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // HOME CONTROLLER
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Inicio", id = UrlParameter.Optional }
            );

            // ADMINISTRACION CONTROLLER
            routes.MapRoute(
                name: "Administracion",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administracion", action = "Inicio", id = UrlParameter.Optional }
            );
        }
    }
}
