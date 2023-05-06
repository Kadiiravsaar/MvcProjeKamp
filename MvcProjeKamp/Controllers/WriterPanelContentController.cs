using BuissnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager _contentManager = new ContentManager(new EFContentDal());

        public ActionResult MyContent()
        {
            var contentValues = _contentManager.GetListByWriter();
            return View(contentValues);
        }
    }
}