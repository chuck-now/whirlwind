using Microsoft.EntityFrameworkCore;
using BaseLib.Domain.Entities;
using BaseLib.Domain.Repositories;
using BaseLib.Reflection;
using System;

namespace BaseLib.EntityFramework.Repositories
{
    /// <summary>
    /// EfCoreRepositoryExtensions
    /// </summary>
    public static class EfCoreRepositoryExtensions
    {
        public static DbContext GetDbContext<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            if (ProxyHelper.UnProxy(repository) is IRepositoryWithDbContext repositoryWithDbContext)
            {
                return repositoryWithDbContext.GetDbContext();
            }

            throw new ArgumentException("Given repository does not implement IRepositoryWithDbContext", nameof(repository));
        }

        public static void DetachFromDbContext<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TEntity entity)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            repository.GetDbContext().Entry(entity).State = EntityState.Detached;
        }
    }
}