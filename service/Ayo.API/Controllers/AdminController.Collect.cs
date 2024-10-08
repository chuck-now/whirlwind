using Ayo.Core.Dto.Collect;
using BaseLib.Services.Dto;
using BaseLib.WebApi;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Ayo.API.Controllers
{
    /// <summary>
    /// 采集管理
    /// </summary>
    public partial class AdminController : ApiControllerBase
    {
        #region robot

        /// <summary>
        /// 获取所有机器人
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/ayo.admin.collect.robot.getall")]
        public async Task<BaseLibResponse<List<RobotDto>>> GetAllRobot()
        {
            var response = new BaseLibResponse<List<RobotDto>>
            {
                Result = await _robotAdminService.GetAll()
            };
            return response;
        }

        #endregion robot
    }
}