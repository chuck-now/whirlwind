using BaseLib;
using Ayo.Core.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using Ayo.Core;

namespace Ayo.API.Jwt
{
    /// <summary>
    /// 生成JWT的service类
    /// </summary>
    public class JwtService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SecurityKey SecurityKey;

        public JwtService()
        {
            _jwtOptions = BaseLibEngine.Instance.Resolve<JwtOptions>();
            SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));
        }

        public string GenerateToken(string uid)
        {
            var claims = new Claim[] {
                new Claim (ClaimTypes.Name,uid)
            };

            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string ResolveToken(string token)
        {
            //校验token
            var validateParameter = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = SecurityKey,
            };
            //不校验，直接解析token
            //  var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var output = string.Empty;
            try
            {
                //校验并解析token
                var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validateParameter, out SecurityToken validatedToken);//validatedToken:解密后的对象
                                                                                                                                              // var jwtPayload = ((JwtSecurityToken)validatedToken).Payload; //获取payload中的数据
                output = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }
            catch (SecurityTokenExpiredException)
            {
                throw new BizException(BizError.TOKEN_EXPIRED);
            }
            catch (SecurityTokenException)
            {
                throw new BizException(BizError.TOKEN_ERROR);
            }
            return output;
        }
    }
}