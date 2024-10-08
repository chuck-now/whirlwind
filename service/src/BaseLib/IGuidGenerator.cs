using System;

namespace BaseLib
{
    /// <summary>
    /// 生成GUID接口
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// 创建GUID
        /// </summary>
        Guid Create();
    }
}