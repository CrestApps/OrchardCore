using CrestApps.Core.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrestApps.Core.Store
{
    public class ReadDataStore<TModel, TKeyType, TRepositoryType> : IReadDataStore<TModel, TKeyType>
       where TModel : class, IReadModel
       where TKeyType : struct
       where TRepositoryType : IReadRepository<TModel, TKeyType>
    {
        protected TRepositoryType Repository { get; }

        public ReadDataStore(TRepositoryType repository)
        {
            Repository = repository;
        }

        public IQueryable<TModel> Query()
        {
            return Repository.Query();
        }

        public IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public virtual TModel Get(TKeyType? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            return Repository.Get(id.Value);
        }

        public virtual async Task<TModel> GetAsync(TKeyType? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            return await Repository.GetAsync(id.Value);
        }

        public virtual TModel Get(TKeyType id)
        {
            return Repository.Get(id);
        }

        public virtual TModel FirstOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            TModel model = Repository.Find(predicate).FirstOrDefault();

            return model;
        }

        public virtual TModel First(TKeyType id)
        {
            return Get(id) ?? throw new ModelNotFoundException();
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return Repository.GetAll();
        }


        public virtual async Task<TModel> GetAsync(TKeyType id)
        {
            return await Repository.GetAsync(id);
        }

        public virtual async Task<TModel> FirstAsync(TKeyType id)
        {
            return await GetAsync(id) ?? throw new ModelNotFoundException();
        }


        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }




        private readonly Dictionary<TKeyType, TModel> CachedModels = new Dictionary<TKeyType, TModel>();

        public TModel GetCached(TKeyType id)
        {
            if (!CachedModels.ContainsKey(id))
            {
                CachedModels[id] = Get(id);
            }

            return CachedModels[id];
        }

        protected void ClearCached(params TKeyType[] ids)
        {
            if (ids == null)
            {
                return;
            }

            foreach (var id in ids)
            {
                if (CachedModels.ContainsKey(id))
                {
                    CachedModels.Remove(id);
                }
            }

        }

        public bool Exists(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.Any(predicate);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await Repository.AnyAsync(predicate);
        }
    }

    public class ReadDataStore<TModel, TKeyType> : ReadDataStore<TModel, TKeyType, IReadRepository<TModel, TKeyType>>
        where TModel : class, IReadModel
        where TKeyType : struct
    {
        public ReadDataStore(IReadRepository<TModel, TKeyType> repository)
            : base(repository)
        {
        }
    }

    public class ReadDataStore<TModel> : ReadDataStore<TModel, int, IReadRepository<TModel, int>>
       where TModel : class, IReadModel
    {
        public ReadDataStore(IReadRepository<TModel, int> repository)
            : base(repository)
        {
        }
    }
}

