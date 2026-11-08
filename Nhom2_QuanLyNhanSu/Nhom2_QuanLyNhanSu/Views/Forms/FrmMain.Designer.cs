using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Control giao diện
        private Panel pnlSidebar;
        private Panel pnlBrand;
        private Label lblBrand;
        private FlowLayoutPanel flowNav;
        private Button btnHome;
        private Button btnEmployee;
        private Button btnDepartment;
        private Button btnPosition;
        private Button btnContract;
        private Button btnWorkHistory;
        private Button btnAccount;
        private Panel pnlBottom;
        private Button btnLogout;
        private Button btnExit;

        private Panel pnlHeader;
        private Label lblPageTitle;
        private Label lblUserBadge;

        private Panel pnlContent;
        private Panel pnlDashboard;
        private Panel pnlDashboardHeader;
        private Label lblWelcome;
        private Label lblSub;
        private FlowLayoutPanel flowCards;
        private Panel cardEmployee;
        private Panel cardDepartment;
        private Panel cardPosition;
        private Panel cardContract;
        private Panel cardWorkHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new Panel();
            this.pnlBrand = new Panel();
            this.lblBrand = new Label();
            this.flowNav = new FlowLayoutPanel();
            this.pnlBottom = new Panel();
            this.btnLogout = new Button();
            this.btnExit = new Button();
            this.pnlHeader = new Panel();
            this.lblPageTitle = new Label();
            this.lblUserBadge = new Label();
            this.pnlContent = new Panel();
            this.pnlDashboard = new Panel();
            this.pnlDashboardHeader = new Panel();
            this.lblWelcome = new Label();
            this.lblSub = new Label();
            this.flowCards = new FlowLayoutPanel();

            this.SuspendLayout();

            // 1. Cấu hình Form chính
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1280, 760);
            this.MinimumSize = new Size(960, 600); // Giới hạn thu nhỏ tối thiểu để không vỡ khung
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Text = "Hệ thống Quản lý Nhân sự - Nhóm 2";
            this.IsMdiContainer = false;

            // 2. Cấu hình Sidebar bên trái
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Width = 250;
            this.pnlSidebar.BackColor = Color.FromArgb(15, 23, 42);

            this.pnlBrand.Dock = DockStyle.Top;
            this.pnlBrand.Height = 80;
            this.pnlBrand.BackColor = Color.FromArgb(30, 41, 59);

            this.lblBrand.Text = "🏢 HR MANAGER";
            this.lblBrand.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblBrand.ForeColor = Color.White;
            this.lblBrand.Dock = DockStyle.Fill;
            this.lblBrand.TextAlign = ContentAlignment.MiddleCenter;
            this.pnlBrand.Controls.Add(this.lblBrand);

            // Danh sách nút điều hướng trên Sidebar
            this.flowNav.Dock = DockStyle.Fill;
            this.flowNav.FlowDirection = FlowDirection.TopDown;
            this.flowNav.WrapContents = false;
            this.flowNav.Padding = new Padding(0, 12, 0, 0);
            this.flowNav.AutoScroll = true;

            this.btnHome = CreateNavButton("🏠  Trang chủ Dashboard");
            this.btnEmployee = CreateNavButton("👥  Hồ sơ Nhân viên");
            this.btnDepartment = CreateNavButton("🏛️  Quản lý Phòng ban");
            this.btnPosition = CreateNavButton("💼  Danh mục Chức vụ");
            this.btnContract = CreateNavButton("📄  Hợp đồng lao động");
            this.btnWorkHistory = CreateNavButton("🕒  Quá trình công tác");
            this.btnAccount = CreateNavButton("🔐  Quản lý Tài khoản");

            this.flowNav.Controls.AddRange(new Control[]
            {
                this.btnHome,
                this.btnEmployee,
                this.btnDepartment,
                this.btnPosition,
                this.btnContract,
                this.btnWorkHistory,
                this.btnAccount
            });

            // Khu vực nút Đăng xuất & Thoát ở đáy Sidebar
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 105;
            this.pnlBottom.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlBottom.Padding = new Padding(12, 8, 12, 12);

            this.btnLogout.Text = "🔄 Đăng xuất";
            this.btnLogout.Dock = DockStyle.Top;
            this.btnLogout.Height = 40;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.BackColor = Color.FromArgb(30, 41, 59);
            this.btnLogout.ForeColor = Color.FromArgb(226, 232, 240);
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogout.Cursor = Cursors.Hand;

            this.btnExit.Text = "🚪 Thoát hệ thống";
            this.btnExit.Dock = DockStyle.Bottom;
            this.btnExit.Height = 40;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.BackColor = Color.FromArgb(220, 38, 38);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnExit.Cursor = Cursors.Hand;

            this.pnlBottom.Controls.Add(this.btnLogout);
            this.pnlBottom.Controls.Add(this.btnExit);

            this.pnlSidebar.Controls.Add(this.flowNav);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Controls.Add(this.pnlBottom);

            // 3. Cấu hình Header phía trên
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 64;
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Padding = new Padding(24, 0, 24, 0);

            this.lblPageTitle.Text = "TRANG CHỦ HỆ THỐNG";
            this.lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblPageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new Point(24, 18);

            this.lblUserBadge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblUserBadge.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblUserBadge.Dock = DockStyle.Right;
            this.lblUserBadge.AutoSize = false;
            this.lblUserBadge.Width = 240;
            this.lblUserBadge.TextAlign = ContentAlignment.MiddleRight;



            this.pnlHeader.Controls.Add(this.lblUserBadge);
            this.pnlHeader.Controls.Add(this.lblPageTitle);

            // 4. Cấu hình vùng Content và Dashboard tự động co giãn (Responsive)
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = Color.FromArgb(241, 245, 249);

            this.pnlDashboard.Dock = DockStyle.Fill;
            this.pnlDashboard.Padding = new Padding(24);

            this.pnlDashboardHeader.Dock = DockStyle.Top;
            this.pnlDashboardHeader.Height = 85;
            this.pnlDashboardHeader.BackColor = Color.Transparent;

            this.lblWelcome.Text = "Chào mừng bạn quay trở lại hệ thống Quản lý Nhân sự!";
            this.lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new Point(4, 8);

            this.lblSub.Text = "Chọn một danh mục bên thanh điều hướng trái hoặc bấm vào các thẻ chức năng bên dưới để làm việc.";
            this.lblSub.Font = new Font("Segoe UI", 10.5F);
            this.lblSub.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new Point(4, 46);

            this.pnlDashboardHeader.Controls.Add(this.lblWelcome);
            this.pnlDashboardHeader.Controls.Add(this.lblSub);

            // FlowLayoutPanel dùng Dock.Fill để tự động xuống dòng và co giãn theo cửa sổ
            this.flowCards.Dock = DockStyle.Fill;
            this.flowCards.AutoScroll = true;
            this.flowCards.WrapContents = true;
            this.flowCards.FlowDirection = FlowDirection.LeftToRight;
            this.flowCards.Padding = new Padding(4, 8, 4, 8);

            this.cardEmployee = CreateDashboardCard("👥 Hồ sơ Nhân sự", "Quản lý thông tin cá nhân, công tác & ảnh", Color.FromArgb(37, 99, 235));
            this.cardDepartment = CreateDashboardCard("🏛️ Phòng ban", "Thêm, sửa, xóa và tra cứu đơn vị phòng ban", Color.FromArgb(13, 148, 136));
            this.cardPosition = CreateDashboardCard("💼 Chức vụ", "Thiết lập danh mục chức vụ và vai trò", Color.FromArgb(124, 58, 237));
            this.cardContract = CreateDashboardCard("📄 Hợp đồng", "Theo dõi hợp đồng lao động, lương & phụ cấp", Color.FromArgb(217, 119, 6));
            this.cardWorkHistory = CreateDashboardCard("🕒 Quá trình công tác", "Lịch sử luân chuyển, thăng chức, khen thưởng", Color.FromArgb(225, 29, 72));

            this.flowCards.Controls.AddRange(new Control[]
            {
                this.cardEmployee,
                this.cardDepartment,
                this.cardPosition,
                this.cardContract,
                this.cardWorkHistory
            });

            // Sự kiện tự động tính toán kích thước thẻ khi kéo giãn cửa sổ
            this.flowCards.SizeChanged += (s, e) => AdjustResponsiveCards();

            this.pnlDashboard.Controls.Add(this.flowCards);
            this.pnlDashboard.Controls.Add(this.pnlDashboardHeader);
            this.pnlContent.Controls.Add(this.pnlDashboard);

            // 5. Thêm các Panel vào Form chuẩn thứ tự Dock (Fill phải nằm trên cùng của Z-Order)
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);

            this.ResumeLayout(false);
        }

        // Hàm tự động chia cột và co giãn độ rộng các thẻ theo kích thước cửa sổ
        private void AdjustResponsiveCards()
        {
            if (this.flowCards.ClientSize.Width <= 0) return;

            int availableWidth = this.flowCards.ClientSize.Width - this.flowCards.Padding.Horizontal;

            // Tự động xác định số cột (từ 1 đến 4 cột tùy độ rộng màn hình)
            int columns = Math.Max(1, availableWidth / 300);
            if (columns > 4) columns = 4;

            int cardMargin = 20; // Khoảng cách giữa các thẻ
            int cardWidth = (availableWidth - (columns * cardMargin)) / columns;
            cardWidth = Math.Max(240, cardWidth);

            this.flowCards.SuspendLayout();
            foreach (Control ctrl in this.flowCards.Controls)
            {
                if (ctrl is Panel card)
                {
                    card.Width = cardWidth;
                    foreach (Control child in card.Controls)
                    {
                        // Tự động mở rộng khung chữ mô tả bên trong thẻ
                        if (child is Label lbl && lbl.Location.Y > 40)
                        {
                            lbl.Width = cardWidth - 36;
                        }
                    }
                }
            }
            this.flowCards.ResumeLayout();
        }

        private Button CreateNavButton(string text)
        {
            var btn = new Button
            {
                Text = "   " + text,
                Width = 250,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(203, 213, 225),
                BackColor = Color.FromArgb(15, 23, 42),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 0, 2)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            return btn;
        }

        private Panel CreateDashboardCard(string title, string desc, Color accentColor)
        {
            var card = new Panel
            {
                Size = new Size(280, 145),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 20, 20),
                Cursor = Cursors.Hand
            };

            var topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 6,
                BackColor = accentColor
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42), // Chữ đậm sắc nét (không dùng Enabled = false)
                Location = new Point(18, 24),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            var lblDesc = new Label
            {
                Text = desc,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(18, 60),
                Size = new Size(244, 65),
                Cursor = Cursors.Hand
            };

            // Chuyển tiếp sự kiện Click từ các Label con lên Panel thẻ cha
            EventHandler forwardClick = (s, e) => this.InvokeOnClick(card, EventArgs.Empty);
            topBar.Click += forwardClick;
            lblTitle.Click += forwardClick;
            lblDesc.Click += forwardClick;

            // Hiệu ứng di chuột nhẹ trên thẻ
            EventHandler mouseEnter = (s, e) => card.BackColor = Color.FromArgb(248, 250, 252);
            EventHandler mouseLeave = (s, e) => card.BackColor = Color.White;
            card.MouseEnter += mouseEnter;
            card.MouseLeave += mouseLeave;
            lblTitle.MouseEnter += mouseEnter;
            lblDesc.MouseEnter += mouseEnter;

            card.Controls.Add(lblDesc);
            card.Controls.Add(lblTitle);
            card.Controls.Add(topBar);
            return card;
        }
    }
}