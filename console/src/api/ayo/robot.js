import request from '@/utils/request'

/**
 * 获取机器人详情
 */
export function getRobot(data) {
    return request({
        url: `/ayo.admin.collect.robot.get?id=` + data,
        method: 'post'
    })
}

/**
 * 查询全部机器人
 */
export function getAllRobot(data) {
    return request({
        url: `/ayo.admin.collect.robot.getall`,
        method: 'post',
        data
    })
}
/**
 * 创建机器人
 * @param {*} data
 */
export function createRobot(data) {
    return request({
        url: `/ayo.admin.collect.robot.create`,
        method: 'post',
        data
    })
}

/**
 * 编辑机器人
 * @param {*} data
 */
export function updateRobot(data) {
    return request({
        url: `/ayo.admin.collect.robot.update`,
        method: 'post',
        data
    })
}

/**
* 修改机器人是否启用
* @param {*} data
*/
export function updateRobotIsEnable(data) {
    return request({
        url: `/ayo.admin.collect.robot.isenable.update`,
        method: 'post',
        data
    })
}

/**
 * 删除机器人
 * @param {*} data
 */
export function deleteRobot(data) {
    return request({
        url: `/ayo.admin.collect.robot.delete`,
        method: 'post',
        data
    })
}
