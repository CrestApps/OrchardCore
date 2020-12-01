using CrestApps.Core.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public abstract class EntityUnitOfWorkBase<TDbContext> : IDisposable
            where TDbContext : DbContext
    {
        private bool Disposed = false;
        protected TDbContext Context { get; private set; }
        protected ILogger Logger { get; private set; }

        protected EntityUnitOfWorkBase(TDbContext context, ILogger logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual int Save()
        {
            Context.SaveChanges();

            return 0;
        }

        public virtual async Task<int> SaveAsync()
        {
            await Context.SaveChangesAsync();

            return 0;
        }

        public virtual IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(Context);
        }


        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed && Context != null && disposing)
            {
                Context.Dispose();
            }

            Disposed = true;
        }

    }
}

