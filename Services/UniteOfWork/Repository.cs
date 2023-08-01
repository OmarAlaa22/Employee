using Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region property
        private readonly EmployeeDbContext employeeDbContext;
        private DbSet<T> entities;
        #endregion
        #region Constructor
        public Repository(EmployeeDbContext employeeDbContext)
        {
            entities = employeeDbContext.Set<T>();
            this.employeeDbContext = employeeDbContext;
        }
        #endregion
        public async Task<T> Get(int Id)
        {
            return await entities.FindAsync(Id);
        }
        public T findbyId(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = employeeDbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.SingleOrDefault(match);
        }
        public async Task<List<T>> GetAll(string[] includes = null)
        {
            IQueryable<T> query = employeeDbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                   
                }
            }
            return await query.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await entities.AddAsync(entity);
            await employeeDbContext.SaveChangesAsync();

        }
        public async Task Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

           
            employeeDbContext.Entry(entity).State = EntityState.Deleted;
            await employeeDbContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await employeeDbContext.SaveChangesAsync();
        }
        public async Task< int> Save()
        {
            return await employeeDbContext.SaveChangesAsync();
        }
        public List<T> Find(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = employeeDbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

    }
}
