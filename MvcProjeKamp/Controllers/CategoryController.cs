using BuissnessLayer.Concrete;
using BuissnessLayer.Valitadion;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryValues = _categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c) 
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            var result = categoryValidator.Validate(c);
            if (result.IsValid)
            {
                _categoryManager.AddCategory(c);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
            }
            return View();
        }

    }
}