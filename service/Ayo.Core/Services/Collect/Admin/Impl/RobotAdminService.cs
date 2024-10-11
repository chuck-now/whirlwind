using Ayo.Core.Domain.Collect;
using Ayo.Core.Domain.Repositories.Collect;
using Ayo.Core.Dto;
using Ayo.Core.Dto.Collect;
using Ayo.Core.Dto.Collect.Admin;
using Ayo.Core.Extensions;
using BaseLib;
using BaseLib.AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Ayo.Core.GlobalConsts;

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

        public async Task<RobotDto> Get(string id)
        {
            var result = await _robotRepository.FirstOrDefaultAsync(id.ToObjectId());
            return result.MapTo<RobotDto>();
        }

        public async Task<List<RobotDto>> GetAll()
        {
            var result = await _robotRepository.GetAll();
            return result.MapTo<List<RobotDto>>();
        }

        public async Task<ActionOutput<string>> Create(CreateRobotInput input)
        {
            var output = new ActionOutput<string>();

            var count = await _robotRepository.CountAsync(x => x.Name == input.Name && x.OperatorType != KnowOperatorType.DELETE);
            if (count > 0)
            {
                output.AddError("机器人名称已存在！");
                return output;
            }

            var robot = new Robot()
            {
                Code = $"ayo_{new Random().Next(1000, 9999)}",
                Name = input.Name,
                Description = input.Description,
                OperatorId = input.OperatorId,
                OperatorName = input.OperatorName,
                OperatorType = KnowOperatorType.CREATE
            };
            var id = await _robotRepository.InsertAndGetIdAsync(robot);
            if (id.IsNotNull())
            {
                output.Result = id.ToString();
            }
            return output;
        }

        public async Task<ActionOutput> Update(UpdateRobotInput input)
        {
            var output = new ActionOutput<string>();

            var robot = await _robotRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (robot.IsNull())
            {
                output.AddError("机器人不存在！");
                return output;
            }

            robot.Name = input.Name;
            robot.Description = input.Description;
            var count = await _robotRepository.UpdateInfo(robot);
            if (count > 0)
            {
                await _robotRepository.UpdateOpInfo(robot.Id, input.OperatorId, input.OperatorName, KnowOperatorType.UPDATE);
            }
            return output;
        }

        public async Task<ActionOutput> UpdateIsEnable(UpdateRobotIsEnableInput input)
        {
            var output = new ActionOutput<string>();

            var robot = await _robotRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (robot.IsNull())
            {
                output.AddError("机器人不存在！");
                return output;
            }

            var count = await _robotRepository.UpdateIsEnable(robot.Id, input.IsEnable);
            if (count > 0)
            {
                await _robotRepository.UpdateOpInfo(robot.Id, input.OperatorId, input.OperatorName, KnowOperatorType.UPDATE);
            }
            return output;
        }

        public async Task<ActionOutput> Delete(DeleteInput input)
        {
            var output = new ActionOutput<string>();

            var robot = await _robotRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (robot.IsNull())
            {
                output.AddError("机器人不存在！");
                return output;
            }

            await _robotRepository.UpdateOpInfo(robot.Id, input.OperatorId, input.OperatorName, KnowOperatorType.DELETE);

            return output;
        }
    }
}