using System.Reflection;

namespace BaseLib.Dependency
{
    /// <summary>
    /// IRegistrationContext
    /// </summary>
    public interface IRegistrationContext
    {
        Assembly Assembly { get; }

        IIocManager IocManager { get; }
    }
}