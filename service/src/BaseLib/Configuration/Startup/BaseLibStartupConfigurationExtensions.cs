using BaseLib.Dependency;
using System;

namespace BaseLib.Configuration.Startup
{
    /// <summary>
    /// BaseLibStartupConfigurationExtensions
    /// </summary>
    public static class BaseLibStartupConfigurationExtensions
    {
        public static void ReplaceService(this IBaseLibStartupConfiguration configuration, Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            configuration.ReplaceService(type, delegate
            {
                configuration.IocManager.Register(type, impl, lifeStyle);
            });
        }

        public static void ReplaceService<TType, TImpl>(this IBaseLibStartupConfiguration configuration, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class where TImpl : class, TType
        {
            configuration.ReplaceService(typeof(TType), delegate
            {
                configuration.IocManager.Register<TType, TImpl>(lifeStyle);
            });
        }

        public static void ReplaceService<TType>(this IBaseLibStartupConfiguration configuration, Action replaceAction) where TType : class
        {
            configuration.ReplaceService(typeof(TType), replaceAction);
        }
    }
}