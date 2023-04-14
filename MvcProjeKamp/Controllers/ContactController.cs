using BuissnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EFContactDal());

        public ActionResult Index()
        {
            var contact = _contactManager.GetList();
            return View(contact);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactById = _contactManager.GetByIdContact(id);
            return View(contactById);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

    }
}