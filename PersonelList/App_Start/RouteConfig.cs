using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonelList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Detail",
              url: "Home/UserDetail",
              defaults: new { controller = "Home", action = "UserDetail" },
              namespaces: new string[] { "PersonelList.Controllers" }
         );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Account", action = "login" },
                namespaces: new string[] { "PersonelList.Controllers" }
           );

         routes.MapRoute(
              name: "Default",
              url: "",
              defaults: new { controller = "Home", action = "AllUserList" },
              namespaces: new string[] { "PersonelList.Controllers" }
         );
        }
    }
}
