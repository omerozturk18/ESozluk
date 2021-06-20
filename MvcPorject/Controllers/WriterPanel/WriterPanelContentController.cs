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
    public class WriterPanelContentController : Controller
    {
        private readonly ContentManager _contentManager = new ContentManager(new EfContentDal());
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult MyContent()
        {
            var writer = _writerManager.GetByWriter((string) Session["WriterUserName"]);
            return View(_contentManager.ListByContentOfWriterId(writer.WriterId));
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            var writer = _writerManager.GetByWriter((string)Session["WriterUserName"]);
            content.ContentDate= DateTime.Now;
            content.WriterId = writer.WriterId;
            content.ContentStatus = true;
            _contentManager.AddContent(content);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }

    }
}