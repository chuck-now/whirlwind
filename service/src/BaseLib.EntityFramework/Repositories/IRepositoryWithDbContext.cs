using Microsoft.EntityFrameworkCore;

namespace BaseLib.EntityFramework.Repositories
{
    /// <summary>
    /// IRepositoryWithDbContext
    /// </summary>
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}