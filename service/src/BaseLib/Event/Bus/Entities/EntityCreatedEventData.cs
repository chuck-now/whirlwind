using System;

namespace BaseLib.Event.Bus.Entities
{
    [Serializable]
    public class EntityCreatedEventData<TEntity> : EntityChangedEventData<TEntity>
    {
        public EntityCreatedEventData(TEntity entity)
            : base(entity)
        {
        }
    }
}