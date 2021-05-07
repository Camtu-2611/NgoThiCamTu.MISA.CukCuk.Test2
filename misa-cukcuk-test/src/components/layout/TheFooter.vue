<template>
  <div class="footer">
    <div class="footer__left">
      <div class="footer__btn">
        <div class="t-btn-footer">
          <misa-button icon="icon-page-first"></misa-button>
        </div>
        <div class="t-btn-footer">
          <misa-button icon="icon-page-prev"></misa-button>
        </div>
        <div class="t-toolbar-separator"></div>
        <div class="x-toolbar-text-default">Trang</div>
        <div class="page-index">
          <misa-input :value=1></misa-input>
        </div>
        <div class="x-toolbar-text-default">trên 18</div>
        <div class="t-toolbar-separator"></div>

        <div class="t-btn-footer">
          <misa-button icon="icon-page-next"></misa-button>
        </div>
        <div class="t-btn-footer">
          <misa-button icon="icon-page-last"></misa-button>
        </div>
        <div class="t-toolbar-separator"></div>

        <div class="t-btn-footer">
          <misa-button icon="icon-refresh"></misa-button>
        </div>
        <div class="t-toolbar-separator"></div>
      </div>
    </div>
    <div class="footer__right">
      <div class="footer__right-text">
        <div class="x-toolbar-text-default">
          Hiển thị
          <span class="first-record">1</span>
          -
          <span class="last-record">100</span>
          trên
          <span class="total-record"> 1000 </span>
          kết quả
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>

.footer {
  height: 100%;
  width: 100%;
  //   background-color: darkgrey;
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
}

.t-toolbar-separator{
    height: 14px;
    border-style: solid;
    border-width: 0 0 0 1px;
    border-color: #ccc !important;
}
.footer__left {
  overflow: hidden;
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
  }
}
</style>