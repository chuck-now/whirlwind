using Ayo.Core.Domain.Collect;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ayo.Core.Domain.Repositories.Collect
{
    public interface IRobotRepository : IAyoRepository<Robot, ObjectId>
    {
        /// <summary>
        /// 获取所有机器人
        /// </summary>
        /// <returns></returns>
        new Task<List<Robot>> GetAll();

        /// <summary>
        /// 修改机器人基本信息
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        Task<long> UpdateInfo(Robot robot);

        /// <summary>
        /// 修改机器人是否启用
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        Task<long> UpdateIsEnable(ObjectId Id, string isEnable);

        /// <summary>
        /// 修改机器人操作人信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="operatorId"></param>
        /// <param name="operatorName"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        Task<long> UpdateOpInfo(ObjectId Id, string operatorId, string operatorName, string operatorType);

        /// <summary>
        /// 增加/减少机器人任务数量
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<long> IncTaskCount(ObjectId Id, int count);

        /// <summary>
        /// 根据ID删除机器人
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<long> DeleteById(ObjectId Id);
    }
}