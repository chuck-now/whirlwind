using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BaseLib.EntityFramework.Configuration
{
    /// <summary>
    /// BaseLibDbContextConfiguration
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class BaseLibDbContextConfiguration<TDbContext>
        where TDbContext : DbContext
    {
        public string ConnectionString { get; internal set; }

        public DbConnection ExistingConnection { get; internal set; }

        public DbContextOptionsBuilder<TDbContext> DbContextOptions { get; }

        public BaseLibDbContextConfiguration(string connectionString, DbConnection existingConnection)
        {
            ConnectionString = connectionString;
            ExistingConnection = existingConnection;

            DbContextOptions = new DbContextOptionsBuilder<TDbContext>();
        }
    }
}