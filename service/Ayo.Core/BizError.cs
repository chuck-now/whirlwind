namespace Ayo.Core
{
    /// <summary>
    /// 定义业务的全局错误返回
    /// </summary>
    public class BizError
    {
        public static BizError UNKNOWN_ERROR = new BizError(-1, "未知错误");
        public static BizError NO_HANDLER_FOUND = new BizError(10001, "未找到指定的资源");
        public static BizError BIND_EXCEPTION_ERROR = new BizError(10002, "请求参数错误");
        public static BizError PARAMTER_VALIDATION_ERROR = new BizError(10003, "请求参数校验失败");
        public static BizError ELASTICSEARCH_ERROR = new BizError(10004, "elasticsearch出错了");
        public static BizError OBJECT_CONVERT_ERROR = new BizError(10005, "对象类型转换失败");
        public static BizError SIGN_VERIFY_ERROR = new BizError(10006, "签名失败");
        public static BizError OBJECTID_ERROR = new BizError(10007, "ObjectId错误");
        public static BizError STATUS_ERROR = new BizError(10007, "数据状态异常");
        public static BizError EXPIRED_ERROR = new BizError(10007, "数据已到过期时间");
        public static BizError EXIST_LIST = new BizError(10008, "数据已存在");
        public static BizError MONGODB_CRUD_ERROR = new BizError(10009, "mongdb执行异常");
        public static BizError TOKEN_ERROR = new BizError(10010, "token 异常");
        public static BizError TOKEN_EXPIRED = new BizError(10011, "token 过期");

        // 业务错误从20000开始

        public BizError(int errCode, string errMessage)
        {
            ErrCode = errCode;
            ErrMessage = errMessage;
        }

        public BizError(BizError err)
        {
            this.ErrCode = err.ErrCode;
            this.ErrMessage = err.ErrMessage;
        }

        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; private set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMessage { get; private set; }
    }
}