using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Generic
{
    public interface IRepository<T> where T : class
    {
       // Task<List<T>> GetAll();
        Task<T> Get(int Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<int> Save();
        List<T> Find(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAll(string[] includes = null);
        T findbyId(Expression<Func<T, bool>> match, string[] includes = null);
    }
}
