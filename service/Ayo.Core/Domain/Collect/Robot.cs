using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Domain.Collect
{
    /// <summary>
    /// 代表一个机器人
    /// </summary>
    public class Robot : BaseEntity
    {
        public Robot()
        {
            Code = "";
            Name = "";
            Description = "";
            Avatar = "";
            IsEnable = KnowSwitch.N;
            TaskCount = 0;
        }

        /// <summary>
        /// 机器人代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 机器人描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 是否启用【Y | N】
        /// <see cref="KnowSwitch"/>
        /// </summary>
        public string IsEnable { get; set; }

        /// <summary>
        /// 任务数量
        /// </summary>
        public int TaskCount { get; set; }
    }
}