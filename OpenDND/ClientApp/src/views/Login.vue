<template>
  <div class="body">
    <!-- Form Header -->
    <div class="panel">
      <h2>Login</h2>
      <p>Please enter your email and password.</p>
    </div>

    <!-- Input Form -->
    <form v-on:submit.prevent>
      <!-- Username Input -->
      <fieldset class="form-group">
        <label>
          <input
            class="form-control form-control-lg"
            type="text"
            v-model="user.email"
            placeholder="User ID"
            required/>
        </label>
      </fieldset>

      <!-- Password Input -->
      <fieldset class="form-group">
        <label>
          <input
            class="form-control form-control-lg"
            type="text"
            v-model="user.password"
            placeholder="Password"
            required/>
        </label>
      </fieldset>

      <!-- Login Button with click event -->
      <button type="submit" class="btn btn-primary" @click="login">
        Login
      </button>
    </form>
  </div>
</template>

<script>

import { mapActions, mapState } from 'vuex'
import UserService from "@/services/UserService";

export default {
  data () {
    return {
      user: {
        email: '',
        password: ''
      },
      submitted: false
    }
  },
  computed:
        {
          ...mapState('account', ['status'])
        },
  created () {
    // reset login status
    this.logout()
  },
  methods: {
    ...mapActions('account', ['login', 'logout']),
    login: async function () {
      let email = this.user.email;
      let password = this.user.password;
        await UserService.Login(email, password)
    }
  }
}
</script>

<style scoped>

</style>
