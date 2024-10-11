using BaseLib.Services.Dto;
using BaseLib.WebApi;
using Ayo.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Ayo.Core.Dto.Manager;
using Ayo.Core.Dto.Manager.Admin.Params;
using Ayo.API.Jwt;
using Ayo.Core;

namespace Ayo.API.Controllers
{
    /// <summary>
    /// 账号管理
    /// </summary>
    public partial class AdminController : ApiControllerBase
    {
        #region account

        /// <summary>
        /// 获取账户详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.get")]
        public async Task<BaseLibResponse<AccountDto>> GetAccount([Required] string id)
        {
            var response = new BaseLibResponse<AccountDto>
            {
                Result = await _accountAdminService.GetAccount(id)
            };
            return response;
        }

        /// <summary>
        /// 获取账户详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.getbytoken")]
        public async Task<BaseLibResponse<AccountDto>> GetAccountByToken([Required] string token)
        {
            //var auth = HttpContext.AuthenticateAsync().Result.Principal.Claims;
            //var uid = auth.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var info = new JwtService().ResolveToken(token);
            var response = new BaseLibResponse<AccountDto>
            {
                Result = await _accountAdminService.GetAccount(info)
            };
            return response;
        }

        /// <summary>
        /// 查询账户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.query")]
        public async Task<BaseLibResponse<PagedResultDto<AccountDto>>> QueryAccount([FromBody] QueryAccountInput input)
        {
            var response = new BaseLibResponse<PagedResultDto<AccountDto>>
            {
                Result = await _accountAdminService.QueryAccount(input)
            };
            return response;
        }

        /// <summary>
        /// 账户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.login")]
        public async Task<BaseLibResponse<string>> AccountLogin([FromBody] AccountLoginInput input)
        {
            var response = new BaseLibResponse<string>();
            var uid = await _accountAdminService.AccountLogin(input);

            if (uid.IsNullOrEmpty())
            {
                throw new BizException(BizError.MANAGER_ACCOUNT_NOT_EXIST);
            }

            string token = new JwtService().GenerateToken(uid);

            if (token.IsNullOrEmpty())
            {
                throw new BizException(BizError.TOKEN_ERROR);
            }

            response.Result = token;
            return response;
        }

        /// <summary>
        /// 创建账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.insert")]
        public async Task<BaseLibResponse> InsertAccount([FromBody] InsertAccountInput input)
        {
            BaseLibResponse res = new BaseLibResponse();
            await _accountAdminService.InsertAccount(input);
            return res;
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.update")]
        public async Task<BaseLibResponse> UpdateAccount([FromBody] UpdateAccountInput input)
        {
            BaseLibResponse res = new BaseLibResponse();
            await _accountAdminService.UpdateAccount(input);
            return res;
        }

        /// <summary>
        /// 修改账户密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.password.update")]
        public async Task<BaseLibResponse> UpdateAccountPassword([FromBody] UpdateAccountPasswordInput input)
        {
            BaseLibResponse res = new BaseLibResponse();
            await _accountAdminService.UpdateAccountPassword(input);
            return res;
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.manager.account.delete")]
        public async Task<BaseLibResponse> DeleteAccount([FromBody] DeleteInput input)
        {
            BaseLibResponse res = new BaseLibResponse();
            await _accountAdminService.DeleteAccount(input);
            return res;
        }

        #endregion account
    }
}