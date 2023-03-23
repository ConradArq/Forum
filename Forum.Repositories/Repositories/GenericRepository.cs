using Forum.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Forum.Repositories.Repositories
{
    /// <summary>
    /// Generic repository. Inherited by all repositories in the solution
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        private FContext _dbContext = new FContext();
        public FContext Context
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public virtual void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            //_dbContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        #region TESTING
        public virtual void DeleteRange(IEnumerable<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
        }

        public virtual void DeleteRangeTest(IEnumerable<T> collection)
        {
            foreach (var entity in collection)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// Allow return related entity -EBF
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include">string like: "Entity1","Entity2", "etc."</param>
        /// <returns></returns>
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);

            foreach (var item in include)
            {
                query = query.Include(item);
            }

            return query;
        }
        #endregion

        public virtual void Save()
        {
            TrackUserChange();
            _dbContext.SaveChanges();
        }

        public virtual T Save(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;

            TrackUserChange();
            _dbContext.SaveChanges();

            return entity;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            return query;
        }


        public FContext GetContext()
        {
            return Context;
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();

        }

        private void TrackUserChange()
        {
            _dbContext.UserID = HttpContext.Current.User.Identity.GetUserId<int>();
        }
    }
}
