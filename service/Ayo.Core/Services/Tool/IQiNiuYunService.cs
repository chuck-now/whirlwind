using Ayo.Core.Dto.Tool.Params;

namespace Ayo.Core.Services.Tool
{
    public partial interface IQiNiuYunService
    {
        /// <summary>
        /// 获取七牛云上传相关信息
        /// </summary>
        /// <returns></returns>
        GetQiniuyunUploadInfoOutput GetQiniuyunUploadInfo();
    }
}