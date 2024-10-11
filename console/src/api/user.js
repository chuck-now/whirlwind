import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/bee.admin.manager.account.login',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/bee.admin.manager.account.getbytoken?token=' + token,
    method: 'post'
  })
}
