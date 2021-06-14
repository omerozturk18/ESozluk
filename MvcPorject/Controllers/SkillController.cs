using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcPorject.Controllers
{
    public class SkillController : Controller
    {
        private readonly SkillManager _skillManager = new SkillManager(new EfSkillDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_skillManager.ListSkill(1));
        }
    }
}