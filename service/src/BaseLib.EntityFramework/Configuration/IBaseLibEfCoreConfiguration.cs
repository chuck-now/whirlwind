using Microsoft.EntityFrameworkCore;
using System;

namespace BaseLib.EntityFramework.Configuration
{
    /// <summary>
    /// IBaseLibEfCoreConfiguration
    /// </summary>
    public interface IBaseLibEfCoreConfiguration
    {
        void AddDbContext<TDbContext>(Action<BaseLibDbContextConfiguration<TDbContext>> action) where TDbContext : DbContext;
    }
}