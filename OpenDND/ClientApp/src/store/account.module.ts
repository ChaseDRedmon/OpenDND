import userService from '../services/UserService'
import router from '../router'

const user = JSON.parse(<string>localStorage.getItem('user'))
const state = user
  ? { status: { loggedIn: true }, user }
  : { status: {}, user: null }

const actions = {
  login ({ dispatch, commit }: any, { username, password }: any) {
    commit('loginRequest', { username })

    userService.Login(username, password)
      .then(
        (user: any) => {
          commit('loginSuccess', user)
          router.push('/')
        },
        (error: any) => {
          commit('loginFailure', error)
          dispatch('alert/error', error, { root: true })
        }
      )
  },
  logout ({ commit }: any) {
    userService.Logout()
    commit('logout')
  },
  register ({ dispatch, commit }: any, user: any) {
    commit('registerRequest', user)

    userService.Register(user)
      .then(
        user => {
          commit('registerSuccess', user)
          router.push('/login')
          setTimeout(() => {
            // display success message after route change completes
            dispatch('alert/success', 'Registration successful', { root: true })
          })
        },
        error => {
          commit('registerFailure', error)
          dispatch('alert/error', error, { root: true })
        }
      )
  }
}

const mutations = {
  loginRequest (state: any, user: any) {
    state.status = { loggingIn: true }
    state.user = user
  },
  loginSuccess (state: any, user: any) {
    state.status = { loggedIn: true }
    state.user = user
  },
  loginFailure (state: any) {
    state.status = {}
    state.user = null
  },
  logout (state: any) {
    state.status = {}
    state.user = null
  },
  registerRequest (state: any, user: any) {
    state.status = { registering: true }
  },
  registerSuccess (state: any, user: any) {
    state.status = {}
  },
  registerFailure (state: any, error: any) {
    state.status = {}
  }
}

export const account = {
  namespaced: true,
  state,
  actions,
  mutations
}
