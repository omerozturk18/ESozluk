using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using BusinessLibrary.ValidationRules;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using FluentValidation.Results;

namespace MvcPorject.Controllers
{
    [Authorize(Roles = "A")]
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
            _ = admin.AdminStatus == true ? admin.AdminStatus = false : admin.AdminStatus = true;
            _adminManager.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }

        public ActionResult EditAdmin(int id)
        {
            var admin = _adminManager.GetByAdminId(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            AdminValidator validator = new AdminValidator();
            ValidationResult result = validator.Validate(admin);
            if (result.IsValid)
            {
                _adminManager.UpdateAdmin(admin);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminDto adminDto)
        {
            AdminDtoValidator validator = new AdminDtoValidator();
            ValidationResult result = validator.Validate(adminDto);
            if (result.IsValid)
            {
                _adminManager.AddAdmin(adminDto);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}