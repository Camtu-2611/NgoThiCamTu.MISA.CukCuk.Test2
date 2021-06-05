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
    /// Lớp lưu trữ các Service xử lý nghiệp vụ chi tiết sở thích phục vụ
    /// CreatedBy: nctu 13.05.2021
    /// </summary>
    public class InventoryItemAdditionDetailService : BaseService<InventoryItemAdditionDetail>, IInventoryItemAdditionDetailService
    {
        private IInventoryItemAdditionDetailRepository _itemRepository;
        public InventoryItemAdditionDetailService(IInventoryItemAdditionDetailRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }
        /// <summary>
        /// Service xóa chi tiết sở thích phục vụ theo id món và id sở thích phục vụ
        /// </summary>
        /// <param name="inventoryItemId">ID món </param>
        /// <param name="inventoryItemAdditionId">ID sở thích phục vụ</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult DeleteInventoryItemAdditionDetail(Guid inventoryItemId, Guid inventoryItemAdditionId)
        {
            var result = new ServiceResult();

            if(string.IsNullOrEmpty(inventoryItemId.ToString()) || string.IsNullOrEmpty(inventoryItemAdditionId.ToString()))
            {
                result.OnBadRequest(result);
            }
            else
            {
                var rowEffect = _itemRepository.DeleteInventoryItemAdditionDetail(inventoryItemId, inventoryItemAdditionId);
                if(rowEffect == 1)
                {
                    result.IsSuccess = true;
                    result.Data = rowEffect;
                    result.DevMsg = Common.Resources.Messages.Success;
                    result.UserMsg = Common.Resources.Messages.Success;
                    result.ErrorCode = ErrorCode.NONE;
                }
                else
                {
                    result.IsSuccess = false;
                    result.DevMsg = Common.Resources.Messages.Error_NotExist;
                    result.UserMsg = Common.Resources.Messages.Error_NotExist;
                    result.ErrorCode = ErrorCode.NOCONTENT;
                }
            }
            return result;
        }

    }
}
