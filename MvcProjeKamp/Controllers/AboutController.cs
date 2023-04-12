using BuissnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AboutController : Controller
    {   
        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var abouts = aboutManager.GetList();
            return View(abouts);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AddAbout(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

    }
}