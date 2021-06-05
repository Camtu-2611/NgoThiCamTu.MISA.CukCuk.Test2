using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trữ thông tin sở thích phục vụ
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public class InventoryItemAddition:BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Key]
        public Guid InventoryItemAdditionId { get; set; }

        /// <summary>
        /// Tên sở thích phục vụ
        /// </summary>
        [Required]
        public String Description { get; set; }

        /// <summary>
        /// Giá thu thêm khi có sở thích phục vụ
        /// </summary>
        public int? UnitPrice { get; set; }
    }
}
