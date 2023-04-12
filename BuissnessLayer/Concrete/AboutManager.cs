using BuissnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDat;

        public AboutManager(IAboutDal aboutDat)
        {
            _aboutDat = aboutDat;
        }

        public void AboutDelete(About about)
        {
            _aboutDat.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDat.Update(about);

        }

        public void AddAbout(About about)
        {
            _aboutDat.Add(about);

        }

        public About GetByIdAbout(int id)
        {
            return _aboutDat.GetById(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDat.List();
        }
    }
}
