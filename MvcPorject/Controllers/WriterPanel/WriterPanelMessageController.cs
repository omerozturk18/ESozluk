using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Concrete;
using BusinessLibrary.ValidationRules;
using DataAccessLibrary.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private readonly MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private readonly MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            return View(_messageManager.GetAllInbox((string)Session["WriterUserName"]));
        }
        public ActionResult Sendbox()
        {
            return View(_messageManager.GetAllSendbox((string)Session["WriterUserName"]));
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = _messageValidator.Validate(message);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            if (Request.Form["draft"] != null) message.IsTheMessageIsDraft = true;
            else message.IsTheMessageIsDraft = false;
            message.MessageDate = DateTime.Now;
            message.IsRead = false;
            message.SenderMail = (string)Session["WriterUserName"];
            _messageManager.AddMessage(message);
            return RedirectToAction("Sendbox");

        }
        public ActionResult Drafts()
        {
            return View(_messageManager.GetAllDraft((string)Session["WriterUserName"]));
        }

        public ActionResult MessageDetail(int id)
        {
            var messageDetail = _messageManager.GetById(id);
            messageDetail.IsRead = true;
            _messageManager.UpdateMessage(messageDetail);
            return View(messageDetail);
        }
        public PartialViewResult WriterMessageListMenu()
        {
            ViewBag.Inbox = _messageManager.GetAllInbox((string)Session["WriterUserName"]).Where(x => x.IsRead == false).Count();
            ViewBag.Draft = _messageManager.GetAllDraft((string)Session["WriterUserName"]).Count();
            return PartialView();
        }
    }
}