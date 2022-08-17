using PersonelList.Areas.Admin.Model;
using PersonelList.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using PersonelList.Models.DataLayer;

namespace PersonelList.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        DataAccessLayer _dataAccessLayer = new DataAccessLayer();
        // GET: Admin/Account
        public ActionResult Alogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alogin(Alogin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            string parolaHash = Md5Encrytion.Encrypt(model.Password);
           


            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Departments = _dataAccessLayer.GetAllDepartments();
         
            Register register=new Register();
            register.BirthDay=DateTime.Now;
            return View(register);
        }
        [HttpPost]
        public ActionResult Register(Register model, List<HttpPostedFileBase> ImageFiles)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _dataAccessLayer.GetAllDepartments();
                return View(model);
            }
            //user kaydı


            //Image kaydı
            if (ImageFiles!=null)
            {
                string temporaryPath = Server.MapPath("~/Images/ResizedImage");
                string newPath = Server.MapPath("~/Images/ResizedImage");
                List<ImageDTO> images = new List<ImageDTO>();
                foreach (var image in ImageFiles)
                {
                    ImageDTO ımageDTO = new ImageDTO()
                    {
                        ImagePath = HelperClass.ImportImage(image, temporaryPath, newPath),
                    };

                    images.Add(ımageDTO);

                }
            }
          


            return View();
        }
    }
    public partial class DataAccessLayer
    {
        public void AddImage(string ImagePathName,int userId)
        {

        }
        public void AddUser(Register register,List<ImageDTO> images)
        {
            UserData userData = new UserData();
            userData.AddUser(register,images);
        }
        public List<Department> GetAllDepartments()
        {
             DepartmentData data = new DepartmentData();
            List<Department> departments= data.GetAllDepartments();
            return departments;
        }

    }
}