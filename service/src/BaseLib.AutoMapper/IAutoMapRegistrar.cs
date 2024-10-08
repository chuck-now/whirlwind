using AutoMapper;

namespace BaseLib.AutoMapper
{
    /// <summary>
    /// IAutoMapRegistrar
    /// </summary>
    public interface IAutoMapRegistrar
    {
        void RegisterMaps(IMapperConfigurationExpression config);
    }
}