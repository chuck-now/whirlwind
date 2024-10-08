using MongoDB.Bson;
using MongoDB.Driver;
using BaseLib.Domain.Entities;
using BaseLib.MongoDb.Repositories;

namespace Ayo.Core.Storage.Mongodb
{
    public abstract class MongodbRepositoryBase
    {
        private readonly MongodbDatabaseProvider _dbProvider;

        public MongodbRepositoryBase(MongodbDatabaseProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public IMongoClient Client => _dbProvider.Client;

        public IMongoDatabase Database => _dbProvider.Database;
    }

    public abstract class MongodbRepositoryBase<TEntity> : MongodbRepositoryBase<TEntity, ObjectId>
            where TEntity : class, IEntity<ObjectId>
    {
        public MongodbRepositoryBase(MongodbDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }

    public abstract class MongodbRepositoryBase<TEntity, TPrimaryKey> : MongoDbRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public MongodbRepositoryBase(MongodbDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}