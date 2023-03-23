using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
        T Save(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> where);
        FContext GetContext();
        void Dispose();
    }
}
