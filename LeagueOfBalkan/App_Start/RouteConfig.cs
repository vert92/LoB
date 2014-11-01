using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeagueOfBalkan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "News",
                "News/{id}/{newsName}",
                new { controller = "News", action = "Details", newsName = UrlParameter.Optional },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "Streams",
                "Stream/{id}/{streamName}",
                new { controller = "Streams", action = "Details", streamName = UrlParameter.Optional },
                new { id = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
