using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrestApps.Core.Data.Abstraction
{

    public interface IRepository<TModel, TKeyType> : IReadRepository<TModel, TKeyType>
        where TModel : class, IWriteModel
        where TKeyType : struct
    {
        // Add single record
        TModel Add(TModel entity);

        // Add multiple records
        IEnumerable<TModel> AddRange(IEnumerable<TModel> entities);

        // Remove records
        void Remove(TModel entity);

        // remove multiple records
        void RemoveRange(IEnumerable<TModel> entities);
        void Update(TModel entity);
        void UpdateRange(IEnumerable<TModel> entities);

        void Save();
        Task SaveAsync();
    }

    public interface IRepository<TModel> : IRepository<TModel, int>
        where TModel : class, IWriteModel
    {

    }
}
