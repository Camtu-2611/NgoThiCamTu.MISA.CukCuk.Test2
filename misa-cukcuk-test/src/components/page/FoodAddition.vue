<template>
  <div class="food-additon">
    <div class="info-food">
      <div class="text-left">
        <span>Món ăn: </span>
      </div>
      <div class="text-bold mg-l4">
        <span>{{ foodName }}</span>
      </div>
    </div>
    <div class="addition-note">
      <div class="text-italic">
        Ghi lại các sở thích của khách hàng giúp nhân viên phục vụ chọn nhanh
        order.
        <br />
         VD: không cay/ ít hành/ thêm phomai...
      </div>
    </div>
    <div class="grid-addition-food">
        <div class="tbl-addition-list">
            <!-- <table>
                <thead>
                  <th>
                    <td>Sở thích phục vụ</td>
                    <td>Thu thêm</td>
                  </th>
                </thead>
                <div class="tbl-body">
                    <tbody>
                        <tr>
                            <td>
                                <input type="text" v-model="select" name="addition-food" >
                            </td>
                            <td>
                                <input type="text" name="addition-food" >
                            </td>
                        </tr>
                    </tbody>
                </div>
            </table> -->

            <table :key="key">
              <thead>
                <tr>
                <th>Company</th>
                <th>Company</th>
                </tr>
              </thead>
              <div>
              <tbody id="stocksTerminal">
              <tr :key="item.key" v-for="(item, index) in data">
                <td>
                  <input type="text" v-model="item.name">
                  <div :id="item.id" v-for="item2 in data2.filter(el => el.name.includes(item.name))" :key="item2.id" @click="chooseItem(index, item2)">{{item2.name}}</div>
                </td>
                <td >{{ item.price }}</td>
              </tr>
              </tbody>

              </div>
              </table>
        </div>
    </div>
    <div class="grid-dialog-toolbar">
        <div class="btn-food-addition btn-addrow">
            <misa-button icon="icon-plus-addition" @click="addRow"> Thêm dòng</misa-button>
        </div>
        <div class="btn-food-addition btn-deleterow">
            <misa-button icon="icon-delete-addition"> Xóa dòng </misa-button>
        </div>
    </div>

    <AddFoodAddition/>
  </div>
</template>

<script lang="ts">
import MisaButton from "@/control/misa-button/MisaButton.vue";
import AddFoodAddition from '@/components/page/AddFoodAddition.vue';
import Vue from "vue";
export default Vue.extend({
  components: { MisaButton, AddFoodAddition, },
  props: {
    foodSelectedName: String,
  },
  data() {
    return {
      key: 0,
      foodName: "Gà hấp lá chanh",
      select: "",
      data : [{
        id: 1,
        name: "Gà hấp lá chanh2",
        price: 200
      },
      {
        id: 2,
        name: "Gà hấp lá chanh3",
        price: 200
      },
      {
        id:3,
        name: "Gà hấp lá chanh4",
        price: 200
      }
      ],
      data2 : [{
        id: 1,
        name: "Gà hấp lá chanh2",
        price: 200
      },
      {
        id: 2,
        name: "Gà hấp lá chanh3",
        price: 200
      },
      {
        id:3,
        name: "Gà hấp lá chanh4",
        price: 200
      }
      ]
    };
  },
  methods: {
    chooseItem(index: number, item: any){
      console.log(index);
      console.log(item);
      console.log(this.data);
      
      this.data[index].name = item.name;
      this.data[index].price = item.price;
      this.key++;
    },
    addRow(){
      this.data.push({
        id: 5,
        name: "",
        price: 0
      })
    }
  }
});
</script>
<style lang="scss" scoped>
.food-additon {
    // display: none;
  width: 100%;
  height: auto;
  font-size: 13px !important;
}
.info-food{
    display: flex;
    margin-bottom: 4px;
}
.addition-note{
    margin-bottom: 8px;
    padding-left: 42px;
    background: url('../../assets/icons/icon-info32-2.png') 3px center no-repeat;
    background-size: 32px;
}
.grid-addition-food{
    width: 100%;
    height: 215px;
    margin-bottom: 4px;
    border: 1px solid #ccc!important;
    box-sizing: border-box;
}
.grid-dialog-toolbar{
    width: 100%;
    height: 25px;
    display: flex;
    .btn-food-addition{
        margin: 0 2px;
    }
}
</style>