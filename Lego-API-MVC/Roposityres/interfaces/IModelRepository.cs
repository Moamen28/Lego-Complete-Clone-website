using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roposityres.interfaces
{
    public interface IModelRepository<T>
    {
         IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);

        T Add(T entity);
        T Update(T entity);

        T Remove(T entity);
        void DeleteRange(IQueryable<T> entity);
        IQueryable<T> GetAllOnly();

    }
}