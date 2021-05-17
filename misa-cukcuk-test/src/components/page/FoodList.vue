<template>
  <div class="food-list">
    <div class="content">
      <div class="content__head">
        <div class="content__title">
          <div class="page-title">
            <div class="title-form-main">Thực đơn</div>
          </div>
        </div>
        <div class="div-feedback">
          <div class="feedback-btn">
            <misa-button icon="icon-feedback" @click="btnFeedbackOnClick"
              >Phản hồi</misa-button
            >
          </div>
        </div>
      </div>

      <!-- begin list -->
      <div class="content__body">
        <div class="grid-toolbar">
          <div class="t-toolbar">
            <div class="toolbar-btn">
              <misa-button icon="icon-plus" @click="showDialogFood('post')"
                >Thêm</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button
                icon="icon-replica"
                @click="showDialogFood('replica')"
                >Nhân bản</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button icon="icon-Edit16" @click="showDialogFood('put')"
                >Sửa</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button icon="icon-delete" @click="btnDeleteMenuOnClick()"
                >Xóa</misa-button
              >
            </div>
            <div class="t-toolbar-separator"></div>
            <div class="toolbar-btn btn-reload">
              <misa-button icon="icon-refresh" @click="reloadData()"
                >Nạp</misa-button
              >
            </div>
          </div>
        </div>
        <div class="grid-table">
          <!-- start grid -->
          <div class="t-grid">
            <div class="grid-scroll">
              <div class="t-table-head">
                <div class="t-cell w-160">
                  <div class="title">Loại món</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name="foodcategory"
                      id="foodcategory"
                      class="t-select filter-content"
                      v-model="filters.inventoryItemTypeName"
                    >
                      <option
                        v-for="(typefood, index) in typeFoods"
                        :key="index"
                        :value="typefood.value"
                      >
                        {{ typefood.typeName }}
                      </option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-180">
                  <div class="title">Mã món</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input
                        v-model="filters.invenrotyItemCode"
                      ></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Tên món</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input
                        v-model="filters.invenrotyItemName"
                      ></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Nhóm thực đơn</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input
                        v-model="filters.invenrotyItemCategoryName"
                      ></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-90">
                  <div class="title">Đơn vị tính</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input v-model="filters.unit"></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-120">
                  <div class="title">Giá bán</div>
                  <div class="filter">
                    <div class="filter-type">≤</div>
                    <div class="filter-content">
                      <misa-input
                        v-model="filters.salePrice"
                        class="txt-num"
                      ></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Thay đổi theo thời giá</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name="changetotimeprice"
                      id="changetotimeprice"
                      class="t-select filter-content"
                      v-model="filters.changeOutwardPrice"
                    >
                      <option
                        v-for="(status, index) in statusFoods"
                        :key="index"
                        :value="status.value"
                      >
                        {{ status.statusName }}
                      </option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Điều chỉnh giá tự do</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name="adjust-price"
                      id="adjust-price"
                      class="t-select filter-content"
                      v-model="filters.allowAdjustPrice"
                    >
                      <option
                        v-for="(status, index) in statusFoods"
                        :key="index"
                        :value="status.value"
                      >
                        {{ status.statusName }}
                      </option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-140">
                  <div class="title">Định lượng NVL</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name=""
                      id=""
                      class="t-select filter-content"
                      v-model="filters.measureInventoryItemStatus"
                    >
                      <option value="0">Đã thiết lập</option>
                      <option value="1">Chưa thiết lập</option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Hiển thị trên thực đơn</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name=""
                      id=""
                      class="t-select filter-content"
                      v-model="filters.isShowOnMenu"
                    >
                      <option
                        v-for="(status, index) in statusFoods"
                        :key="index"
                        :value="status.value"
                      >
                        {{ status.statusName }}
                      </option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-110">
                  <div class="title">Ngừng bán</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select
                      name=""
                      id=""
                      class="t-select filter-content"
                      v-model="filters.inActive"
                    >
                      <option value="0">Không</option>
                      <option value="1">Có</option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="t-table-body">
                <!-- Loading mask -->
                <div v-show="!isLoaded" class="loading" style="display: none">
                  <!-- <div class="loader"></div> -->
                  <div class="text">Đang nạp dữ liệu</div>
                </div>
                <!-- notify when no data -->
                <div class="not-find" style="display: none">
                  <i class="notify">Không tìm thấy kết quả</i>
                </div>

                <table class="t-table">
                  <tbody ref="t-tbody">
                    <tr
                      class="t-row"
                      v-for="(food, index) in foods"
                      :key="index"
                      @click="rowOnClick(index, food.inventoryItemId)"
                      @dblclick="showDialogFood('put')"
                      :class="{ selected: rowSelected == index }"
                    >
                      <td class="w-160">{{ food.inventoryItemTypeName }}</td>
                      <td class="w-180">{{ food.inventoryItemCode }}</td>
                      <td class="w-150">{{ food.inventoryItemName }}</td>
                      <td class="w-150">
                        {{ food.inventoryItemCategoryName }}
                      </td>
                      <td class="w-90">{{ food.unit }}</td>
                      <td class="w-120 txt-num">
                        {{ formatPrice(food.salePrice) }}
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <input
                            type="button"
                            id="cb-1"
                            class="checkbox-default checkbox-checked"
                            :class="{
                              'checkbox-checked': food.changeOutwardPrice,
                            }"
                          />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <input
                            type="button"
                            id="cb-2"
                            class="checkbox-default"
                            :class="{
                              'checkbox-checked': food.allowAdjustPrice,
                            }"
                          />
                        </div>
                      </td>
                      <td class="w-140">
                        {{
                          formatMeasureInventoryItemStatus(
                            food.measureInventoryItemStatus
                          )
                        }}
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <input
                            type="button"
                            id="cb-3"
                            class="checkbox-default"
                            :class="{ 'checkbox-checked': food.isShowOnMenu }"
                          />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <input
                            type="button"
                            id="cb-3"
                            class="checkbox-default"
                            :class="{ 'checkbox-checked': food.inActive }"
                          />
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
          <!-- end grid -->
          <div>
            <!-- <misa-table :columns="columns" :data="data" @request="msTableOnRequest($event)"></misa-table> -->

            <!-- <misa-input v-model="name"></misa-input>{{ name }}
            <misa-dropdown
              v-model="selectedFruit"
              :options="optionsFruits"
            ></misa-dropdown
            >{{ selectedFruit }} -->
          </div>
        </div>
      </div>
      <!-- endlist -->

      <!-- begin footer -->
      <div class="content__footer">
        <div class="footer">
          <div class="footer__left">
            <div class="footer__btn">
              <div class="t-btn-footer">
                <misa-button
                  icon="icon-page-first"
                  @click="firstPage"
                  :class="{ disable: disablePrevPage }"
                  ref="firstPage"
                ></misa-button>
              </div>
              <div class="t-btn-footer">
                <misa-button
                  icon="icon-page-prev"
                  @click="prevPage"
                  :class="{ disable: disablePrevPage }"
                  ref="prevPage"
                ></misa-button>
              </div>
              <div class="t-toolbar-separator"></div>
              <div class="x-toolbar-text-default">Trang</div>
              <div class="page-index">
                <misa-input
                  v-model="currentPage"
                  @keydown.13="changePage"
                ></misa-input>
              </div>
              <div class="x-toolbar-text-default">trên {{ getTotalPage() }}</div>
              <div class="t-toolbar-separator"></div>

              <div class="t-btn-footer">
                <misa-button
                  icon="icon-page-next"
                  @click="nextPage"
                  ref="nextPage"
                  :class="{ disable: disableNextPage }"
                ></misa-button>
              </div>
              <div class="t-btn-footer">
                <misa-button
                  icon="icon-page-last"
                  @click="lastPage"
                  :class="{ disable: disableNextPage }"
                  :aria-disabled="disableNextPage"
                  ref="lastPage"
                ></misa-button>
              </div>
              <div class="t-toolbar-separator"></div>

              <div class="t-btn-footer">
                <misa-button
                  icon="icon-loading"
                  @click="reloadData()"
                ></misa-button>
              </div>
              <div class="t-toolbar-separator"></div>
              <div class="t-select-paging">
                <select name="" id="" class="t-select" v-model="recordPerPage">
                  <option value="15">15</option>
                  <option value="25">25</option>
                  <option value="50">50</option>
                  <option value="100">100</option>
                </select>
              </div>
            </div>
          </div>
          <div class="footer__right">
            <div class="footer__right-text">
              <div class="x-toolbar-text-default">
                Hiển thị
                <span class="first-record">{{
                  startPosition + availableFood > 0 ? startPosition + 1 : 0
                }}</span>
                -
                <span class="last-record">{{
                  startPosition + availableFood
                }}</span>
                trên
                <span class="total-record"> {{ totalRecord }} </span>
                kết quả
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- end footer -->
    </div>
    <food-detail
      v-show="isShowDialogFood"
      @closeDialog="closeDialog"
      :msg="msg"
      :isShowDialog="isShowDialogFood"
      @reloadData="reloadData"
      ref="Dialog"
    ></food-detail>
    <DeletePopUp
      v-show="isShowDialogDelete"
      :isShowDialogDelete="isShowDialogDelete"
      @closeDialogDelete="closeDialogDelete"
    ></DeletePopUp>
  </div>
</template>


<script lang="ts">
import Vue from "vue";
import { mapGetters, mapState } from "vuex";
import commonFunction from "@/common/commonFunction";
import constFood from "@/common/constFood";
import entity from "@/common/entity";
import FoodDetail from "@/components/page/FoodDetail.vue";
import DeletePopUp from "@/components/page/DeletePopUp.vue";
import MisaButton from "@/control/misa-button/MisaButton.vue";
import MisaInput from "@/control/misa-input/MisaInput.vue";
import filterFields from "@/common/filterData";
import inventoryItemService from "@/services/inventoryItemService";

declare var filterPaging: filterFields;

export default Vue.extend({
  components: {
    // "the-footer": TheFooter,
    "food-detail": FoodDetail,
    DeletePopUp,
    MisaButton,
    MisaInput,
  },
  data() {
    return {
      msg: "post",
      isShowDialogFood: false,
      isShowDialogDelete: false,
      rowSelected: null,

      typeFoods: constFood.TYPEFOODS,
      statusFoods: constFood.STATUSYESNO,
      filters: entity.filterFields,

      noContent: true,
      index: 1,
      offset: 15,
      disableNextPage: false,
      disablePrevPage: true,
      startPosition: 0,
      recordPerPage: 15,
      availableFood: 15,
      currentPage: 1,
      totalPage: 0,
    };
  },
  created() {
    this.$store.dispatch("getFoods");

      // filterPaging = {
      // pageIndex: this.index,
      // pageSize: this.offset,
      // inventoryItemTypeName: this.filters.inventoryItemTypeName,
      // invenrotyItemCode: this.filters.invenrotyItemCode,
      // invenrotyItemName: this.filters.invenrotyItemName,
      // invenrotyItemCategoryName: this.filters.invenrotyItemCategoryName,
      // unit: this.filters.unit,
      // salePrice: this.filters.salePrice,
      // changeOutwardPrice: this.filters.changeOutwardPrice,
      // allowAdjustPrice: this.filters.allowAdjustPrice,
      // measureInventoryItemStatus: this.filters.measureInventoryItemStatus,
      // isShowOnMenu: this.filters.isShowOnMenu,
      // inActive: this.filters.inActive,
    // };

    // this.$store.dispatch("getFoodPaging", filterPaging);
  },
  computed: {
    ...mapState({
      foods: "foods",
      isLoaded: "loadData",
      totalRecord:"totalRecord",
    }),
    // mapState(["foods"])
  },
  methods: {
    /**
      Hàm lấy lại dữ liệu khi thực hiện xong thêm sửa xóa
     */
    reloadData() {
      this.$store.commit("loading");
      inventoryItemService.get().then((response) => {
        this.$store.commit("loaded");
        this.$store.commit("setFoods", response.data.data);
        this.rowSelected = null;
        console.log("reload");
      }).catch((error)=>{
        console.log(error);
      })
    },

    /**
     * Hàm xử lý sự kiện khi click chọn 1 hàng trên dánh sách
     * CreatedBy: nctu 14.05.2021
     */
    rowOnClick(index: any, foodId: string) {
      this.rowSelected = index;
      this.$store.dispatch("getFoodById", foodId);
    },

    /**
     * Hàm xử lý sự kiện đóng form chi tiết món
     * CreatedBy: nctu 13.05.2021
     */
    closeDialog() {
      this.isShowDialogFood = false;
    },

    closeDialogDelete() {
      this.isShowDialogDelete = false;
      console.log("đóng dialog xóa");
    },

    btnFeedbackOnClick() {
      console.log("feedback");
    },

    /**
     * Hàm xử lý sự kiện hiện form chi tiết món
     * CreatedBy: nctu 13.05.2021
     */
    showDialogFood(text: string) {
      console.log("Mở dialog");
      this.isShowDialogFood = true;
      this.msg = text;
    },

    /**
     * Hàm xử lý sự kiện khi click vào nút Xóa
     * CreatedBy: nctu 12.05.2021
     * ModifiedBy: nctu 14.05.2021
     */
    btnDeleteMenuOnClick() {
      if (this.rowSelected == null) {
        console.log("please select a record");
      } else {
        console.log("Xóa món");
        this.isShowDialogDelete = true;
      }
    },

    /**
     * Hàm định dạng trạng thái định lượng NVL
     * CreatedBy: nctu 14.05.2021
     */
    formatMeasureInventoryItemStatus(status: number) {
      if (status == 0) return "Chưa thiết lập";
      else return "Đã thiết lập";
    },

    /**
     * Hàm định dạng giá tiền
     * CreatedBy: nctu 14.05.2021
     */
    formatPrice(value: number) {
      return commonFunction.formatMoney(value);
    },
    /**
     * Tính tổng số trang
     * CreatedBy: nctu 15.05.2021
     */
    getTotalPage() {
      var recordLastPage =  this.totalRecord % this.recordPerPage;
      console.log(recordLastPage);
      var lastIndex = Math.floor(this.totalRecord / this.recordPerPage);
      if (recordLastPage == 0) {
        return lastIndex;
      } else {
        return lastIndex + 1;
      }
    },

    /**
     * Sự kiện khi click vào trang đầu tiên
     * CreatedBy: nctu 15.05.2021
     */
    firstPage() {
      this.currentPage = 1;
      this.startPosition = 0;
      this.changePage();
    },

    /**
     * Sự kiện khi click vào trang trước
     * CreatedBy: nctu 15.05.2021
     */
    prevPage() {
      this.currentPage--;
      this.changePage();
    },

    /**
     * Sự kiện khi click vào trang tiếp theo
     * CreatedBy: nctu 15.05.2021
     */
    nextPage() {
      this.currentPage++;
      this.changePage();
    },

    /**
     * Sự kiện khi click vào trang cuối cùng
     * CreatedBy: nctu 15.05.2021
     */
    lastPage() {
      this.currentPage = this.getTotalPage();
      this.startPosition = (this.currentPage - 1) * this.recordPerPage;
      this.changePage();
    },

    /**
     * Sự kiện khi click vào các nút thay đổi trang
     * CreatedBy: nctu 15.05.2021
     */
    changePage() {
      // kiểm tra trang hợp lệ
      if (this.currentPage < 1) this.currentPage = 1;
      if (this.currentPage > this.getTotalPage())
        this.currentPage = this.getTotalPage();

      // kiểm tra trang đầu tiên
      if (this.currentPage <= 1) {
        // vô hiệu hóa nút prev và first page
        this.disablePrevPage = true;
      } else {
        this.disablePrevPage = false;
      }

      // kiểm tra trang cuối cùng
      if (this.currentPage >= this.getTotalPage()) {
        // vô hiệu hóa nút prev và first page
        this.disableNextPage = true;
      } else {
        this.disableNextPage = false;
      }

      // thay đổi vị trí bắt đầu
      this.startPosition = (this.currentPage - 1) * this.recordPerPage;
      // inventoryItemService.getpaging().then(()=>{
        // this.$store.commit("setFoodsPaging", this.filters);
      // })
      console.log("changepaging");
    },
  },
});
</script>

<style lang="scss" scoped>
$height-toolbar: 25px;

.food-list {
  width: calc(100% - 230px);
}
.content {
  width: 100%;
  height: 100%;
  color: #000;
  background-color: #fff;
}

.content__head {
  width: 100%;
  height: 50px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 8px;
}

.content__title {
  width: calc(100% - 116px);
  height: 100%;
  position: relative;
  white-space: nowrap;
  overflow: hidden;
  .page-title {
    position: absolute;
    top: 14px;
    left: 8px;
    height: 36px;

    .title-form-main {
      font-size: 22px;
      line-height: 24px;
      padding: 5px 0 1px 0;
    }
  }
}

.div-feedback {
  width: 116px;
  height: 42px;
  margin-right: 8px;
  position: relative;

  .feedback-btn {
    width: 100px;
    height: 28px;
    background: #fff;
    border-color: #ccc;
    position: absolute;
    top: 14px;
    right: 0;
  }
}

.content__body {
  width: calc(100% - 16px);
  height: calc(100% - 93px);
  margin: 0 8px;
}
.grid-toolbar {
  height: auto;
  width: 100%;
  background-color: #ededed;
  padding: 2px;
  box-sizing: border-box;
  border-width: 1px 1px 0px;
  border-style: solid;
  border-color: #c1c1c1;
  overflow: hidden;
  background-image: -webkit-linear-gradient(top, #f9f9f9, #e3e4e6);

  .t-toolbar {
    height: 22px;
    display: flex;
    align-items: center;
  }
  .toolbar-btn {
    display: flex;
    margin: 0 8px 0 0;
  }

  .btn-reload {
    margin-left: 4px;
  }
}

.grid-table {
  width: 100%;
  height: calc(100% - 25px);
  background-color: #fff;
  border-width: 1px;
  border-style: solid;
  border-color: #ccc;
  box-sizing: border-box;
  border-bottom: none;
}

/* Định nghĩa cho các phần bên trong content */
.t-grid {
  width: 100%;
  height: 100%;
  opacity: 0.9;

  .grid-scroll {
    overflow-x: auto;
    overflow-y: hidden !important;
    width: 100%;
    height: 100%;
  }
  .t-table-head {
    width: 100%;
    height: 56px;
    display: flex;
    background-color: #ededed;
  }
  .t-table-head .t-cell {
    display: flex;
    flex-direction: column;
    border-right: 1px solid #c5c5c5;
    border-bottom: 1px solid #cccccc;
    background: #f0f0f0;
    height: 100%;
    box-sizing: border-box;
    white-space: nowrap;
    position: sticky;
    top: 0;
  }
  .t-cell .title {
    padding: 7px 10px;
    white-space: nowrap;
    color: #212121;
    text-align: center;
    height: 29px;
    box-sizing: border-box;

    &:hover {
      background-color: #eef6fb;
      cursor: default;
    }
  }
  .t-cell .filter {
    display: flex;
    align-items: center;
    height: 26px;
    margin: 0 1px;
    position: relative;
  }
  .filter .filter-type {
    box-sizing: border-box;
    width: 24px;
    min-width: 24px;
    height: 24px;
    min-height: 24px;
    background-color: #fcfcfc;
    padding: 4px 3px;
    cursor: pointer;
    border: 1px solid #ccc;
    text-align: center;
  }
  .filter .filter-content {
    border-color: #c1c1c1 #d9d9d9 #d9d9d9;
    outline: none;
    width: 100%;
    height: 24px;
  }

  .t-table-body {
    width: fit-content;
    height: calc(100% - 56px);
    overflow: auto;
    .t-row {
      display: flex;
      height: 24px;
    }
    .checkbox-data {
      width: 100%;
      height: 100%;
      text-align: center;
    }
    .txt-num {
      text-align: right;
    }
  }
}

/* Định dạng cho phần tbody */

/* phần tử được chọn */
.selected {
  background-color: #c1ddf1 !important;
  color: #000;
  cursor: default !important;
}
.content__footer {
  height: 27px;
  width: calc(100% - 16px);
  margin-left: 8px;

  .disable {
    opacity: 0.5;
    cursor: context-menu;
  }
  .disable:hover {
    background-color: transparent;
  }

  .footer {
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    position: relative;
    overflow: hidden;
    border: 1px solid #c1c1c1;
    box-sizing: border-box;
    padding: 2px;
  }

  .x-toolbar-text-default {
    padding: 0 4px;
    color: #333f49;
    margin: 0px 4px 0px 4px;
  }
  .footer__left {
    // overflow: hidden;
    height: 24px;

    .footer__btn {
      display: flex;
      align-items: center;
      justify-content: space-between;
      height: 100%;
      width: 100%;
      white-space: nowrap;

      .t-btn-footer {
        height: 22px;
        width: 24px;
        margin: 0px 3px 0 3px;
      }
    }

    .page-index {
      height: 22px;
    }
  }

  .footer__right {
    position: absolute;
    right: 8px;

    .footer__right-text {
      white-space: nowrap;
    }
  }
}
.t-toolbar-separator {
  height: 14px;
  border-style: solid;
  border-width: 0 0 0 1px;
  border-color: #ccc !important;
  margin: 0px 4px;
}

.loading {
  width: calc(100% - 248px);
  height: calc(100vh - 230px);
  position: fixed;
  top: 195px;
  background-image: url("../../assets/images/loading.gif");
  background-repeat: no-repeat;
  background-position: center;
  background-color: rgba(0, 0, 0, 0.3);
  color: #ffffff;
  text-align: center;
}
.loading .text {
  position: fixed;
  left: calc(50% + 70px);
  top: calc(50% + 100px);
}
</style>