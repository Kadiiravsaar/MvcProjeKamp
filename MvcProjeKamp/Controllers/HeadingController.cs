using BuissnessLayer.Abstract;
using BuissnessLayer.Concrete;
using BuissnessLayer.Valitadion;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager _writerManager = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var headings = _headingManager.GetList();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in _writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.WriterName + " " + x.WriterSurName,
                                                     Value = x.WriterID.ToString()
                                                 }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {
           
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.AddHeading(h);
            return RedirectToAction("Index");
          
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;

            var headingId = _headingManager.GetByIdHeading(id);
            return View(headingId);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");

        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingManager.GetByIdHeading(id);
            heading.HeadingStatus = false;
            _headingManager.HeadingDelete(heading);
            return RedirectToAction("Index");

        }



    }
}