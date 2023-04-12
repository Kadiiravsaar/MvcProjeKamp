using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AddAbout(About about);

        About GetByIdAbout(int id);

        void AboutDelete(About about);
             
        void AboutUpdate(About about);
    }
}
