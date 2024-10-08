using BaseLib.Dependency;
using System.Collections.Generic;

namespace BaseLib.Event
{
    public class SubscriptionService : ISubscriptionService, ITransientDependency
    {
        public IList<IConsumer<T>> GetSubscriptions<T>()
        {
            return BaseLibEngine.Instance.IocManager.ResolveAll<IConsumer<T>>();
        }
    }
}