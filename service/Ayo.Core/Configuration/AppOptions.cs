using Microsoft.Extensions.Configuration;

namespace Ayo.Core.Configuration
{
    /// <summary>
    /// 应用配置，所有配置项聚合
    /// - Storage 数据存储
    /// - Caching 缓存配置
    /// - APIService 外部服务接口配置
    /// - Evaluation 测评相关配置
    /// </summary>
    public class AppOptions
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 最小工作线程
        /// 小于16 不设置
        /// https://stackexchange.github.io/StackExchange.Redis/Timeouts
        /// 当大量并发进入服务器时，线程池立即创建线程来达到这个最小值，超过最小值后线程池创建新的线程速率是比较慢的，这时新的线程来不及创建补充从而造成阻塞排队。
        /// 16 核 16G 最大工作线程 = 32767
        /// </summary>
        public int SetMinThreads { get; internal set; }

        /// <summary>
        /// 数据库存储配置
        /// </summary>
        public StorageOptions StorageOptions { get; internal set; }

        /// <summary>
        /// 上传配置
        /// </summary>
        public UploadOptions UploadOptions { get; internal set; }

        /// <summary>
        /// 初始化读取
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static AppOptions ReadFromConfiguration(IConfiguration config)
        {
            AppOptions options = new AppOptions
            {
                Name = config.GetValue<string>(nameof(Name)),
                StorageOptions = StorageOptions.ReadFromConfiguration(config),
                UploadOptions = UploadOptions.ReadFromConfiguration(config)
            };
            return options;
        }
    }
}