using System;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IEmployeeView
    {
        // 1. --- CÁC THUỘC TÍNH (PROPERTIES) ---
        // Nơi Presenter lấy từ khóa tìm kiếm hoặc trả về thông báo
        string SearchValue { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // 2. --- CÁC SỰ KIỆN (EVENTS) ---
        // Lắng nghe các thao tác của người dùng trên giao diện
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler PrintEvent;

        // 3. --- CÁC PHƯƠNG THỨC (METHODS) ---
        // Đổ dữ liệu danh sách nhân viên từ Database lên DataGridView
        void SetEmployeeListBindingSource(BindingSource employeeList);

        // Hàm hiển thị Form (mặc định của WinForms)
        void Show();
    }
}