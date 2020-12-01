using CrestApps.Data.Abstraction;
using CrestApps.Data.Core.Abstraction;
using CrestApps.Data.Models;
using Microsoft.Extensions.Logging;

namespace CrestApps.Data.Entity
{
    public class UnitOfWork : EntityUnitOfWorkBase<ApplicationContext, UnitOfWork>, IUnitOfWork
    {
        public IRepository<Location> Locations { get; private set; }

        public UnitOfWork(ApplicationContext context, ILogger<UnitOfWork> logger)
            : base(context, logger)
        {
            Locations = new EntityRepository<Location>(context);
        }

    }
}
