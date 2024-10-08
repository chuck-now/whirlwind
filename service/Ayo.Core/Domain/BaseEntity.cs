using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using BaseLib.Domain.Entities;
using BaseLib.Domain.Entities.Auditing;

namespace Ayo.Core.Domain
{
    /// <summary>
    /// 实体类父类
    /// </summary>
    [BsonIgnoreExtraElements]
    public abstract class BaseEntity : IEntity<ObjectId>, ISoftDelete, IHasDeletionTime
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// objid
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id == ObjectId.Empty;
        }
    }
}