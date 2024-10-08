using Ayo.Core.Dto;
using Ayo.Core.Dto.Collect;
using Ayo.Core.Dto.Collect.Admin;
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
        /// 获取单个机器人详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.get")]
        public async Task<BaseLibResponse<RobotDto>> GetRobot([Required(ErrorMessage = "id 不能为空")] string id)
        {
            var response = new BaseLibResponse<RobotDto>
            {
                Result = await _robotAdminService.Get(id)
            };
            return response;
        }

        /// <summary>
        /// 获取所有机器人
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.getall")]
        public async Task<BaseLibResponse<List<RobotDto>>> GetAllRobot()
        {
            var response = new BaseLibResponse<List<RobotDto>>
            {
                Result = await _robotAdminService.GetAll()
            };
            return response;
        }

        /// <summary>
        /// 新增机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.create")]
        public async Task<BaseLibResponse<string>> CreateRobot([FromBody] CreateRobotInput input)
        {
            var res = new BaseLibResponse<string>();
            var result = await _robotAdminService.Create(input);
            if (!result.Success)
            {
                res.SetMessage(ResponseStatusCode.InternalServerError, result.GetErrorMessage());
            }
            else
            {
                res.Result = result.Result;
            }
            return res;
        }

        /// <summary>
        /// 修改机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.update")]
        public async Task<BaseLibResponse> UpdateRobot([FromBody] UpdateRobotInput input)
        {
            var res = new BaseLibResponse();
            var result = await _robotAdminService.Update(input);
            if (!result.Success)
            {
                res.SetMessage(ResponseStatusCode.InternalServerError, result.GetErrorMessage());
            }
            return res;
        }

        /// <summary>
        /// 修改机器人是否启用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.isenable.update")]
        public async Task<BaseLibResponse> UpdateRobotIsEnable([FromBody] UpdateRobotIsEnableInput input)
        {
            var res = new BaseLibResponse();
            var result = await _robotAdminService.UpdateIsEnable(input);
            if (!result.Success)
            {
                res.SetMessage(ResponseStatusCode.InternalServerError, result.GetErrorMessage());
            }
            return res;
        }

        /// <summary>
        /// 删除机器人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.admin.collect.robot.delete")]
        public async Task<BaseLibResponse> DeleteRobot([FromBody] DeleteInput input)
        {
            var res = new BaseLibResponse();
            var result = await _robotAdminService.Delete(input);
            if (!result.Success)
            {
                res.SetMessage(ResponseStatusCode.InternalServerError, result.GetErrorMessage());
            }
            return res;
        }

        #endregion robot
    }
}