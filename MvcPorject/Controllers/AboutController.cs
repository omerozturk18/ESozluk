using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {

            return View(_aboutManager.GetAll());
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutManager.AddAbout(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}