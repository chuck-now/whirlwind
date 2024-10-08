using BaseLib.Configuration.Startup;
using System;

namespace BaseLib.RedisCache
{
    /// <summary>
    /// BaseLibRedisCacheOptions
    /// </summary>
    public class BaseLibRedisCacheOptions
    {
        public IBaseLibStartupConfiguration BaseLibStartupConfiguration { get; }

        public string ConnectionString { get; set; }

        public int DatabaseId { get; set; }

        public BaseLibRedisCacheOptions(IBaseLibStartupConfiguration BaseLibStartupConfiguration)
        {
            this.BaseLibStartupConfiguration = BaseLibStartupConfiguration;

            DatabaseId = GetDefaultDatabaseId();
            ConnectionString = GetDefaultConnectionString();
        }

        private static int GetDefaultDatabaseId()
        {
            try
            {
                var defaultRedisCacheSettings = BaseLibEngine.Instance.Resolve<DefaultRedisCacheSettings>();
                int databaseId = defaultRedisCacheSettings.DefaultDatabaseId;

                return databaseId;
            }
            catch (Exception ex)
            {
                throw new BaseLibException(ex.Message);
            }
        }

        private static string GetDefaultConnectionString()
        {
            try
            {
                var defaultRedisCacheSettings = BaseLibEngine.Instance.Resolve<DefaultRedisCacheSettings>();
                string connectionString = defaultRedisCacheSettings.DefaultConnectionString;

                return connectionString;
            }
            catch (Exception ex)
            {
                throw new BaseLibException(ex.Message);
            }
        }
    }
}