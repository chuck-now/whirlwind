using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Collect.Admin
{
    public class CreateRobotInput : OperatorInput
    {
        /// <summary>
        /// 机器人名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 机器人描述
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}