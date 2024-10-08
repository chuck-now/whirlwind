using Microsoft.EntityFrameworkCore;
using BaseLib.Domain.Uow;

namespace BaseLib.EntityFramework.Uow
{
    /// <summary>
    /// UnitOfWorkDbContextProvider
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        public UnitOfWorkDbContextProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }

        public TDbContext GetDbContext()
        {
            return _currentUnitOfWorkProvider.Current.GetDbContext<TDbContext>();
        }
    }
}