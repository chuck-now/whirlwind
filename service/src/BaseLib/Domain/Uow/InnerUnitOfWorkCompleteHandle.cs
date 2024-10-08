using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BaseLib.Domain.Uow
{
    internal class InnerUnitOfWorkCompleteHandle : IUnitOfWorkCompleteHandle, IDisposable
    {
        public const string DidNotCallCompleteMethodExceptionMessage = "未调用完整方法的工作单元";

        private volatile bool _isCompleteCalled;

        private volatile bool _isDisposed;

        public void Complete()
        {
            _isCompleteCalled = true;
        }

        public Task CompleteAsync()
        {
            _isCompleteCalled = true;
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                if (!_isCompleteCalled && !HasException())
                {
                    throw new BaseLibException("Did not call Complete method of a unit of work.");
                }
            }
        }

        private static bool HasException()
        {
            try
            {
                return Marshal.GetExceptionCode() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}