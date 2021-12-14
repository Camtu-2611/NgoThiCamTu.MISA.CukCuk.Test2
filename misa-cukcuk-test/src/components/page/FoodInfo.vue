<template>
  <div class="food-info">
    <div class="dialog-left">
      <div class="dialog-row row-select">
        <div class="row-label">
          <span class="d-label">Loại món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input field-required">
          <div class="select-input">
            <div class="select-btn">
              <span class="t-select-arrow-default"></span>
              <div class="btn-add">
                <button class="t-btn t-btn-default icon-add-blue"></button>
              </div>
            </div>
            <select
              name="unit"
              id="unit"
              class="t-select required"
              v-model="food.inventoryItemTypeName"
              tabindex="2"
              :class="{ 'border-warning': !validate.inventoryItemTypeName }"
              @blur="tab('inventoryItemTypeName')"
            >
              <option v-for="(foodType, index) in foodTypes" :key="index" :value="foodType.value">
                {{ foodType.typeName }}
              </option>
            </select>
          </div>
          <span v-show="!validate.unit" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              Trường này không được để trống
            </span>
          </span>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Tên món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input field-required">
          <misa-input
            type="text"
            class="required"
            v-model="food.foodName"
            tabindex="3"
            id="foodName"
            :class="{ 'border-warning': !validate.foodName }"
            @blur="tab('foodName')"
          ></misa-input>
          <span v-show="!validate.foodName" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              Trường này không được để trống
            </span>
          </span>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Mã món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input field-required">
          <misa-input
            type="text"
            class="required"
            v-model="food.foodCode"
            tabindex="4"
            :class="{ 'border-warning': !validate.foodCode }"
            @blur="tab('foodCode')"
          ></misa-input>
          <span v-show="!validate.foodCode" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              {{ msgValidate.msgFoodCode }}
            </span>
          </span>
          <!-- v-model="food.inventoryItemCode"ryItemCode" -->
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Nhóm thực đơn</span>
        </div>
        <div class="row-input row-select">
          <div class="select-btn">
            <span class="t-select-arrow-default"></span>
            <div class="btn-add">
              <button class="t-btn t-btn-default icon-add-blue"></button>
            </div>
          </div>
          <select
            name="areacook"
            id="area-cook"
            class="t-select t-select-default"
            v-model="food.inventoryItemCategoryName"
            tabindex="5"
          >
            <option
              v-for="(cateName, index) in foodCategories"
              :key="index"
              :value="cateName"
            >
              {{ cateName }}
            </option>
          </select>
        </div>
      </div>
      <div class="dialog-row row-select">
        <div class="row-label">
          <span class="d-label">Đơn vị tính</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input field-required">
          <div class="select-input">
            <div class="select-btn">
              <span class="t-select-arrow-default"></span>
              <div class="btn-add">
                <button class="t-btn t-btn-default icon-add-blue"></button>
              </div>
            </div>
            <select
              name="unit"
              id="unit"
              class="t-select required"
              v-model="food.unit"
              tabindex="6"
              :class="{ 'border-warning': !validate.unit }"
              @blur="tab('unit')"
            >
              <!-- v-model="food.unit" -->
              <option v-for="(unit, index) in units" :key="index" :value="unit">
                {{ unit }}
              </option>
            </select>
          </div>
          <span v-show="!validate.unit" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              Trường này không được để trống
            </span>
          </span>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Giá bán</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input">
          <div class="row-30 field-required">
            <misa-input-money
              class="input-number required"
              v-model="food.salePrice"
              tabindex="7"
              :class="{ 'border-warning': !validate.salePrice }"
              @blur="tab('salePrice')"
              type="text"
            ></misa-input-money>
            <span v-show="!validate.salePrice" class="invalid-icon-default">
              <span class="tooltiptext tooltipFoodAddition">
                Trường này không được để trống
              </span>
            </span>
          </div>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Giá vốn</span>
        </div>
        <div class="row-input">
          <div class="row-30">
            <misa-input
              type="text"
              class="input-number"
              v-model="food.realPrice"
              tabindex="8"
            ></misa-input>
            <!-- v-model="food.realPrice" -->
          </div>
        </div>
      </div>
      <div class="dialog-row row-text-area">
        <div class="row-label">
          <span class="d-label">Mô tả</span>
        </div>
        <div class="row-input input-textarea">
          <textarea
            name="description"
            id="d-text-are"
            class="t-text-area"
            cols="5"
            rows="3"
            v-model="food.description"
            tabindex="9"
          ></textarea>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Chế biến tại</span>
        </div>
        <div class="row-input row-select">
          <div class="select-btn">
            <span class="t-select-arrow-default"></span>
            <div class="btn-add">
              <button class="t-btn t-btn-default icon-add-blue"></button>
            </div>
          </div>
          <select
            name="areacook"
            id="area-cook"
            class="t-select"
            v-model="food.kitchen"
            tabindex="10"
          >
            <!-- v-model="food.kitchen" -->
            <option
              v-for="(kitchen, index) in kitchenName"
              :key="index"
              :value="kitchen"
            >
              {{ kitchen }}
            </option>
          </select>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label"></span>
        </div>
        <div class="row-input row-checkbox">
          <input
            type="button"
            name="d-checkbox"
            id="d-checkbox"
            class="checkbox-default"
            :class="[ food.isShowOnMenu == '1'? 'checkbox-checking':'' ]"
            @click="cbOnClick()"
            tabindex="11"
          />
          <!-- v-model="food.isShowOnMenu" -->
          <span class="label-checkbox">Hiển thị lên thực đơn</span>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label"></span>
        </div>
        <div class="row-input row-checkbox">
          <input
            type="button"
            name="d-checkbox2"
            id="d-checkbox2"
            class="checkbox-default"
            :class="[ food.inActive == '1'? 'checkbox-checking':'' ]"
            @click="cbInActiveOnClick()"
            tabindex="12"
          />
          <!-- v-model="food.isShowOnMenu" -->
          <span class="label-checkbox">Ngừng bán</span>
        </div>
      </div>
    </div>
    <div class="dialog-right">
      <div class="dialog-image">
        <fieldset>
          <legend>
            <span class="legend-img">Ảnh đại diện</span>
          </legend>
          <div class="row-upfile">
            <div class="food-img">
              <div class="food-icon">
                <misa-button icon="icon-selectIconMenu"
                  ><span class="icon-text">Biểu tượng</span></misa-button
                >
              </div>
              <div class="food-img-default">
                <img
                  src="../../assets/images/ImageHandler.png"
                  alt="Ảnh đại diện món ăn"
                />
              </div>
              <span class="img-note">
                <p>Chọn các ảnh có định dạng</p>
                <p class="text-bold">(.jpg, .jpeg, .png, .gif)</p>
              </span>
            </div>
            <div class="upfile-button">
              <div class="btn-upload-img">
                <div class="btn-upload">
                  <misa-button icon="icon-upload" tabindex="13"></misa-button>
                </div>
              </div>
              <div class="btn-remove-img">
                <div class="btn-remove-img">
                  <misa-button
                    icon="icon-remove-img"
                    tabindex="14"
                  ></misa-button>
                </div>
              </div>
            </div>
          </div>
        </fieldset>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import commonFunction from "@/common/commonFunction";
import Vue from "vue";
import constFood from "@/common/constFood";
import MisaInputMoney from "@/control/misa-input/MisaInputMoney.vue";

export default Vue.extend({
  components: { MisaInputMoney },
  props: {
    food: {
      type: Object,
    },
    validate: {
      type: Object,
    },
    msgValidate: {
      type: Object,
    },
  },
  data() {
    return {
      foodTypes: constFood.TYPEFOODS,
      foodCategories: constFood.FOOD_CATEGORY,
      units: constFood.UNIT,
      kitchenName: constFood.KITCHEN_AREA,
    };
  },
  computed: {
    // firstFocus() {
    //   return (this.$refs.foodName as Vue & { focus: () => boolean });
    // },
  },
  created(){
    console.log(this.food.salePrice)
    console.log(this.food.inActive)
  },
  methods: {
    firstForcus() {
      return this.$refs.foodName as Vue & { focus: () => boolean };
    },
    /**
     * Xử lý sự kiện khi click vào checkbox
     * CreatedBy: nctu 14.05.2021
     */
    cbOnClick() {
      // this.isChecked = !this.isChecked;
      if (this.food.isShowOnMenu == "0") {
        this.food.isShowOnMenu = "1";
      } else if (this.food.isShowOnMenu == "1") {
        this.food.isShowOnMenu = "0";
      }
    },

    /**
     * Xử lý sự kiện khi click vào checkbox
     * CreatedBy: nctu 14.05.2021
     */
    cbInActiveOnClick() {
      if (this.food.inActive == "0") {
        this.food.inActive = "1";
      } else if (this.food.inActive == "1") {
        this.food.inActive = "0";
      }
    },

    /**
     * Hàm xử lý chỉ cho phép nhập số trong ô giá tiền
     * CreatedBy: nctu 14.05.2021
     */
    onlyForCurrency() {
      console.log("curreny");
    },
    /**
     * Hàm định dạng giá tiền
     * CreatedBy: nctu 14.05.2021
     */
    formatPrice(value: number) {
      return commonFunction.formatMoney(value);
    },

    /**
     * Validate các ô trống khi tab/blur
     * CreatedBy: nctu 16.05.2021
     */
    tab(text: string) {
      if (text == "typename") {
        if (!this.food.unit) {
          this.validate.inventoryItemTypeName = false;
        } else {
          this.validate.inventoryItemTypeName = true;
        }
      }
      if (text == "foodName") {
        if (!this.food.foodName) {
          this.validate.foodName = false;
        } else {
          this.validate.foodName = true;
        }
      }
      if (text == "foodCode") {
        if (!this.food.foodCode) {
          this.validate.foodCode = false;
          this.msgValidate.msgFoodCode = "Trường này không được để trống";
        } else {
          this.validate.foodCode = true;
        }
      }
      if (text == "unit") {
        if (!this.food.unit) {
          this.validate.unit = false;
        } else {
          this.validate.unit = true;
        }
      }
      if (text == "salePrice") {
        if (!this.food.salePrice) {
          this.validate.salePrice = false;
        } else {
          this.validate.salePrice = true;
        }
      }
    },
  },
});
</script>

<style lang="scss" scoped>
.food-info {
  width: 100%;
  height: auto;
  display: flex;

  //   display: none;
}

.dialog-left {
  width: 70%;
  height: auto;

  .dialog-row {
    display: flex;
    height: 24px;
    width: 100%;
    margin: 2px 0px 4px 0px !important;
  }
  .row-text-area {
    height: 50px;
    margin-bottom: 4px;
  }
  .row-checkbox {
    display: flex;
    margin-top: 8px;
  }

  .row-label {
    width: 125px;
  }
  .row-input {
    flex: 1;
    height: 100%;
  }
  .select-input {
    width: 100%;
    height: 100%;
  }

  .row-select {
    position: relative;
  }
  .input-number {
    text-align: right !important;
  }
  .row-30 {
    width: 30%;
    height: 100%;
  }

  .select-btn {
    display: flex;
    position: relative;
  }
  .t-select-arrow-default {
    width: 22px;
    height: 22px;
    background-image: url("../../assets/icons/trigger.png");
    background-position: 0 center;
    // background-size: 22px;
    background-color: transparent;
    position: absolute;
    right: 22px;
    top: 1px;
  }
  .btn-add {
    width: 22px;
    height: 22px;
    position: absolute;
    right: 1px;
    top: 1px;
    .icon-add-blue:hover {
      border-color: transparent;
    }
  }
}

.dialog-right {
  flex: 1;
  height: fit-content;
  margin-left: 8px;
  //   background-color: darkgoldenrod;

  .dialog-image {
    width: 100%;
  }
  fieldset {
    margin: 0;
    padding: 0;
    border: 1px solid #afafaf;

    legend {
      margin-left: 6px;
    }
  }

  .row-upfile {
    padding: 8px;
    display: flex;
    justify-content: space-between;
  }
  .food-img {
    position: relative;
    width: calc(100% - 27px);
  }
  .food-icon {
    position: absolute;
    width: 110px;
    height: 25px;
    .icon-text {
      color: #026b97;
    }
  }

  .food-img-default {
    width: 100%;
    height: fit-content;
  }

  .img-note {
    text-align: center;
    font-size: 12px;
  }
  .upfile-button {
    width: 27px;
    .btn-upload-img {
      margin-bottom: 4px;
    }
  }
}

.field-required {
  display: flex;
  align-items: center;
}
</style>