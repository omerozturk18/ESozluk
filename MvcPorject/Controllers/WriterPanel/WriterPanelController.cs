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
using PagedList;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        private readonly HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());

        public ActionResult WriterProfile()
        {
            var writer = _writerManager.GetByWriterDto((string)Session["WriterUserName"]);
            return View(writer);
        }

        [HttpPost]
        public ActionResult WriterProfile(WriterDto writerDto)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writerDto);
            if (result.IsValid)
            {
                _writerManager.UpdateWriterDto(writerDto);
                return RedirectToAction("MyHeading");
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
        public ActionResult MyHeading()
        {
            var writer = _writerManager.GetByWriter((string)Session["WriterUserName"]);
            return View(_headingManager.GetByWriterOfStatus(writer.WriterId));
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            GetCategorizes();
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);
            if (result.IsValid)
            {
                var writer = _writerManager.GetByWriter((string)Session["WriterUserName"]);
                heading.HeadingDate = DateTime.Now;
                heading.WriterId = writer.WriterId;
                heading.HeadingStatus = true;
                _headingManager.AddHeading(heading);
                return RedirectToAction("WriterProfile");
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
            return RedirectToAction("WriterProfile");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingDelete = _headingManager.GetById(id);
            headingDelete.HeadingStatus = false;
            _headingManager.DeleteHeading(headingDelete);
            return RedirectToAction("WriterProfile");
        }
        public ActionResult AllHeading(int page=1)
        {
            var list=_headingManager.GetAll().ToPagedList(page, 10);

            return View(list);
        }
        private void GetCategorizes()
        {
            List<SelectListItem> categorizes = (from x in _categoryManager.GetAllActive()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString(),
                }).ToList();
            ViewBag.Categorys = categorizes;
        }

    }
}