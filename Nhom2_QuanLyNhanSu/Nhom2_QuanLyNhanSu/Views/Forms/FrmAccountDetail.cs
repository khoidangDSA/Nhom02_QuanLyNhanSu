using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmAccountDetail : Form
    {
        public int AccountId { get; set; }
        public bool IsEdit { get; set; }

        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;
        public int Role => cmbRole.SelectedIndex >= 0 ? cmbRole.SelectedIndex : 1;
        public int? EmployeeId => cmbEmployee.SelectedValue != null && Convert.ToInt32(cmbEmployee.SelectedValue) > 0 ? Convert.ToInt32(cmbEmployee.SelectedValue) : null;
        public bool IsActive => chkIsActive.Checked;

        public event EventHandler SaveEvent;

        public FrmAccountDetail()
        {
            InitializeComponent();

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                if (!IsEdit && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu khởi tạo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                if (cmbRole.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn vai trò!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveEvent?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        public void LoadEmployeeLookup(DataTable dt)
        {
            cmbEmployee.DataSource = dt;
            cmbEmployee.DisplayMember = "DisplayName";
            cmbEmployee.ValueMember = "Id";
        }
    }
}