using MISA.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    /// <summary>
    /// InventoryItem Addition Repos
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IInventoryItemAdditionRepository:IBaseRepository<InventoryItemAddition>
    {
        /// <summary>
        /// Lấy danh sách sở thích phục vụ theo id món
        /// </summary>
        /// <param name="inventoryItemId">ID món</param>
        /// <returns></returns>
        public IEnumerable<InventoryItemAddition> GetInventoryItemAdditionByInventoryItemId(Guid inventoryItemId);
    }
}
