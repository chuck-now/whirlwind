using BaseLib.Dependency;
using BaseLib.Runtime.Caching.Configuration;

namespace BaseLib.Runtime.Caching.Memory
{
    public static class BaseLibMemoryCacheConfigurationExtensions
    {
        public static void UseMemoryCache(this ICachingConfiguration cachingConfiguration)
        {
            IIocManager iocManager = cachingConfiguration.BaseLibConfiguration.IocManager;
            iocManager.RegisterIfNot<ICacheManager, BaseLibMemoryCacheManager>();
        }
    }
}