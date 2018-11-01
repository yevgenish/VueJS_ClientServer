import Vue from 'vue'
import App from './App.vue'

window.Vue = Vue;

var VueResource = require('vue-resource');
Vue.use(VueResource);

export const serverBus = new Vue();

new Vue({
  el: '#app',
  render: h => h(App)
});

//created in Visual Studio Code
//to run the project run command in Terminal:
//npm run dev