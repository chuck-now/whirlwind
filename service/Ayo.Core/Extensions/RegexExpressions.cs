namespace Ayo.Core.Extensions
{
    /// <summary>
    /// </summary>
    public class RegexExpressions
    {
        /// <summary>
        /// Url地址 TODO 此正则需调整
        /// </summary>
        public const string URL = @"^[a-zA-Z0-9\u4e00-\u9fa5]+$";

        /// <summary>
        /// 非特殊字符
        /// </summary>
        public const string NON_SPECIALCHAR = @"^[a-zA-Z0-9\u4e00-\u9fa5]+$";

        /// <summary>
        /// 电话
        /// </summary>
        public const string PHONE = @"^\d{3}-\d{8}|\d{4}-\d{7}$";

        /// <summary>
        /// 机构版本
        /// </summary>
        public const string VERSIONTYPE = @"^[1-4]{1}$";

        /// <summary>
        /// 时间
        /// </summary>
        public const string DATETIME = @"^((((1[6-9]|[2-9]\d)\d{2})-(0[13578]|1[02])-(0[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0[13456789]|1[012])-(0[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-02-(0[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-02-29-))\s{1}(([0-1][0-9])|(2[0-3])):([0-5][0-9]):([0-5][0-9])$";

        /// <summary>
        /// 邮箱
        /// </summary>
        public const string EMAIL = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        /// <summary>
        /// 手机号
        /// </summary>
        public const string MOBILE = @"^1[1-9]\d{9}$";

        /// <summary>
        /// 1 or 2
        /// </summary>
        public const string ONE_OR_TWO = @"^[1,2]$";

        /// <summary>
        /// 0 or 1
        /// </summary>
        public const string ZERO_OR_ONE = @"^[0,1]$";

        /// <summary>
        /// ObjectId
        /// </summary>
        public const string OBJECT_ID = @"^[0-9a-z]{24}$";

        /// <summary>
        /// 身份证
        /// </summary>
        public const string CERTIFICATENO = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";

        /// <summary>
        /// 1-3
        /// </summary>
        public const string NUMBE_RANGE_ONE_THREE = @"^[1,2,3]$";

        /// <summary>
        /// 3 or 4
        /// </summary>
        public const string NUMBE_RANGE_THREE_FOUR = @"^[3,4]$";

        /// <summary>
        /// true or false
        /// </summary>
        public const string BOOL_TRUE_FALSE = @"\b(true|false|True|False|TRUE|FALSE)\b";
    }
}