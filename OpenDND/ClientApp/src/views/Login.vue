<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex>
        <v-layout align-center justify-center>
          <v-card class="elevation-12" width="400" >
            <v-toolbar color="primary" dark flat>
              <v-toolbar-title>Login form</v-toolbar-title>
            </v-toolbar>
            <v-spacer></v-spacer>
            <v-card-text>
              <v-form v-on:submit.prevent>
                <v-text-field
                  label="Login"
                  name="login"
                  type="text"
                ></v-text-field>

                <v-text-field
                  id="password"
                  label="Password"
                  name="password"
                  type="password"
                ></v-text-field>
              </v-form>
            </v-card-text>
            <v-spacer></v-spacer>
            <v-divider></v-divider>
            <v-card-actions>
              <router-link to="/register">
                <v-btn color="success">Register</v-btn>
              </router-link>
              <v-spacer></v-spacer>

              <v-btn color="info" @click="login">Login</v-btn>
            </v-card-actions>
          </v-card>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
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
