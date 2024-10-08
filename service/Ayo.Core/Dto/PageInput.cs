using System;
using System.ComponentModel.DataAnnotations;

namespace Ayo.Core.Dto
{
    /// <summary>
    /// 分页输入模型
    /// </summary>
    public class PageInput
    {
        /// <summary>
        /// 当前页
        /// </summary>
        [Range(1, 100000, ErrorMessage = "输入的起始页范围不合法")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 页大小
        /// </summary>
        [Range(1, 50)]
        public int PageSize { get; set; } = 20;
    }
}