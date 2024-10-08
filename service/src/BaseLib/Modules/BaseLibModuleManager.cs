using Castle.Core.Logging;
using BaseLib.Configuration.Startup;
using BaseLib.Dependency;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BaseLib.Modules
{
    /// <summary>
    /// 模块管理
    /// </summary>
    public class BaseLibModuleManager : IBaseLibModuleManager
    {
        public BaseLibModuleInfo StartupModule { get; private set; }

        public IReadOnlyList<BaseLibModuleInfo> Modules => _modules.ToImmutableList();

        public ILogger Logger { get; set; }

        private BaseLibModuleCollection _modules;

        private readonly IIocManager _iocManager;

        public BaseLibModuleManager(IIocManager iocManager, IBaseLibStartupConfiguration startupConfiguration)
        {
            _iocManager = iocManager;
            Logger = NullLogger.Instance;
        }

        public virtual void Initialize(Type startupModule)
        {
            _modules = new BaseLibModuleCollection(startupModule);
            LoadAllModules();
        }

        public virtual void StartModules()
        {
            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.ForEach(module => module.Instance.PreInitialize());
            sortedModules.ForEach(module => module.Instance.Initialize());
            sortedModules.ForEach(module => module.Instance.PostInitialize());
        }

        public virtual void ShutdownModules()
        {
            Logger.Debug("开始关闭模块");
            List<BaseLibModuleInfo> sortedModuleListByDependency = _modules.GetSortedModuleListByDependency();
            sortedModuleListByDependency.Reverse();
            sortedModuleListByDependency.ForEach(delegate (BaseLibModuleInfo sm)
            {
                sm.Instance.Shutdown();
            });
            Logger.Debug("模块关闭完成");
        }

        private void LoadAllModules()
        {
            Logger.Debug("加载模块...");

            var moduleTypes = FindAllModuleTypes().Distinct().ToList();

            Logger.Debug("找到 " + moduleTypes.Count + " 个模块.");

            RegisterModules(moduleTypes);
            CreateModules(moduleTypes);

            _modules.EnsureLeadershipToBeFirst();
            _modules.EnsureStartupModuleToBeLast();

            SetDependencies();

            Logger.DebugFormat("{0} 个模块已加载.", _modules.Count);
        }

        private List<Type> FindAllModuleTypes()
        {
            return BaseLibModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(_modules.StartupModuleType);
        }

        private void CreateModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                if (!(_iocManager.Resolve(moduleType) is BaseLibModule moduleObject))
                {
                    throw new BaseLibInitializationException("从类型不是 BaseLib 模块: " + moduleType.AssemblyQualifiedName);
                }

                moduleObject.IocManager = _iocManager;
                moduleObject.Configuration = _iocManager.Resolve<IBaseLibStartupConfiguration>();

                var moduleInfo = new BaseLibModuleInfo(moduleType, moduleObject);

                _modules.Add(moduleInfo);

                if (moduleType == _modules.StartupModuleType)
                {
                    StartupModule = moduleInfo;
                }

                Logger.DebugFormat("加载模块: " + moduleType.AssemblyQualifiedName);
            }
        }

        private void RegisterModules(ICollection<Type> moduleTypes)
        {
            foreach (Type moduleType in moduleTypes)
            {
                _iocManager.RegisterIfNot(moduleType);
            }
        }

        private void SetDependencies()
        {
            foreach (BaseLibModuleInfo module in _modules)
            {
                module.Dependencies.Clear();
                foreach (Type dependedModuleType in BaseLibModule.FindDependedModuleTypes(module.Type))
                {
                    BaseLibModuleInfo BaseLibModuleInfo = _modules.FirstOrDefault((BaseLibModuleInfo m) => m.Type == dependedModuleType);
                    if (BaseLibModuleInfo == null)
                    {
                        throw new BaseLibInitializationException("无法找到依赖的模块 " + dependedModuleType.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName);
                    }
                    if (module.Dependencies.FirstOrDefault((BaseLibModuleInfo dm) => dm.Type == dependedModuleType) == null)
                    {
                        module.Dependencies.Add(BaseLibModuleInfo);
                    }
                }
            }
        }
    }
}