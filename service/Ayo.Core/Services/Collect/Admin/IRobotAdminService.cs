using Ayo.Core.Dto.Collect;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ayo.Core.Services.Collect.Admin
{
    /// <summary>
    /// 机器人管理服务
    /// </summary>
    public interface IRobotAdminService
    {
        /// <summary>
        /// 获取所有机器人
        /// </summary>
        /// <returns></returns>
        Task<List<RobotDto>> GetAll();
    }
}