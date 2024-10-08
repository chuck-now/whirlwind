using AutoMapper;
using Castle.MicroKernel.Registration;
using BaseLib.Configuration.Startup;
using BaseLib.Modules;
using BaseLib.Reflection;
using System.Reflection;
using IObjectMapper = BaseLib.ObjectMapping.IObjectMapper;
using System;
using System.Collections.Generic;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// BaseLibeAutoMapperModule
    /// </summary>
    [DependsOn(typeof(BaseLibLeadershipModule))]
    public class BaseLibAutoMapperModule : BaseLibModule
    {
        private readonly ITypeFinder _typeFinder;

        private static volatile bool _createdMappingsBefore;
        private static readonly object SyncObj = new object();

        public BaseLibAutoMapperModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public override void PreInitialize()
        {
            IocManager.Register<IBaseLibAutoMapperConfiguration, BaseLibAutoMapperConfiguration>();

            Configuration.ReplaceService<IObjectMapper, AutoMapperObjectMapper>();
        }

        public override void PostInitialize()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            lock (SyncObj)
            {
                Action<IMapperConfigurationExpression> action = delegate (IMapperConfigurationExpression configuration)
                {
                    configuration.CreateMissingTypeMaps = true;
                    FindAndAutoMapTypes(configuration);
                    IEnumerable<Type> enumerable = _typeFinder.FindClassesOfType<IAutoMapRegistrar>();
                    List<IAutoMapRegistrar> list = new List<IAutoMapRegistrar>();
                    foreach (Type item2 in enumerable)
                    {
                        IAutoMapRegistrar item = Activator.CreateInstance(item2) as IAutoMapRegistrar;
                        list.Add(item);
                    }

                    list.ForEach(delegate (IAutoMapRegistrar x)
                    {
                        x.RegisterMaps(configuration);
                    });
                    foreach (Action<IMapperConfigurationExpression> configurator in base.IocManager.Resolve<IBaseLibAutoMapperConfiguration>().Configurators)
                    {
                        configurator(configuration);
                    }
                };
                if (IocManager.Resolve<IBaseLibAutoMapperConfiguration>().UseStaticMapper)
                {
                    if (!_createdMappingsBefore)
                    {
                        Mapper.Initialize(action);
                        _createdMappingsBefore = true;
                    }

                    IocManager.IocContainer.Register(Component.For<IMapper>().Instance(Mapper.Instance).LifestyleSingleton());
                }
                else
                {
                    MapperConfiguration mapperConfiguration = new MapperConfiguration(action);
                    IocManager.IocContainer.Register(Component.For<IMapper>().Instance(mapperConfiguration.CreateMapper()).LifestyleSingleton());
                }
            }
        }

        private void FindAndAutoMapTypes(IMapperConfigurationExpression configuration)
        {
            Type[] array = _typeFinder.Find(delegate (Type type)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(AutoMapAttribute)) || typeInfo.IsDefined(typeof(AutoMapFromAttribute)) || typeInfo.IsDefined(typeof(AutoMapToAttribute));
            });

            Logger.DebugFormat("Found {0} classes define auto mapping attributes", array.Length);

            Type[] array2 = array;
            foreach (Type type2 in array2)
            {
                Logger.Debug(type2.FullName);
                configuration.CreateAutoAttributeMaps(type2);
            }
        }
    }
}