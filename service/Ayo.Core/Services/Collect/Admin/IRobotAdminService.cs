using Ayo.Core.Dto;
using Ayo.Core.Dto.Collect;
using Ayo.Core.Dto.Collect.Admin;
using BaseLib;
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
        /// 获取单个机器人详情
        /// </summary>
        /// <returns></returns>
        Task<RobotDto> Get(string id);

        /// <summary>
        /// 获取所有机器人
        /// </summary>
        /// <returns></returns>
        Task<List<RobotDto>> GetAll();

        /// <summary>
        /// 创建机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ActionOutput<string>> Create(CreateRobotInput input);

        /// <summary>
        /// 修改机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ActionOutput> Update(UpdateRobotInput input);

        /// <summary>
        /// 修改机器人是否启用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ActionOutput> UpdateIsEnable(UpdateRobotIsEnableInput input);

        /// <summary>
        /// 删除机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ActionOutput> Delete(DeleteInput input);
    }
}