using BaseLib.Dependency;
using System.Collections.Generic;

namespace BaseLib.Event
{
    public interface ISubscriptionService : ITransientDependency
    {
        IList<IConsumer<T>> GetSubscriptions<T>();
    }
}