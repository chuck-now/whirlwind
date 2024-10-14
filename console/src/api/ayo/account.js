import request from '@/utils/request'

/**
 * 获取账户详情
 */
export function getAccount(data) {
    return request({
        url: `/ayo.admin.manager.account.get?id=` + data,
        method: 'post'
    })
}

/**
 * 查询账户
 */
export function queryAccount(data) {
    return request({
        url: `/ayo.admin.manager.account.query`,
        method: 'post',
        data
    })
}
/**
 * 创建账户
 * @param {*} data
 */
export function insertAccount(data) {
    return request({
        url: `/ayo.admin.manager.account.insert`,
        method: 'post',
        data
    })
}

/**
 * 编辑账户
 * @param {*} data
 */
export function updateAccount(data) {
    return request({
        url: `/ayo.admin.manager.account.update`,
        method: 'post',
        data
    })
}

/**
* 修改账户密码
* @param {*} data
*/
export function updateAccountPassword(data) {
    return request({
        url: `/ayo.admin.manager.account.password.update`,
        method: 'post',
        data
    })
}

/**
 * 删除账户
 * @param {*} data
 */
export function deleteAccount(data) {
    return request({
        url: `/ayo.admin.manager.account.delete`,
        method: 'post',
        data
    })
}
