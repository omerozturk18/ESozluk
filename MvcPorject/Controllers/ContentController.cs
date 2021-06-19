using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentManager _contentManager = new ContentManager(new EfContentDal());
        // GET: Content

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            return View(_contentManager.ListByHeadingId(id));
        }
    }
}