using AutoMapper;
using System;
using System.Collections.Generic;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// IBaseLibAutoMapperConfiguration
    /// </summary>
    public interface IBaseLibAutoMapperConfiguration
    {
        List<Action<IMapperConfigurationExpression>> Configurators { get; }

        /// <summary>
        /// Use static <see cref="Mapper.Instance"/>.
        /// Default: true.
        /// </summary>
        bool UseStaticMapper { get; set; }
    }
}