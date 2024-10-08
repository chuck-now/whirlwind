using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using BaseLib.Configuration;
using BaseLib.Configuration.Startup;
using BaseLib.Domain.Uow;
using BaseLib.Modules;
using BaseLib.Reflection;
using BaseLib.Runtime.Caching.Configuration;

namespace BaseLib.Dependency.Installers
{
    /// <summary>
    /// BaseLibCoreInstaller
    /// </summary>
    internal class BaseLibCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<DefaultSettings>().ImplementedBy<DefaultSettings>().LifestyleSingleton(),
                Component.For<IUnitOfWorkDefaultOptions, UnitOfWorkDefaultOptions>().ImplementedBy<UnitOfWorkDefaultOptions>().LifestyleSingleton(),
                Component.For<IBaseLibStartupConfiguration, BaseLibStartupConfiguration>().ImplementedBy<BaseLibStartupConfiguration>().LifestyleSingleton(),
                Component.For<IBaseLibModuleManager, BaseLibModuleManager>().ImplementedBy<BaseLibModuleManager>().LifestyleSingleton(),
                Component.For<IAssemblyFinder, AssemblyFinder>().ImplementedBy<AssemblyFinder>().LifestyleSingleton(),
                Component.For<ITypeFinder, TypeFinder>().ImplementedBy<TypeFinder>().LifestyleSingleton(),
                Component.For<ICachingConfiguration, CachingConfiguration>().ImplementedBy<CachingConfiguration>().LifestyleSingleton(),
                Component.For<IValidationConfiguration, ValidationConfiguration>().ImplementedBy<ValidationConfiguration>().LifestyleSingleton()
            );
        }
    }
}