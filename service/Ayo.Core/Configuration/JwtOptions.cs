using Microsoft.Extensions.Configuration;

namespace Ayo.Core.Configuration
{
    /// <summary>
    /// jwt token配置
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// 谁颁发的
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 颁发给谁
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 令牌密码
        /// a secret that needs to be at least 16 characters long
        /// </summary>
        public string SigningKey { get; set; }

        public static JwtOptions ReadFromConfiguration(IConfiguration config)
        {
            JwtOptions options = new JwtOptions();
            var cs = config.GetSection("Jwt");

            options.Audience = cs.GetValue<string>(nameof(Audience));
            options.Issuer = cs.GetValue<string>(nameof(Issuer));
            options.SigningKey = cs.GetValue<string>(nameof(SigningKey));

            return options;
        }
    }
}