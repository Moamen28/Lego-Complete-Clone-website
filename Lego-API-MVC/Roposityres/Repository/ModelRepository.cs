using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Roposityres.Repository
{
    public class ModelRepository<T> : IModelRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext Context;
        protected DbSet<T> Table;

        public ModelRepository(ApplicationDbContext _Context)
        {
            Context = _Context;
            Table = Context.Set<T>();
        }
        public IQueryable<T>FindByCondition(Expression<Func<T, bool>> expression)
        {

            return Table.Where(expression).AsNoTracking();
        }
        public   IQueryable<T> GetAll()
        {
            return  Table;
        }
        public IQueryable<T> GetAllOnly()
        {
            return Table;
        }

        public  T GetById(int id)
        {
            return  Table.Find(id);
        }

        public  T Add(T s)
        {
             Table.Add(s);
            return s;
        }

        public  T Update(T entity)
        {
            //var existingEntity = Table.FirstOrDefaultAsync(i => i.Id == entity.Id);//Table.Find(obj.ID);
            //Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            Table.Update(entity);
            return entity;
        }

        public  T Remove(T entity)
        {
            Table.Remove(entity);
            return entity;
        }

        public void DeleteRange(IQueryable<T> entity)
        {
            //_context.RemoveRange(entity);
            Table.RemoveRange(entity.ToList());
        }

        //T IModelRepository<T>.Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveByID(int id)
        //{
        //    Table.Remove(GetById(id));
        //}

    }
}