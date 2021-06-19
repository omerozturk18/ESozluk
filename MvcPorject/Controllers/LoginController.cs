using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Security;
namespace MvcProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthManager _adminManager = new AuthManager(new EfAuthDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminDto adminDto)
        {
            var admin = _adminManager.Login(adminDto.AdminUserName, adminDto.AdminPassword);
            if (admin!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName,false);
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
       
            ViewBag.Result = true;
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminDto adminDto)
        {
            _adminManager.Register(adminDto);
            return RedirectToAction("Index");
        }
    }
}