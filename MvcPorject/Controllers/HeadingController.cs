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

namespace MvcPorject.Controllers
{
    public class HeadingController : Controller
    {
        private readonly HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
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
            return View(_headingManager.GetByCategory(id));
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            GetCategorys();
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);
            if (result.IsValid)
            {
                heading.HeadingDate=DateTime.Now;
                heading.WriterId = 3;
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
            _headingManager.DeleteHeading(headingDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            GetCategorys();
            var headingValue = _headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            _headingManager.UpdateHeading(heading);
            return RedirectToAction("Index");
        }

        private void GetCategorys()
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();

            foreach (var item in _categoryManager.GetAll())
            {
                kategoriler.Add(
                    new SelectListItem
                    {
                        Text = item.CategoryName,
                        Value = item.CategoryId.ToString(),
                    });
            }
            ViewBag.Categorys = kategoriler;
        }
    }
}