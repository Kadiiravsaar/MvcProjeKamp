using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface ICategoryService 
    {
        List<Category> GetList();
        void AddCategory(Category category);   
        
        Category GetByIdCategory(int id);

        void CategoryDelete(Category category);

        void CategoryUpdate(Category category); 

    }
}
