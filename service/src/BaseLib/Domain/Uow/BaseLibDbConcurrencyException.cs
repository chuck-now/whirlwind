using System;
using System.Runtime.Serialization;

namespace BaseLib.Domain.Uow
{
    /// <summary>
    /// BaseLibDbConcurrencyException
    /// </summary>
    [Serializable]
    public class BaseLibDbConcurrencyException : BaseLibException
    {
        public BaseLibDbConcurrencyException()
        {
        }

        public BaseLibDbConcurrencyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        }

        public BaseLibDbConcurrencyException(string message)
            : base(message)
        {
        }

        public BaseLibDbConcurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}