using BaseLib.Services.Dto;
using Ayo.Core.Dto;
using Ayo.Core.Dto.Manager;
using Ayo.Core.Dto.Manager.Admin.Params;
using System.Threading.Tasks;

namespace Ayo.Core.Services.Manager.Admin
{
    /// <summary>
    /// 后台账号管理服务
    /// </summary>
    public interface IAccountAdminService
    {
        /// <summary>
        /// 获取账户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccount(string id);

        /// <summary>
        /// 查询账户
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<AccountDto>> QueryAccount(QueryAccountInput input);

        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> AccountLogin(AccountLoginInput input);

        /// <summary>
        /// 创建账户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task InsertAccount(InsertAccountInput input);

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAccount(UpdateAccountInput input);

        /// <summary>
        /// 修改账户密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAccountPassword(UpdateAccountPasswordInput input);

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAccount(DeleteInput input);
    }
}