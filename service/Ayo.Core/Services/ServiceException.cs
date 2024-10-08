using BaseLib;

namespace Ayo.Core.Services
{
    public class ServiceException : BaseLibException
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}