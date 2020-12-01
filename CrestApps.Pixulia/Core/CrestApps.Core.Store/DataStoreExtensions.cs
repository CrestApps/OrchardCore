using CrestApps.Core.Data.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace CrestApps.Core.Store
{
    public static class DataStoreExtensions
    {
        public static IQueryable<TModel> QueryByStatus<TModel, TKeyType>(this IReadDataStore<TModel, TKeyType> store, IEnumerable<TKeyType> includeIds, bool? isActive)
            where TKeyType : struct
            where TModel : class, IHaveStatus, IIdAsPrimaryKey<TKeyType>, IReadModel
        {
            if (isActive.HasValue && includeIds != null && includeIds.Any())
            {
                return store.Where(x => x.IsActive == isActive.Value || includeIds.Contains(x.Id));
            }

            return store.QueryByStatus(isActive);
        }

        public static IQueryable<TModel> QueryByStatus<TModel, TKeyType>(this IReadDataStore<TModel, TKeyType> store, TKeyType? includeId, bool? isActive)
            where TKeyType : struct
            where TModel : class, IHaveStatus, IIdAsPrimaryKey<TKeyType>, IReadModel
        {
            if (isActive.HasValue && includeId.HasValue)
            {
                return store.Where(x => x.IsActive == isActive.Value || includeId.Value.Equals(x.Id));
            }

            return store.QueryByStatus(isActive);
        }

        public static IQueryable<TModel> QueryByStatus<TModel, TKeyType>(this IReadDataStore<TModel, TKeyType> store, bool? isActive)
            where TKeyType : struct
            where TModel : class, IHaveStatus, IIdAsPrimaryKey<TKeyType>, IReadModel
        {
            if (isActive.HasValue)
            {
                return store.Where(x => x.IsActive == isActive.Value);
            }

            return store.Query();
        }


        public static IQueryable<TModel> QueryByStatus<TModel, TKeyType>(this IDataStore<TModel, TKeyType> store, IEnumerable<TKeyType> includeIds, bool? isActive)
            where TKeyType : struct
            where TModel : class, IHaveStatus, IIdAsPrimaryKey<TKeyType>, IWriteModel
        {
            if (isActive.HasValue && includeIds != null && includeIds.Any())
            {
                return store.Where(x => x.IsActive == isActive.Value || includeIds.Contains(x.Id));
            }

            return store.QueryByStatus(isActive);
        }

        public static IQueryable<TModel> QueryByStatus<TModel, TKeyType>(this IDataStore<TModel, TKeyType> store, TKeyType? includeId, bool? isActive)
            where TKeyType : struct
            where TModel : class, IHaveStatus, IIdAsPrimaryKey<TKeyType>, IWriteModel
        {
            if (isActive.HasValue && includeId.HasValue)
            {
                return store.Where(x => x.IsActive == isActive.Value || includeId.Value.Equals(x.Id));
            }

            return store.QueryByStatus(isActive);
        }
    }
}
