using System;
using System.Drawing;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmLogin : Form, ILoginView
    {
        private bool _isDarkMode = false;

        public FrmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;

            // Xử lý nút Đăng nhập
            btnLogin.Click += (s, e) =>
            {
                lblError.Text = "";
                LoginRequested?.Invoke(this, EventArgs.Empty);
            };

            // Xử lý nút Thoát có xác nhận
            btnExit.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát ứng dụng không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };

            // Ẩn / Hiện mật khẩu
            chkShow.CheckedChanged += (s, e) =>
                txtPassword.UseSystemPasswordChar = !chkShow.Checked;

            // Chuyển đổi giao diện Sáng / Tối (Dark/Light mode)
            btnThemeToggle.Click += (s, e) =>
            {
                _isDarkMode = !_isDarkMode;
                ApplyTheme();
            };

            // Hover nút Đăng nhập
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(29, 78, 216);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void ApplyTheme()
        {
            if (_isDarkMode)
            {
                // GIAO DIỆN TỐI (DARK MODE)
                btnThemeToggle.Text = "☀️";
                btnThemeToggle.ForeColor = Color.FromArgb(253, 224, 71);
                lblIconHeader.ForeColor = Color.White;

                BackColor = Color.FromArgb(15, 23, 42);
                pnlCard.BackColor = Color.FromArgb(30, 41, 59);

                lblTitle.ForeColor = Color.White;
                lblSub.ForeColor = Color.FromArgb(148, 163, 184);

                lblUsername.ForeColor = Color.FromArgb(226, 232, 240);
                lblPassword.ForeColor = Color.FromArgb(226, 232, 240);

                pnlUserBox.BackColor = Color.FromArgb(51, 65, 85);
                pnlUserBox.BorderStyle = BorderStyle.None;
                lblUserIcon.ForeColor = Color.FromArgb(203, 213, 225);
                txtUsername.BackColor = Color.FromArgb(51, 65, 85);
                txtUsername.ForeColor = Color.White;

                pnlPassBox.BackColor = Color.FromArgb(51, 65, 85);
                pnlPassBox.BorderStyle = BorderStyle.None;
                lblLockIcon.ForeColor = Color.FromArgb(203, 213, 225);
                txtPassword.BackColor = Color.FromArgb(51, 65, 85);
                txtPassword.ForeColor = Color.White;

                chkShow.ForeColor = Color.FromArgb(148, 163, 184);

                btnExit.BackColor = Color.FromArgb(51, 65, 85);
                btnExit.ForeColor = Color.FromArgb(226, 232, 240);
            }
            else
            {
                // GIAO DIỆN SÁNG (LIGHT MODE)
                btnThemeToggle.Text = "🌙";
                btnThemeToggle.ForeColor = Color.FromArgb(100, 116, 139);
                lblIconHeader.ForeColor = Color.FromArgb(30, 41, 59);

                BackColor = Color.FromArgb(226, 232, 240);
                pnlCard.BackColor = Color.White;

                lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
                lblSub.ForeColor = Color.FromArgb(100, 116, 139);

                lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
                lblPassword.ForeColor = Color.FromArgb(51, 65, 85);

                pnlUserBox.BackColor = Color.FromArgb(248, 250, 252);
                pnlUserBox.BorderStyle = BorderStyle.FixedSingle;
                lblUserIcon.ForeColor = Color.FromArgb(148, 163, 184);
                txtUsername.BackColor = Color.FromArgb(248, 250, 252);
                txtUsername.ForeColor = Color.Black;

                pnlPassBox.BackColor = Color.FromArgb(248, 250, 252);
                pnlPassBox.BorderStyle = BorderStyle.FixedSingle;
                lblLockIcon.ForeColor = Color.FromArgb(148, 163, 184);
                txtPassword.BackColor = Color.FromArgb(248, 250, 252);
                txtPassword.ForeColor = Color.Black;

                chkShow.ForeColor = Color.FromArgb(100, 116, 139);

                btnExit.BackColor = Color.FromArgb(241, 245, 249);
                btnExit.ForeColor = Color.FromArgb(100, 116, 139);
            }
        }

        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;
        public string UserRole { get; set; } = "hr";

        // Thuộc tính đồng bộ với Program.cs để truyền quyền sang FrmMain
        public string LoggedInRole
        {
            get => UserRole;
            set => UserRole = value;
        }

        public string UserIcon { get; set; }
        public event EventHandler? LoginRequested;

        public void ShowError(string message)
        {
            lblError.Text = message;
            txtPassword.Clear();
            txtPassword.Focus();
        }

        public void CloseWithSuccess()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}