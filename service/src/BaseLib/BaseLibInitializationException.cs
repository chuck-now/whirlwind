using System;
using System.Runtime.Serialization;

namespace BaseLib
{
    /// <summary>
    /// 如果初始化过程中出现问题,将引发此异常
    /// </summary>
    [Serializable]
    public class BaseLibInitializationException : BaseLibException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseLibInitializationException()
        {

        }

        /// <summary>
        /// 构造函数用于序列化
        /// </summary>
        public BaseLibInitializationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public BaseLibInitializationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">内部异常</param>
        public BaseLibInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}