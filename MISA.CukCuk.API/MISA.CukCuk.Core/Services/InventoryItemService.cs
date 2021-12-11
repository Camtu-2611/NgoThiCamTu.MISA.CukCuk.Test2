using MISA.CukCuk.Common;
using MISA.CukCuk.Core.Interfaces;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Lớp lưu trữ các service xử lý nghiệp vụ cho thực thể món
    /// </summary>
    public class InventoryItemService : BaseService<InventoryItem>, IInventoryItemService
    {
        private IInventoryItemRepository _itemRepository;
        public InventoryItemService(IInventoryItemRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        /// <summary>
        /// Service lấy thông tin món theo mã món
        /// </summary>
        /// <param name="inventoryItemCode">Mã món</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult GetInventoryItemByCode(string inventoryItemCode)
        {
            var result = new ServiceResult();

            var data = _itemRepository.GetInventoryItemByCode(inventoryItemCode);

            if (data != null)
            {
                result.Data = data;
                result.UserMsg = Common.Resources.Messages.Success;
                result.DevMsg = Common.Resources.Messages.Success;
                result.ErrorCode = ErrorCode.NONE;
            }
            else
            {
                result.UserMsg = Common.Resources.Messages.Error_NotExist;
                result.DevMsg = Common.Resources.Messages.Error_NotExist;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Service xử lý phân trang và lọc dữ liệu
        /// </summary>
        /// <param name="pageSize">Số bản ghi 1 trang</param>
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
        /// <param name="isShowOnMenu">Hiển thị trên menu</param>
        /// <param name="inActive">Ngừng bán</param>
        /// <returns>ServiceResult với data là kết quả phân trang - PagingResult</returns>
        /// CreatedBy: nctu 13.05.2021
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
            int? inActive)
        {
            var result = new ServiceResult();
            var pagingResult = _itemRepository.GetInventoryItemFilterPaging(pageSize,
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

            if (pagingResult != null)
            {
                result.IsSuccess = true;
                result.Data = pagingResult;
                result.ErrorCode = ErrorCode.NONE;
            }
            else
            {
                result.ErrorCode = ErrorCode.NOCONTENT;
                result.UserMsg = Common.Resources.Messages.NoContent;
                result.DevMsg = Common.Resources.Messages.NoContent;
            }
            return result;
        }


        /// <summary>
        /// Service validate dữ liệu khi thêm hoặc sửa
        /// </summary>
        /// <param name="result">Kết quả khi validate</param>
        /// <param name="item">Thông tin cần validate</param>
        /// <param name="itemId">khóa chính của thực thể </param>
        /// <param name="functionName">tên hàm</param>
        /// CreatedBy: nctu 13.05.2021
        public override void Validate(ServiceResult result, InventoryItem item, Guid? itemId, string functionName)
        {
            var propertyUnique = "Mã món";
            var propertyRequired = new Dictionary<string, string>();
            propertyRequired.Add("Mã món", item.InventoryItemCode);
            propertyRequired.Add("Tên món", item.InventoryItemName);
            propertyRequired.Add("Đơn vị tính", item.Unit);
            propertyRequired.Add("Giá bán", item.SalePrice.ToString());

            foreach (var property in propertyRequired)
            {
                if (string.IsNullOrEmpty(property.Value))
                {
                    result.IsSuccess = false;
                    result.ErrorCode = ErrorCode.BADREQUEST;
                    result.DevMsg = property.Key + " " + Common.Resources.Messages.Error_Required;
                    result.UserMsg = property.Key + " " + Common.Resources.Messages.Error_Required;
                }
            }

            int num1, num2;
            var isNummeric = int.TryParse(item.SalePrice.ToString(), out num1);
            var isNummeric2 = int.TryParse(item.RealPrice.ToString(), out num2);

            if (!isNummeric || !isNummeric2)
            {
                result.IsSuccess = false;
                result.ErrorCode = ErrorCode.BADREQUEST;
                result.DevMsg = Common.Resources.Messages.Non_numeric;
                result.UserMsg = Common.Resources.Messages.Non_numeric;
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate

            bool checkDuplicateCode = _itemRepository.CheckInventoryItemCode(itemId, item.InventoryItemCode, functionName);

            if (checkDuplicateCode)
            {
                result.IsSuccess = false;
                result.ErrorCode = ErrorCode.BADREQUEST;
                result.DevMsg = propertyUnique + " " + Common.Resources.Messages.Error_Duplicate;
                result.UserMsg = propertyUnique + " " + Common.Resources.Messages.Error_Duplicate;
            }

        }

    }
}
