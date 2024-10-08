using Microsoft.EntityFrameworkCore;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// IDbContextProvider
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IDbContextProvider<out TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}