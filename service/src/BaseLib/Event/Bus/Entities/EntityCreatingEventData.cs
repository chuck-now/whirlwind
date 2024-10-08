using System;

namespace BaseLib.Event.Bus.Entities
{
    [Serializable]
    public class EntityCreatingEventData<TEntity> : EntityChangingEventData<TEntity>
    {
        public EntityCreatingEventData(TEntity entity)
            : base(entity)
        {
        }
    }
}