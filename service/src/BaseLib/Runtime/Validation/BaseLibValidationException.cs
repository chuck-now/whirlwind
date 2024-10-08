using BaseLib.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseLib.Runtime.Validation
{
    /// <summary>
    /// BaseLibValidationException
    /// </summary>
    [Serializable]
    public class BaseLibValidationException : BaseLibException, IHasLogSeverity
    {
        public IList<ValidationResult> ValidationErrors { get; set; }

        public LogSeverity Severity { get; set; }

        public BaseLibValidationException()
        {
            ValidationErrors = new List<ValidationResult>();
            Severity = LogSeverity.Warn;
        }

        public BaseLibValidationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            ValidationErrors = new List<ValidationResult>();
            Severity = LogSeverity.Warn;
        }

        public BaseLibValidationException(string message)
            : base(message)
        {
            ValidationErrors = new List<ValidationResult>();
            Severity = LogSeverity.Warn;
        }

        public BaseLibValidationException(string message, IList<ValidationResult> validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
            Severity = LogSeverity.Warn;
        }

        public BaseLibValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationErrors = new List<ValidationResult>();
            Severity = LogSeverity.Warn;
        }
    }
}