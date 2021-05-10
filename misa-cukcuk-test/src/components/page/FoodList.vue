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
              <misa-button icon="icon-plus" @click="btnAddMenuOnClick"
                >Thêm</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button icon="icon-replica" @click="btnReplicaMenuOnClick"
                >Nhân bản</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button icon="icon-Edit16" @click="btnEditMenuOnClick"
                >Sửa</misa-button
              >
            </div>
            <div class="toolbar-btn">
              <misa-button icon="icon-delete" @click="btnDeleteMenuOnClick"
                >Xóa</misa-button
              >
            </div>
          </div>
        </div>
        <div class="grid-table">
          <!-- start grid -->
          <div class="t-grid">
            <table
              id="tbl-list-store"
              cellspacing="0"
              cellpadding="0"
              width="100%"
            >
              <thead>
                <tr>
                  <th class="col-15">
                    <div class="thead-text">Mã món</div>
                    <div class="thead-filter">
                      <button class="t-btn condition">*</button>
                      <input
                        type="text"
                        class="t-input filter-text"
                        id="filter-food-code"
                      />
                    </div>
                  </th>
                  <th class="col-21">
                    <div class="thead-text">Tên món</div>
                    <div class="thead-filter">
                      <button class="t-btn condition">*</button>
                      <input
                        type="text"
                        class="t-input filter-text"
                        id="filter-food-name"
                      />
                    </div>
                  </th>
                  <th class="col-4">
                    <div class="thead-text">Nhóm thực đơn</div>
                    <div class="thead-filter">
                      <button class="t-btn condition">*</button>
                      <input
                        type="text"
                        class="t-input filter-text"
                        id="filter-foodcategory"
                      />
                    </div>
                  </th>
                  <th class="col-10">
                    <div class="thead-text">Đơn vị tính</div>
                    <div class="thead-filter">
                      <button class="t-btn condition">*</button>
                      <input
                        type="text"
                        class="t-input filter-text"
                        id="filter-unit"
                      />
                    </div>
                  </th>
                  <th class="col-12" >
                    <div class="thead-text">Giá bán</div>
                    <div class="thead-filter">
                      <select
                        type="text"
                        class="filter-select"
                        id="filter-status"
                      >
                        <!-- <option
                        v-for="option in storeStatus"
                        :key="option.value"
                        :value="option.value"
                      >
                        {{ option.statusName }}
                      </option> -->
                      </select>
                    </div>
                  </th>
                </tr>
              </thead>

              <div class="loading">
                <div class="loader"></div>
                <div class="text">Đang nạp dữ liệu</div>
              </div>

              <div class="not-find">
                <i class="notify">Không tìm thấy kết quả</i>
              </div>

              <!-- <tbody v-if="shops && shops.length" class="tbl-scroll">
              <tr
                class="row-data"
                v-for="shop in shops"
                :key="shop.storeId"
                @click="clickRow(shop.storeId)"
                @dblclick="openEditDialog(shop.storeId)"
                v-bind:class="isSelected(shop.storeId) ? 'selected' : ''"
              >
                <td class="col-15">{{ shop.storeCode }}</td>
                <td class="col-21">{{ shop.storeName }}</td>
                <td class="col-42">{{ shop.address }}</td>
                <td class="col-10">{{ shop.phoneNumber }}</td>
                <td class="col-12">{{ getStatusStoreName(shop.status) }}</td>
              </tr>
            </tbody> -->
            </table>
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
        <the-footer></the-footer>
      </div>
      <!-- end footer -->
    </div>
    <food-detail></food-detail>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import TheFooter from "@/components/layout/TheFooter.vue";
import FoodDetail from "@/components/page/FoodDetail.vue";
import MisaButton from "@/control/misa-button/MisaButton.vue";
export default Vue.extend({
  components: {
    "the-footer": TheFooter,
    "food-detail": FoodDetail,
    MisaButton,
  },
  data() {
    return {
      selectedFruit: "",
      name: "message",
      optionsFruits: [
        {
          value: 1,
          name: "apple",
        },
        {
          value: 2,
          name: "banana",
        },
        {
          value: 3,
          name: "orange",
        },
      ],
      columns: [
        {
          title: "Loại món",
          index: "",
        },
        {
          title: "Mã món",
          index: "",
        },
      ],

      data: [],
    };
  },

  methods: {
    // msTableOnRequest(request: any) {
    //   inventoryItemService.getPaging()
    // }
    btnFeedbackOnClick() {
      console.log("feedback");
    },
    btnAddMenuOnClick() {
      console.log("Thêm món");
    },
    btnReplicaMenuOnClick() {
      console.log("Nhân bản");
    },
    btnEditMenuOnClick() {
      console.log("Sửa món");
    },
    btnDeleteMenuOnClick() {
      console.log("Xóa món");
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
  background-color: cornflowerblue;
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
}

.grid-table {
  width: 100%;
  height: calc(100% - 25px);
  background: #fff;
  border-width: 1px;
  border-style: solid;
  border-color: #ccc;
  box-sizing: border-box;
  background-color: cadetblue;
}

.content__footer {
  height: 27px;
  width: calc(100% - 16px);
  margin-left: 8px;
}
</style>