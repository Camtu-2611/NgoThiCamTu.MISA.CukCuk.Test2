using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces
{
    /// <summary>
    /// Inventory Item Service
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemService: IBaseService<InventoryItem>
    {
        /// <summary>
        /// Lấy danh sách món theo số lượng bản ghi, chỉ số trang, kết hợp lọc dữ liệu theo các cột 
        /// </summary>
        /// <param name="pageSize">Số lượng bản ghi</param>
        /// <param name="pageIndex">Chỉ số trang</param>
        /// <param name="inventoryItemTypeName">Loại món</param>
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
        /// <returns>ServiceResult</returns>
        public ServiceResult GetInventoryItemFilterPaging(
            int pageSize,
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
            int? inActive);

        /// <summary>
        /// Lấy thông tin món theo mã món
        /// </summary>
        /// <param name="inventoryItemCode">mã món</param>
        /// <returns></returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult GetInventoryItemByCode(string inventoryItemCode);
    }
}
