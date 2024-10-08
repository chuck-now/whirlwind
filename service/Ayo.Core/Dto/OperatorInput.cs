using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto
{
    /// <summary>
    /// 操作人信息
    /// </summary>
    public class OperatorInput
    {
        /// <summary>
        /// 操作人标识
        /// </summary>
        [Required]
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Required]
        public string OperatorName { get; set; }
    }
}