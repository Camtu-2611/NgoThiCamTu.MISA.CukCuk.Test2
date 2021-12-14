<template>
  <div class="food-additon">
    <div class="info-food">
      <div class="text-left">
        <span>Món ăn: </span>
      </div>
      <div class="text-bold mg-l4">
        <span>{{ food.foodName }}</span>
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
        <table :key="key">
          <thead>
            <tr>
              <th>Sở thích phục vụ</th>
              <th>Thu thêm</th>
            </tr>
          </thead>
          <div>
            <tbody id="stocksTerminal" style="width: 100%; height: 100%">
              <tr
                :key="index"
                v-for="(item, index) in data"
                @click="rowAdditionSelected(index)"
                :class="{ selected: rowSelected == index }"
              >
                <td>
                  <select name="" id="" v-model="data[index]" class="t-select">
                    <option
                      v-for="(op, key) in additionOptions"
                      :value="op"
                      :key="key"
                    >
                      {{ op.name }}
                    </option>
                  </select>
                </td>
                <td>{{ item.value }}</td>
              </tr>
            </tbody>
          </div>
        </table>
      </div>
    </div>
    <div class="grid-dialog-toolbar">
      <div class="btn-food-addition btn-addrow">
        <misa-button icon="icon-plus-addition" @click="addRow">
          Thêm dòng</misa-button
        >
      </div>
      <div class="btn-food-addition btn-deleterow">
        <misa-button icon="icon-delete-addition" @click="removeRow()">
          Xóa dòng
        </misa-button>
      </div>
    </div>

    <AddFoodAddition />
  </div>
</template>

<script lang="ts">
import MisaButton from "@/control/misa-button/MisaButton.vue";
import AddFoodAddition from "@/components/page/AddFoodAddition.vue";
import Vue from "vue";
import axios from "axios";
export default Vue.extend({
  components: { MisaButton, AddFoodAddition },
  props: {
    food: {
      type: Object,
    },
  },
  data() {
    return {
      key: 0,
      rowSelected: null,
      data: [
        {
          name: "",
          value: 0,
        },
      ],
      additionOptions: [],
    };
  },
  watch: {
    data() {
      this.food.foodAdditions = this.data;
    },
  },
  mounted() {
    this.getAllAddition();
    this.data = this.food.foodAdditions
      ? this.food.foodAdditions
      : [
          {
            name: "",
            value: 0,
          },
        ];
  },
  methods: {
    addRow() {
      this.data.push({
        name: "",
        value: 0,
      });
    },
    removeRow() {
      console.log(this.rowSelected)
      if (!this.rowSelected && this.rowSelected == null) {
        return
      }else{
        this.data.splice(this.rowSelected,1)
      }
    },
    getAllAddition() {
      axios.get("/addition").then((response) => {
        if (response && response.data) {
          this.additionOptions = response.data;
        }
      });
    },
    rowAdditionSelected(index: any) {
      this.rowSelected = index;
    },
  },
});
</script>
<style lang="scss" scoped>
/* phần tử được chọn */
.selected {
  background-color: #c1ddf1 !important;
  color: #000;
  cursor: default !important;
}
.food-additon {
  width: 100%;
  height: auto;
  font-size: 13px !important;
}
.info-food {
  display: flex;
  margin-bottom: 4px;
}
.addition-note {
  margin-bottom: 8px;
  padding-left: 42px;
  background: url("../../assets/icons/icon-info32-2.png") 3px center no-repeat;
  background-size: 32px;
}
.grid-addition-food {
  width: 100%;
  height: 215px;
  margin-bottom: 4px;
  border: 1px solid #ccc !important;
  box-sizing: border-box;
}
.tbl-addition-list {
  font-weight: normal;
}
.grid-dialog-toolbar {
  width: 100%;
  height: 25px;
  display: flex;
  .btn-food-addition {
    margin: 0 2px;
  }
}

.list-addition {
  display: none;
}
</style>