using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trữ thông tin của thực đơn
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public class InventoryItem : BaseEntity
    {
        /// <summary>
        /// Khóa chính 
        /// </summary>
        [Key]
        public Guid InventoryItemId { get; set; }

        /// <summary>
        /// Loại món
        /// </summary>
        public String InventoryItemTypeName { get; set; }

        /// <summary>
        /// Mã món
        /// </summary>
        [Required]
        [Unique]
        [MaxLength(20)]
        public String InventoryItemCode { get; set; }

        /// <summary>
        /// Tên món
        /// </summary>
        [Required]
        public String InventoryItemName { get; set; }

        /// <summary>
        /// Nhóm thực đơn
        /// </summary>
        public String InventoryItemCategoryName { get; set; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        [Required]
        public String Unit { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        [Required]
        public int SalePrice { get; set; }

        /// <summary>
        /// Giá vốn
        /// </summary>
        public int? RealPrice { get; set; }



        /// <summary>
        /// Thay đổi theo thời giá (0 - Không, 1 - Có)
        /// </summary>
        public int? ChangeOutwardPrice { get; set; }

        /// <summary>
        /// Điểu chỉnh giá tự do (0 - Không, 1 - Có)
        /// </summary>
        public int? AllowAdjustPrice { get; set; }

        /// <summary>
        /// Định lượng NVL (0 - Chưa thiết lập, 1 - Đã thiết lập)
        /// </summary>
        public int? MeasureInventoryItemStatus { get; set; }

        /// <summary>
        /// Hiển thị trên thực đơn (0 - Không hiển thị, 1 - Hiển thị)
        /// </summary>
        public int? IsShowOnMenu { get; set; }

        /// <summary>
        /// Ngừng bán (0 - Ngừng bán, 1 - Đang bán)
        /// </summary>
        public int? InActive { get; set; }

        /// <summary>
        /// Link hình ảnh của món
        /// </summary>
        public String ImageUrl { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Chế biến tại
        /// </summary>
        public String Kitchen { get; set; }


    }
}
