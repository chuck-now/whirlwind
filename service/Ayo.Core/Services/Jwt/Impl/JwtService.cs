using BaseLib;
using Ayo.Core.Configuration;

namespace Ayo.Core.Services.Jwt.Impl
{
    /// <summary>
    /// 生成JWT的service类
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;

        public JwtService()
        {
            _jwtOptions = BaseLibEngine.Instance.Resolve<JwtOptions>();
        }

        public object SecurityAlgorithms { get; private set; }

        /// <summary>
        /// 根据uid获取token
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetToken(string uid)
        {
            return "";
        }
    }
}