using System;
using System.Runtime.Serialization;

namespace BaseLib
{
    /// <summary>
    /// 所有异常应继承此异常基类
    /// </summary>
    [Serializable]
    public class BaseLibException : Exception
    {
        /// <summary>
        /// 创建一个新的 <see cref="BaseLibException"/> 对象
        /// </summary>
        public BaseLibException()
        {

        }

        /// <summary>
        /// 创建一个新的 <see cref="BaseLibException"/> 对象
        /// </summary>
        public BaseLibException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// 创建一个新的 <see cref="BaseLibException"/> 对象
        /// </summary>
        /// <param name="message">异常消息</param>
        public BaseLibException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 创建一个新的 <see cref="BaseLibException"/> 对象
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">内部异常</param>
        public BaseLibException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}