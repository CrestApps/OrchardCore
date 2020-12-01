namespace CrestApps.Core.Data.Abstraction
{
    public interface IUnitOfWorkTransaction
    {
        IDatabaseTransaction BeginTransaction();
    }
}

