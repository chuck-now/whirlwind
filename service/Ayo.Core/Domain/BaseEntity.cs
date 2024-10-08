using MongoDB.Bson;
using System;
using BaseLib.Domain.Entities;
using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Domain
{
    /// <summary>
    /// 实体类父类
    /// </summary>
    public abstract class BaseEntity : IEntity<ObjectId>
    {
        public BaseEntity()
        {
            OperatorType = KnowOperatorType.CREATE;
            OperatorId = "";
            OperatorName = "";
            OperatorAt = DateTime.Now;
        }

        /// <summary>
        /// objid
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 操作类型【create | update | delete】
        /// <see cref="KnowOperatorType"/>
        /// </summary>
        public string OperatorType { get; set; }

        /// <summary>
        /// 操作人标识
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperatorAt { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id == ObjectId.Empty;
        }
    }
}