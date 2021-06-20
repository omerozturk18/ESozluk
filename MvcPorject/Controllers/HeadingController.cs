using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using BusinessLibrary.ValidationRules;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        private readonly HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private readonly AdminManager _adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            return View(_headingManager.GetAll());
        }
        public ActionResult GetByWriter(int id)
        {
            return View(_headingManager.GetByWriter(id));
        }
        public ActionResult GetByCategory(int id)
        {
            ViewBag.categoryHeader = _categoryManager.GetById(id).CategoryName;
            return View(_headingManager.GetByCategory(id));
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            GetCategorizes();
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);
            if (result.IsValid)
            {
                var admin = _adminManager.GetByAdmin((string) Session["AdminUserName"]);
                heading.HeadingDate=DateTime.Now;
                heading.WriterId = admin.AdminId;
                heading.HeadingStatus = true;

                _headingManager.AddHeading(heading);
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
        public ActionResult DeleteHeading(int id)
        {
            var headingDelete = _headingManager.GetById(id);
            headingDelete.HeadingStatus = false;
            _headingManager.DeleteHeading(headingDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            GetCategorizes();
            var headingValue = _headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            _headingManager.UpdateHeading(heading);
            return RedirectToAction("Index");
        }


        private void GetCategorizes()
        {
            List<SelectListItem> categorizes = (from x in _categoryManager.GetAll()
                    select  new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString(),
                    }).ToList();
            ViewBag.Categorys = categorizes;
        }

    }
}