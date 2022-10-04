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
        //GenericRepository<Category> _repository = new GenericRepository<Category>();
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Add(category);

        }

        public List<Category> GetList()
        {
            var get = _categoryDal.List();
            return get;

        }

    }
}
