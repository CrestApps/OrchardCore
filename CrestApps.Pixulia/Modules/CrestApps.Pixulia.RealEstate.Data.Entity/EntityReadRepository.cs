using CrestApps.Core.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
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

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> GetAsync(TKeyType id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> FirstAsync(TKeyType id)
        {
            return await GetAsync(id) ?? throw new ModelNotFoundException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }



        public virtual TEntity Get(TKeyType id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity First(TKeyType id)
        {
            return Get(id) ?? throw new ModelNotFoundException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> Query()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> Query(QueryOptions options)
        {
            if (options != null && !options.IsTrackable)
            {
                return DbSet.AsNoTracking();
            }

            return Query();
        }
    }


    public class EntityReadRepository<TEntity> : EntityReadRepository<TEntity, int>
        where TEntity : class, IReadModel
    {
        public EntityReadRepository(DbContext context)
            : base(context)
        {
        }
    }
}

