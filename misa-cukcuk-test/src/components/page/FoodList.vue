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
                    >
                      <option value="0">Tất cả</option>
                      <option value="1">Món ăn</option>
                      <option value="2">Đồ uống</option>
                      <option value="3">Combo</option>
                      <option value="4">Set đồ ăn</option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-180">
                  <div class="title">Mã món</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Tên món</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-150">
                  <div class="title">Nhóm thực đơn</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-90">
                  <div class="title">Đơn vị tính</div>
                  <div class="filter">
                    <div class="filter-type">*</div>
                    <div class="filter-content">
                      <misa-input></misa-input>
                    </div>
                  </div>
                </div>
                <div class="t-cell w-120">
                  <div class="title">Giá bán</div>
                  <div class="filter">
                    <div class="filter-type">≤</div>
                    <div class="filter-content">
                      <misa-input></misa-input>
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
                    >
                      <option value="0">Có</option>
                      <option value="1">Không</option>
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
                    >
                      <option value="0">Có</option>
                      <option value="1">Không</option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-140">
                  <div class="title">Định lượng NVL</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select name="" id="" class="t-select filter-content">
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
                    <select name="" id="" class="t-select filter-content">
                      <option value="0">Có</option>
                      <option value="1">Không</option>
                    </select>
                  </div>
                </div>
                <div class="t-cell w-110">
                  <div class="title">Ngừng bán</div>
                  <div class="filter">
                    <div class="select-btn">
                      <span class="t-select-arrow"></span>
                    </div>
                    <select name="" id="" class="t-select filter-content">
                      <option value="0">Có</option>
                      <option value="1">Không</option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="t-table-body">
                <!-- Loading mask -->
                <div class="loading" style="display: none">
                  <div class="loader"></div>
                  <div class="text">Đang nạp dữ liệu</div>
                </div>
                <!-- notify when no data -->
                <div class="not-find" style="display: none">
                  <i class="notify">Không tìm thấy kết quả</i>
                </div>

                <table class="t-table">
                  <tbody ref="t-tbody">
                    <tr class="t-row selected">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
                        </div>
                      </td>
                    </tr>
                    <tr class="t-row">
                      <td class="w-160">Món ăn</td>
                      <td class="w-180">CRTC</td>
                      <td class="w-150">Cơm rang thập cẩm</td>
                      <td class="w-150">Cơm</td>
                      <td class="w-90">Đĩa</td>
                      <td class="w-120 txt-num">50000</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-1" />
                        </div>
                      </td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-2" />
                        </div>
                      </td>
                      <td class="w-140">Chưa thiết lập</td>
                      <td class="w-150">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-3" />
                        </div>
                      </td>
                      <td class="w-110">
                        <div class="checkbox-data">
                          <img src="#" alt="" class="cb-4" />
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
import MisaInput from "@/control/misa-input/MisaInput.vue";
export default Vue.extend({
  components: {
    "the-footer": TheFooter,
    "food-detail": FoodDetail,
    MisaButton,
    MisaInput,
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
      // margin-left: 2px;
      height: 24px;
    }
    .checkbox-data {
      width: 100%;
      height: 100%;
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
}
</style>