using AutoMapper;
using System;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// AutoMapAttributeBase
    /// </summary>
    public abstract class AutoMapAttributeBase : Attribute
    {
        public Type[] TargetTypes { get; private set; }

        protected AutoMapAttributeBase(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public abstract void CreateMap(IMapperConfigurationExpression configuration, Type type);
    }
}