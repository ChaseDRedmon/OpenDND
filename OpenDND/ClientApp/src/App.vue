<template>
  <v-app>
    <nav>
    <v-toolbar app light>
      <v-toolbar-title class="headline">OpenDND</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat to="/" exact>Home</v-btn>
        <v-btn flat to="/about">About</v-btn>
        <v-btn flat to="/login">Login</v-btn>
        <v-btn flat to="/register">Signup</v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <!-- End of mobile side menu -->
    </nav>

    <v-content>
      <!-- Display view pages here based on route -->
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
    export default {
        name: "App",
        data() {
            return {
                title: 'OpenDND',
                items: [
                    {title: 'Home', icon: 'home', link: '/'},
                    {title: 'About', icon: 'home', link: '/about'},
                    {title: 'Login', icon: 'get_app', link: '/login'},
                    {title: 'Register', icon: 'get_app', link: '/register'},
                ]
            };
        }
    };
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
