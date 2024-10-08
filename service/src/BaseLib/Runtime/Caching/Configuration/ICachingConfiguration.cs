using BaseLib.Configuration.Startup;
using System;
using System.Collections.Generic;

namespace BaseLib.Runtime.Caching.Configuration
{
    /// <summary>
    /// 缓存配置接口
    /// </summary>
    public interface ICachingConfiguration
    {
        /// <summary>
        /// 获取 BaseLib 配置对象。
        /// </summary>
        IBaseLibStartupConfiguration BaseLibConfiguration { get; }

        IReadOnlyList<ICacheConfigurator> Configurators { get; }

        void ConfigureAll(Action<ICache> initAction);

        void Configure(string cacheName, Action<ICache> initAction);
    }
}