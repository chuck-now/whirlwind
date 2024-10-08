using Ayo.Core.Configuration;
using Ayo.Core.Domain;
using Ayo.Core.Storage.Mongodb;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Reflection;
using BaseLib;
using BaseLib.AutoMapper;
using BaseLib.Modules;
using BaseLib.MongoDb;

namespace Ayo.Core
{
    [DependsOn(
      typeof(BaseLibLeadershipModule),
      typeof(BaseLibMongoDbModule),
      typeof(BaseLibAutoMapperModule)
      )]
    public class AyoCoreModule : BaseLibModule
    {
        public override void PreInitialize()
        {
            var options = IocManager.Resolve<AppOptions>();

            #region Mongodb

            IocManager.Register<MongodbDatabaseProvider>();

            var camelCaseConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConventionPack, type => true);

            BsonClassMap.RegisterClassMap<BaseEntity>(u =>
            {
                u.AutoMap();

                u.MapIdMember(x => x.Id).SetIdGenerator(ObjectIdGenerator.Instance);
                u.MapProperty(x => x.CreatedAt).SetSerializer(new DateTimeSerializer(DateTimeKind.Local));
                u.MapProperty(x => x.UpdatedAt).SetSerializer(new DateTimeSerializer(DateTimeKind.Local));

                u.SetIgnoreExtraElements(true);
            });

            MongodbMapper.CreateMappings();

            #endregion Mongodb
        }

        public override void Initialize()
        {
            IocManager.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}