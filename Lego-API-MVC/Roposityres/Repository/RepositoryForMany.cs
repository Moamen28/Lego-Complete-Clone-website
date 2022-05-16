
using Microsoft.EntityFrameworkCore;
using Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Roposityres.Repository
{
    public class RepositoryForMany<T> : IRepositoryForMany<T> where T : class
    {
        protected ApplicationDbContext Context;
        protected DbSet<T> Table;

        public RepositoryForMany(ApplicationDbContext _Context)
        {
            Context = _Context;
            Table = Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public void Remove(int id)
        {
            var deptDelete = Table.Find(id);
            Context.Entry(deptDelete).State = EntityState.Deleted;
        }
    }
}
