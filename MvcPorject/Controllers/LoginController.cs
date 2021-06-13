using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace MvcPorject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminManager _adminManager = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminDto adminDto)
        {
            var result = _adminManager.Login(adminDto.AdminUserName, adminDto.AdminPassword);
            if (result)return RedirectToAction("Index","AdminCategory");
       
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