using BuissnessLayer.Concrete;
using BuissnessLayer.Valitadion;
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
    public class AdminCategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var category = _categoryManager.GetList();
            return View(category);
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
            ValidationResult result = categoryValidator.Validate(c);
            if (result.IsValid)
            {
                _categoryManager.AddCategory(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var cat in result.Errors)
                {
                    ModelState.AddModelError(cat.PropertyName, cat.ErrorMessage);
                }
            }
                
            return View();
        }

    }
}