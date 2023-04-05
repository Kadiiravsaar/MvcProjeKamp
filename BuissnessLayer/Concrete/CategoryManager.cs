using BuissnessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Add(category);

        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
           _categoryDal.Update(category);
        }

        public Category GetByIdCategory(int id)
        {
            return _categoryDal.GetById(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            var get = _categoryDal.List();
            return get;

        }

    }
}
