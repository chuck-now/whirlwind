using System;

namespace BaseLib.Event.Bus.Entities
{
    [Serializable]
    public class EntityDeletingEventData<TEntity> : EntityChangingEventData<TEntity>
    {
        public EntityDeletingEventData(TEntity entity)
            : base(entity)
        {
        }
    }
}