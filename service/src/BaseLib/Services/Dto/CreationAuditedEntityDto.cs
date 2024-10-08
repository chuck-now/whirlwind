﻿using BaseLib.Domain.Entities.Auditing;
using System;

namespace BaseLib.Services.Dto
{
    [Serializable]
    public abstract class CreationAuditedEntityDto : CreationAuditedEntityDto<int>
    {
    }

    [Serializable]
    public abstract class CreationAuditedEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>, ICreationAudited, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        protected CreationAuditedEntityDto()
        {
            CreationTime = DateTime.Now;
        }
    }
}