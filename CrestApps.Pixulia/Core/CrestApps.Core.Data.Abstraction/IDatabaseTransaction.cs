using System;
using System.Threading.Tasks;

namespace CrestApps.Core.Data.Abstraction
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();

        Task CommitAsync();
        Task RollbackAsync();
    }
}

