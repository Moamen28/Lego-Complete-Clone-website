using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roposityres.interfaces
{
    public interface IRepositoryForMany<T>
    {
        void Remove(int id);
        IQueryable<T> GetAll();
    }
}
