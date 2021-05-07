<template>
  <div class="sidebar bg-default">
    <div class="scroll-sidebar">
      <div class="sidebar__list">
        <a class="sidebar__item bg-active">
          <span href="#" class="sidebar__item-icon icon-menufood"></span>
          <span class="sidebar__item-text">Thực đơn</span>
        </a>
        <!-- <a class="sidebar__item">
          <span href="#" class="sidebar__item-icon"></span>
          <span class="sidebar__item-text"></span>
        </a> -->
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.sidebar {
  width: 230px;
  height: 100%;
  font-family: Tahoma,helvetica,arial,verdana,sans-serif;
  .sidebar__list {
    width: 100%;
    overflow-y: auto;
  }
  .sidebar__item {
    height: 40px;
    display: flex;
    align-items: center;
    border-top: 1px solid #038ac1;
    border-bottom: 1px solid #016087;
    &:first-child {
      border-top: 1px solid #016087!important;
    }

    &:hover{
      background-color: #eb7728;
      cursor: pointer;
    }
  }

  .sidebar__item-icon {
    width: 42px;
    height: 24px;
    background-repeat: no-repeat;
    background-position: center;
    margin-left: 3px;
  }

  .icon-menufood {
    background-image: url("../../assets/images/vector-smart-object.png");
  }

  .sidebar__item-text {
    margin-left: 2px;
  }
}
</style>