using System;
using System.Collections.Generic;

namespace BaseLib.Modules
{
    /// <summary>
    /// 模块管理接口
    /// </summary>
    public interface IBaseLibModuleManager
    {
        BaseLibModuleInfo StartupModule { get; }

        IReadOnlyList<BaseLibModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}