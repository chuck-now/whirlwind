using BaseLib.Configuration.Startup;
using BaseLib.Dependency;

namespace BaseLib.Domain.Uow
{
    /// <summary>
    /// DefaultConnectionStringResolver
    /// </summary>
    public class DefaultConnectionStringResolver : IConnectionStringResolver, ITransientDependency
    {
        private readonly IBaseLibStartupConfiguration _configuration;

        public DefaultConnectionStringResolver(IBaseLibStartupConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            string defaultNameOrConnectionString = _configuration.DefaultSettings.GetDefaultNameOrConnectionString();
            if (!string.IsNullOrWhiteSpace(defaultNameOrConnectionString))
            {
                return defaultNameOrConnectionString;
            }
            return defaultNameOrConnectionString;
        }
    }
}