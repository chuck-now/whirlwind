using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Manager.Admin.Params
{
    /// <summary>
    /// 编辑账户传入参数
    /// </summary>
    public class UpdateAccountInput : OperatorInput
    {
        /// <summary>
        /// 账户id
        /// </summary>
        [Required(ErrorMessage = "账户id 不能为空")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        public string MobilePhone { get; set; }
    }
}