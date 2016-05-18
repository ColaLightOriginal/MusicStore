using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStoreMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Album",
                    action = "Index",
                    genre = (string)null,
                    page = 1
                });

            routes.MapRoute(null,
                "Strona{page}",
                new
                {
                    controller = "Album",
                    action = "Index",
                    genre = (string)null
                },
                    new { page = @"\d+" }
                );

            routes.MapRoute(null,
                "{genre}",
                new
                {
                    controller = "Album",
                    action = "Index",
                    page = 1
                });


            routes.MapRoute(null,
                "{genre}/Strona{page}",
                new { controller = "Album", action = "Index" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
