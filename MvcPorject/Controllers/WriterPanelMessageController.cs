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

namespace MvcPorject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private readonly MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private readonly MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            return View(_messageManager.GetAllInbox("omer@omer.com"));
        }
        public ActionResult Sendbox()
        {
            return View(_messageManager.GetAllSendbox("omer@omer.com"));
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
            message.SenderMail = "omer@omer.com";
            _messageManager.AddMessage(message);
            return RedirectToAction("Sendbox");

        }
        public ActionResult Drafts()
        {
            return View(_messageManager.GetAllDraft("omer@omer.com"));
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
            ViewBag.Inbox = _messageManager.GetAllInbox("omer@omer.com").Where(x => x.IsRead == false).Count();
            ViewBag.Draft = _messageManager.GetAllDraft("omer@omer.com").Count();
            return PartialView();
        }
    }
}