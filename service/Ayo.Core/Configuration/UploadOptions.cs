using Microsoft.Extensions.Configuration;

namespace Ayo.Core.Configuration
{
    /// <summary>
    /// 文件上传配置
    /// </summary>
    public class UploadOptions
    {
        /// <summary>
        /// 七牛云AccessKey
        /// </summary>
        public string QiNIuAccessKey { get; internal set; }

        /// <summary>
        /// 七牛云SecretKey
        /// </summary>
        public string QiNIuSecretKey { get; internal set; }

        /// <summary>
        /// 七牛云上传空间
        /// </summary>
        public string QiNIuScope { get; internal set; }

        /// <summary>
        /// 七牛云外链地址
        /// </summary>
        public string QiNIuOutUrl { get; internal set; }

        public static UploadOptions ReadFromConfiguration(IConfiguration config)
        {
            UploadOptions options = new UploadOptions();
            var cs = config.GetSection("Upload");

            options.QiNIuAccessKey = cs.GetValue<string>(nameof(QiNIuAccessKey));
            options.QiNIuSecretKey = cs.GetValue<string>(nameof(QiNIuSecretKey));
            options.QiNIuScope = cs.GetValue<string>(nameof(QiNIuScope));
            options.QiNIuOutUrl = cs.GetValue<string>(nameof(QiNIuOutUrl));

            return options;
        }
    }
}