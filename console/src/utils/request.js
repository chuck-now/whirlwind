import axios from 'axios'
import {
  Message
} from 'element-ui'

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  // withCredentials: true, // send cookies when cross-domain requests
  timeout: 10000 // request timeout
})

// request interceptor
/* service.interceptors.request.use(
  config => {
    // 验签
    let original = ''
    const signKey = process.env.VUE_APP_API_SIGN_KEY
    const reqBody = config.data || {}
    if (Object.keys(reqBody).length > 0) {
      original = `${JSON.stringify(reqBody)}&${signKey}`
    } else {
      original = `&{${signKey}}`
    }

    original = original.toLowerCase()
    const originalSign = md5(original)

    config.headers['dove-signature'] = originalSign
    return config
  },
  error => {
    // do something with request error
    console.log(error) // for debug
    return Promise.reject(error)
  }
) */

// response interceptor
service.interceptors.response.use(
  /**
   * If you want to get http information such as headers or status
   * Please return  response => response
   */

  /**
   * Determine the request status by custom code
   * Here is just an example
   * You can also judge the status by HTTP Status Code
   */
  response => {
    const res = response.data
    // console.log(res)
    if (res.isSuccess !== true) {
      Message({
        message: res.message || 'Error',
        type: 'error',
        duration: 5 * 1000
      })
      return res
    } else {
      return res
    }
  },
  error => {
    // console.log(error) // for debug
    Message({
      message: error.message,
      type: 'error',
      duration: 5 * 1000
    })
    return Promise.reject(error)
  }
)

export default service
