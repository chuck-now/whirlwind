using System.Reflection;
using BaseLib;
using BaseLib.Modules;
using Ayo.Core;

namespace Ayo.API
{
    [DependsOn(
       typeof(BaseLibLeadershipModule),
       typeof(AyoCoreModule)
       )]
    public class AyoAPIModule : BaseLibModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}