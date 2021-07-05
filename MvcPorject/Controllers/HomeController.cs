using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly StatisticManager _statisticManager = new StatisticManager(new EfStatisticDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var dashboardStatistic = _statisticManager.DashboardStatistic();
            ViewBag.HeadingCount = dashboardStatistic.HeadingCount;
            ViewBag.EntryCount = dashboardStatistic.EntryCount;
            ViewBag.WriterCount = dashboardStatistic.WriterCount;
            ViewBag.MessagesCount = dashboardStatistic.MessagesCount;
            return View();
        }
    }
}