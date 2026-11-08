using Nhom2_QuanLyNhanSu.Presenters;
using Nhom2_QuanLyNhanSu.Repositories;
using Nhom2_QuanLyNhanSu.Services;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmMain : Form, IMainView
    {
        private readonly string _currentRole;
        private Button _activeButton;
        private Form _activeChildForm;

        // Sự kiện chuẩn của IMainView
        public event EventHandler ShowEmployeeView;
        public event EventHandler ShowDepartmentView;
        public event EventHandler ShowPositionView;
        public event EventHandler ShowContractView;
        public event EventHandler ShowAccountView;
        public event EventHandler ShowWorkHistoryView;
        public event EventHandler LogoutEvent;

        public FrmMain(string role)
        {
            InitializeComponent();
            _currentRole = role?.Trim().ToLower() ?? "hr";

            this.Load += FrmMain_Load;
            AssociateEvents();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
            SetActiveButton(btnHome, "TRANG CHỦ HỆ THỐNG");
            ShowDashboardHome();
        }

        private void ApplyRolePermissions()
        {

            string role = _currentRole?.Trim().ToLower() ?? "hr";
            bool isAdmin = (role == "admin" || role == "administrator" || role == "quanly");

            lblUserBadge.Text = isAdmin ? "👤 Quản trị viên (Admin)" : "👤 Nhân viên Nhân sự (HR)";
            btnAccount.Visible = isAdmin;
        }

        private void AssociateEvents()
        {
            // Sự kiện trên thanh Sidebar
            btnHome.Click += (s, e) =>
            {
                SetActiveButton(btnHome, "TRANG CHỦ HỆ THỐNG");
                ShowDashboardHome();
            };

            btnEmployee.Click += (s, e) => OpenEmployeeModule();
            btnDepartment.Click += (s, e) => OpenDepartmentModule();
            btnPosition.Click += (s, e) => OpenPositionModule();
            btnContract.Click += (s, e) => OpenContractModule();
            btnWorkHistory.Click += (s, e) => OpenWorkHistoryModule();
            btnAccount.Click += (s, e) => OpenAccountModule();

            // Sự kiện trên các thẻ Dashboard
            cardEmployee.Click += (s, e) => OpenEmployeeModule();
            cardDepartment.Click += (s, e) => OpenDepartmentModule();
            cardPosition.Click += (s, e) => OpenPositionModule();
            cardContract.Click += (s, e) => OpenContractModule();
            cardWorkHistory.Click += (s, e) => OpenWorkHistoryModule();

            // Hệ thống
            btnLogout.Click += (s, e) =>
            {
                LogoutEvent?.Invoke(this, EventArgs.Empty);
                Application.Restart();
            };
            btnExit.Click += (s, e) => Application.Exit();
        }

        // Các hàm điều hướng từng phân hệ
        private void OpenEmployeeModule()
        {
            SetActiveButton(btnEmployee, "QUẢN LÝ HỒ SƠ NHÂN VIÊN");
            ShowEmployeeView?.Invoke(this, EventArgs.Empty);

            var view = new FrmEmployee(_currentRole);

            // 🔥 Sửa lại chỗ này: Bỏ repository ra khỏi EmployeeService()
            _ = new EmployeePresenter(view, new EmployeeService());

            OpenChildForm(view);
        }

        private void OpenDepartmentModule()
        {
            SetActiveButton(btnDepartment, "QUẢN LÝ PHÒNG BAN");
            ShowDepartmentView?.Invoke(this, EventArgs.Empty);
            var view = new FrmDepartment();
            _ = new DepartmentPresenter(view, new DepartmentService(new DepartmentRepository()));
            OpenChildForm(view);
        }

        private void OpenPositionModule()
        {
            SetActiveButton(btnPosition, "QUẢN LÝ CHỨC VỤ");
            ShowPositionView?.Invoke(this, EventArgs.Empty);

            var view = new FrmPosition();
            var repository = new PositionRepository(); 
            var service = new PositionService(repository); 

            _ = new PositionPresenter(view, service); 

            OpenChildForm(view);
        }

        private void OpenContractModule()
        {
            SetActiveButton(btnContract, "QUẢN LÝ HỢP ĐỒNG LAO ĐỘNG");
            ShowContractView?.Invoke(this, EventArgs.Empty);

            // Truyền _currentRole vào constructor FrmContract
            var view = new FrmContract(_currentRole);

            // Khởi tạo Service và Presenter tương ứng của nhóm bạn
            var service = new ContractService(); // Hoặc new ContractService(new ContractRepository())
            _ = new ContractPresenter(view, service);

            OpenChildForm(view);
        }

        private void OpenWorkHistoryModule()
        {
            SetActiveButton(btnWorkHistory, "THEO DÕI QUÁ TRÌNH CÔNG TÁC");
            ShowWorkHistoryView?.Invoke(this, EventArgs.Empty);

            // Truyền _currentRole vào constructor:
            var view = new FrmWorkHistory(_currentRole);

            var service = new WorkHistoryService();
            _ = new WorkHistoryPresenter(view, service);

            OpenChildForm(view);
        }

        private void OpenAccountModule()
        {
            SetActiveButton(btnAccount, "QUẢN LÝ TÀI KHOẢN HỆ THỐNG");
            ShowAccountView?.Invoke(this, EventArgs.Empty);

            // 1. Khởi tạo View
            var view = new FrmAccount(); 

            // 2. Khởi tạo Service và Presenter
            var service = new AccountService();
            _ = new AccountPresenter(view, service);

            // 3. Nhúng Form vào panel chính
            OpenChildForm(view);
        }

        private void SetActiveButton(Button btn, string title)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.FromArgb(15, 23, 42);
                _activeButton.ForeColor = Color.FromArgb(203, 213, 225);
                _activeButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            }

            _activeButton = btn;
            _activeButton.BackColor = Color.FromArgb(13, 148, 136);
            _activeButton.ForeColor = Color.White;
            _activeButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPageTitle.Text = title;
        }

        public void OpenChildForm(Form childForm)
        {
            if (_activeChildForm != null)
                _activeChildForm.Close();

            pnlDashboard.Visible = false;

            _activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void OpenModuleByName(string formClassName)
        {
            if (_activeChildForm != null && _activeChildForm.GetType().Name == formClassName)
                return;

            // 🔥 Sửa lại cách lấy Type bằng Assembly đang chạy hiện tại
            var type = System.Reflection.Assembly.GetExecutingAssembly()
                        .GetType($"Nhom2_QuanLyNhanSu.Views.Forms.{formClassName}");

            if (type != null)
            {
                try
                {
                    if (Activator.CreateInstance(type) is Form frm)
                        OpenChildForm(frm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khởi tạo form {formClassName}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Không tìm thấy Form: {formClassName}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowDashboardHome()
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm = null;
            }
            pnlDashboard.Visible = true;
            pnlDashboard.BringToFront();
        }
    }
}