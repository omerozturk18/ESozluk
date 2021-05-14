using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcPorject.Controllers
{
    public class StatisticController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private readonly StatisticManager _statisticManager = new StatisticManager(new EfWriterDal(),new EfHeadingDal(),new EfCategoryDal());

        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.numberOfCategory = _statisticManager.NumberOfCategory();
            ViewBag.numberOfHeaderInCategory = _statisticManager.NumberOfHeaderInCategory(1);
            ViewBag.writerFilterCount = _statisticManager.WriterFilterCount();
            ViewBag.categoryWithTheMostHeader = _categoryManager.GetById(_statisticManager.CategoryWithTheMostHeader()).CategoryName;
            ViewBag.trueOrFalseDifferenceOfCategory = _statisticManager.TrueOrFalseDifferenceOfCategory();
            return View();
        }
    }
}