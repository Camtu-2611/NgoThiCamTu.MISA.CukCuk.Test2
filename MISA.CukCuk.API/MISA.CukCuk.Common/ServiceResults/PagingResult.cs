using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lưu trữ thông tin phân trang
    /// </summary>
    /// <typeparam name="T">Đối tượng cần phân trang</typeparam>
    public class PagingResult<T>
    {
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Danh sách dữ liệu trả về của 1 trang
        /// </summary>
        public List<T> Data { get; set; }
    }
}
