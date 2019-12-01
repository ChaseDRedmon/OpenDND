<template>
  <div class="body">
    <!-- Form Header -->
    <div class="panel">
      <h2>Sign up</h2>
      <p>Please enter your email and password.</p>
    </div>

    <!-- Input Form -->
    <form v-on:submit.prevent>
      <div class="form-row">
        <div class="form-group col-md-4">
          <fieldset class="form-group" id="input-group-4" label="Email: " label-for="input-4">
            <input id="input-4"
                   class="form-control"
                   type="text"
                   v-model="user.email"
                   placeholder="User ID"
            />
          </fieldset>
        </div>
        <div class="form-group col-md-4">
          <fieldset class="form-group" id="input-group-5" label="Password: " label-for="input-5">
            <input id="input-5"
                   class="form-control"
                   type="text"
                   v-model="user.password"
                   placeholder="Password"
            />
          </fieldset>
        </div>
        <div class="form-group col-md-4">
          <fieldset class="form-group" id="input-group-6" label="Confirm Password " label-for="input-6">
            <input id="input-6"
                   class="form-control"
                   type="text"
                   v-model="user.passwordConfirmation"
                   placeholder="Confirm Password"
            />
          </fieldset>
        </div>
      </div>

        <div class="form-group col-md-6">
          <button type="button"
                  class="btn btn-primary"
                  @click="register">
            Submit
          </button>
          <button type="button" class="btn btn-danger">Reset</button>
        </div>
    </form>
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'

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
      this.$store.dispatch('Authentication', { email, password })
        .then(() => this.$router.push('/'))
        .catch(err => console.log(err))
    }
  }
}
</script>

<style scoped>

</style>
