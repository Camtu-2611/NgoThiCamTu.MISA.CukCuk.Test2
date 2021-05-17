<template>
  <div class="dialog-food-addition">
    <div class="dialog-modal"></div>
    <div class="dialog-add">
      <div class="dialog-header">
        <div class="dialog-title">
          {{ dialogTitle }}
        </div>
        <div class="div-close">
          <button
            class="t-btn t-btn-defaul t-btn-close"
            @click="closeDialogDelete()"
          ></button>
        </div>
      </div>
      <div class="dialog-body">
          <div class="icon-question"></div>
          <div class="msg-popup">
              <span>
               Bạn có chắc chắn muốn xóa món   <i> {{foodselectedCode}} - {{foodselectedName}} </i> không?
              </span>
          </div>
      </div>
      <div class="dialog-footer">
        <div class="dialog-footer-btn">
          <div class="d-footer-left">
            <!-- <div class="d-btn-footer btn-help">
              <misa-button icon="icon-help" @click="btnHelpOnClick"
                >Giúp</misa-button
              >
            </div> -->
          </div>
          <div class="d-footer-right">
            <div class="d-btn-footer btn-save">
              <button
                class="t-btn t-btn-default t-btn-deletepopup"
                @click="btnDeleteFood"
              >
                Có
              </button>
            </div>
            <div class="d-btn-footer btn-cancel">
              <button
                class="t-btn t-btn-default t-btn-deletepopup"
                @click="closeDialogDelete()"
              >
                Không
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import inventoryItemService from "@/services/inventoryItemService";
import Vue from "vue";
export default Vue.extend({
  props: {
    isShowDialogDelete: Boolean,
  },
  data() {
    return {
      dialogTitle: "CUKCUK - Quản lý nhà hàng",
      foodselectedId: "00000000-0000-0000-0000-000000000000",
      foodselectedCode: null,
      foodselectedName: null,
    };
  },
  methods: {
    closeDialogDelete() {
      console.log("Đóng Dialog xóa");
      this.$emit("closeDialogDelete");
    },

    btnDeleteFood() {
      inventoryItemService.delete(this.foodselectedId);
      this.closeDialogDelete();
    },
  },
  watch: {
    isShowDialogDelete() {
      var foodselected = this.$store.getters.getFoodById;
      this.foodselectedId = foodselected.inventoryItemId;
      this.foodselectedCode = foodselected.inventoryItemCode;
      this.foodselectedName = foodselected.inventoryItemName;
    },
  },
});
</script>

<style lang="scss" scoped>
.dialog-food-addition {
  //   display: block;
  //   display: none;
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
  width: 400px;
  height: 125px;
  border: 5px solid #0072bc !important;
  position: absolute;
  top: calc(50% - (125px / 2));
  left: calc(50% - 200px);
  z-index: 1000;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: rgb(136 136 136) -1px 1px 3px;
  box-sizing: border-box;
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
  height: calc(100% - 74px);
  padding: 8px;
  display: flex;
  align-items: center;
  
  .icon-question{
      width: 32px;
      height: 32px;
      background-image: url('../../assets/icons/icon-question.png');
      margin-right: 8px;
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
    .btn-save, .btn-cancel {
      width: 75px;
    }
    .t-btn-deletepopup {
      background-color: #fcfcfc !important;
      background-image: -webkit-linear-gradient(
        top,
        #f2f2f2,
        #e0e0e0
      ) !important;
    }
  }
}
</style>