using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrestApps.Core.Store
{
    public interface IReadDataStore<TModel, TKeyType>
       where TModel : class
       where TKeyType : struct
    {
        /// <summary>
        /// Query the store
        /// </summary>
        /// <returns></returns>
        IQueryable<TModel> Query();

        /// <summary>
        /// Execute predicte on the store
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate);


        /// <summary>
        /// Execute predicte on the store
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TModel FirstOrDefault(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Check if at least one item exists that matches the given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Get the first record by id from the store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Get(TKeyType id);

        /// <summary>
        /// Get the first record by id from the store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Get(TKeyType? id);

        /// <summary>
        /// Get the first record by id from the store
        /// </summary>
        /// <param name="id"></param>
        /// <throw>It throws ModelNotFoundException if no model found</throw>
        /// <returns></returns>
        TModel First(TKeyType id);

        /// <summary>
        /// Gets all the records in the store
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetAll();





        /// <summary>
        /// Get the first record by id from the store asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetAsync(TKeyType id);


        /// <summary>
        /// Get the first record by id from the store asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetAsync(TKeyType? id);

        /// <summary>
        /// Get the first record by id from the store asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <throw>It throws ModelNotFoundException if no model found</throw>
        /// <returns></returns>
        Task<TModel> FirstAsync(TKeyType id);

        /// <summary>
        /// Gets all the records in the store asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync();


        /// <summary>
        /// Check if at least one item exists that matches the given predicate asynchronously
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Get the first record by id from the store and will cache it until the Store is disposed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel GetCached(TKeyType id);
    }

    public interface IReadDataStore<TModel> : IReadDataStore<TModel, int>
       where TModel : class
    {

    }
}

