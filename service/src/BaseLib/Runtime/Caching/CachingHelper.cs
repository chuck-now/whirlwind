using System.Reflection;

namespace BaseLib.Runtime.Caching
{
    public class CachingHelper
    {
        public static bool HasCachingAttribute(MemberInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(CachingAttribute), inherit: true);
        }
    }
}