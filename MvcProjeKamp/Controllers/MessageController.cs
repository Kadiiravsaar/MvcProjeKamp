using BuissnessLayer.Abstract;
using BuissnessLayer.Concrete;
using BuissnessLayer.Valitadion;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class MessageController : Controller
    {
       MessageManager messageManager = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Index() // inbox
        {
            var messagelist = messageManager.GetListInBox();
            return View(messagelist);
        }

        public ActionResult SendBox()
        {
            var messagelist = messageManager.GetListSendBox();
            return View(messagelist);
        }

        public ActionResult GetInBoxDetails(int id)
        {
            var messageById = messageManager.GetByIdMessage(id);
            return View(messageById);
        }

        public ActionResult GetSendBoxDetails(int id)
        {
            var messageById = messageManager.GetByIdMessage(id);
            return View(messageById);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {   message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AddMessage(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}