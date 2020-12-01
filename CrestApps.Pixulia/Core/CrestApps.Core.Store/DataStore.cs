using CrestApps.Core.Data.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrestApps.Core.Store
{
    public class DataStore<TModel, TKeyType, TRepositoryType> : ReadDataStore<TModel, TKeyType, TRepositoryType>, IDataStore<TModel, TKeyType>
         where TModel : class, IWriteModel
         where TKeyType : struct
         where TRepositoryType : IRepository<TModel, TKeyType>

    {
        public DataStore(TRepositoryType repository)
            : base(repository)
        {
        }

        public virtual void Create(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Add(model);
            Repository.Save();
        }

        public virtual void Create(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.AddRange(models);
            Repository.Save();
        }

        public virtual async Task CreateAsync(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Add(model);
            await Repository.SaveAsync();
        }

        public virtual async Task CreateAsync(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.AddRange(models);
            await Repository.SaveAsync();
        }


        public virtual void Remove(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Remove(model);
            Repository.Save();
        }

        public virtual void Remove(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.RemoveRange(models);
            Repository.Save();
        }

        public virtual async Task RemoveAsync(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Remove(model);
            await Repository.SaveAsync();
        }

        public virtual async Task RemoveAsync(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.RemoveRange(models);
            await Repository.SaveAsync();
        }

        public virtual void Update(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Update(model);
            Repository.Save();
        }

        public virtual void Update(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.UpdateRange(models);
            Repository.Save();
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            if (model == null)
            {
                return;
            }

            Repository.Update(model);
            await Repository.SaveAsync();
        }

        public virtual async Task UpdateAsync(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                return;
            }

            Repository.UpdateRange(models);
            await Repository.SaveAsync();
        }
    }

    public class DataStore<TModel, TKeyType> : DataStore<TModel, TKeyType, IRepository<TModel, TKeyType>>
        where TModel : class, IWriteModel
        where TKeyType : struct
    {
        public DataStore(IRepository<TModel, TKeyType> repository)
            : base(repository)
        {
        }
    }

    public class DataStore<TModel> : DataStore<TModel, int, IRepository<TModel, int>>
    where TModel : class, IWriteModel
    {
        public DataStore(IRepository<TModel, int> repository)
            : base(repository)
        {
        }
    }
}

