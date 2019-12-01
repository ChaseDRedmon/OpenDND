import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store/store'
import Vuetify from 'vuetify'
import Axios from 'axios'
import '@babel/polyfill'
import ValidationProvider from 'vee-validate'

Vue.use(Vuetify)

Vue.prototype.$http = Axios
Vue.config.productionTip = false

const token = localStorage.getItem('token')

if (token) {
  Vue.prototype.$http.defaults.headers.common['Authorization'] = token
}

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
