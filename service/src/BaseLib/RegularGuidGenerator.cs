using BaseLib.Dependency;
using System;

namespace BaseLib
{
    /// <summary>
    /// RegularGuidGenerator
    /// </summary>
    public class RegularGuidGenerator : IGuidGenerator, ITransientDependency
    {
        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}