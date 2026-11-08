#nullable disable
namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmPosition
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlCard = new Panel();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblAllowance = new Label();
            txtAllowance = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlGrid = new Panel();
            dgvPosition = new DataGridView();
            pnlSearch.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPosition).BeginInit();
            SuspendLayout();
            // 
            // pnlSearch (Khu vực tìm kiếm)
            // 
            pnlSearch.BackColor = Color.FromArgb(248, 250, 252);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1009, 65);
            pnlSearch.TabIndex = 0;
            // 
            // txtSearch: Kéo dài tự động theo kích thước form
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11.5F);
            txtSearch.Location = new Point(20, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo mã hoặc tên chức vụ...";
            txtSearch.Size = new Size(829, 33);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch: Chiều cao đồng bộ với thanh tìm kiếm, bám góc phải
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(859, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 33);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "TÌM KIẾM";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // pnlGrid (Chứa bảng dữ liệu)
            // 
            pnlGrid.Controls.Add(dgvPosition);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 65);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20, 10, 20, 15);
            pnlGrid.Size = new Size(1009, 395);
            pnlGrid.TabIndex = 1;
            // 
            // dgvPosition
            // 
            dgvPosition.BackgroundColor = Color.White;
            dgvPosition.BorderStyle = BorderStyle.FixedSingle;
            dgvPosition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPosition.Dock = DockStyle.Fill;
            dgvPosition.Location = new Point(20, 10);
            dgvPosition.Name = "dgvPosition";
            dgvPosition.RowHeadersWidth = 51;
            dgvPosition.Size = new Size(969, 370);
            dgvPosition.TabIndex = 0;
            // 
            // pnlCard (Panel nhập thông tin phía dưới)
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblCode);
            pnlCard.Controls.Add(txtCode);
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(txtName);
            pnlCard.Controls.Add(lblAllowance);
            pnlCard.Controls.Add(txtAllowance);
            pnlCard.Controls.Add(lblDescription);
            pnlCard.Controls.Add(txtDescription);
            pnlCard.Controls.Add(btnAdd);
            pnlCard.Controls.Add(btnUpdate);
            pnlCard.Controls.Add(btnDelete);
            pnlCard.Controls.Add(btnClear);
            pnlCard.Dock = DockStyle.Bottom;
            pnlCard.Location = new Point(0, 460);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1009, 215);
            pnlCard.TabIndex = 2;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.ForeColor = Color.FromArgb(71, 85, 105);
            lblCode.Location = new Point(20, 18);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(85, 19);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã chức vụ:";
            // 
            // txtCode
            // 
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Location = new Point(20, 42);
            txtCode.MaxLength = 20;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(200, 27);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.FromArgb(71, 85, 105);
            lblName.Location = new Point(240, 18);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 19);
            lblName.TabIndex = 2;
            lblName.Text = "Tên chức vụ:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(240, 42);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 27);
            txtName.TabIndex = 3;
            // 
            // lblAllowance
            // 
            lblAllowance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAllowance.AutoSize = true;
            lblAllowance.ForeColor = Color.FromArgb(71, 85, 105);
            lblAllowance.Location = new Point(680, 18);
            lblAllowance.Name = "lblAllowance";
            lblAllowance.Size = new Size(62, 19);
            lblAllowance.TabIndex = 4;
            lblAllowance.Text = "Phụ cấp:";
            // 
            // txtAllowance
            // 
            txtAllowance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAllowance.BorderStyle = BorderStyle.FixedSingle;
            txtAllowance.Location = new Point(680, 42);
            txtAllowance.MaxLength = 15;
            txtAllowance.Name = "txtAllowance";
            txtAllowance.PlaceholderText = "VD: 3000000";
            txtAllowance.Size = new Size(309, 27);
            txtAllowance.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.ForeColor = Color.FromArgb(71, 85, 105);
            lblDescription.Location = new Point(20, 80);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(49, 19);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(20, 105);
            txtDescription.MaxLength = 255;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(969, 27);
            txtDescription.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 150);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 38);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(245, 158, 11);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(140, 150);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 38);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(260, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 38);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(226, 232, 240);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(51, 65, 85);
            btnClear.Location = new Point(380, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 38);
            btnClear.TabIndex = 11;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // FrmPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1009, 675);
            Controls.Add(pnlGrid);
            Controls.Add(pnlCard);
            Controls.Add(pnlSearch);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPosition";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý chức vụ";
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPosition).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlCard;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblAllowance;
        private TextBox txtAllowance;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel pnlGrid;
        private DataGridView dgvPosition;
    }
}