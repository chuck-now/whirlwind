using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using BaseLib.Configuration.Startup;
using BaseLib.Dependency;
using BaseLib.Dependency.Installers;
using BaseLib.Domain.Uow;
using BaseLib.Modules;
using BaseLib.Runtime.Validation.Interception;
using System;
using System.Reflection;

namespace BaseLib
{
    /// <summary>
    /// BaseLibStarter
    /// </summary>
    public class BaseLibStarter : IDisposable
    {
        protected bool IsDisposed;

        private ILogger _logger;

        private IBaseLibModuleManager _moduleManager;

        public Type StartupModule { get; }

        public IIocManager IocManager { get; }

        private BaseLibStarter(Type startupModule, Action<BaseLibStarterOptions> optionsAction = null)
        {
            BaseLibStarterOptions BaseLibStarterOptions = new BaseLibStarterOptions();
            optionsAction?.Invoke(BaseLibStarterOptions);
            if (!((TypeInfo)typeof(BaseLibModule)).IsAssignableFrom(startupModule))
            {
                throw new ArgumentException("startupModule should be derived from BaseLibModule.");
            }
            StartupModule = startupModule;
            IocManager = BaseLibStarterOptions.IocManager;
            _logger = NullLogger.Instance;
            AddInterceptorRegistrars();
        }

        public static BaseLibStarter Create<TStartupModule>(Action<BaseLibStarterOptions> optionsAction = null) where TStartupModule : BaseLibModule
        {
            return new BaseLibStarter(typeof(TStartupModule), optionsAction);
        }

        public static BaseLibStarter Create(Type startupModule, Action<BaseLibStarterOptions> optionsAction = null)
        {
            return new BaseLibStarter(startupModule, optionsAction);
        }

        public virtual void Initialize()
        {
            BaseLibEngine.Instance.Initialize(IocManager);
            ResolveLogger();
            try
            {
                RegisterStarter();
                _logger.Debug("BaseLibStarter 开始初始化.");
                BaseLibEngine.Instance.IocManager.IocContainer.Install(new BaseLibCoreInstaller());
                BaseLibEngine.Instance.PostInitialize();
                IocManager.Resolve<BaseLibStartupConfiguration>().Initialize();
                _moduleManager = BaseLibEngine.Instance.Resolve<BaseLibModuleManager>();
                _moduleManager.Initialize(StartupModule);
                _moduleManager.StartModules();
                _logger.Debug("BaseLibStarter 初始化完成.");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }

        public virtual void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                _moduleManager?.ShutdownModules();
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(BaseLibStarter));
            }
        }

        private void RegisterStarter()
        {
            if (!IocManager.IsRegistered<BaseLibStarter>())
            {
                IocManager.IocContainer.Register(
                     Component.For<BaseLibStarter>().Instance(this)
                );
            }
        }

        public void AddInterceptorRegistrars()
        {
            ValidationInterceptorRegistrar.Initialize(IocManager);
            UnitOfWorkRegistrar.Initialize(IocManager);
        }
    }
}