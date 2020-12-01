using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrestApps.Core.Store
{
    public interface IDataStore<TModel, TKeyType> : IReadDataStore<TModel, TKeyType>
        where TModel : class
        where TKeyType : struct
    {
        /// <summary>
        /// Adds the given model into the store
        /// </summary>
        /// <param name="model"></param>
        void Create(TModel model);

        /// <summary>
        /// Updates the given model in the store
        /// </summary>
        /// <param name="model"></param>
        void Update(TModel model);

        /// <summary>
        /// Permanently removes the given model from the store
        /// </summary>
        /// <param name="model"></param>
        void Remove(TModel model);

        /// <summary>
        /// Permanently removes given model from the store
        /// </summary>
        /// <param name="models"></param>
        void Remove(IEnumerable<TModel> models);

        /// <summary>
        /// Adds multiple given models in to the store
        /// </summary>
        /// <param name="models"></param>
        void Create(IEnumerable<TModel> models);

        /// <summary>
        /// Updates multiple given models in the store
        /// </summary>
        /// <param name="models"></param>
        void Update(IEnumerable<TModel> models);



        /// <summary>
        /// Adds the given model into the store
        /// </summary>
        /// <param name="model"></param>
        Task CreateAsync(TModel model);

        /// <summary>
        /// Updates the given model in the store
        /// </summary>
        /// <param name="model"></param>
        Task UpdateAsync(TModel model);

        /// <summary>
        /// Permanently removes the given model from the store
        /// </summary>
        /// <param name="model"></param>
        Task RemoveAsync(TModel model);

        /// <summary>
        /// Permanently removes given model from the store
        /// </summary>
        /// <param name="models"></param>
        Task RemoveAsync(IEnumerable<TModel> models);

        /// <summary>
        /// Adds multiple given models in to the store
        /// </summary>
        /// <param name="models"></param>
        Task CreateAsync(IEnumerable<TModel> models);

        /// <summary>
        /// Updates multiple given models in the store
        /// </summary>
        /// <param name="models"></param>
        Task UpdateAsync(IEnumerable<TModel> models);

    }

    public interface IDataStore<TModel> : IDataStore<TModel, int>
        where TModel : class
    {

    }
}

