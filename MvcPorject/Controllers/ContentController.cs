using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcPorject.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentManager _contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            return View(_contentManager.ListByHeadingId(id));
        }
    }
}