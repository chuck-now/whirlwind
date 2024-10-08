using BaseLib.Dependency;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseLib.Runtime.Validation.Interception
{
    /// <summary>
    /// IMethodParameterValidator
    /// </summary>
    public interface IMethodParameterValidator : ITransientDependency
    {
        IReadOnlyList<ValidationResult> Validate(object validatingObject);
    }
}