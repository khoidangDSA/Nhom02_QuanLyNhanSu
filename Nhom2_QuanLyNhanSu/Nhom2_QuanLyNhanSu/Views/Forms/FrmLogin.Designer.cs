#nullable disable
namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            btnThemeToggle = new Label();
            lblIconHeader = new Label();
            lblTitle = new Label();
            lblSub = new Label();
            lblUsername = new Label();
            pnlUserBox = new Panel();
            lblUserIcon = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            pnlPassBox = new Panel();
            lblLockIcon = new Label();
            txtPassword = new TextBox();
            chkShow = new CheckBox();
            lblError = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            pnlCard.SuspendLayout();
            pnlUserBox.SuspendLayout();
            pnlPassBox.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(btnThemeToggle);
            pnlCard.Controls.Add(lblIconHeader);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSub);
            pnlCard.Controls.Add(lblUsername);
            pnlCard.Controls.Add(pnlUserBox);
            pnlCard.Controls.Add(lblPassword);
            pnlCard.Controls.Add(pnlPassBox);
            pnlCard.Controls.Add(chkShow);
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(btnExit);
            pnlCard.Location = new Point(45, 30);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(440, 520);
            pnlCard.TabIndex = 0;
            // 
            // btnThemeToggle
            // 
            btnThemeToggle.Cursor = Cursors.Hand;
            btnThemeToggle.Font = new Font("Segoe UI Emoji", 14F);
            btnThemeToggle.Location = new Point(385, 12);
            btnThemeToggle.Name = "btnThemeToggle";
            btnThemeToggle.Size = new Size(40, 40);
            btnThemeToggle.TabIndex = 6;
            btnThemeToggle.Text = "🌙";
            btnThemeToggle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIconHeader
            // 
            lblIconHeader.Font = new Font("Segoe UI Emoji", 28F);
            lblIconHeader.Location = new Point(0, 20);
            lblIconHeader.Name = "lblIconHeader";
            lblIconHeader.Size = new Size(440, 50);
            lblIconHeader.TabIndex = 7;
            lblIconHeader.Text = "🏢";
            lblIconHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 72);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 38);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "QUẢN LÝ NHÂN SỰ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 9.5F);
            lblSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblSub.Location = new Point(0, 110);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(440, 25);
            lblSub.TabIndex = 9;
            lblSub.Text = "Đăng nhập hệ thống để tiếp tục";
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.Location = new Point(40, 150);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(144, 25);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // pnlUserBox
            // 
            pnlUserBox.BackColor = Color.FromArgb(248, 250, 252);
            pnlUserBox.BorderStyle = BorderStyle.FixedSingle;
            pnlUserBox.Controls.Add(lblUserIcon);
            pnlUserBox.Controls.Add(txtUsername);
            pnlUserBox.Location = new Point(40, 178);
            pnlUserBox.Name = "pnlUserBox";
            pnlUserBox.Size = new Size(360, 40);
            pnlUserBox.TabIndex = 1;
            // 
            // lblUserIcon
            // 
            lblUserIcon.Font = new Font("Segoe UI Emoji", 11F);
            lblUserIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblUserIcon.Location = new Point(5, 5);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(30, 28);
            lblUserIcon.TabIndex = 0;
            lblUserIcon.Text = "👤";
            lblUserIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(248, 250, 252);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 10.5F);
            txtUsername.Location = new Point(40, 8);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";
            txtUsername.Size = new Size(310, 28);
            txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.Location = new Point(40, 230);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(96, 25);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Mật khẩu";
            // 
            // pnlPassBox
            // 
            pnlPassBox.BackColor = Color.FromArgb(248, 250, 252);
            pnlPassBox.BorderStyle = BorderStyle.FixedSingle;
            pnlPassBox.Controls.Add(lblLockIcon);
            pnlPassBox.Controls.Add(txtPassword);
            pnlPassBox.Location = new Point(40, 258);
            pnlPassBox.Name = "pnlPassBox";
            pnlPassBox.Size = new Size(360, 40);
            pnlPassBox.TabIndex = 2;
            // 
            // lblLockIcon
            // 
            lblLockIcon.Font = new Font("Segoe UI Emoji", 11F);
            lblLockIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblLockIcon.Location = new Point(5, 5);
            lblLockIcon.Name = "lblLockIcon";
            lblLockIcon.Size = new Size(30, 28);
            lblLockIcon.TabIndex = 0;
            lblLockIcon.Text = "🔒";
            lblLockIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 250, 252);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(40, 8);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.Size = new Size(310, 28);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkShow
            // 
            chkShow.AutoSize = true;
            chkShow.Font = new Font("Segoe UI", 9F);
            chkShow.ForeColor = Color.FromArgb(100, 116, 139);
            chkShow.Location = new Point(40, 308);
            chkShow.Name = "chkShow";
            chkShow.Size = new Size(153, 29);
            chkShow.TabIndex = 3;
            chkShow.Text = "Hiện mật khẩu";
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(225, 29, 72);
            lblError.Location = new Point(40, 338);
            lblError.Name = "lblError";
            lblError.Size = new Size(360, 25);
            lblError.TabIndex = 12;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(40, 375);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 42);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(241, 245, 249);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(100, 116, 139);
            btnExit.Location = new Point(40, 428);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(360, 38);
            btnExit.TabIndex = 5;
            btnExit.Text = "THOÁT";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 232, 240);
            ClientSize = new Size(530, 580);
            Controls.Add(pnlCard);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlUserBox.ResumeLayout(false);
            pnlUserBox.PerformLayout();
            pnlPassBox.ResumeLayout(false);
            pnlPassBox.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlCard;
        private Label btnThemeToggle;
        private Label lblIconHeader;
        private Label lblTitle;
        private Label lblSub;
        private Label lblUsername;
        private Panel pnlUserBox;
        private Label lblUserIcon;
        private TextBox txtUsername;
        private Label lblPassword;
        private Panel pnlPassBox;
        private Label lblLockIcon;
        private TextBox txtPassword;
        private CheckBox chkShow;
        private Label lblError;
        private Button btnLogin;
        private Button btnExit;
    }
}