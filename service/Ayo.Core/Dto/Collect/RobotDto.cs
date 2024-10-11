using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Dto.Collect
{
    public class RobotDto
    {
        /// <summary>
        /// 机器人Id
        /// </summary>
        public string Id { get; set; }

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
        /// 是否启用【Y | N】
        /// <see cref="KnowSwitch"/>
        /// </summary>
        public string IsEnable { get; set; }

        /// <summary>
        /// 任务数量
        /// </summary>
        public int TaskCount { get; set; }

        /// <summary>
        /// 操作类型【create | update | delete】
        /// <see cref="KnowOperatorType"/>
        /// </summary>
        public string OperatorType { get; set; }

        /// <summary>
        /// 操作人标识
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperatorAt { get; set; }
    }
}