﻿using Castle.Core.Logging;
using BaseLib.Dependency;
using BaseLib.Runtime.Caching.Configuration;

namespace BaseLib.Runtime.Caching.Memory
{
    /// <summary>
    /// Implements <see cref="ICacheManager"/> to work with MemoryCache.
    /// </summary>
    public class BaseLibMemoryCacheManager : CacheManagerBase
    {
        public ILogger Logger { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseLibMemoryCacheManager(IIocManager iocManager, ICachingConfiguration configuration)
            : base(iocManager, configuration)
        {
            Logger = NullLogger.Instance;
        }

        protected override ICache CreateCacheImplementation(string name)
        {
            return new BaseLibMemoryCache(name)
            {
                Logger = Logger
            };
        }

        protected override void DisposeCaches()
        {
            foreach (var cache in Caches.Values)
            {
                cache.Dispose();
            }
        }
    }
}