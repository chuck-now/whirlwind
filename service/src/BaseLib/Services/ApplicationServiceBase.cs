using Castle.Core.Logging;
using BaseLib.Dependency;
using BaseLib.Event;

namespace BaseLib.Services
{
    public abstract class ApplicationServiceBase : IApplicationService, ITransientDependency
    {
        public ILogger Logger { protected get; set; }

        public IEventPublisher EventPublisher { protected get; set; }

        protected ApplicationServiceBase()
        {
            Logger = NullLogger.Instance;
            EventPublisher = BaseLibEngine.Instance.Resolve<IEventPublisher>();
        }
    }
}