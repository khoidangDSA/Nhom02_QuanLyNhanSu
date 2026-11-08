using System;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IEmployeeDetailView
    {
        // 1. --- CÁC THUỘC TÍNH (PROPERTIES) HỒ SƠ NHÂN VIÊN ---
        int Id { get; set; }                      // Khóa chính phục vụ khi Sửa
        bool IsEdit { get; set; }                 // true: Sửa, false: Thêm mới
        string MaNV { get; set; }
        string HoTen { get; set; }
        int GioiTinh { get; set; }                // 0: Nam, 1: Nữ (khớp kiểu INT CSDL)
        DateTime NgaySinh { get; set; }
        string CCCD { get; set; }                 // Cột IdCard trong CSDL
        string DienThoai { get; set; }
        string Email { get; set; }
        string DiaChi { get; set; }
        int PhongBanId { get; set; }              // Khóa ngoại DepartmentId
        int ChucVuId { get; set; }                // Khóa ngoại PositionId
        DateTime NgayVaoLam { get; set; }         // Cột HireDate (NOT NULL)
        int TrangThai { get; set; }               // 0: Đang làm việc, 1: Đã nghỉ việc, 2: Nghỉ dài hạn
        string AvatarPath { get; set; }

        // Các thuộc tính phản hồi trạng thái chuẩn MVP
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // 2. --- CÁC SỰ KIỆN (EVENTS) ---
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // 3. --- CÁC PHƯƠNG THỨC (METHODS) ---
        // Đổ dữ liệu danh mục vào ComboBox từ Presenter
        void SetPhongBanList(object dataSource, string displayMember, string valueMember);
        void SetChucVuList(object dataSource, string displayMember, string valueMember);

        // Hiển thị form dưới dạng hộp thoại
        DialogResult ShowDialog();
        void Close();
    }
}