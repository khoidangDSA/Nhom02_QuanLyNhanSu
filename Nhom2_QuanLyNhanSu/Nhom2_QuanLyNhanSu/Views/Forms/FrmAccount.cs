using System;
using System.Drawing;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmAccount : Form, IAccountView
    {
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler ResetPasswordEvent;

        private string _message;
        private bool _isSuccessful;

        public string SearchValue
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public bool IsSuccessful
        {
            get => _isSuccessful;
            set => _isSuccessful = value;
        }

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        private string _currentRole;

        public FrmAccount() : this("admin")
        {
        }

        public FrmAccount(string role)
        {
            InitializeComponent();
            _currentRole = role;
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Tìm kiếm
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Thao tác
            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            dgvAccount.DoubleClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };

            // Khôi phục mật khẩu
            btnResetPassword.Click += delegate { ResetPasswordEvent?.Invoke(this, EventArgs.Empty); };

            // Xóa tài khoản
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
        }

        public void SetAccountListBindingSource(BindingSource source)
        {
            dgvAccount.DataSource = source;

            // 1. Ẩn các ID kỹ thuật
            if (dgvAccount.Columns.Contains("Id")) dgvAccount.Columns["Id"].Visible = false;
            if (dgvAccount.Columns.Contains("EmployeeId")) dgvAccount.Columns["EmployeeId"].Visible = false;
            if (dgvAccount.Columns.Contains("IsActive")) dgvAccount.Columns["IsActive"].Visible = false;

            // 2. Định dạng tiêu đề hiển thị sang tiếng Việt
            if (dgvAccount.Columns.Contains("Username"))
                dgvAccount.Columns["Username"].HeaderText = "Tên đăng nhập";

            if (dgvAccount.Columns.Contains("Role"))
                dgvAccount.Columns["Role"].HeaderText = "Vai trò (Quyền)";

            if (dgvAccount.Columns.Contains("EmployeeCode"))
                dgvAccount.Columns["EmployeeCode"].HeaderText = "Mã NV";

            if (dgvAccount.Columns.Contains("EmployeeName"))
                dgvAccount.Columns["EmployeeName"].HeaderText = "Nhân viên sở hữu";

            if (dgvAccount.Columns.Contains("StatusStr"))
                dgvAccount.Columns["StatusStr"].HeaderText = "Trạng thái";
        }
    }
}