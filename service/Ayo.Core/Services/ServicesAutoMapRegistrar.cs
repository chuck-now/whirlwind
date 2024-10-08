using AutoMapper;
using BaseLib.AutoMapper;

namespace Ayo.Core.Services
{
    public class ServicesAutoMapRegistrar : IAutoMapRegistrar
    {
        public void RegisterMaps(IMapperConfigurationExpression config)
        {
            //config.CreateMap<Category, CategoryDto>()
            //       .ForMember(dto => dto.ParentName, opt => opt.Ignore());

            //config.CreateMap<User, UserDto>()
            //       .ForMember(dto => dto.Birthday, opt => opt.MapFrom(x => x.Birthday == new DateTime() ? "-" : x.Birthday.ToString("yyyy-MM-dd")));
        }
    }
}