import Vue from 'vue'
import Vuex from 'vuex'
import client from '@/services/ApiClientBase'

import { alert } from './alert.module'
import { account } from './account.module'
import { users } from './users.module'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {

  },
  mutations: {

  },
  actions: {

  },
  modules: {
    alert,
    account,
    users
  }
})
