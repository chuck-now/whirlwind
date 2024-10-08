using BaseLib.Dependency;
using BaseLib.Domain.Uow;
using BaseLib.Runtime.Caching.Configuration;
using System;
using System.Collections.Generic;

namespace BaseLib.Configuration.Startup
{
    /// <summary>
    /// 该类用于在启动时配置模块
    /// </summary>
    public class BaseLibStartupConfiguration : DictionaryBasedConfig, IBaseLibStartupConfiguration, IDictionaryBasedConfig
    {
        public IIocManager IocManager { get; private set; }

        public Dictionary<Type, Action> ServiceReplaceActions { get; private set; }

        public IUnitOfWorkDefaultOptions UnitOfWork { get; private set; }

        public ICachingConfiguration Caching { get; private set; }

        public IValidationConfiguration Validation { get; private set; }

        public DefaultSettings DefaultSettings { get; private set; }

        public BaseLibStartupConfiguration(IIocManager iocManager, DefaultSettings settings)
        {
            IocManager = iocManager;
            DefaultSettings = settings;
        }

        public void Initialize()
        {
            UnitOfWork = IocManager.Resolve<IUnitOfWorkDefaultOptions>();
            Caching = IocManager.Resolve<ICachingConfiguration>();
            Validation = IocManager.Resolve<IValidationConfiguration>();
            ServiceReplaceActions = new Dictionary<Type, Action>();
        }

        public void ReplaceService(Type type, Action replaceAction)
        {
            ServiceReplaceActions[type] = replaceAction;
        }

        public T Get<T>()
        {
            return GetOrCreate(typeof(T).FullName, () => IocManager.Resolve<T>());
        }
    }
}