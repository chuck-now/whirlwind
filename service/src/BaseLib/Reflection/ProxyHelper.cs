using Castle.DynamicProxy;

namespace BaseLib.Reflection
{
    /// <summary>
    /// ProxyHelper
    /// </summary>
    public class ProxyHelper
    {
        public static object UnProxy(object obj)
        {
            return ProxyUtil.GetUnproxiedInstance(obj);
        }
    }
}