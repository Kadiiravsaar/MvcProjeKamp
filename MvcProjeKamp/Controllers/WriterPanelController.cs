﻿using BuissnessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager _headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());
        Context _context = new Context();

        


        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = _context.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            var values = _headingManager.GetListByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterID = writerIdInfo;
            h.HeadingStatus = true;
            _headingManager.AddHeading(h);
            return RedirectToAction("WriterProfile");
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
            return RedirectToAction("MyHeading");

        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingManager.GetByIdHeading(id);
            heading.HeadingStatus = false;
            _headingManager.HeadingDelete(heading);
            return RedirectToAction("MyHeading");

        }

    }

}