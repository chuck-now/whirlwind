namespace Ayo.Core.Dto.Manager.Admin.Params
{
    /// <summary>
    /// 查询账户传入参数
    /// </summary>
    public class QueryAccountInput : PageInput
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
    }
}