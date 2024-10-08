using BaseLib.Configuration.Startup;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// BaseLibAutoMapperConfigurationExtensions
    /// </summary>
    public static class BaseLibAutoMapperConfigurationExtensions
    {
        public static IBaseLibAutoMapperConfiguration BaseLibAutoMapper(this IBaseLibStartupConfiguration configuration)
        {
            return configuration.Get<IBaseLibAutoMapperConfiguration>();
        }
    }
}