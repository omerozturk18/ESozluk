using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult MyContent()
        {
            return View(_contentManager.ListByWriterId(1));
        }
    }
}