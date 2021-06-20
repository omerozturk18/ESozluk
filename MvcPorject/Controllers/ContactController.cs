using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using BusinessLibrary.ValidationRules;
using DataAccessLibrary.Concrete.EntityFramework;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager = new ContactManager(new EfContactDal());
        private readonly MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private readonly ContactValidator _contactValidator = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            return View(_contactManager.GetAll());
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactDetail = _contactManager.GetById(id);
            contactDetail.IsRead = true;
            _contactManager.UpdateContact(contactDetail);
            return View(contactDetail);
        }
        public PartialViewResult MessageListMenu()
        {
            ViewBag.Contact = _contactManager.GetAll().Where(x => x.IsRead == false).Count();
            ViewBag.Inbox = _messageManager.GetAllInbox((string)Session["AdminUserUserName"]).Where(x => x.IsRead == false).Count();
            ViewBag.Draft = _messageManager.GetAllDraft((string)Session["AdminUserUserName"]).Count();
            return PartialView();
        }
    }
}