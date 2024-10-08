using BaseLib.Modules;
using BaseLib.MongoDb.Configuration;
using BaseLib.MongoDb.Uow;
using System.Reflection;

namespace BaseLib.MongoDb
{
    /// <summary>
    /// MongoDB 数据访问层
    /// </summary>
    [DependsOn(typeof(BaseLibLeadershipModule))]
    public class BaseLibMongoDbModule : BaseLibModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IMongoDbModuleConfiguration, MongoDbModuleConfiguration>();
        }

        public override void Initialize()
        {
            IocManager.Register<IMongoDatabaseProvider, UnitOfWorkMongoDatabaseProvider>();
            IocManager.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}