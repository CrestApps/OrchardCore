using CrestApps.Data.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
namespace CrestApps.Data.Entity
{
    public class EntityReadRepository<TEntity, TKeyType> : IReadRepository<TEntity, TKeyType>
         where TEntity : class, IReadModel
         where TKeyType : struct
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public EntityReadRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }


        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Query().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(TKeyType id, CancellationToken cancellationToken = default)
        {
            TEntity entity = await DbSet.FindAsync(new object[] { id }, cancellationToken);

            return entity;
        }

        public virtual async Task<TEntity> FirstAsync(TKeyType id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(id, cancellationToken) ?? throw new ModelNotFoundException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Query().ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Query().AnyAsync(predicate, cancellationToken);
        }



        public virtual TEntity Get(TKeyType id)
        {
            TEntity entity = DbSet.Find(new object[] { id });

            return entity;
        }

        public virtual TEntity First(TKeyType id)
        {
            return Get(id) ?? throw new ModelNotFoundException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Query().ToList();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().Any(predicate);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().Where(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().SingleOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> Query(QueryOptions options = null)
        {
            if (options != null && !options.IsTrackable)
            {
                return DbSet.AsNoTracking();
            }

            return DbSet;
        }
    }


    public class EntityReadRepository<TEntity> : EntityReadRepository<TEntity, Guid>
        where TEntity : class, IReadModel
    {
        public EntityReadRepository(DbContext context)
            : base(context)
        {
        }
    }
}
