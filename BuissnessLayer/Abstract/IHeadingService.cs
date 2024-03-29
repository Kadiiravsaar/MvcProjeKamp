﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void AddHeading(Heading heading);

        Heading GetByIdHeading(int id);

        void HeadingDelete(Heading heading);

        void HeadingUpdate(Heading heading);

    }
}
