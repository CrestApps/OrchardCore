using CrestApps.Data.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrestApps.Data.Entity
{
    public class EntityRepository<TEntity, TKeyType> : EntityReadRepository<TEntity, TKeyType>, IRepository<TEntity, TKeyType>
         where TEntity : class, IWriteModel
         where TKeyType : struct
    {

        public EntityRepository(ApplicationContext context)
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

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
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

        public virtual void Remove(IEnumerable<TEntity> entities)
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


        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }

            DbSet.UpdateRange(entities);
        }


        public virtual void Save()
        {
            Context.SaveChanges();
        }



        public virtual async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

    }


    public class EntityRepository<TEntity> : EntityRepository<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class, IWriteModel
    {
        public EntityRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
