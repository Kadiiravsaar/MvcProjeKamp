using BuissnessLayer.Abstract;
using BuissnessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        public ActionResult Index()
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var messagelist = messageManager.GetListSendBox();
            return View(messagelist);
        }
    }
}