<template>
  <div class="header bg-default">
    <div class="header__left">
      <div class="pull-left">
        <div class="pull-sidebar">
          <div class="icon-header-left"></div>
        </div>
        <div class="text-header-left"></div>
      </div>
    </div>
    <div class="header__right">
      <div class="find-address">
        <div class="list-address">
          <div class="select-btn">
            <span class="t-select-arrow"></span>
          </div>
          <select name="" id="" class="t-select header-select cb-restaurant">
            <option value="0">Chuỗi nhà hàng</option>
            <option value="1">Ánh Dương restaurant</option>
            <option value="2">Nhà hàng Buffet hải sản</option>
            <option value="3">Kho tổng</option>
          </select>
        </div>
        <div class="filter-branch">
          <div class="icon-filter-branch"></div>
        </div>
      </div>
      <div class="user-toolbar">
        <div class="cb-language">
          <div class="list-language">
            <div class="select-btn">
              <span class="t-select-arrow"></span>
            </div>
            <select name="" id="" class="t-select header-select cb-language">
              <option value="0">Chọn ngôn ngữ</option>
              <option value="1" selected>Tiếng Việt (Tiếng Việt)</option>
              <option value="2">English (Tiếng Anh)</option>
              <option value="3">Chinese (Tiếng Trung)</option>
            </select>
          </div>
        </div>
        <div class="notification">
          <div class="notify-btn">
            <button class="t-btn t-btn-default header-btn icon-notify"></button>
          </div>
        </div>
        <div class="misa-support">
          <div class="support-btn">
            <button class="t-btn t-btn-default header-btn btn-support"></button>
          </div>
        </div>
        <div class="user-setting">
          <div class="user-img"></div>
          <div class="user-control">
            <div class="select-btn">
              <span class="t-select-arrow"></span>
            </div>
            <select name="" id="" class="t-select header-select cb-user">
              <option value="0">Cam Tu</option>
              <option value="1">Thay đổi mật khẩu</option>
              <option value="2">Đăng xuất</option>
            </select>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@mixin flex() {
  display: flex;
  display: -webkit-flex;
}

.header {
  width: 100%;
  height: 55px;
  color: #fff;
  @include flex();

  .header__left {
    width: 230px;
    height: 55px;

    .pull-left {
      width: 100%;
      height: 100%;
      @include flex();
      align-items: center;
    }
    .pull-sidebar {
      width: 36px;
      margin-left: 3px;
    }

    .icon-header-left {
      cursor: pointer;
      margin-left: 12px;
      width: 24px;
      height: 24px;
      margin-top: 3px;
      background-image: url("../../assets/images/icon-left-header.png");
    }
    .text-header-left {
      cursor: pointer;
      width: 100%;
      height: 30px;
      margin-left: 2px;
      background-image: url("../../assets/images/logo-text.png");
      background-repeat: no-repeat;
      background-position: 4px center;
    }
  }

  .header__right {
    width: calc(100% - 230px);
    height: 55px;
    @include flex();
    align-items: center;
    margin: 0 8px;

    .t-select-arrow {
      background-image: url("../../assets/images/trigger.png");
      top: 3px;
    }

    .list-address,
    .list-language,
    .user-control {
      position: relative;
      height: 32px;
      min-width: 148px;
      // line-height: 24px;
    }

    .header-select {
      background-color: #005082;
      color: #fff;
      padding-top: 5px 3px;
      line-height: 24px !important;
      border: 1px solid #005082;
      font-size: 12px !important;
    }
    .find-address {
      width: 240px;
      margin-left: 4px;
      display: flex;
      align-items: center;
      overflow: hidden;
    }
    .cb-restaurant {
      width: 178px;
    }
    .cb-language {
      width: 160px;
    }

    .filter-branch {
      width: 28px;
      height: 32px;
      background-color: #005082;
      padding: 3px;
      box-sizing: border-box;
    }

    .icon-filter-branch {
      width: 20px;
      height: 20px;
      margin-top: 1px;
      background-image: url("../../assets/icons/filter_1.png");
      background-repeat: no-repeat;
    }
    .user-toolbar {
      display: flex;
      align-items: center;
      justify-content: flex-end;
      flex: 1;
      margin: 0 4px;
      overflow: hidden;
    }

    .notification,
    .misa-support {
      height: 100%;
    }

    .header-btn {
      border-radius: unset;
    }
    .notify-btn {
      width: 40px;
      height: 40px;
      margin: 0 8px;
    }

    .support-btn {
      width: 65px;
      height: 55px;
      margin-right: 8px;
    }

    .btn-support {
      background-image: url("../../assets/icons/ic_support.svg") !important;
      background-repeat: no-repeat;
      background-size: 65px;
      height: 55px !important;
      width: 65px !important;
      background-color: transparent;
      border: none;

      &:hover {
        background-color: #3386c2;
      }
    }

    .user-setting {
      width: 190px;
      display: flex;
      justify-content: center;
      margin-left: 8px;
      padding-left: 4px;
      box-sizing: border-box;
    }
    .user-control {
      // width: 160px;
    }
    .cb-user {
      height: 28px;
      background-color: #0973b9;
      border-color: #0973b9;
      padding: 0 2px 0 4px;
    }
    .user-img {
      width: 28px;
      height: 28px;
      border-radius: 14px;
      background-image: url("../../assets/images/EmployeeImage.png");
      background-repeat: no-repeat;
      background-color: #fff;
      background-size: 25px;
    }
  }
}
</style>