using BuissnessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _contentManager = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = _contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}