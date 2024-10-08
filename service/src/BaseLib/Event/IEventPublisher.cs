using BaseLib.Dependency;

namespace BaseLib.Event
{
    public interface IEventPublisher : ITransientDependency
    {
        void Publish<T>(T eventMessage);
    }
}