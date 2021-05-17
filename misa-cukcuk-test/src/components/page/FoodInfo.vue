<template>
  <div class="food-info">
    <div class="dialog-left">
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Tên món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input field-required">
          <misa-input
            type="text"
            v-model="food.inventoryItemName"
            tabindex="2"
            ref="foodName"
            id="foodName"
            :class="{ 'border-warning': !validate.foodName }"
            @blur="checkFoodNameEmpty()"
          ></misa-input>
          <span v-show="!validate.foodName" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              {{ msgValidate.msgWarningEmpty }}
            </span>
          </span>
          <!-- v-model="food.inventoryItemName" -->
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
            v-model="food.inventoryItemCode"
            tabindex="3"
            :class="{ 'border-warning': !validate.foodCode }"
            @blur="checkFoodCodeEmpty()"
          ></misa-input>
          <span v-show="!validate.foodCode" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              {{ msgValidate.msgWarningEmpty }}
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
            tabindex="4"
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
              name="areacook"
              id="area-cook"
              class="t-select"
              v-model="food.unit"
              tabindex="5"
              :class="{ 'border-warning': !validate.unit }"
              @blur="checkUnitEmpty()"
            >
              <!-- v-model="food.unit" -->
              <option v-for="(unit, index) in units" :key="index" :value="unit">
                {{ unit }}
              </option>
            </select>
          </div>
          <span v-show="!validate.unit" class="invalid-icon-default">
            <span class="tooltiptext tooltipFoodAddition">
              {{ msgValidate.msgWarningEmpty }}
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
            <misa-input
              type="text"
              class="input-number"
              :value="0"
              v-model="food.salePrice"
              @keypress="onlyForCurrency()"
              tabindex="6"
              :class="{ 'border-warning': !validate.salePrice }"
              @blur="checkSalePriceEmpty()"
            ></misa-input>
            <span v-show="!validate.salePrice" class="invalid-icon-default">
              <span class="tooltiptext tooltipFoodAddition">
                {{ msgValidate.msgWarningEmpty }}
              </span>
            </span>
            <!-- v-model="food.salePrice" -->
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
              :value="0"
              v-model="food.realPrice"
              tabindex="7"
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
            tabindex="8"
          ></textarea>
          <!-- v-model="food.description" -->
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
            tabindex="9"
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
            :class="{ 'checkbox-checking': food.isShowOnMenu == 1 }"
            @click="cbOnClick()"
            tabindex="10"
          />
          <!-- v-model="food.isShowOnMenu" -->
          <span class="label-checkbox">Không hiển thị lên thực đơn</span>
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
                  <misa-button icon="icon-upload" tabindex="11"></misa-button>
                </div>
              </div>
              <div class="btn-remove-img">
                <div class="btn-remove-img">
                  <misa-button
                    icon="icon-remove-img"
                    tabindex="12"
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

export default Vue.extend({
  props: {
    food: {
      type: Object,
    },
    validate:{
      type: Object,
    },
    msgValidate:{
      type: Object,
    },
  },
  data() {
    return {
      // isChecked: false,
      foodCategories: constFood.FOOD_CATEGORY,
      units: constFood.UNIT,
      kitchenName: constFood.KITCHEN_AREA,
      
      
    };
  },
  computed: {
    firstFocus() {
      return (this.$refs.foodName as Vue & { focus: () => boolean }).focus();
    },
  },
  methods: {
    /**
     * Xử lý sự kiện khi click vào checkbox
     * CreatedBy: nctu 14.05.2021
     */
    cbOnClick() {
      // this.isChecked = !this.isChecked;
      if (this.food.isShowOnMenu == 0) {
        this.food.isShowOnMenu = 1;
      } else if (this.food.isShowOnMenu == 1) {
        this.food.isShowOnMenu = 0;
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
  .select-input{
    width: 100%;
    height: 100%;
  }

  .row-select {
    position: relative;
  }
  .input-number {
    text-align: right;
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