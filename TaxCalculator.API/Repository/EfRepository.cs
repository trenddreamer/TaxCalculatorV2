using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;

namespace TaxCalculator.API.Repository
{ 
    public class EfRepository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbSet;


        public EfRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            //Our linq query is passed in by filter

            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            //we need to loop through all include items and add them to the query

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            //Our linq query is passed in by filter

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //we need to loop through all include items and add them to the query

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }



        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void Add(int id)
        {
            T entity = dbSet.Find(id);
            Add(entity);
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }
    }
}
