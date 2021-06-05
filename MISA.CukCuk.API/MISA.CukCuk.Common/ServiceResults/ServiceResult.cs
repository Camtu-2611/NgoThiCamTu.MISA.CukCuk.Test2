using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common
{
    /// <summary>
    /// Lớp lưu trừ thông tin trả về của 1 request
    /// </summary>
    public class ServiceResult
    {
        // thông báo thao tác thành công hay thất bại, default là true
        public bool IsSuccess { get; set; } = true;

        // nội dung thông báo cho người lập trình
        public string DevMsg { get; set; }

        // nội dung thông báo cho user
        public string UserMsg { get; set; }

        // mã code lỗi của thao tác, mặc định ban đầu là NONE - không có lỗi
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NONE;

        // thông tin tìm hiểu thêm cho dev
        public string MoreInfo { get; set; }

        // mã lỗi để tìm kiếm trên trang web nào đó ví dụ abc.com.vn
        public string TraceId { get; set; }

        // dữ liệu của kết quả trả về
        public object Data { get; set; }

        /// <summary>
        /// Xử lý lỗi ngoại lệ
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ex"></param>
        public void OnException(ServiceResult result, Exception ex)
        {
            result.UserMsg = Resources.Messages.Exception_User;
            result.DevMsg = Resources.Messages.Exception_User;
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.EXCEPTION;
        }

        /// <summary>
        /// Xử lý lỗi dữ liệu sai
        /// </summary>
        /// <param name="result"></param>
        public void OnBadRequest(ServiceResult result)
        {
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.BADREQUEST;
            result.DevMsg = Resources.Messages.BadRequest;
            result.UserMsg = Resources.Messages.BadRequest;
        }

    }
}
