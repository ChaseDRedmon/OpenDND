<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex>
        <v-layout align-center justify-center>
          <v-card class="elevation-12" width="400" >
            <v-toolbar color="primary" dark flat>
              <v-toolbar-title>Register</v-toolbar-title>
            </v-toolbar>
            <v-spacer></v-spacer>
            <v-card-text>
              <v-form>
                <v-text-field
                  label="Email"
                  name="email"
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
              <v-btn color="success" @click="register">Register</v-btn>
            </v-card-actions>
          </v-card>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import UserService from '@/services/UserService'

export default {
  data () {
    return {
      user: {
        email: '',
        password: '',
        passwordConfirmation: ''
      },
      submitted: false
    }
  },
  computed: {
    ...mapState('account', ['status'])
  },
  methods: {
    ...mapActions('account', ['register']),
    register: async function () {
      let email = this.user.email
      let password = this.user.password

      await UserService.Register({ email, password })
        .then(() => this.$router.push('/'))
        .catch(err => console.log(err))
    }
  }
}
</script>

<style scoped>

</style>
