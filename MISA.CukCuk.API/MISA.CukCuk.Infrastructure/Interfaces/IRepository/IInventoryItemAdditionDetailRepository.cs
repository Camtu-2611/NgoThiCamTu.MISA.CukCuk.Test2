using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    /// <summary>
    /// InventoryItem Addition Detail Repos
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemAdditionDetailRepository:IBaseRepository<InventoryItemAdditionDetail>
    {
        /// <summary>
        /// Xóa sở thích phục vụ theo món
        /// </summary>
        /// <param name="inventoryItemId">ID món</param>
        /// <param name="inventoryItemAdditionId">ID sở thích phục vụ</param>
        /// <returns></returns>
        /// CreatedBy: nctu 13.05.2021
        public int DeleteInventoryItemAdditionDetail(Guid inventoryItemId, Guid inventoryItemAdditionId);
    }
}
