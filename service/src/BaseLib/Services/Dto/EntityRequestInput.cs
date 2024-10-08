﻿using System;

namespace BaseLib.Services.Dto
{
    [Serializable]
    public class EntityRequestInput<TPrimaryKey> : EntityDto<TPrimaryKey>, IInputDto, IDto
    {
        public EntityRequestInput()
        {
        }

        public EntityRequestInput(TPrimaryKey id)
            : base(id)
        {
        }
    }
}