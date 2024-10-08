using BaseLib.Domain.Entities;
using BaseLib.Domain.Repositories;

namespace Ayo.Core.Domain
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAyoRepository<TEntity> : IAyoRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IAyoRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}