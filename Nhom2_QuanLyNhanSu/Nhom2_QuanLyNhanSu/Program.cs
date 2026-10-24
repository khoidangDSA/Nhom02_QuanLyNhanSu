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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();

            //Application.Run(new FrmDepartment());
            //    IDepartmentRepository repo = new DepartmentRepository();

            // 2. Khởi tạo Service (chứa logic nghiệp vụ)
            //    IDepartmentService service = new DepartmentService(repo);

            // 3. Khởi tạo Form View
            //   var form = new FrmDepartment();

            // 4. Khởi tạo Presenter kết nối View với Service
            //  var presenter = new DepartmentPresenter(form, service);

            // 5. Chạy ứng dụng
            // Application.Run(form);
            var repo = new PositionRepository();
            var service = new PositionService(repo);
            var view = new FrmPosition();
            var presenter = new PositionPresenter(view, service);

            Application.Run(view);

        }
    }
}