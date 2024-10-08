using BaseLib.CodeAnnotations;

namespace Ayo.Core
{
    /// <summary>
    /// 性别枚举【-1=未知 || 0=男 || 1=女 】
    /// </summary>
    public enum SexEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        [EnumAlias("男")]
        Man = 0,

        /// <summary>
        /// 女
        /// </summary>
        [EnumAlias("女")]
        Woman = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 会员等级 【-1=未知 || 0=普通会员 || 1=黄金会员 || 2=白金会员 || 3=钻石会员 】
    /// </summary>
    public enum MemberLevelEnum
    {
        /// <summary>
        /// 普通会员
        /// </summary>
        [EnumAlias("普通会员")]
        Common = 0,

        /// <summary>
        /// 黄金会员
        /// </summary>
        [EnumAlias("黄金会员")]
        Gold = 1,

        /// <summary>
        /// 白金会员
        /// </summary>
        [EnumAlias("白金会员")]
        Platinum = 2,

        /// <summary>
        /// 钻石会员
        /// </summary>
        [EnumAlias("钻石会员")]
        Diamond = 3,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 支付方式【-1=未知 || 0=购买 || 1=充值 】
    /// </summary>
    public enum PayTypeEnum
    {
        /// <summary>
        /// 购买
        /// </summary>
        [EnumAlias("购买")]
        Buy = 0,

        /// <summary>
        /// 充值
        /// </summary>
        [EnumAlias("充值")]
        Recharge = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 充值方式【-1=未知 || 0=支付宝 || 1=微信 】
    /// </summary>
    public enum RechargeTypeEnum
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [EnumAlias("支付宝")]
        Alipay = 0,

        /// <summary>
        /// 微信
        /// </summary>
        [EnumAlias("微信")]
        WeChat = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 订单类型【-1=未知 || 0=普通订单 || 1=限时抢购 || 2=商品预售 || 3= 积分换购】
    /// </summary>
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 普通订单
        /// </summary>
        [EnumAlias("普通订单")]
        PTDD = 0,

        /// <summary>
        /// 限时抢购
        /// </summary>
        [EnumAlias("限时抢购")]
        XSQG = 1,

        /// <summary>
        /// 商品预售
        /// </summary>
        [EnumAlias("商品预售")]
        SPYS = 2,

        /// <summary>
        /// 积分换购
        /// </summary>
        [EnumAlias("积分换购")]
        JFHG = 3,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 订单状态【-1=未知 || 0=等待付款 || 1=等待发货 || 2=等待收货 || 3= 签收完成 || 4=交易完成 || 5=订单取消】
    /// </summary>
    public enum OrderStateEnum
    {
        /// <summary>
        /// 等待付款
        /// </summary>
        [EnumAlias("等待付款")]
        DDFK = 0,

        /// <summary>
        /// 等待发货
        /// </summary>
        [EnumAlias("等待发货")]
        DDFH = 1,

        /// <summary>
        /// 等待收货
        /// </summary>
        [EnumAlias("等待收货")]
        DDSH = 2,

        /// <summary>
        /// 签收完成
        /// </summary>
        [EnumAlias("签收完成")]
        QSWC = 3,

        /// <summary>
        /// 交易完成
        /// </summary>
        [EnumAlias("交易完成")]
        JYWC = 4,

        /// <summary>
        /// 订单取消
        /// </summary>
        [EnumAlias("订单取消")]
        DDQX = 5,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 订单支付类型【-1=未知 || 0=支付宝 || 1=微信 || 2=余额支付 】
    /// </summary>
    public enum OrderPayTypeEnum
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [EnumAlias("支付宝")]
        Alipay = 0,

        /// <summary>
        /// 微信
        /// </summary>
        [EnumAlias("微信")]
        WeChat = 1,

        /// <summary>
        /// 余额支付
        /// </summary>
        [EnumAlias("余额支付")]
        YEZF = 2,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }

    /// <summary>
    /// 订单支付状态【-1=未知 || 0=未付款 || 1=已付款 】
    /// </summary>
    public enum OrderPayStateEnum
    {
        /// <summary>
        /// 未付款
        /// </summary>
        [EnumAlias("未付款")]
        WFK = 0,

        /// <summary>
        /// 已付款
        /// </summary>
        [EnumAlias("已付款")]
        YFK = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumAlias("未知")]
        Unknow = -1
    }
}