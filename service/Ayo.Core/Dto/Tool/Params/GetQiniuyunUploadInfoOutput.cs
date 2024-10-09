namespace Ayo.Core.Dto.Tool.Params
{
    /// <summary>
    /// 获取七牛云上传相关信息 返回信息
    /// </summary>
    public class GetQiniuyunUploadInfoOutput
    {
        /// <summary>
        /// 上传令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string Url { get; set; }
    }
}