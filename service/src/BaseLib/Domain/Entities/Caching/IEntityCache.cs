﻿using BaseLib.Runtime.Caching;
using System.Threading.Tasks;

namespace BaseLib.Domain.Entities.Caching
{
    /// <summary>
    /// IEntityCache
    /// </summary>
    /// <typeparam name="TCacheItem"></typeparam>
    public interface IEntityCache<TCacheItem> : IEntityCache<TCacheItem, int>
    {

    }

    /// <summary>
    /// IEntityCache
    /// </summary>
    /// <typeparam name="TCacheItem"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntityCache<TCacheItem, TPrimaryKey>
    {
        TCacheItem this[TPrimaryKey id] { get; }

        string CacheName { get; }

        ITypedCache<TPrimaryKey, TCacheItem> InternalCache { get; }

        TCacheItem Get(TPrimaryKey id);

        Task<TCacheItem> GetAsync(TPrimaryKey id);
    }
}