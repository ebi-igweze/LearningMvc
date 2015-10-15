using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningMVC.Core.DataAccess
{
    public class DataRepository
    {
        private readonly DbContext _dbContext;

        public DataRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = Query<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetByID<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Add<T>(T item) where T : class
        {
            _dbContext.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _dbContext.Set<T>().Remove(item);
        }

        public void Update<T>(T entity) where T : class
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
