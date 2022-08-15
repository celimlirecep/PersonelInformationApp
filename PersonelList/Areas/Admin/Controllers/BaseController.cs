using PersonelList.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelList.Areas.Admin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected Employee CurrentEmployee
        {
            get { return (Employee)Session["CurrentEmployee"]; }
            set { Session["CurrentEmployee"] = value; }
        }
        protected CurrentLoginType CurrentLoginType
        {
            get { return (CurrentLoginType)Session["CurrentLoginType"]; }
            set { Session["CurrentLoginType"] = value; }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
    public enum CurrentLoginType
    {
        User=1,
        Admin=2
    }
}