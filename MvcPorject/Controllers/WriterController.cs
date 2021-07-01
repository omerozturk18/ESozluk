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

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View(_writerManager.GetAll());
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(WriterDto writerDto)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writerDto);
            if (result.IsValid)
            {
                _writerManager.AddWriter(writerDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteWriter(int id)
        {
            var writerDelete = _writerManager.GetById(id);
            _writerManager.DeleteWriter(writerDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writerValue = _writerManager.GetByIdOfWriterDto(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult UpdateWriter(WriterDto writerDto)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writerDto);
            if (result.IsValid)
            {
                _writerManager.UpdateWriterDto(writerDto);
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