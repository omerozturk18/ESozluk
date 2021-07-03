using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;
using MvcPorject.Models;

namespace MvcProject.Controllers
{
    public class StatisticController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private readonly StatisticManager _statisticManager = new StatisticManager(new EfStatisticDal());

        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.numberOfCategory = _statisticManager.NumberOfCategory();
            ViewBag.numberOfHeaderInCategory = _statisticManager.NumberOfHeaderInCategory(1);
            ViewBag.writerFilterCount = _statisticManager.WriterFilterCount();
            ViewBag.categoryWithTheMostHeader = _statisticManager.CategoryWithTheMostHeader();
            ViewBag.trueOrFalseDifferenceOfCategory = _statisticManager.TrueOrFalseDifferenceOfCategory();
            return View();
        }
        public ActionResult CategoryChart()
        {
            return View();
        }
        public ActionResult CategoryChar()
        {
            return Json(_statisticManager.CategoryChart(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ContentChart()
        {
            return View();
        }
        public ActionResult ContentChar()
        {
            return Json(_statisticManager.ContentChart(), JsonRequestBehavior.AllowGet);
        }


    }
}