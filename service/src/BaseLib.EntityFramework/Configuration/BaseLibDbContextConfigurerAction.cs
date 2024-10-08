using Microsoft.EntityFrameworkCore;
using System;

namespace BaseLib.EntityFramework.Configuration
{
    /// <summary>
    /// BaseLibDbContextConfigurerAction
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class BaseLibDbContextConfigurerAction<TDbContext> : IBaseLibDbContextConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        public Action<BaseLibDbContextConfiguration<TDbContext>> Action { get; set; }

        public BaseLibDbContextConfigurerAction(Action<BaseLibDbContextConfiguration<TDbContext>> action)
        {
            Action = action;
        }

        public void Configure(BaseLibDbContextConfiguration<TDbContext> configuration)
        {
            Action(configuration);
        }
    }
}