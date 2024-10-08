using BaseLib.Dependency;
using BaseLib.Domain.Uow;
using BaseLib.Event.Bus;
using BaseLib.Services;

namespace Ayo.Core.Services
{
    /// <summary>
    /// 所有应用服务的基类
    /// </summary>
    public abstract class ServiceBase : ApplicationServiceBase, ITransientDependency
    {
        public readonly IUnitOfWorkManager UnitOfWorkManager;
        public EventBus EventBus => EventBus.Default;

        public ServiceBase()
        {
        }
    }
}