using Microsoft.EntityFrameworkCore;
using BaseLib.Dependency;
using BaseLib.Domain.Uow;

namespace BaseLib.EntityFramework.Uow
{
    /// <summary>
    /// IEfCoreTransactionStrategy
    /// </summary>
    public interface IEfCoreTransactionStrategy
    {
        void InitOptions(UnitOfWorkOptions options);

        DbContext CreateDbContext<TDbContext>(string connectionString, IDbContextResolver dbContextResolver) where TDbContext : DbContext;

        void Commit();

        void Dispose(IIocResolver iocResolver);
    }
}