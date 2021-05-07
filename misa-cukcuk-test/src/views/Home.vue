<template>
  <div class="main">
    <TheHeader />
    <div class="t-container">
      <TheSidebar/>
      <FoodList/>
    </div>
  </div>
</template> 

<script lang="ts">
import Vue from 'vue';
import TheHeader from '@/components/layout/TheHeader.vue';
import TheSidebar from '@/components/layout/TheSidebar.vue';
import FoodList from '@/components/page/FoodList.vue';
export default Vue.extend({
  name: 'Home',
  components: {
    TheHeader,
    TheSidebar,
    FoodList,
  },

  data() {
    return {
      // selectedFruit:'',
      // name: 'message',
      // optionsFruits:[
      //   {
      //     value: 1,
      //     name: 'apple',
      //     selected: true,
      //   },
      //   {
      //     value: 2,
      //     name: 'banana',
      //     selected: false,
      //   },
      //   {
      //     value: 3,
      //     name: 'orange',
      //     selected: false,
      //   }
      // ],
      // columns: [
      //   {
      //     title: 'Loại món',
      //     index: '',
      //   },
      //   {
      //     title: 'Mã món',
      //     index: '',
      //   }
      // ],

      data: []
    }
  },

  methods: {
      // msTableOnRequest(request: any) {
      //   inventoryItemService.getPaging()
      // }

      // btnAddMenuOnClick() {
      //   console.log('Thêm mons');
        
      // }
    },
});
</script>

<style lang="scss" scoped>
.t-container{
  display: flex;
  width: 100%;
  height: calc(100vh - 55px);
  background: #f5f5f5;
}
</style>
