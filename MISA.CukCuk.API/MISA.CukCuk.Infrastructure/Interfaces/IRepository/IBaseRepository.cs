using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    /// <summary>
    /// Base Repos
    /// CreatedBy: nctu 12.05.2021
    /// </summary>
    public interface IBaseRepository<T>
    {
        // <summary>
        /// Lấy toàn bộ dữ liệu của bảng trong database
        /// </summary>
        /// <returns>Danh sách các đối tượng</returns>
        /// CreatedBy: nctu 12.05.2021
        IEnumerable<T> GetEntities();

        /// <summary>
        /// Lấy thông tin của thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns>1 thực thể duy nhất có ID tương ứng truyền vào</returns>
        /// CreatedBy: nctu 12.05.2021
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số bản ghi thêm mới được vào DB</returns>
        /// CreatedBy: nctu 12.05.2021
        int Insert(T entity);

        /// <summary>
        /// Sửa thông tin của một đối tượng
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <param name="entityId">ID của thực thể</param>
        /// <returns>Số bản ghi đã được cập nhật nội dụng trong DB</returns>
        /// CreatedBy: nctu 12.05.2021
        int Update(T entity, Guid entityId);

        /// <summary>
        /// Xóa một bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng cần xóa</param>
        /// <returns>Số bản ghi đã xóa trong DB</returns>
        /// CreatedBy: nctu 12.05.2021
        int Delete(Guid entityId);
    }
}
