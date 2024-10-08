using StackExchange.Redis;

namespace BaseLib.RedisCache
{
    /// <summary>
    /// 用于获取 <see cref="IDatabase"/> Redis cache。
    /// </summary>
    public interface IBaseLibRedisCacheDatabaseProvider
    {
        /// <summary>
        /// 获取数据连接
        /// </summary>
        /// <returns></returns>
        IDatabase GetDatabase();
    }
}