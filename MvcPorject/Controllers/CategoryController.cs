using BusinessLibrary.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using BusinessLibrary.ValidationRules;
using DataAccessLibrary.Concrete.EntityFramework;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
       // private readonly ICategoryService _categoryService;
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        //public CategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        // GET: Category
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            return View(_categoryManager.GetAllActive());
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
                return RedirectToAction("GetCategoryList");
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