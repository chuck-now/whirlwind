using System;

namespace BaseLib.Dependency
{
    /// <summary>
    /// 此接口用于包装从IOC容器解析的对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDisposableDependencyObjectWrapper<out T> : IDisposable
    {
        /// <summary>
        /// The resolved object
        /// </summary>
        T Object { get; }
    }
}