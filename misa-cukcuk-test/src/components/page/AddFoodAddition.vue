<template>
  <div class="dialog-food-addition">
    <div class="dialog-modal"></div>
    <div class="dialog-add">
      <div class="dialog-header">
        <div class="dialog-title">
          {{ dialogTitle }}
        </div>
        <div class="div-close">
          <button class="t-btn t-btn-defaul t-btn-close"></button>
        </div>
      </div>
      <div class="dialog-body">
        <div class="dialog-row row-text-area">
          <div class="row-label">
            <span class="d-label">Sở thích phục vụ</span>
            <span class="text-red"> (*)</span>
          </div>
          <div class="row-input input-textarea">
            <textarea
              name="description"
              id="d-text-are"
              class="t-text-area border-warning"
              cols="5"
              rows="3"
            ></textarea>
            <span class="invalid-icon-default">
              <span class="tooltiptext tooltipFoodAddition"> {{warningMsg4}} </span>
            </span>
          </div>
        </div>
        <div class="dialog-row">
          <div class="row-label">
            <span class="d-label">Thu thêm</span>
          </div>
          <div class="row-input">
            <div class="row-30">
              <misa-input
                type="text"
                class="input-number"
                :value="0"
              ></misa-input>
            </div>
          </div>
        </div>
        <div class="dialog-row">
          <div class="row-label">
            <span class="d-label">Nhóm sở thích phục vụ</span>
          </div>
          <div class="row-input row-select">
            <div class="select-btn">
              <span class="t-select-arrow-default"></span>
              <div class="btn-add">
                <button class="t-btn t-btn-default icon-add-blue"></button>
              </div>
            </div>
            <select
              name="foodaddition-category"
              id="foodaddition-category"
              class="t-select"
            >
              <option value="1">Bếp</option>
            </select>
          </div>
        </div>
      </div>
      <div class="dialog-footer">
        <div class="dialog-footer-btn">
          <div class="d-footer-left">
            <div class="d-btn-footer btn-help">
              <misa-button icon="icon-help" @click="btnHelpOnClick"
                >Giúp</misa-button
              >
            </div>
          </div>
          <div class="d-footer-right">
            <div class="d-btn-footer btn-save">
              <misa-button icon="icon-Save16" @click="btnSaveInfoOnClick"
                >Cất</misa-button
              >
            </div>
            <div class="d-btn-footer btn-cancel">
              <misa-button icon="icon-Disable16" @click="btnCancelFormOnClick"
                >Hủy bỏ</misa-button
              >
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      dialogTitle: "Thêm Sở thích phục vụ",
      warningMsg4:"Trường này không được để trống"
    };
  },
  methods: {
    btnHelpOnClick() {
      console.log("Giúp");
    },
    btnSaveInfoOnClick() {
      console.log("Cất");
    },
    btnCancelFormOnClick() {
      console.log("xóa");
    },
  },
});
</script>

<style lang="scss" scoped>
.dialog-food-addition {
//   display: block;
  display: none;
}

.dialog-modal {
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  background-color: rgba(10, 10, 10, 0.4) !important;
  z-index: 999;
}

.dialog-add {
  width: 460px;
  height: 200px;
  border: 5px solid #0072bc !important;
  position: absolute;
  top: calc(50% - 100px);
  left: calc(50% - 230px);
  z-index: 1000;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: rgb(136 136 136) -1px 1px 3px;
}

.dialog-header {
  height: auto;
  width: 100%;
  color: #fff;
  border-color: #0072bc !important;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: #0072bc;
  box-sizing: border-box;
  margin-top: -4px;
  padding: 5px 2px 5px 5px;

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

.dialog-body {
  width: calc(100% - 16px);
  height: calc(100% - 78px);
  padding: 8px;

  .dialog-row {
    width: 100%;
    height: 24px;
    margin: 2px 0px 4px 0px !important;
    display: flex;
    position: relative;
  }
  .row-text-area {
    height: 50px;
    margin-bottom: 8px !important;
  }
  .row-label {
    width: 185px;
  }
  .row-input {
    width: calc(100% - 185px);
    height: 100%;
  }

  .input-textarea{
      display: flex;
      align-items: center;
  }

  .input-number {
    text-align: right;
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

.dialog-footer {
  height: 40px;
  width: 100%;
  position: absolute;
  bottom: 0;
  background-color: transparent;
  display: flex;
  align-items: center;

  .dialog-footer-btn {
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
    .btn-cancel {
      width: 91px;
    }
    .btn-help {
      width: 75px;
      margin-left: 0px;
    }
  }
}
</style>