using Castle.MicroKernel.Registration;
using BaseLib.EntityFramework.Configuration;
using BaseLib.EntityFramework.Repositories;
using BaseLib.EntityFramework.Uow;
using BaseLib.Modules;
using BaseLib.Orm;
using BaseLib.Reflection;
using System;
using System.Reflection;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// EntityFramework 数据访问层
    /// </summary>
    [DependsOn(typeof(BaseLibLeadershipModule))]
    public class BaseLibEntityFrameworkModule : BaseLibModule
    {
        private readonly ITypeFinder _typeFinder;

        public BaseLibEntityFrameworkModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public override void PreInitialize()
        {
            IocManager.Register<IBaseLibEfCoreConfiguration, BaseLibEfCoreConfiguration>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssembly(typeof(BaseLibEntityFrameworkModule).GetAssembly());

            IocManager.IocContainer.Register(
                Component.For(typeof(IDbContextProvider<>))
                    .ImplementedBy(typeof(UnitOfWorkDbContextProvider<>))
                    .LifestyleTransient()
                );

            RegisterGenericRepositoriesAndMatchDbContexes();
        }

        private void RegisterGenericRepositoriesAndMatchDbContexes()
        {
            var dbContextTypes =
                _typeFinder.Find(type =>
                {
                    var typeInfo = type.GetTypeInfo();
                    return typeInfo.IsPublic &&
                           !typeInfo.IsAbstract &&
                           typeInfo.IsClass &&
                           typeof(BaseLibDbContext).IsAssignableFrom(type);
                });

            if (dbContextTypes.IsNullOrEmpty())
            {
                Logger.Warn("No class found derived from BaseLibDbContext.");
                return;
            }

            foreach (var dbContextType in dbContextTypes)
            {
                Logger.Debug("Registering DbContext: " + dbContextType.AssemblyQualifiedName);

                IocManager.Resolve<IEfGenericRepositoryRegistrar>().RegisterForDbContext(dbContextType, IocManager, EfCoreAutoRepositoryTypes.Default);

                IocManager.IocContainer.Register(
                    Component.For<ISecondaryOrmRegistrar>()
                        .Named(Guid.NewGuid().ToString("N"))
                        .Instance(new EfCoreBasedSecondaryOrmRegistrar(dbContextType, IocManager.Resolve<IDbContextEntityFinder>()))
                        .LifestyleTransient()
                );
            }

            IocManager.Resolve<IDbContextTypeMatcher>().Populate(dbContextTypes);
        }
    }
}