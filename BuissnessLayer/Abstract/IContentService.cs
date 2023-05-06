using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);

        void AddContent(Content content);

        Content GetByIdContent(int id);

        void ContentDelete(Content content);

        void ContentUpdate(Content content);
    }
}
