using System;

namespace BaseLib.Event.Bus.Exceptions
{
    public class BaseLibHandledExceptionData : ExceptionData
    {
        public BaseLibHandledExceptionData(Exception exception) : base(exception)
        {
        }
    }
}