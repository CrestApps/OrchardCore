using CrestApps.Data.Core.Abstraction;
using CrestApps.Data.Models;

namespace CrestApps.Data.Abstraction
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IRepository<Location> Locations { get; }
    }
}
