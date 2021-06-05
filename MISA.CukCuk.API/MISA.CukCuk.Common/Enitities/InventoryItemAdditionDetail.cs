using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trữ thông tin chi tiết sở thích phục vụ
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public class InventoryItemAdditionDetail:BaseEntity
    {
        /// <summary>
        /// Khóa chính của bảng
        /// </summary>
        [Key]
        public Guid InventoryItemAdditionDetailId { get; set; }

        /// <summary>
        /// ID món - Khóa ngoại với InventoryItem
        /// </summary>
        [Required]
        public Guid InventoryItemId { get; set; }

        /// <summary>
        /// ID sở thích phục vụ - Khóa ngoại với InventoryItemAddition
        /// </summary>
        [Required]
        public Guid InventoryItemAdditionId { get; set; }
    }
}
