using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void AddWriter(Writer writer);

        Writer GetByIdWriter(int id);

        void WriterDelete(Writer writer);

        void WriterUpdate(Writer writer);
    }
}
