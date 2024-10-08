using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto.Collect.Admin
{
    public class UpdateRobotInput : OperatorInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public string Id { get; set; }

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

        /// <summary>
        /// 头像
        /// </summary>
        [Required]
        public string Avatar { get; set; }
    }
}