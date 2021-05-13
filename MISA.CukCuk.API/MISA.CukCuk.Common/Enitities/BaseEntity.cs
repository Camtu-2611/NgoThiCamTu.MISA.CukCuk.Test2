using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trữ thông tin chung của các thực thể
    /// CreatedBy: nctu(12/05/2021)
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo thực thể
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo thực thể
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa thực thể
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa đối tượng
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
