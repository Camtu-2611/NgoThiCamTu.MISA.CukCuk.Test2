using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trữ thông tin nhóm thực đơn
    /// </summary>
    public class InventoryItemCategory:BaseEntity
    {
        /// <summary>
        /// Khóa chính 
        /// </summary>
        public Guid InventoryItemCategoryId { get; set; }

        /// <summary>
        /// Tên nhóm thực đơn
        /// </summary>
        public String InventoryItemCategoryName { get; set; }
    }
}
