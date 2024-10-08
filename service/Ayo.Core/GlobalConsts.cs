namespace Ayo.Core
{
    /// <summary>
    /// 全局的常量
    /// </summary>
    public static class GlobalConsts
    {
        /// <summary>
        /// 任务状态
        /// </summary>
        public static class JobType
        {
            /// <summary>
            /// 未运行
            /// </summary>
            public const int UnRuning = 0;

            /// <summary>
            /// 等待中
            /// </summary>
            public const int Waiting = 50000;

            /// <summary>
            /// 运行中
            /// </summary>
            public const int Runing = 10000;

            /// <summary>
            /// 已停止
            /// </summary>
            public const int Stopped = 10000;

            /// <summary>
            /// 已完成
            /// </summary>
            public const int Completed = 10000;
        }
    }
}