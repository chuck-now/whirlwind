using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto
{
    /// <summary>
    /// 批量删除传入参数
    /// </summary>
    public class BatchDeleteInput
    {
        /// <summary>
        /// id列表
        /// </summary>
        [Required(ErrorMessage = "id列表 不能为空")]
        public IList<string> Ids { get; set; }
    }
}