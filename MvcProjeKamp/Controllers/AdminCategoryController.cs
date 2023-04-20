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

        [Authorize(Roles="A")]
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

        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryManager.GetByIdCategory(id);
            _categoryManager.CategoryDelete(category);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = _categoryManager.GetByIdCategory(id);
            //return RedirectToAction("Index");

            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {

            _categoryManager.CategoryUpdate(c);
            return RedirectToAction("Index");

        }



    }
}