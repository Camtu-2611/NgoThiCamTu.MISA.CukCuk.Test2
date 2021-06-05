<template>
  <div class="dialog" ref="DetailDialog">
    <div class="dialog__modal" @click="closeDialog"></div>
    <div class="dialog__form">
      <!-- begin header -->
      <div class="dialog__header">
        <div class="food-detail-header">
          <div class="dialog-title">
            {{ dialogTitle }}
          </div>
          <div class="div-close">
            <button
              class="t-btn t-btn-defaul t-btn-close"
              @click="closeDialog"
            ></button>
          </div>
        </div>
      </div>
      <!-- end header -->
      <!-- begin body -->
      <div class="dialog__body">
        <div class="dialog__tab">
          <a
            class="t-tab"
            :class="{ 't-tab-active': isShowFoodInfo }"
            @click="closeFoodAddition()"
          >
            <div class="t-tab-text">Thông tin chung</div>
          </a>
          <a
            class="t-tab"
            :class="{ 't-tab-active': isShowFoodAddition }"
            @click="showFoodAddition()"
          >
            <div class="t-tab-text">Sở thích phục vụ</div>
          </a>
        </div>
        <div class="dialog__content">
          <!-- Loading mask -->
          <div
            v-show="isLoadedDialog"
            class="loadingDialog"
            style="display: none"
          >
            <!-- <div class="loader"></div>
            <div class="text">Đang nạp dữ liệu</div> -->
          </div>
          <div class="dialog-food">
            <!-- <span tabindex="1" @focus="tabIndexLast()"></span> -->
            <FoodInfo
              v-if="isShowFoodInfo"
              :food="food"
              :validate="validate"
              :msgValidate="msgValidate"
              ref="foodInfo"
            />
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
              <misa-button
                icon="icon-help"
                @click="btnHelpOnClick"
                tabindex="13"
                >Giúp</misa-button
              >
            </div>
          </div>
          <div class="d-footer-right">
            <div class="d-btn-footer btn-save">
              <misa-button
                icon="icon-Save16"
                @click="btnSaveOnClick('save')"
                tabindex="14"
                >Cất</misa-button
              >
            </div>
            <div class="d-btn-footer btn-saveadd">
              <misa-button
                icon="icon-SaveAdd16"
                @click="btnSaveOnClick('saveadd')"
                tabindex="15"
                >Cất và Thêm</misa-button
              >
            </div>
            <div class="d-btn-footer btn-cancel">
              <misa-button
                icon="icon-Disable16"
                @click="closeDialog"
                tabindex="16"
                ref="cancelBtn"
                >Hủy bỏ</misa-button
              >
            </div>
          </div>
        </div>
      </div>
      <!-- end footer -->
      <!-- <span tabindex="17" @focus="tabIndexFirst()"></span> -->
    </div>
  </div>
</template>

<script lang="ts">
import MisaButton from "@/control/misa-button/MisaButton.vue";
import FoodInfo from "@/components/page/FoodInfo.vue";
import FoodAddition from "@/components/page/FoodAddition.vue";
import entity from "../../common/entity";
import Vue from "vue";
import commonFunction from "../../common/commonFunction";
import { mapGetters, mapState } from "vuex";
import inventoryItemService from "@/services/inventoryItemService";

export default Vue.extend({
  components: { MisaButton, FoodInfo, FoodAddition },
  props: {
    msg: String,
    isShowDialog: Boolean,
  },
  data() {
    return {
      dialogTitle: "Thêm món",
      isShowFoodInfo: true,
      isShowFoodAddition: false,
      food: {
        inventoryItemId: "00000000-0000-0000-0000-000000000000",
        inventoryItemCode: "",
        inventoryItemName: "",
        inventoryItemCategoryName: "",
        inventoryItemTypeName: "Món khác",
        unit: "",
        salePrice: 0,
        realPrice: 0,
        description: "",
        kitchen: "",
        imgUrl: "",
        isShowOnMenu: 0,
        // createdBy: "nctu",
        // createdDate: Date.now(),
        // modifiedBy: "nctu",
        // modifiedDate: Date.now(),
      },
      validate: {
        foodCode: true,
        foodName: true,
        unit: true,
        salePrice: true,
      },
      msgValidate: {
        msgWarningEmpty: "",
        msgFoodCode: "",
      },
    };
  },
  computed: {
    ...mapGetters({
      foodById: "getFoodById",
    }),
    ...mapState({
      isLoadedDialog: "loadDialog",
    }),
  },
  methods: {
    // focusFirstElement(){
    //   this.$refs.foodName.focus()
    // },
    /**
     * Xử lý việc đóng form chi tiết
     * CreatedBy: nctu 13.05.2021
     */
    closeDialog() {
      // console.log("Đóng Dialog");
      this.$emit("closeDialog");
      this.resetDialog();
    },
    /**
     * Xử lý sự kiện hiện màn hình sở thích phục vụ
     * CreatedBy: nctu 13.05.2021
     */
    showFoodAddition() {
      // console.log("mở sở thích phục vụ");
      this.isShowFoodAddition = true;
      this.isShowFoodInfo = false;
    },
    /**
     * Xử lý sự kiện ẩn màn hình sở thích phục vụ
     * CreatedBy: nctu 13.05.2021
     */
    closeFoodAddition() {
      // console.log("đóng sở thích phục vụ");
      this.isShowFoodAddition = false;
      this.isShowFoodInfo = true;
    },

    /**
     * Thiết lập lại trạng thái ban đầu khi đóng Dialog
     * CreatedBy: nctu 13.05.2021
     * ModifiedBy: nctu 14.05.2021
     */
    resetDialog() {
      this.dialogTitle = "Thêm món";
      this.isShowFoodInfo = true;
      this.isShowFoodAddition = false;
      this.food.inventoryItemId = "00000000-0000-0000-0000-000000000000";
      this.food.inventoryItemCode = "";
      this.food.inventoryItemName = "";
      this.food.inventoryItemCategoryName = "";
      this.food.inventoryItemTypeName = "";
      this.food.unit = "";
      this.food.salePrice = 0;
      this.food.realPrice = 0;
      this.food.description = "";
      this.food.kitchen = "";
      this.food.imgUrl = "";
      this.food.isShowOnMenu = 0;
      this.validate.foodName = true;
      this.validate.foodCode = true;
      this.validate.unit = true;
      this.validate.salePrice = true;
    },

    btnHelpOnClick() {
      console.log("Giúp");
    },

    /**
     * Sự kiện khi click vào nút Cất hoặc Cất và thêm.
     * CreatedBy: nctu 15.05.2021
     */
    btnSaveOnClick(text: string) {
      // console.log("Cất");
      var validEmpty = this.checkValidEmpty();
      var validDuplicate = this.checkDuplicate(this.food.inventoryItemCode);
      console.log(validEmpty, validDuplicate);
      switch (this.msg) {
        case "post":
        case "replica": {
          if (validEmpty && validDuplicate) {
            // this.$store.commit("loadingDialog");
            inventoryItemService
              .post(this.food)
              .then((response) => {
                // this.$store.commit("loadedDialog");
                // console.log("post");
                // console.log(response);
                if (text == "save") {
                  this.closeDialog();
                } else if (text == "saveadd") {
                  this.resetDialog();
                }
                this.$emit("reloadData");
              })
              .catch((error) => {
                console.log(error);
              });
          } else {
            console.log("Có lỗi xảy ra");
          }
          break;
        }
        case "put": {
          if (validEmpty && validDuplicate) {
            // this.$store.commit("loadingDialog");
            inventoryItemService
              .put(this.food.inventoryItemId, this.food)
              .then((response) => {
                return response;
              })
              .then((response) => {
                // console.log(response);
                if (text == "save") {
                // this.$store.commit("loadedDialog");
                  this.closeDialog();
                } else if (text == "saveadd") {
                // this.$store.commit("loadedDialog");
                  this.resetDialog();
                }
                this.$emit("reloadData");
              })
              .catch((error) => {
                console.log(error);
              });
          } else {
            console.log("Có lỗi xảy ra");
          }
          break;
        }
      }
    },

    /**
     * Kiểm tra dữ liệu trống trước khi lưu
     * CreatedBy: nctu 17.05.2021
     */
    checkValidEmpty() {
      var valid = true;
      if (!this.food.inventoryItemName) {
        this.validate.foodName = false;
        valid = false;
      } else {
        this.validate.foodName = true;
        valid = true;
      }
      if (!this.food.inventoryItemCode) {
        this.validate.foodCode = false;
        this.msgValidate.msgFoodCode = "Trường này không được để trống";
        valid = false;
      } else {
        this.validate.foodCode = true;
        valid = true;
      }
      if (!this.food.unit) {
        this.validate.unit = false;
        valid = false;
      } else {
        this.validate.unit = true;
        valid = true;
      }
      if (!this.food.salePrice) {
        this.validate.salePrice = false;
        valid = false;
      } else {
        this.validate.salePrice = true;
        valid = true;
      }
      // console.log(valid);
      return valid;
    },

    /**
     * Kiểm tra mã món đã tồn tại hay chưa
     * CreatedBy: nctu 17.05.2021
     */
    checkDuplicate(itemCode: string) {
      let valid = true;
      if (this.food.inventoryItemCode) {
        inventoryItemService
          .getByCode(itemCode)
          .then((response) => {
            if (response.data.errorCode == 0) {
              if (this.msg == "post" || this.msg == "replica") {
                this.validate.foodCode = false;
                this.msgValidate.msgFoodCode = "Mã món đã tồn tại";
                valid = false;
              } else if (this.msg == "put") {
                if (
                  response.data.data.inventoryItemId !=
                  this.food.inventoryItemId
                ) {
                  this.validate.foodCode = false;
                  this.msgValidate.msgFoodCode = "Mã món đã tồn tại";
                  valid = false;
                }
              }
              // console.log(valid);
            } else {
              this.validate.foodCode = true;
              valid = true;
            }
          })
          .catch((error) => {
            console.log(error);
          });
      }
      return valid;
    },

    /**
     * Kiểm tra price xem có phải là số không
     * CreatedBy: nctu 17.05.2021
     */
    checkNumericMoney(value: number){
      let regex = /^[0-9]*$/;
      if (!regex.test(value.toString())){
        return false;
      }
      return true;
    }
  },
  watch: {
    /**
     * Theo dõi việc mở form với từng mục đích: Thêm, sửa, nhân bản
     * CreatedBy: nctu 14.05.2021
     */
    isShowDialog() {
      if (this.msg == "post") {
        this.dialogTitle = "Thêm món";
        this.resetDialog();
      } else {
        var foodselected = this.$store.getters.getFoodById;
        // this.food = foodselected;
        this.food.inventoryItemCode = foodselected.inventoryItemCode;
        this.food.inventoryItemName = foodselected.inventoryItemName;
        this.food.inventoryItemCategoryName =
          foodselected.inventoryItemCategoryName;
        this.food.inventoryItemTypeName = foodselected.inventoryItemTypeName;
        this.food.unit = foodselected.unit;
        this.food.salePrice = foodselected.salePrice;
        this.food.realPrice = foodselected.realPrice;
        this.food.description = foodselected.description;
        this.food.kitchen = foodselected.kitchen;
        this.food.imgUrl = foodselected.imgUrl;
        this.food.isShowOnMenu = foodselected.isShowOnMenu;

        if (this.msg == "put") {
          this.dialogTitle = "Sửa món";
          this.food.inventoryItemId = foodselected.inventoryItemId;
        } else if (this.msg == "replica") {
          this.dialogTitle = "Thêm món";
          this.food.inventoryItemId = "00000000-0000-0000-0000-000000000000";
        }
      }
      // this.$nextTick(()=>{
      //   let dialogInfo = this.$refs.foodInfo as any;
      //   dialogInfo.focusFirstElement();
      // })
      // this.$nextTick(() => this.focusFirstElement());
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
  .loadingDialog {
    width: 734px;
    height: 432px;
    position: fixed;
    top: 132px;
    background-image: url("../../assets/images/loading.gif");
    background-repeat: no-repeat;
    background-position: center;
    background-color: rgba(0, 0, 0, 0.3);
    color: #ffffff;
    text-align: center;
    z-index: 100000;
  }
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