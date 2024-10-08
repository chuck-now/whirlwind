using BaseLib.Domain.Entities;
using up = BaseLib.Domain.Repositories;

namespace Ayo.Core.Storage.Mongodb
{
    public interface IMongodbRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {
    }

    public interface IRepository<TEntity, TPrimaryKey> : up.IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}