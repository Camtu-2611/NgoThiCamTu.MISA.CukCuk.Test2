using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    /// <summary>
    /// Inventory Item Repos
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemRepository : IBaseRepository<InventoryItem>
    {
        /// <summary>
        /// Lấy danh sách món theo số lượng bản ghi, chỉ số trang, kết hợp lọc dữ liệu theo các cột 
        /// </summary>
        /// <param name="pageSize">Số lượng bản ghi 1 trang</param>
        /// <param name="pageIndex">Chỉ số trang</param>
        /// <returns>Danh sách món theo số lượng bản ghi và chỉ số trang truyền vào</returns>
        /// CreatedBy: nctu 12.05.2021
        public PagingResult<InventoryItem> GetInventoryItemFilterPaging(
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
            int? inActive );

        /// <summary>
        /// Lấy thực đơn theo mã món
        /// </summary>
        /// <param name="inventoryItemCode">mã món</param>
        /// <returns></returns>
        /// CreatedBy: nctu 13.05.2021
        public InventoryItem GetInventoryItemByCode(string inventoryItemCode); 

        /// <summary>
        /// Check trùng mã món khi insert hoặc update
        /// </summary>
        /// <param name="inventoryItemId">ID món truyền vào khi sửa</param>
        /// <param name="inventoryItemCode">Mã món </param>
        /// <param name="functionName"> Tên hàm cần thực thi: Insert - thêm bản ghi, Update - Sửa bản ghi</param>
        /// <returns>true - mã bị trùng, false - mã không bị trùng</returns>
        /// CreatedBy: nctu 12.05.2021
        bool CheckInventoryItemCode(Guid? inventoryItemId, string inventoryItemCode, string functionName);
    }
}
