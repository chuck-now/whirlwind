using BaseLib.Dependency;
using BaseLib.Runtime.Caching;
using BaseLib.Runtime.Caching.Configuration;
using System;

namespace BaseLib.RedisCache
{
    /// <summary>
    /// RedisCacheConfigurationExtensions
    /// </summary>
    public static class RedisCacheConfigurationExtensions
    {
        public static void UseRedis(this ICachingConfiguration cachingConfiguration)
        {
            cachingConfiguration.UseRedis(options => { });
        }

        public static void UseRedis(this ICachingConfiguration cachingConfiguration, Action<BaseLibRedisCacheOptions> optionsAction)
        {
            var iocManager = cachingConfiguration.BaseLibConfiguration.IocManager;

            iocManager.RegisterIfNot<ICacheManager, BaseLibRedisCacheManager>();

            optionsAction(iocManager.Resolve<BaseLibRedisCacheOptions>());
        }
    }
}