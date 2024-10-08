using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseLib.Modules
{
    /// <summary>
    /// 将对象存储为字典
    /// </summary>
    public class BaseLibModuleCollection : List<BaseLibModuleInfo>
    {
        public Type StartupModuleType { get; }

        public BaseLibModuleCollection(Type startupModuleType)
        {
            StartupModuleType = startupModuleType;
        }

        public TModule GetModule<TModule>() where TModule : BaseLibModule
        {
            var BaseLibModuleInfo = this.FirstOrDefault((BaseLibModuleInfo x) => x.Type == typeof(TModule));
            if (BaseLibModuleInfo == null)
            {
                throw new BaseLibException("Can not find module for " + typeof(TModule).FullName);
            }
            return (TModule)BaseLibModuleInfo.Instance;
        }

        public List<BaseLibModuleInfo> GetSortedModuleListByDependency()
        {
            return this.SortByDependencies((BaseLibModuleInfo x) => x.Dependencies);
        }

        public void EnsureLeadershipToBeFirst()
        {
            EnsureLeadershipToBeFirst(this);
        }

        public void EnsureStartupModuleToBeLast()
        {
            EnsureStartupModuleToBeLast(this, StartupModuleType);
        }

        public static void EnsureLeadershipToBeFirst(List<BaseLibModuleInfo> modules)
        {
            int num = modules.FindIndex((BaseLibModuleInfo x) => x.Type == typeof(BaseLibLeadershipModule));
            if (num > 0)
            {
                BaseLibModuleInfo item = modules[num];
                modules.RemoveAt(num);
                modules.Insert(0, item);
            }
        }

        public static void EnsureStartupModuleToBeLast(List<BaseLibModuleInfo> modules, Type startupModuleType)
        {
            int num = modules.FindIndex((BaseLibModuleInfo x) => x.Type == startupModuleType);
            if (num < modules.Count - 1)
            {
                BaseLibModuleInfo item = modules[num];
                modules.RemoveAt(num);
                modules.Add(item);
            }
        }
    }
}