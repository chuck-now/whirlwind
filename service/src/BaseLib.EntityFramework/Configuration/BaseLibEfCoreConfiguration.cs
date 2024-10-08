using Castle.MicroKernel.Registration;
using Microsoft.EntityFrameworkCore;
using BaseLib.Dependency;
using System;

namespace BaseLib.EntityFramework.Configuration
{
    /// <summary>
    /// BaseLibEfCoreConfiguration
    /// </summary>
    public class BaseLibEfCoreConfiguration : IBaseLibEfCoreConfiguration
    {
        private readonly IIocManager _iocManager;

        public BaseLibEfCoreConfiguration(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        public void AddDbContext<TDbContext>(Action<BaseLibDbContextConfiguration<TDbContext>> action) where TDbContext : DbContext
        {
            _iocManager.IocContainer.Register(
                Component.For<IBaseLibDbContextConfigurer<TDbContext>>().Instance(
                    new BaseLibDbContextConfigurerAction<TDbContext>(action)
                ).IsDefault()
            );
        }
    }
}