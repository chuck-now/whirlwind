using System.Collections.Generic;
using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Domain.Manager
{
    /// <summary>
    /// 后台账号
    /// </summary>
    public class Account : BaseEntity
    {
        public Account()
        {
            Name = "";
            Roles = new List<string>().ToArray();
            Email = "";
            MobilePhone = "";
            Password = "";
        }

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
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 角色
        /// <see cref="AccountRole"/>
        /// </summary>
        public string[] Roles { get; set; }
    }
}