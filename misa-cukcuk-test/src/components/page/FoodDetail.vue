<template>
  <div class="dialog">
    <div class="dialog__modal"></div>
    <div class="dialog__form">
      <!-- begin header -->
      <div class="dialog__header">
        <div class="food-detail-header">
          <div class="dialog-title">
            {{ dialogTitle }}
          </div>
          <div class="div-close">
            <button class="t-btn t-btn-default btn-x"></button>
          </div>
        </div>
      </div>
      <!-- end header -->
      <!-- begin body -->
      <div class="dialog__body">
        <div class="dialog__tab">
          <a class="t-tab t-tab-active">
            <div class="t-tab-text">Thông tin chung</div>
          </a>
          <a class="t-tab">
            <div class="t-tab-text">Sở thích phục vụ</div>
          </a>
        </div>
        <div class="dialog__content"></div>
      </div>
      <!-- end body -->
      <!-- begin footer -->
      <div class="dialog__footer">
        <div class="dialog__footer-btn">
          <div class="d-footer-left">
            <div class="d-btn-footer">
              <misa-button icon="icon-help" @click="btnHelpOnClick"
                >Giúp</misa-button
              >
            </div>
          </div>
          <div class="d-footer-right">
            <div class="d-btn-footer">
              <misa-button icon="icon-Save16" @click="btnSaveOnClick"
                >Cất</misa-button
              >
            </div>
            <div class="d-btn-footer">
              <misa-button icon="icon-SaveAdd16" @click="btnSaveNewOnClick"
                >Cất và Thêm</misa-button
              >
            </div>
            <div class="d-btn-footer">
              <misa-button icon="icon-Disable16" @click="btnCancelOnClick"
                >Hủy</misa-button
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
import Vue from "vue";
export default Vue.extend({
  components: { MisaButton },
  data() {
    return {
      dialogTitle: "Thêm món",
    };
  },
  methods: {
    btnHelpOnClick() {
      console.log("Giúp");
    },
    btnSaveOnClick() {
      console.log("Cất");
    },
    btnSaveNewOnClick() {
      console.log("Cất và thêm");
    },
    btnCancelOnClick() {
      console.log("xóa");
    },
  },
});
</script>

<style lang="scss" scoped>

@mixin x-tab-dialog($color) {
  background-color: $color;
  border-bottom: medium none;
  border-left-color: #d3d3d3 !important;
  border-right-color: #d3d3d3 !important;
  border-top: 2px solid #0072bc !important;
  box-shadow: 0 1px 1px 1px #d3d3d3 !important;
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
  // background-color: #000000;
  // opacity: 0.2;
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
  position: relative;

  .food-detail-header {
    height: 16px;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
    border: 5px solid #0072bc;
    background-color: #0072bc;
    position: absolute;
    left: -5px;
    top: -5px;
  }

  .dialog-title {
    width: 100%;
    height: auto;
  }
  .div-close {
    width: 16px;
    height: 16px;
    .btn-x {
      width: 100%;
      height: 100%;
    }
  }
}

.dialog__body {
  position: absolute;
  top: 21px;
  padding: 8px;
  width: calc(100% - 16px);
  height: calc(100% - 66px);

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
    }

    .t-tab-text {
      margin: 4px 8px;
    }
  }

  .dialog__content{
    width: 100%;
    height: calc(100% - 28px);
    background-color: wheat;
  }
}

.dialog__footer {
  height: 40px;
  width: 100%;
  position: absolute;
  bottom: 0;
  background-color: floralwhite;
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
  }
}
</style>