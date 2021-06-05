<template>
  <div class="footer">
    <div class="footer__left">
      <div class="footer__btn">
        <div class="t-btn-footer">
          <misa-button
            icon="icon-page-first"
            @click="firstPage"
            :class="{'disable' : disablePrevPage}"
            ref="firstPage"
          ></misa-button>
        </div>
        <div class="t-btn-footer">
          <misa-button
            icon="icon-page-prev"
            @click="prevPage"
            :class="{'disable' : disablePrevPage}"
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
        <div class="x-toolbar-text-default">trên {{ totalPage }}</div>
        <div class="t-toolbar-separator"></div>

        <div class="t-btn-footer">
          <misa-button
            icon="icon-page-next"
            @click="nextPage"
            ref="nextPage"
            :class="{'disable' : disableNextPage}"
          ></misa-button>
        </div>
        <div class="t-btn-footer">
          <misa-button
            icon="icon-page-last"
            @click="lastPage"
            :class="{'disable' : disableNextPage}"
            :aria-disabled="disableNextPage"
            ref="lastPage"
          ></misa-button>
        </div>
        <div class="t-toolbar-separator"></div>

        <div class="t-btn-footer">
          <misa-button icon="icon-refresh" @click="reload()"></misa-button>
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
          <span class="last-record">{{ startPosition + availableFood }}</span>
          trên
          <span class="total-record"> {{ totalRecord }} </span>
          kết quả
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: {
    totalRecord: Number,
    noContent: Boolean,
  },
  data() {
    return {
      disableNextPage: false,
      disablePrevPage: true,
      startPosition: 0,
      recordPerPage: 15,
      availableFood: 15,
      currentPage: 1,
      totalPage: 0,
    };
  },
  methods: {
    getTotalPage(){
      var recordLastPage = this.totalRecord % this.recordPerPage;
      var lastIndex = (this.totalRecord / this.recordPerPage);
      if(recordLastPage == 0){
        return lastIndex;
      }
      else{
        return lastIndex + 1;
      }
    },
    firstPage() {
      this.currentPage = 1;
      this.startPosition = 0;
      this.changePage();
    },
    prevPage() {
      this.currentPage--;
      this.changePage();
    },
    nextPage() {
      this.currentPage++;
      this.changePage();
    },
    lastPage() {
        this.currentPage = this.getTotalPage();
      
      this.startPosition = (this.currentPage - 1) * this.recordPerPage;
      this.changePage();
    },
    changePage(){
      
      // kiểm tra trang hợp lệ
      if(this.currentPage < 1) this.currentPage = 1;
      if(this.currentPage > this.getTotalPage()) this.currentPage = this.getTotalPage();

      // kiểm tra trang đầu tiên
      if(this.currentPage <=1){
        // vô hiệu hóa nút prev và first page
        this.disablePrevPage = true;
      }
      else{
        this.disablePrevPage = false;
      }

      // kiểm tra trang cuối cùng
      if(this.currentPage >= this.getTotalPage()){
        // vô hiệu hóa nút prev và first page
        this.disableNextPage = true;
      }
      else{
        this.disableNextPage = false;
      }

      // thay đổi vị trí bắt đầu
      this.startPosition = (this.currentPage - 1) * this.recordPerPage;
      this.$emit('loadDataPaging', this.startPosition, this.recordPerPage);
      
    }
  },
});
</script>

<style lang="scss" scoped>
.disable{
  opacity: 0.5;
  cursor: context-menu;
}
.disable:hover{
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

.t-toolbar-separator {
  height: 14px;
  border-style: solid;
  border-width: 0 0 0 1px;
  border-color: #ccc !important;
  margin: 0px 4px;
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
</style>