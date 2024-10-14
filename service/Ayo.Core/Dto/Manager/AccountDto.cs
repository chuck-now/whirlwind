using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Dto.Manager
{
    /// <summary>
    /// 后台账户数据传输模型
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// 账户Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 角色
        /// <see cref="KnowAccountRole"/>
        /// </summary>
        public string[] Roles { get; set; }

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