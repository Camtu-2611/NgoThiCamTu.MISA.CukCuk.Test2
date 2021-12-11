using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Common;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    /// <summary>
    /// InventoryItem Controller - chứa các đầu API của riêng đối tượng inventory item
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public class InventoryItemController : BaseEntityController<InventoryItem>
    {
        private IInventoryItemService _inventoryService;
        public InventoryItemController(IInventoryItemService inventoryService) : base(inventoryService)
        {
            _inventoryService = inventoryService;
        }

        #region API
        /// <summary>
        /// API phân trang và lọc dữ liệu
        /// </summary>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <param name="pageIndex">Chỉ số trang</param>
        /// <param name="inventoryItemTypeName">Tên Loại món</param>
        /// <param name="inventoryItemCode">Mã món</param>
        /// <param name="inventoryItemName">Tên món</param>
        /// <param name="inventoryItemCategoryName">Nhóm thực đơn</param>
        /// <param name="unit">Đơn vị tính</param>
        /// <param name="salePrice">Giá bán</param>
        /// <param name="changeOutwardPrice">Thay đổi theo thời giá</param>
        /// <param name="allowAdjustPrice">Điều chỉnh giá tự do</param>
        /// <param name="measureInventoryItemStatus">Định lượng NVL</param>
        /// <param name="isShowOnMenu">Hiển thị trên thực đơn</param>
        /// <param name="inActive">Ngừng bán</param>
        /// <returns>Danh sách đã lọc và phân trang</returns>
        /// CreatedBy: nctu 13.05.2021
        [HttpGet("paging")]
        public IActionResult Get(int pageSize,
            int pageIndex,
            string inventoryItemTypeName,
            string inventoryItemCode,
            string inventoryItemName,
            string inventoryItemCategoryName,
            string unit,
            int? salePrice,
            int? changeOutwardPrice,
            int? allowAdjustPrice,
            int? measureInventoryItemStatus,
            int? isShowOnMenu,
            int? inActive)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _inventoryService.GetInventoryItemFilterPaging(pageSize,
                    pageIndex,
                    inventoryItemTypeName,
                    inventoryItemCode,
                    inventoryItemName,
                    inventoryItemCategoryName,
                    unit,
                    salePrice,
                    changeOutwardPrice,
                    allowAdjustPrice,
                    measureInventoryItemStatus,
                    isShowOnMenu,
                    inActive);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }

            return Ok(responseResult);
        }


        /// <summary>
        /// API lấy thông tin một món theo mã món
        /// </summary>
        /// <param name="inventoryItemCode">Mã món</param>
        /// <returns></returns>
        /// CreatedBy: nctu 13.05.2021
        [HttpGet("bycode/{inventoryItemCode}")]
        public IActionResult Get(string inventoryItemCode)
        {
            var result = new ServiceResult();
            try
            {
                result = _inventoryService.GetInventoryItemByCode(inventoryItemCode);
            }
            catch (Exception)
            {
                result.OnBadRequest(result);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
    #endregion

}
