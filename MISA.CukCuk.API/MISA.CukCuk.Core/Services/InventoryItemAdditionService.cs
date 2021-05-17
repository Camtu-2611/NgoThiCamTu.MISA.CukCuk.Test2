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
    /// Lớp lưu trữ các Service xử lý nghiệp vụ cho thực thể Sở thích phục vụ
    /// CreatedBy: nctu 13.05.2021
    /// </summary>
    public class InventoryItemAdditionService:BaseService<InventoryItemAddition>, IInventoryItemAdditionService
    {
        private IInventoryItemAdditionRepository _itemRepository;
        public InventoryItemAdditionService(IInventoryItemAdditionRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        /// <summary>
        /// Service lấy danh sách sở thích phục vụ theo ID món
        /// </summary>
        /// <param name="inventoryItemId">ID món</param>
        /// <returns>ServiceResult với data là danh sách các sở thích phục vụ</returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult GetInventoryItemAdditionByInventoryItemId(Guid inventoryItemId)
        {
            var result = new ServiceResult();
            var entities = _itemRepository.GetInventoryItemAdditionByInventoryItemId(inventoryItemId);

            if (entities != null)
            {
                result.Data = entities;
                result.ErrorCode = ErrorCode.NONE;
                result.UserMsg = Common.Resources.Messages.Success;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = Common.Resources.Messages.NoContent;
                result.DevMsg = Common.Resources.Messages.NoContent;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }
    }
}
