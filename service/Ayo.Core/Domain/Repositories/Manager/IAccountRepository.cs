using Ayo.Core.Domain.Manager;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ayo.Core.Domain.Repositories.Manager
{
    public interface IAccountRepository : IAyoRepository<Account, ObjectId>
    {
        /// <summary>
        /// 分页查询账户
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(int, IList<Account>)> Query(string keyword, int pageIndex, int pageSize);

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        new Task Update(Account account);

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task DeleteById(Account account);
    }
}