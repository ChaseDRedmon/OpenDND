import UserService from '@/services/UserService'

const state = {
  all: {}
}

const actions = {
  getAll ({ commit }: any) {
    commit('getAllRequest')

    UserService.GetAll()
      .then(
        users => commit('getAllSuccess', users),
        error => commit('getAllFailure', error)
      )
  },

  delete ({ commit }: any, id: any) {
    commit('deleteRequest', id)

    UserService.Delete(id)
      .then(
        user => commit('deleteSuccess', id),
        error => commit('deleteSuccess', { id, error: error.toString() })
      )
  }
}

const mutations = {
  getAllRequest (state: any) {
    state.all = { loading: true }
  },
  getAllSuccess (state: any, users: any) {
    state.all = { items: users }
  },
  getAllFailure (state: any, error: any) {
    state.all = { error }
  },
  deleteRequest (state: any, id: any) {
    // add 'deleting:true' property to user being deleted
    state.all.items = state.all.items.map((user: any) =>
      user.id === id
        ? { ...user, deleting: true }
        : user
    )
  },
  deleteSuccess (state: any, id: any) {
    // remove deleted user from state
    state.all.items = state.all.items.filter((user: any) => user.id !== id)
  },
  deleteFailure (state: any, { id, error }: any) {
    // remove 'deleting:true' property and add 'deleteError:[error]' property to user
    state.all.items = state.items.map((user: any) => {
      if (user.id === id) {
        // make copy of user without 'deleting:true' property
        const { deleting, ...userCopy } = user
        // return copy of user with 'deleteError:[error]' property
        return { ...userCopy, deleteError: error }
      }

      return user
    })
  }
}

export const users = {
  namespaced: true,
  state,
  actions,
  mutations
}
