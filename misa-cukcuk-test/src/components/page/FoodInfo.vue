<template>
  <div class="food-info">
    <div class="dialog-left">
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Tên món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input">
          <misa-input type="text"></misa-input>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Mã món</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input">
          <misa-input type="text"></misa-input>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Nhóm thực đơn</span>
        </div>
        <div class="row-input row-select">
          <div class="select-btn">
            <span class="t-select-arrow-default"></span>
            <div class="btn-add">
              <button class="t-btn t-btn-default icon-add-blue"></button>
            </div>
          </div>
          <select
            name="areacook"
            id="area-cook"
            class="t-select t-select-default"
          >
            <option value="1">Chọn nhóm thực đơn</option>
          </select>
        </div>
      </div>
      <div class="dialog-row row-select">
        <div class="row-label">
          <span class="d-label">Đơn vị tính</span>
          <span class="text-red"> (*)</span>
        </div>
        <div class="row-input">
          <div class="select-btn">
            <span class="t-select-arrow-default"></span>
            <div class="btn-add">
              <button class="t-btn t-btn-default icon-add-blue"></button>
            </div>
          </div>
          <select name="areacook" id="area-cook" class="t-select">
            <option value="1">Chọn đơn vị tính</option>
          </select>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Giá bán</span>
          <span class="text-red"> (*)</span>
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
          <span class="d-label">Giá vốn</span>
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
      <div class="dialog-row row-text-area">
        <div class="row-label">
          <span class="d-label">Mô tả</span>
        </div>
        <div class="row-input input-textarea">
          <textarea
            name="description"
            id="d-text-are"
            class="t-text-area"
            cols="5"
            rows="3"
          ></textarea>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label">Chế biến tại</span>
        </div>
        <div class="row-input row-select">
          <div class="select-btn">
            <span class="t-select-arrow-default"></span>
            <div class="btn-add">
              <button class="t-btn t-btn-default icon-add-blue"></button>
            </div>
          </div>
          <select name="areacook" id="area-cook" class="t-select">
            <option value="1">Bếp</option>
          </select>
        </div>
      </div>
      <div class="dialog-row">
        <div class="row-label">
          <span class="d-label"></span>
        </div>
        <div class="row-input row-checkbox">
          <input
            type="button"
            name="d-checkbox"
            id="d-checkbox"
            class="checkbox-default"
            :class="{'checkbox-checking' : isChecked }"
            @click="cbOnClick()"
          />
          <span class="label-checkbox">Không hiển thị lên thực đơn</span>
        </div>
      </div>
    </div>
    <div class="dialog-right">
      <div class="dialog-image">
        <fieldset>
          <legend>
            <span class="legend-img">Ảnh đại diện</span>
          </legend>
          <div class="row-upfile">
            <div class="food-img">
              <div class="food-icon">
                <misa-button icon="icon-selectIconMenu"
                  ><span class="icon-text">Biểu tượng</span></misa-button
                >
              </div>
              <div class="food-img-default">
                <img
                  src="../../assets/images/ImageHandler.png"
                  alt="Ảnh đại diện món ăn"
                />
              </div>
              <span class="img-note">
                <p>Chọn các ảnh có định dạng</p>
                <p class="text-bold">(.jpg, .jpeg, .png, .gif)</p>
              </span>
            </div>
            <div class="upfile-button">
              <div class="btn-upload-img">
                <div class="btn-upload">
                  <misa-button icon="icon-upload"></misa-button>
                </div>
              </div>
              <div class="btn-remove-img">
                <div class="btn-remove-img">
                  <misa-button icon="icon-remove-img"></misa-button>
                </div>
              </div>
            </div>
          </div>
        </fieldset>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  data(){
    return{
      isChecked: false,
    }
  },
  methods:{
    cbOnClick(){
      this.isChecked = !this.isChecked;
    }
  }
})
</script>

<style lang="scss" scoped>
.food-info {
  width: 100%;
  height: auto;
  display: flex;

//   display: none;
}

.dialog-left {
  width: 70%;
  height: auto;

  .dialog-row {
    display: flex;
    height: 24px;
    width: 100%;
    margin: 2px 0px 4px 0px !important;
  }
  .row-text-area {
    height: 50px;
    margin-bottom: 4px;
  }
  .row-checkbox {
    display: flex;
    margin-top: 8px;
  }

  .row-label {
    width: 125px;
  }
  .row-input {
    flex: 1;
    height: 100%;
  }

  .row-select {
    position: relative;
  }
  .input-number {
    text-align: right;
  }
  .row-30 {
    width: 30%;
    height: 100%;
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
    // background-size: 22px;
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

.dialog-right {
  flex: 1;
  height: fit-content;
  margin-left: 8px;
  //   background-color: darkgoldenrod;

  .dialog-image {
    width: 100%;
  }
  fieldset {
    margin: 0;
    padding: 0;
    border: 1px solid #afafaf;

    legend {
      margin-left: 6px;
    }
  }

  .row-upfile {
    padding: 8px;
    display: flex;
    justify-content: space-between;
  }
  .food-img {
    position: relative;
    width: calc(100% - 27px);
  }
  .food-icon {
    position: absolute;
    width: 110px;
    height: 25px;
    .icon-text {
      color: #026b97;
    }
  }

  .food-img-default {
    width: 100%;
    height: fit-content;
  }

  .img-note {
    text-align: center;
    font-size: 12px;
  }
  .upfile-button {
    width: 27px;
    .btn-upload-img {
      margin-bottom: 4px;
    }
  }
}
</style>