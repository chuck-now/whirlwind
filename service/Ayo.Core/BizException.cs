using System;
using BaseLib.WebApi;

namespace Ayo.Core
{
    /// <summary>
    /// 通用的业务错误异常包装
    /// </summary>
    public class BizException : Exception
    {
        public BaseLibResponse CommonError { get; private set; }

        public BizException(BizError bizError)
        {
            CommonError = new BaseLibResponse();
            CommonError.SetMessage(bizError.ErrCode.ToString(), bizError.ErrMessage);
        }

        public BizException(BizError bizError, string errMsg)
        {
            CommonError = new BaseLibResponse();
            CommonError.SetMessage(bizError.ErrCode.ToString(), errMsg);
        }
    }
}