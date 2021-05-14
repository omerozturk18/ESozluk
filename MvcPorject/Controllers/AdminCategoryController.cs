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
    public class AdminCategoryController : Controller
    {
        // private readonly ICategoryService _categoryService;
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        //public CategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

      
        public ActionResult Index()
        {
            return View(_categoryManager.GetAll());
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                _categoryManager.AddCategory(category);
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

        public ActionResult DeleteCategory(int id)
        {
            var deleteCategory = _categoryManager.GetById(id);
            _categoryManager.DeleteCategory(deleteCategory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = _categoryManager.GetById(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _categoryManager.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}