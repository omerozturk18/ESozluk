using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Security;
using EntityLayer.Dtos;

namespace MvcProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthManager _authManager = new AuthManager(new EfAdminDal(),new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            var admin = _authManager.Login(loginDto);
            if (admin!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName,false);
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Result = true;
                return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminDto adminDto)
        {
            _authManager.Register(adminDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(LoginDto loginDto)
        {
            var writer = _authManager.WriterLogin(loginDto);
            if (writer != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["WriterUserName"] = writer.WriterMail;
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                ViewBag.Result = true;
                return View();
            }
        }
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(LoginDto loginDto)
        {
            _authManager.WriterRegister(loginDto);
            return RedirectToAction("WriterLogin");
        }
    }
}