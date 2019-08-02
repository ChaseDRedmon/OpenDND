<template>
  <div>
    <!-- Form Header -->
    <div class="panel">
      <h2>Login</h2>
      <p>Please enter your email and password.</p>
    </div>

    <!-- Input Form -->
    <form class="login" @submit.prevent="login">
      <!-- Username Input -->
      <fieldset class="form-group">
        <input
          class="form-control form-control-lg"
          type="text"
          v-model="email"
          placeholder="User ID"
          required/>
      </fieldset>

      <!-- Password Input -->
      <fieldset class="form-group">
        <input
          class="form-control form-control-lg"
          type="text"
          v-model="password"
          placeholder="Password"
          required/>
      </fieldset>

      <!-- Login Button with click event -->
      <button type="submit" class="btn btn-primary" @click="onSubmitAsync(email, password)">
        Login
      </button>
    </form>
  </div>
</template>

<script>
  export default {
    data(){
      return {
        email : "",
        password : ""
      }
    },
    methods: {
      login: function () {
        let email = this.email
        let password = this.password
        this.$store.dispatch('login', { email, password })
          .then(() => this.$router.push('/'))
          .catch(err => console.log(err))
      }
    }
  }
</script>

<style scoped>

</style>
