using BaseLib.Collections;
using BaseLib.Runtime.Validation.Interception;
using System;
using System.Collections.Generic;

namespace BaseLib.Configuration.Startup
{
    /// <summary>
    /// ValidationConfiguration
    /// </summary>
    public class ValidationConfiguration : IValidationConfiguration
    {
        public List<Type> IgnoredTypes { get; }

        public ITypeList<IMethodParameterValidator> Validators { get; }

        public ValidationConfiguration()
        {
            IgnoredTypes = new List<Type>();
            Validators = new TypeList<IMethodParameterValidator>();
        }
    }
}