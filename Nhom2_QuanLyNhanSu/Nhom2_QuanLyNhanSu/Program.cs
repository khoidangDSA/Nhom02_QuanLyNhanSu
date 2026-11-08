using System;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Data; // Namespace chứa DatabaseInitializer
using Nhom2_QuanLyNhanSu.Presenters;
using Nhom2_QuanLyNhanSu.Repositories;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using Nhom2_QuanLyNhanSu.Services;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Forms;

namespace Nhom2_QuanLyNhanSu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. TỰ ĐỘNG TẠO DATABASE & BẢNG (Chạy đầu tiên để đảm bảo bảng đã tồn tại trong SQL Server)
            DatabaseInitializer.Initialize();

            // 2. KHỞI TẠO TÀI KHOẢN MẶC ĐỊNH (Admin / HR)
            var auth = new AuthService(new AccountRepository());
            auth.EnsureDefaultAccounts();

            // 3. HIỂN THỊ MÀN HÌNH ĐĂNG NHẬP (FrmLogin)
            var loginView = new FrmLogin();
            _ = new LoginPresenter(loginView, auth);

            // Nếu người dùng tắt form đăng nhập hoặc đăng nhập thất bại thì dừng chương trình
            if (loginView.ShowDialog() != DialogResult.OK) return;

            // 4. SAU KHI ĐĂNG NHẬP THÀNH CÔNG -> MỞ FORM CHÍNH (FrmMain)
            // Lấy role của tài khoản vừa đăng nhập thành công từ FrmLogin (hoặc LoginPresenter)
            string loggedInRole = loginView.LoggedInRole; 
            var mainView = new FrmMain(loggedInRole);

            // Nếu nhóm của bạn có viết MainPresenter để quản lý sự kiện cho FrmMain, bạn có thể khởi tạo ở đây:
            // _ = new MainPresenter(mainView, ...); 

            Application.Run(mainView);
        }
    }
}