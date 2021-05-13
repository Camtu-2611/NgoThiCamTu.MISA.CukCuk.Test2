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
    public class InventoryItemService : BaseService<InventoryItem>, IInventoryItemService
    {
        private IInventoryItemRepository _itemRepository;
        public InventoryItemService(IInventoryItemRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

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

        public override void Validate(ServiceResult responseResult, InventoryItem item, Guid? itemId, string functionName)
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
                    responseResult.IsSuccess = false;
                    responseResult.ErrorCode = ErrorCode.BADREQUEST;
                    responseResult.DevMsg = property.Key + " " + Common.Resources.Messages.Error_Required;
                    responseResult.UserMsg = property.Key + " " + Common.Resources.Messages.Error_Required;
                }
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate

            bool checkDuplicateCode = _itemRepository.CheckInventoryItemCode(itemId, item.InventoryItemCode, functionName);

            if (checkDuplicateCode)
            {
                responseResult.IsSuccess = false;
                responseResult.ErrorCode = ErrorCode.BADREQUEST;
                responseResult.DevMsg = propertyUnique + " " + Common.Resources.Messages.Error_Duplicate;
                responseResult.UserMsg = propertyUnique + " " + Common.Resources.Messages.Error_Duplicate;
            }

        }

    }
}
