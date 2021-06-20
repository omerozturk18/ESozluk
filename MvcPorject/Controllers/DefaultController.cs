using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcPorject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private  readonly  HeadingManager _headingManager=new HeadingManager(new EfHeadingDal());
        private  readonly  ContentManager _contentManager=new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            return View(_headingManager.GetAll());
        }

        public PartialViewResult Index(int id=0)
        {
            return PartialView(_contentManager.ListByHeadingId(id));
        }
    }
}