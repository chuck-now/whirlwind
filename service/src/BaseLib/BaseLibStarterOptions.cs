using BaseLib.Dependency;

namespace BaseLib
{
    /// <summary>
    /// BaseLibStarterOptions
    /// </summary>
    public class BaseLibStarterOptions
    {
        public IIocManager IocManager { get; set; }

        public BaseLibStarterOptions()
        {
            IocManager = Dependency.IocManager.Instance;
        }
    }
}