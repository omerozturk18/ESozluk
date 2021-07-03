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
    public class AuthorizationController : Controller
    {
        private readonly AdminManager _adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            return View(_adminManager.GetAll());
        }
        public ActionResult DeleteAdmin(int id)
        {
            var admin = _adminManager.GetByAdminId(id);
            admin.AdminStatus = false;
            _adminManager.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }
        public ActionResult EditAdmin()
        {
            return View(_adminManager.GetAll());
        }
        public ActionResult AddAdmin()
        {
            return View(_adminManager.GetAll());
        }
    }
}