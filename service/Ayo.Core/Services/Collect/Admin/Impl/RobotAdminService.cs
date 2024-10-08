using Ayo.Core.Domain.Repositories.Collect;
using Ayo.Core.Dto.Collect;
using BaseLib.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ayo.Core.Services.Collect.Admin.Impl
{
    public class RobotAdminService : ServiceBase, IRobotAdminService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotAdminService(
          IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public async Task<List<RobotDto>> GetAll()
        {
            var result = await _robotRepository.GetAll();
            return result.MapTo<List<RobotDto>>();
        }
    }
}