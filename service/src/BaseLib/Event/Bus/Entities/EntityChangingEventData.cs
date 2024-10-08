﻿using System;

namespace BaseLib.Event.Bus.Entities
{
    [Serializable]
    public class EntityChangingEventData<TEntity> : EntityEventData<TEntity>
    {
        public EntityChangingEventData(TEntity entity)
            : base(entity)
        {
        }
    }
}