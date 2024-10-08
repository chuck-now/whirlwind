using BaseLib.Reflection;
using System;

namespace BaseLib.Domain.Entities
{
    /// <summary>
    /// EntityHelper
    /// </summary>
    public static class EntityHelper
    {
        public static bool IsEntity(Type type)
        {
            return ReflectionHelper.IsAssignableToGenericType(type, typeof(IEntity<>));
        }

        public static Type GetPrimaryKeyType<TEntity>()
        {
            return GetPrimaryKeyType(typeof(TEntity));
        }

        public static Type GetPrimaryKeyType(Type entityType)
        {
            Type[] interfaces = entityType.GetInterfaces();
            foreach (Type type in interfaces)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    return type.GenericTypeArguments[0];
                }
            }
            throw new BaseLibException("Can not find primary key type of given entity type: " + entityType + ". Be sure that this entity type implements IEntity<TPrimaryKey> interface");
        }

        public static object GetEntityId(object entity)
        {
            if (!ReflectionHelper.IsAssignableToGenericType(entity.GetType(), typeof(IEntity<>)))
            {
                throw new BaseLibException(entity.GetType() + " is not an Entity !");
            }
            return ReflectionHelper.GetValueByPath(entity, entity.GetType(), "Id");
        }

        public static string GetHardDeleteKey(object entity)
        {
            return entity.GetType().FullName + ";Id=" + GetEntityId(entity);
        }
    }
}