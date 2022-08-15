using System.Web.Mvc;

namespace PersonelList.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Admin_register",
               "admin/register",
               new { controller = "Account", action = "register", id = UrlParameter.Optional },
               namespaces: new string[] { "PersonelList.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               "Admin_login",
               "alogin",
               new { controller = "Account", action = "alogin", id = UrlParameter.Optional },
               namespaces: new string[] { "PersonelList.Areas.Admin.Controllers" }
           );
            context.MapRoute(
                "Admin_default",
                "Admin/dashboard",
                new {controller="Dashboard", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PersonelList.Areas.Admin.Controllers" }
            );
        }
    }
}