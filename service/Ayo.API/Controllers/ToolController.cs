using BaseLib;
using BaseLib.WebApi;
using Ayo.Core.Dto.Tool.Params;
using Ayo.Core.Services.Tool;
using Microsoft.AspNetCore.Mvc;

namespace Ayo.API.Controllers
{
    /// <summary>
    /// 工具箱
    /// </summary>
    public class ToolController : ApiControllerBase
    {
        private readonly IQiNiuYunService _qiNiuYunService;

        /// <summary>
        /// </summary>
        public ToolController()
        {
            _qiNiuYunService = BaseLibEngine.Instance.Resolve<IQiNiuYunService>();
        }

        /// <summary>
        /// 获取七牛云上传相关信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ayo.tool.qiniuyun.upload.info.get")]
        public BaseLibResponse<GetQiniuyunUploadInfoOutput> GetQiniuyunUploadInfo()
        {
            var response = new BaseLibResponse<GetQiniuyunUploadInfoOutput>
            {
                Result = _qiNiuYunService.GetQiniuyunUploadInfo()
            };
            return response;
        }
    }
}