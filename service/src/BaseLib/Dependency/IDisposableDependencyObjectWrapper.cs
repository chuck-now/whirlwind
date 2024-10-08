using System;

namespace BaseLib.Dependency
{
    /// <summary>
    /// 此接口用于包装从IOC容器解析的对象
    /// </summary>
    public interface IDisposableDependencyObjectWrapper : IDisposableDependencyObjectWrapper<object>, IDisposable
    {

    }
}