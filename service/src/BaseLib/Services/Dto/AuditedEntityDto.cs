using BaseLib.Domain.Entities.Auditing;
using System;

namespace BaseLib.Services.Dto
{
    [Serializable]
    public abstract class AuditedEntityDto : AuditedEntityDto<int>
    {
    }

    [Serializable]
    public abstract class AuditedEntityDto<TPrimaryKey> : CreationAuditedEntityDto<TPrimaryKey>, IAudited, ICreationAudited, IHasCreationTime, IModificationAudited, IHasModificationTime
    {
        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }
    }
}