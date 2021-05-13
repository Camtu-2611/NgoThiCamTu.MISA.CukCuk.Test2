using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces
{
    /// <summary>
    /// InventoryItem Addition Detail Service
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemAdditionDetailService:IBaseService<InventoryItemAdditionDetail>
    {
        /// <summary>
        /// Xóa sở thích phục vụ theo món
        /// </summary>
        /// <param name="inventoryItemId">ID món</param>
        /// <param name="inventoryItemAdditionId">ID sở thích phục vụ</param>
        /// <returns></returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult DeleteInventoryItemAdditionDetail(Guid inventoryItemId, Guid inventoryItemAdditionId);
    }
}
