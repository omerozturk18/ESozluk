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
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());

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
            GetCategorys();
            GetWriter();
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
                heading.WriterId = 4;
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
            List<SelectListItem> categorys = (from x in _categoryManager.GetAll()
                    select  new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString(),
                    }).ToList();
            ViewBag.Categorys = categorys;
        }

        private void GetWriter()
        {
            List<SelectListItem> writer = (from x in _writerManager.GetAll()
                select new SelectListItem
                {
                    Text = x.WriterName + " " + x.WriterSurName,
                    Value = x.WriterId.ToString(),
                }).ToList();
            ViewBag.Writer = writer;
        }
    }
}