using BaseLib.Collections;
using BaseLib.Runtime.Validation.Interception;
using System;
using System.Collections.Generic;

namespace BaseLib.Configuration.Startup
{
    /// <summary>
    /// IValidationConfiguration
    /// </summary>
    public interface IValidationConfiguration
    {
        List<Type> IgnoredTypes { get; }

        /// <summary>
        /// 方法参数验证器的列表
        /// </summary>
        ITypeList<IMethodParameterValidator> Validators { get; }
    }
}