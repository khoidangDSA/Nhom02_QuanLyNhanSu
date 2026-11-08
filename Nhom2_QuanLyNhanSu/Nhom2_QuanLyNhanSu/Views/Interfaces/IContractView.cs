using System;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IContractView
    {
        // 1. --- CÁC THUỘC TÍNH (PROPERTIES) DỮ LIỆU ---
        string SearchValue { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // 2. --- CÁC SỰ KIỆN (EVENTS) NGƯỜI DÙNG THAO TÁC ---
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;

        // Sự kiện đặc thù của chức năng Hợp đồng: In ấn
        event EventHandler PrintEvent;

        // 3. --- CÁC PHƯƠNG THỨC (METHODS) ĐIỀU KHIỂN ---
        // Đổ dữ liệu danh sách hợp đồng lên DataGridView
        void SetContractListBindingSource(BindingSource contractList);

        // Hiển thị Form
        void Show();
    }
}