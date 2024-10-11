using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Manager.Admin.Params
{
    /// <summary>
    /// 修改账户密码传入参数
    /// </summary>
    public class UpdateAccountPasswordInput : OperatorInput
    {
        /// <summary>
        /// 账户id
        /// </summary>
        [Required(ErrorMessage = "账户id 不能为空")]
        public string Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码 不能为空")]
        public string Password { get; set; }
    }
}