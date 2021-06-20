using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcProject.Controllers
{
    public class SkillController : Controller
    {
        private readonly SkillManager _skillManager = new SkillManager(new EfSkillDal());
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            var writer = _writerManager.GetByWriter((string)Session["WriterUserName"]);
            return View(_skillManager.ListSkill(writer.WriterId));
        }
    }
}