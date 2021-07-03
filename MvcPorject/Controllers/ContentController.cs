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
    public class ContentController : Controller
    {
        private readonly ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult GetAllContent(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return View(_contentManager.Filter(filter));
            }
            return View(_contentManager.GetAll());
        }

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            return View(_contentManager.ListByHeadingId(id));
        }
    }
}