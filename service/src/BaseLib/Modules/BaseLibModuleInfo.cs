using System;
using System.Collections.Generic;
using System.Reflection;

namespace BaseLib.Modules
{
    /// <summary>
    /// BaseLibModuleInfo
    /// </summary>
    public class BaseLibModuleInfo
    {
        public Assembly Assembly { get; }

        public Type Type { get; }

        public BaseLibModule Instance { get; }

        public bool IsLoadedAsPlugIn { get; }

        public List<BaseLibModuleInfo> Dependencies { get; }

        public BaseLibModuleInfo(Type type, BaseLibModule instance)
        {
            Type = type;
            Instance = instance;
            Assembly = Type.GetTypeInfo().Assembly;
            Dependencies = new List<BaseLibModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ?? Type.FullName;
        }
    }
}