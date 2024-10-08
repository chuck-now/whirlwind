using BaseLib.Dependency;
using BaseLib.Services.Dto;

namespace BaseLib.Services
{
    public interface ICrudAppService<TEntityDto, TPrimaryKey, in TCreateInput, in TUpdateInput, in TDeleteInput> : IApplicationService, ITransientDependency where TEntityDto : IEntityDto<TPrimaryKey> where TUpdateInput : IEntityDto<TPrimaryKey> where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        TEntityDto Create(TCreateInput input);

        TEntityDto Update(TUpdateInput input);

        void Delete(TDeleteInput input);
    }
}