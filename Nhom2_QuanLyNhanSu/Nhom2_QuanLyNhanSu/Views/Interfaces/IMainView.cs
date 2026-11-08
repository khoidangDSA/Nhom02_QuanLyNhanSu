using System;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IMainView
    {
        // --- CÁC SỰ KIỆN MỞ FORM (NAVIGATION EVENTS) ---
        // Presenter sẽ lắng nghe các sự kiện này để khởi tạo và mở các Form con
        event EventHandler ShowEmployeeView;
        event EventHandler ShowDepartmentView;
        event EventHandler ShowPositionView;
        event EventHandler ShowContractView;
        event EventHandler ShowAccountView;
        event EventHandler ShowWorkHistoryView;

        // --- CÁC SỰ KIỆN HỆ THỐNG ---
        event EventHandler LogoutEvent;

        // --- PHƯƠNG THỨC ---
        // Hàm mặc định của WinForms
        void Show();
    }
}