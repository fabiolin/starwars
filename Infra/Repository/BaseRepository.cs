using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace starwars.Infra.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> List(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        T SaveAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> entity_;
        protected AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
            entity_ = context.Set<T>();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> expression)
        {
            return entity_.Where(expression).ToList();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return entity_.Any(expression);
        }

        public T SaveAsync(T entity)
        {
            entity_.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            entity_.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            entity_.Remove(entity);
            context.SaveChanges();
        }
    }
}
