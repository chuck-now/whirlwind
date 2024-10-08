using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Ayo.Core.Configuration
{
    /// <summary>
    /// 应用的数据库存储配置
    /// </summary>
    public class StorageOptions
    {
        /// <summary>
        /// 多个数据库服务器ip+端口
        /// </summary>
        public IList<MongoDbServerAddress> MongoServers { get; internal set; }

        /// <summary>
        /// 数据库连接模式
        /// </summary>
        public string MongoConnectionMode { get; internal set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string MongoDbName { get; internal set; }

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string MongoUsername { get; internal set; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string MongoPassword { get; internal set; }

        /// <summary>
        /// 加载数据库配置
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static StorageOptions ReadFromConfiguration(IConfiguration config)
        {
            StorageOptions options = new StorageOptions();
            var cs = config.GetSection("Storage");

            options.MongoServers = new List<MongoDbServerAddress>();
            var mongoServersSource = cs.GetSection(nameof(MongoServers)).Get<List<string>>();
            if (mongoServersSource.IsNotNull() && mongoServersSource.Count > 0)
            {
                mongoServersSource.ForEach(x =>
                {
                    var host = x.Replace("：", ":").Split(':');
                    if (host.Length == 2)
                    {
                        options.MongoServers.Add(new MongoDbServerAddress() { Host = host[0], Port = host[1].ToInt() });
                    }
                });
            }

            options.MongoConnectionMode = cs.GetValue<string>(nameof(MongoConnectionMode));
            options.MongoDbName = cs.GetValue<string>(nameof(MongoDbName));
            options.MongoUsername = cs.GetValue<string>(nameof(MongoUsername));
            options.MongoPassword = cs.GetValue<string>(nameof(MongoPassword));
            return options;
        }
    }
}