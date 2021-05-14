import inventoryItemService from '@/services/inventoryItemService';
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    foods: [],
    foodById: {},
  },
  getters: {
    /**
     * Lấy danh sách thực đơn
     * @param state 
     * @returns 
     * CreatedBy: nctu 13.05.2021
     */
    getFoods(state) {
      return state.foods;
    },
    /**
     * Lấy thông tin 1 món
     * @param state 
     * @returns 
     */
    getFoodById(state) {
      return state.foodById;
    },
  },
  mutations: {
    /**
     * Gán dữ liệu cho danh sách thực đơn
     * @param state 
     * @param payload dữ liệu lấy được từ API
     * CreatedBy: nctu 13,05.2021
     */
    setFoods(state, payload) {
      state.foods = payload;
    },
    setFoodById(state, foodById) {
      state.foodById = foodById;
    }
  },
  actions: {
    getFoods: async function name(context: any) {
      console.log("lấy data");
      await inventoryItemService.get().then(response => {
        context.commit("setFoods", response.data.data);
      })
    },
    getFoodById: async function name(context: any, foodId: string) {
      console.log("lấy 1 món");
      await inventoryItemService.getById(foodId).then(response => {
        context.commit("setFoodById", response.data.data);
      });

    }
  },
  modules: {
  }
})
