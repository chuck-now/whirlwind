using Castle.Core.Logging;
using BaseLib.Configuration;
using BaseLib.Dependency;

namespace BaseLib
{
    /// <summary>
    /// 注入引擎
    /// </summary>
    public class BaseLibEngine
    {
        private bool _initialized = false;

        public IIocManager IocManager { get; private set; }

        public ILogger Logger { get; private set; }

        public DefaultSettings DefaultSettings { get; private set; }

        public static BaseLibEngine Instance { get; private set; }

        static BaseLibEngine()
        {
            Instance = new BaseLibEngine();
        }

        public void Initialize(IIocManager iocManage)
        {
            if (!_initialized)
            {
                Logger = NullLogger.Instance;
                IocManager = iocManage;
                _initialized = true;
                return;
            }
            throw new BaseLibException("BaseLibEngine 未初始化成功！");
        }

        public void PostInitialize()
        {
            if (_initialized)
            {
                DefaultSettings = Resolve<DefaultSettings>();
            }
        }

        public void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where T : class
        {
            IocManager.Register(typeof(T), typeof(T), lifeStyle);
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocManager.Register(typeof(TType), typeof(TImpl), lifeStyle);
        }

        public T Resolve<T>() where T : class
        {
            return IocManager.Resolve<T>();
        }
    }
}