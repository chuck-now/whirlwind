using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Collect.Admin
{
    public class UpdateRobotIsEnableInput : OperatorInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 是否启用 【 Y | N 】
        /// </summary>
        [Required]
        public string IsEnable { get; set; }
    }
}