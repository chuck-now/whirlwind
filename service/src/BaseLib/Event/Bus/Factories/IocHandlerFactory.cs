using BaseLib.Dependency;
using BaseLib.Event.Bus.Handlers;
using System;

namespace BaseLib.Event.Bus.Factories
{
    /// <summary>
    /// IocHandlerFactory
    /// </summary>
    public class IocHandlerFactory : IEventHandlerFactory
    {
        private readonly IIocResolver _iocResolver;

        public Type HandlerType { get; private set; }

        public IocHandlerFactory(IIocResolver iocResolver, Type handlerType)
        {
            _iocResolver = iocResolver;
            HandlerType = handlerType;
        }

        public IEventHandler GetHandler()
        {
            return (IEventHandler)_iocResolver.Resolve(HandlerType);
        }

        public void ReleaseHandler(IEventHandler handler)
        {
            _iocResolver.Release(handler);
        }
    }
}