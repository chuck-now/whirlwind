using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Manager.Admin.Params
{
    /// <summary>
    /// 账户登录传入参数
    /// </summary>
    public class AccountLoginInput
    {
        /// <summary>
        /// 用户名【用户名, 邮箱，手机号】
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}