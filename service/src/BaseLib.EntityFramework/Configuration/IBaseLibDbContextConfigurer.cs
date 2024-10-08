using Microsoft.EntityFrameworkCore;

namespace BaseLib.EntityFramework.Configuration
{
    /// <summary>
    /// IBaseLibDbContextConfigurer
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IBaseLibDbContextConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        void Configure(BaseLibDbContextConfiguration<TDbContext> configuration);
    }
}