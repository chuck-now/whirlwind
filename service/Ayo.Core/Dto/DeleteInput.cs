using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto
{
    /// <summary>
    /// 单个删除传入参数
    /// </summary>
    public class DeleteInput : OperatorInput
    {
        /// <summary>
        /// id
        /// </summary>
        [Required(ErrorMessage = "id 不能为空")]
        public string Id { get; set; }
    }
}