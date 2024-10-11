import Cookies from 'js-cookie'

const TokenKey = 'bee-token'

export function getToken() {
  return Cookies.get(TokenKey, { domain: process.env.VUE_APP_COOKIE_DOMAIN })
}

export function setToken(token) {
  return Cookies.set(TokenKey, token, {
    domain: process.env.VUE_APP_COOKIE_DOMAIN,
    expires: 7
  })
}

export function removeToken() {
  return Cookies.remove(TokenKey, { domain: process.env.VUE_APP_COOKIE_DOMAIN })
}
