using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcPorject.Controllers
{
    public class GalleryController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
        // GET: Gallery
        public ActionResult Index()
        {
            return View(_writerManager.GetAll());
        }
    }
}