using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TaxCalculator.API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Get entity T by ID
        T Get(int id);

        //Add entity T to the database
        void Add(T entity);

        //Add entity T by id to the database
        void Add(int id);

        //Get a List of entity T
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Gets the first entity of T or null
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

       //Remove entity T from the database
        void Remove(T entity);

        //Remove entity T by id to the database
        void Remove(int id);

        //Removes a range of entity T from the database
        void RemoveRange(IEnumerable<T> entity);

    }
}
