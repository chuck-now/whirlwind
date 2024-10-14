import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/ayo.admin.manager.account.login',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/ayo.admin.manager.account.getbytoken?token=' + token,
    method: 'post'
  })
}
