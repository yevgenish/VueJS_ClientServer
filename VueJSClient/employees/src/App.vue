<template>
  <div id="app">
    <img src="./assets/logo.png" class="logo">
    <h1>{{ msg }}</h1>
    <p class="employee-list">
      <cmp-employee-list></cmp-employee-list>
    </p>
     <p class="employee-details">
      <cmp-employee-details></cmp-employee-details>
    </p>
  </div>
</template>

<script>
import serverData from './services/serverData';

import employeeList from './employee/employeeList.vue';
import employeeDetails from './employee/employeeDetails.vue';

export default {
  name: 'app',
  data () {
    return {
      msg: 'Welcome to Vue.js App'
    }
  },
  components:{
    cmpEmployeeList:employeeList,
    cmpEmployeeDetails: employeeDetails
  },
  created(){

  },
  methods:{

  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 20px;
}

h1, h2 {
  font-weight: normal;
}

h1{
  font-size: 15px;
}

h2{
  font-size: 12px;
}

/*

*/
a {
  color: #42b983;
}

.logo{
  height: 50px;
}

ul{
  margin: 8px 0 0 0;
}

div.controls{
  width: 600px;
  display: inline-block;
  padding-top: 4px;
}

.error, .validator{
    color: red;
}

.message{
    color: #42b983;
}

input{
    margin: 5px;
}

</style>
