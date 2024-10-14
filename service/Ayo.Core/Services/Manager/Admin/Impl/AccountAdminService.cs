using BaseLib.Services.Dto;
using Ayo.Core.Domain.Repositories.Manager;
using Ayo.Core.Dto;
using Ayo.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ayo.Core.Dto.Manager;
using BaseLib.AutoMapper;
using Ayo.Core.Dto.Manager.Admin.Params;
using Ayo.Core.Domain.Manager;
using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Services.Manager.Admin.Impl
{
    public class AccountAdminService : ServiceBase, IAccountAdminService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountAdminService(
          IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<AccountDto> GetAccount(string id)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(id.ToObjectId());
            return account.MapTo<AccountDto>();
        }

        public async Task<PagedResultDto<AccountDto>> QueryAccount(QueryAccountInput input)
        {
            var result = await _accountRepository.Query(input.Keyword, input.PageIndex, input.PageSize);
            return new PagedResultDto<AccountDto>(result.Item1, result.Item2.MapTo<List<AccountDto>>());
        }

        public async Task<string> AccountLogin(AccountLoginInput input)
        {
            var output = string.Empty;

            var account = await _accountRepository.FirstOrDefaultAsync(x => x.Name == input.UserName && x.Password == input.Password.Md5());
            if (account != null)
            {
                output = account.Id.ToString();
                return output;
            }

            account = await _accountRepository.FirstOrDefaultAsync(x => x.Email == input.UserName && x.Password == input.Password.Md5());
            if (account != null)
            {
                output = account.Id.ToString();
                return output;
            }

            account = await _accountRepository.FirstOrDefaultAsync(x => x.MobilePhone == input.UserName && x.Password == input.Password.Md5());
            if (account != null)
            {
                output = account.Id.ToString();
                return output;
            }

            return output;
        }

        public async Task InsertAccount(InsertAccountInput input)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(x => x.Name == input.Name && x.OperatorType == KnowOperatorType.DELETE);
            if (account.IsNotNull())
            {
                throw new BizException(BizError.MANAGER_ACCOUNT_NAME_EXIST);
            }
            var roles = new List<string>() { KnowAccountRole.General };

            await _accountRepository.InsertAsync(new Account()
            {
                Name = input.Name,
                Email = input.Email,
                MobilePhone = input.MobilePhone,
                Password = input.Password,
                Roles = roles.ToArray(),
                OperatorId = input.OperatorId,
                OperatorName = input.OperatorName,
                OperatorType = KnowOperatorType.CREATE
            });
        }

        public async Task UpdateAccount(UpdateAccountInput input)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (account.IsNull())
            {
                throw new BizException(BizError.PARAMTER_VALIDATION_ERROR);
            }

            account.Name = input.Name;
            account.Email = input.Email;
            account.MobilePhone = input.MobilePhone;
            account.OperatorId = input.OperatorId;
            account.OperatorName = input.OperatorName;
            account.OperatorType = KnowOperatorType.UPDATE;
            await _accountRepository.Update(account);
        }

        public async Task UpdateAccountPassword(UpdateAccountPasswordInput input)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (account.IsNull())
            {
                throw new BizException(BizError.PARAMTER_VALIDATION_ERROR);
            }

            account.Password = input.Password;
            account.OperatorId = input.OperatorId;
            account.OperatorName = input.OperatorName;
            account.OperatorType = KnowOperatorType.UPDATE;
            await _accountRepository.Update(account);
        }

        public async Task DeleteAccount(DeleteInput input)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(input.Id.ToObjectId());
            if (account.IsNull())
            {
                throw new BizException(BizError.PARAMTER_VALIDATION_ERROR);
            }

            account.OperatorId = input.OperatorId;
            account.OperatorName = input.OperatorName;
            account.OperatorType = KnowOperatorType.DELETE;
            await _accountRepository.DeleteById(account);
        }
    }
}