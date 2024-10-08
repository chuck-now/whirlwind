using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseLib.EntityFramework.Extensions
{
    /// <summary>
    /// DbContextExtensions
    /// </summary>
    internal static class DbContextExtensions
    {
        public static bool HasRelationalTransactionManager(this DbContext dbContext)
        {
            return dbContext.Database.GetService<IDbContextTransactionManager>() is IRelationalTransactionManager;
        }
    }
}