import Vue from 'vue'
import Router from 'vue-router'
Vue.use(Router)

/* Layout */
import Layout from '@/layout'

/**
 * Note: sub-menu only appear when route children.length >= 1
 * Detail see: https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 *
 * hidden: true                   if set true, item will not show in the sidebar(default is false)
 * alwaysShow: true               if set true, will always show the root menu
 *                                if not set alwaysShow, when item has more than one children route,
 *                                it will becomes nested mode, otherwise not show the root menu
 * redirect: noRedirect           if set noRedirect will no redirect in the breadcrumb
 * name:'router-name'             the name is used by <keep-alive> (must set!!!)
 * meta : {
    roles: ['admin','editor']    control the page roles (you can set multiple roles)
    title: 'title'               the name show in sidebar and breadcrumb (recommend set)
    icon: 'svg-name'             the icon show in the sidebar
    breadcrumb: false            if set false, the item will hidden in breadcrumb(default is true)
    activeMenu: '/example/list'  if set path, the sidebar will highlight the path you set
  }
 */

/**
 * constantRoutes
 * a base page that does not have permission requirements
 * all roles can be accessed
 */
export const constantRoutes = [{
    path: '/login',
    component: () => import('@/views/login/index'),
    hidden: true
  },
  {
    path: '/404',
    component: () => import('@/views/404'),
    hidden: true
  },
  {
    path: '/',
    component: Layout,
    redirect: '/dashboard',
    children: [
      {
        path: 'dashboard',
        component: () => import('@/views/dashboard/index'),
        name: 'Dashboard',
        meta: { title: '数据看板', icon: 'dashboard', affix: true }
      }
    ]
  },
  // {
  //   path: '/job',
  //   component: Layout,
  //   redirect: '/job/list',
  //   meta: {
  //     title: '采集管理', icon: 'documentation'
  //   },
  //   children: [{
  //       path: 'index',
  //       name: 'CreateJob',
  //       component: () => import('@/views/job/index'),
  //       meta: {
  //         title: '创建采集任务',
  //         icon: 'star'
  //       }
  //     },
  //     {
  //       path: 'list',
  //       name: 'JobList',
  //       component: () => import('@/views/job/list'),
  //       meta: {
  //         title: '采集任务列表',
  //         icon: 'list'
  //       }
  //     }
  //   ]
  // },
  // 404 page must be placed at the end !!!
  {
    path: '*',
    redirect: '/404',
    hidden: true
  }
]

/**
 * asyncRoutes
 * the routes that need to be dynamically loaded based on user roles
 */
export const asyncRoutes = [
  {
    path: '/sysconfig',
    component: Layout,
    redirect: '/noRedirect',
    meta: {
      title: '系统设置',
      icon: 'setting',
      roles: ['admin']
    },
    alwaysShow: true,
    children: [
      {
        path: 'accountlist',
        name: 'AccountList',
        component: () => import('@/views/manager/accountlist'),
        meta: {
          title: '账户管理',
          icon: 'user',
          roles: ['admin']
        }
      }
    ]
  }
]

const createRouter = () =>
  new Router({
    // mode: 'history', // require service support
    scrollBehavior: () => ({
      y: 0
    }),
    routes: constantRoutes
  })

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher // reset router
}

export default router