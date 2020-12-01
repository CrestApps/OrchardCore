using CrestApps.Core.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public class EntityRepository<TEntity, TKeyType> : EntityReadRepository<TEntity, TKeyType>, IRepository<TEntity, TKeyType>
        where TEntity : class, IWriteModel
        where TKeyType : struct
    {

        public EntityRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            DbSet.Add(entity);

            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return null;
            }

            DbSet.AddRange(entities);

            return entities;
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }

            DbSet.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            DbSet.Attach(entity);
            var record = Context.Entry(entity);
            record.State = EntityState.Modified;
        }


        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }

            foreach (TEntity entity in entities)
            {
                Update(entity);
            }
        }


        //public virtual void AddOrUpdate(TEntity entity)
        //{
        //    if (entity == null)
        //    {
        //        return;
        //    }


        //    DbSet.AddOrUpdate(entity);
        //}

        //public virtual void AddOrUpdateRange(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    DbSet.AddOrUpdate(entities.ToArray());
        //}

        public virtual void Save()
        {
            Context.SaveChanges();
        }


        //public void BulkMerge(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    Context.BulkMerge(entities);
        //}


        //public async Task BulkMergeAsync(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    await Context.BulkMergeAsync(entities);
        //}


        //public void BulkAdd(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    Context.BulkInsert(entities);
        //}

        //public void BulkRemove(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    Context.BulkDelete(entities);
        //}

        //public void BulkUpdate(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    Context.BulkUpdate(entities);
        //}


        //public async Task BulkAddAsync(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    await Context.BulkInsertAsync(entities);
        //}

        //public async Task BulkRemoveAsync(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    await Context.BulkDeleteAsync(entities);
        //}


        //public async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    await Context.BulkUpdateAsync(entities);
        //}

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

    }


    public class EntityRepository<TEntity> : EntityRepository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IWriteModel
    {
        public EntityRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
