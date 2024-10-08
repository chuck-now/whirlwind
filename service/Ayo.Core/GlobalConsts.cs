namespace Ayo.Core
{
    /// <summary>
    /// 全局的常量
    /// </summary>
    public static class GlobalConsts
    {
        /// <summary>
        /// 表示 开/关 或 是/否
        /// </summary>
        public static class KnowSwitch
        {
            /// <summary>
            /// 开启
            /// </summary>
            public const string Y = "Y";

            /// <summary>
            /// 关闭
            /// </summary>
            public const string N = "N";
        }

        /// <summary>
        /// 操作人类型
        /// </summary>
        public static class KnowOperatorType
        {
            /// <summary>
            ///  创建
            /// </summary>
            public const string CREATE = "create";

            /// <summary>
            /// 修改
            /// </summary>
            public const string UPDATE = "update";

            /// <summary>
            /// 删除
            /// </summary>
            public const string DELETE = "delete";
        }
    }
}