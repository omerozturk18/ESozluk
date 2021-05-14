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
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.AddWriter(writer);
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
    }
}