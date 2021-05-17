import inventoryItemService from '@/services/inventoryItemService';
import filterFields from '@/common/filterData';
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    foods: [],
    foodById: {},
    totalRecord: 0,
    loadData: false,
  },
  getters: {
    /**
     * Lấy danh sách thực đơn
     * @param state 
     * @returns 
     * CreatedBy: nctu 13.05.2021
     */
    getFoods(state) {
      console.log("lấy data get");
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
    /**
     * Lấy số lượng bản ghi hiện có
     * @param state 
     * @returns 
     */
    getTotalFood(state) {
      return state.totalRecord =  state.foods.length;
    },

    getLoadData(state){
      return state.loadData;
    }
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
      console.log('commit')
    },
    /**
     * Gán thông tin bản ghi
     * @param state 
     * @param foodById 
     */
    setFoodById(state, foodById) {
      state.foodById = foodById;
    },
    /**
     * Lấy danh bản ghi phân trang
     * @param state 
     * @param payload 
     */
     setFoodsPaging(state, payload){
      state.foods = payload;
      console.log("gán data");
    },
    loading(state){
      state.loadData = false;
    },
    loaded(state){
      state.loadData = true;
    }
  },
  actions: {
    getFoods: async function name(context: any) {
      console.log("lấy data");
      context.commit("loading");
      await inventoryItemService.get().then(response => {
        context.commit("loaded");
        context.commit("setFoods", response.data.data);
      });
    },
    getFoodById: async function name(context: any, foodId: string) {
      console.log("lấy 1 món");
      await inventoryItemService.getById(foodId).then(response => {
        context.commit("setFoodById", response.data.data);
      });

    },
    getFoodPaging: async function name(context:any, filterFields: filterFields) {
      console.log("lấy dữ liệu phân trang");
      context.commit("loading");
      await inventoryItemService.getpaging(filterFields).then(response=>{
        context.commit("loaded");
        context.commit("setFoodsPaging", response.data.data);
       console.log("lấy dữ liệu", response.data.data);

      });
      console.log("lấy dữ liệu phân trang xong");

    }
  },
  modules: {
  }
})
