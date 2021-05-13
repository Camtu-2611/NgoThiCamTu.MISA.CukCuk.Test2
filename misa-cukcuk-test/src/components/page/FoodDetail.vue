<template>
  <div class="dialog">
    <div class="dialog__modal" @click="closeDialog"></div>
    <div class="dialog__form">
      <!-- begin header -->
      <div class="dialog__header">
        <div class="food-detail-header">
          <div class="dialog-title">
            {{ dialogTitle }}
          </div>
          <div class="div-close">
            <button class="t-btn t-btn-defaul t-btn-close" @click="closeDialog"></button>
          </div>
        </div>
      </div>
      <!-- end header -->
      <!-- begin body -->
      <div class="dialog__body">
        <div class="dialog__tab">
          <a class="t-tab" :class="{'t-tab-active' : isShowFoodInfo}" @click="closeFoodAddition()">
            <div class="t-tab-text">Thông tin chung</div>
          </a>
          <a class="t-tab" :class="{'t-tab-active' : isShowFoodAddition}" @click="showFoodAddition()">
            <div class="t-tab-text" >Sở thích phục vụ</div>
          </a>
        </div>
        <div class="dialog__content">
          <div class="dialog-food">
            <FoodInfo v-if="isShowFoodInfo" />
            <FoodAddition v-if="isShowFoodAddition" />
          </div>
        </div>
      </div>
      <!-- end body -->
      <!-- begin footer -->
      <div class="dialog__footer">
        <div class="dialog__footer-btn">
          <div class="d-footer-left">
            <div class="d-btn-footer btn-help">
              <misa-button icon="icon-help" @click="btnHelpOnClick"
                >Giúp</misa-button
              >
            </div>
          </div>
          <div class="d-footer-right">
            <div class="d-btn-footer btn-save">
              <misa-button icon="icon-Save16" @click="btnSaveOnClick"
                >Cất</misa-button
              >
            </div>
            <div class="d-btn-footer btn-saveadd">
              <misa-button icon="icon-SaveAdd16" @click="btnSaveNewOnClick"
                >Cất và Thêm</misa-button
              >
            </div>
            <div class="d-btn-footer btn-cancel">
              <misa-button icon="icon-Disable16" @click="closeDialog"
                >Hủy bỏ</misa-button
              >
            </div>
          </div>
        </div>
      </div>
      <!-- end footer -->
    </div>
  </div>
</template>

<script lang="ts">
import MisaButton from "@/control/misa-button/MisaButton.vue";
import FoodInfo from "@/components/page/FoodInfo.vue";
import FoodAddition from "@/components/page/FoodAddition.vue";

import Vue from "vue";
export default Vue.extend({
  components: { MisaButton, FoodInfo, FoodAddition },
  props:{
    
  },
  data() {
    return {
      dialogTitle: "Thêm món",
      isShowFoodInfo: true,
      isShowFoodAddition: false,
    };
  },
  methods: {
    closeDialog() {
      console.log("Đóng Dialog");
      this.$emit('closeDialog');
      this.resetDialog();
    },
    showFoodAddition(){
      console.log("mở sở thích phục vụ");
      this.isShowFoodAddition = true;
      this.isShowFoodInfo = false;
    },
    closeFoodAddition(){
      console.log("đóng sở thích phục vụ");
      this.isShowFoodAddition = false;
      this.isShowFoodInfo = true;
    },
    resetDialog(){
      this.isShowFoodInfo = true;
      this.isShowFoodAddition = false;
    },
    btnHelpOnClick() {
      console.log("Giúp");
    },

    btnSaveOnClick() {
      console.log("Cất");
    },
    btnSaveNewOnClick() {
      console.log("Cất và thêm");
    },
  },
});
</script>

<style lang="scss" scoped>
@mixin x-tab-dialog($color) {
  background-color: $color;
  border-bottom: medium none;
  border-left: 1px solid #d3d3d3 !important;
  // border-right: 1px solid #d3d3d3 !important;
  border-top: 2px solid #0072bc !important;
  margin-left: 1px !important;
}

.dialog {
  // display: none;
}
.dialog__modal {
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  background-color: rgba(10, 10, 10, 0.4) !important;
  z-index: 990;
}
.dialog__form {
  width: 750px;
  height: 540px;
  border: 5px solid #0072bc !important;
  position: absolute;
  top: calc(50% - 270px);
  left: calc(50% - 375px);
  z-index: 1000;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: rgb(136 136 136) -1px 1px 3px;
}

.dialog__header {
  height: auto;
  width: 100%;
  color: #fff;
  border-color: #0072bc !important;

  .food-detail-header {
    height: 30px;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: #0072bc;
    box-sizing: border-box;
    margin-top: -4px;
    padding: 5px 2px 5px 5px;
  }

  .dialog-title {
    width: 100%;
    height: auto;
  }
  .div-close {
    width: 18px;
    height: 18px;

    .t-btn-close {
      width: 18px;
      height: 18px;
      border-color: transparent;
      overflow: hidden;
      background-image: url("../../assets/icons/tool-sprites.png");
      background-position: 0 0;
      background-color: transparent;
      background-repeat: no-repeat;
      margin: 0;
    }
  }
}

.dialog__body {
  position: absolute;
  top: 25px;
  padding: 8px;
  width: calc(100% - 16px);
  height: calc(100% - 80px);

  .dialog__tab {
    width: 100%;
    height: 28px;
    background-color: #f5f5f5;
    display: flex;

    .t-tab {
      height: 100%;
      color: #000;
      cursor: pointer;
      box-sizing: border-box;

      &:hover {
        @include x-tab-dialog(rgba(127, 199, 227, 0.4));
      }
    }
    .t-tab-active {
      color: #0072bc;
      @include x-tab-dialog(#fff);
      &:hover {
        @include x-tab-dialog(#fff);
      }
    }

    .t-tab-text {
      margin: 4px 8px;
    }
  }

  .dialog__content {
    width: 100%;
    height: calc(100% - 28px);
  }
}

.dialog__footer {
  height: 40px;
  width: 100%;
  position: absolute;
  bottom: 0;
  background-color: transparent;
  display: flex;
  align-items: center;

  .dialog__footer-btn {
    width: 100%;
    display: flex;
    justify-content: space-between;
    padding: 8px;

    .d-footer-right {
      display: flex;
      justify-items: end;
    }

    .d-btn-footer {
      margin-left: 8px;
    }
    .btn-save {
      width: 86px;
    }
    .btn-saveadd {
      width: 123px;
    }
    .btn-cancel {
      width: 91px;
    }
    .btn-help {
      width: 75px;
      margin-left: 0px;
    }
  }
}

.dialog-food {
  width: 100%;
  height: 100%;
  box-sizing: border-box;
  padding-top: 10px;
}
</style>