<template>
  <div id="app">
    <Home/>
  </div>
</template>

<script lang="ts">
import Home from '@/views/Home.vue';

import Vue from 'vue'
export default Vue.extend({
  components:{
    Home,
  },
})
</script>


<style src="./styles/main.scss" lang="scss" />
