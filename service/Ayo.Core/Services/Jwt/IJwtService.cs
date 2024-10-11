namespace Ayo.Core.Services.Jwt
{
    public interface IJwtService
    {
        /// <summary>
        /// 根据uid获取token
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        string GetToken(string uid);
    }
}