using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces
{
    /// <summary>
    /// Inventory Item Addition Service
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemAdditionService:IBaseService<InventoryItemAddition>
    {
        /// <summary>
        /// Lấy danh sách sở thích phục vụ theo id món
        /// </summary>
        /// <param name="inventoryItemId">id món</param>
        /// <returns>Danh sách sở thích phục vụ của món có id truyền vào</returns>
        /// CreatedBy: nctu 13.05.2021
        public ServiceResult GetInventoryItemAdditionByInventoryItemId(Guid inventoryItemId);
    }
}
