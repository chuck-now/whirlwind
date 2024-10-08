using BaseLib.Dependency;
using BaseLib.Runtime.Caching;
using BaseLib.Runtime.Caching.Configuration;

namespace BaseLib.RedisCache
{
    /// <summary>
    /// BaseLibRedisCacheManager
    /// </summary>
    public class BaseLibRedisCacheManager : CacheManagerBase
    {
        public BaseLibRedisCacheManager(IIocManager iocManager, ICachingConfiguration configuration)
            : base(iocManager, configuration)
        {
            IocManager.RegisterIfNot<BaseLibRedisCache>(DependencyLifeStyle.Transient);
        }

        protected override ICache CreateCacheImplementation(string name)
        {
            return IocManager.Resolve<BaseLibRedisCache>();
        }
    }
}