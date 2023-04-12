using BuissnessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;


        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

    

        public void AddHeading(Heading heading)
        {
            _headingDal.Add(heading);

        }

        public Heading GetByIdHeading(int id)
        {
            return _headingDal.GetById(x => x.HeadingID == id);

        }

        public List<Heading> GetList()
        {
            var get = _headingDal.List();
            return get;
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);

        }
    }
}
