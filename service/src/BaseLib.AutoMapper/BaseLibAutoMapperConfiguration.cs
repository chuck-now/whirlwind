using AutoMapper;
using System;
using System.Collections.Generic;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// BaseLibAutoMapperConfiguration
    /// </summary>
    public class BaseLibAutoMapperConfiguration : IBaseLibAutoMapperConfiguration
    {
        public List<Action<IMapperConfigurationExpression>> Configurators { get; }

        public bool UseStaticMapper { get; set; }

        public BaseLibAutoMapperConfiguration()
        {
            UseStaticMapper = true;
            Configurators = new List<Action<IMapperConfigurationExpression>>();
        }
    }
}