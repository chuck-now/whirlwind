using Microsoft.EntityFrameworkCore;
using BaseLib.Domain.Entities;
using BaseLib.Domain.Repositories;

namespace BaseLib.EntityFramework.Repositories
{
    /// <summary>
    /// EfCoreRepositoryBase
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class EfCoreRepositoryBase<TDbContext, TEntity> : EfCoreRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : DbContext
    {
        public EfCoreRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}