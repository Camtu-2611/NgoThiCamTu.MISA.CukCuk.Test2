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
      <div class="filter-address">

      </div>
      <div class="user-toolbar">
        <div class="cb-language">

        </div>
        <div class="notification">

        </div>
        <div class="misa-support">

        </div>
        <div class="user-setting">
          
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
    

    .pull-left{
        width: 100%;
        height: 100%;
        @include flex();
        align-items: center;
    }
    .pull-sidebar{
        width: 36px;
        margin-left: 3px;
    }

    .icon-header-left{
        cursor: pointer;
        margin-left: 12px;
        width: 24px;
        height: 24px;
        margin-top: 3px;
        background-image: url('../../assets/images/icon-left-header.png');
    }
    .text-header-left{
        cursor: pointer;
        width: 100%;
        height: 30px;
        margin-left: 2px;
        background-image: url('../../assets/images/logo-text.png');
        background-repeat: no-repeat;
        background-position: 4px center;
    }
  }

  .header__right {
    width: calc(100% - 230px);
    height: 55px;
    @include flex();
  }
}
</style>