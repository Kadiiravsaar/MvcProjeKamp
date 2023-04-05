using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> List();

        T GetById(Expression<Func<T, bool>> filter);

        void Add(T p);

        void Delete(T p);

        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
