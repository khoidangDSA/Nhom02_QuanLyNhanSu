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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlInput = new Panel();
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
            dgvPosition = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPosition).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1009, 56);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(20, 0, 0, 0);
            lblTitle.Size = new Size(1009, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ CHỨC VỤ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 56);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1009, 64);
            pnlSearch.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(29, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo mã hoặc tên chức vụ...";
            txtSearch.Size = new Size(770, 37);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.None;
            btnSearch.Image = Properties.Resources.search2;
            btnSearch.Location = new Point(819, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(160, 41);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.Controls.Add(lblCode);
            pnlInput.Controls.Add(txtCode);
            pnlInput.Controls.Add(lblName);
            pnlInput.Controls.Add(txtName);
            pnlInput.Controls.Add(lblAllowance);
            pnlInput.Controls.Add(txtAllowance);
            pnlInput.Controls.Add(lblDescription);
            pnlInput.Controls.Add(txtDescription);
            pnlInput.Controls.Add(btnAdd);
            pnlInput.Controls.Add(btnUpdate);
            pnlInput.Controls.Add(btnDelete);
            pnlInput.Controls.Add(btnClear);
            pnlInput.Location = new Point(0, 408);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(990, 224);
            pnlInput.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(20, 24);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(44, 28);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(110, 20);
            txtCode.MaxLength = 20;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(220, 34);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(360, 24);
            lblName.Name = "lblName";
            lblName.Size = new Size(45, 28);
            lblName.TabIndex = 2;
            lblName.Text = "Tên:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(411, 24);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(540, 34);
            txtName.TabIndex = 3;
            // 
            // lblAllowance
            // 
            lblAllowance.AutoSize = true;
            lblAllowance.Location = new Point(20, 68);
            lblAllowance.Name = "lblAllowance";
            lblAllowance.Size = new Size(85, 28);
            lblAllowance.TabIndex = 4;
            lblAllowance.Text = "Phụ cấp:";
            // 
            // txtAllowance
            // 
            txtAllowance.Location = new Point(110, 64);
            txtAllowance.MaxLength = 15;
            txtAllowance.Name = "txtAllowance";
            txtAllowance.PlaceholderText = "VD: 3000000";
            txtAllowance.Size = new Size(220, 34);
            txtAllowance.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 112);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(68, 28);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(110, 108);
            txtDescription.MaxLength = 255;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(841, 34);
            txtDescription.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Image = Properties.Resources.circle_plus;
            btnAdd.Location = new Point(381, 163);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 47);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.None;
            btnUpdate.Image = Properties.Resources.pencil;
            btnUpdate.Location = new Point(517, 163);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 47);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Sửa";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Image = Properties.Resources.trash;
            btnDelete.Location = new Point(653, 163);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 47);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.Image = Properties.Resources.refresh_cw1;
            btnClear.Location = new Point(789, 163);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 47);
            btnClear.TabIndex = 11;
            btnClear.Text = "Làm mới";
            btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // dgvPosition
            // 
            dgvPosition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPosition.Location = new Point(24, 126);
            dgvPosition.Name = "dgvPosition";
            dgvPosition.RowHeadersWidth = 62;
            dgvPosition.Size = new Size(966, 276);
            dgvPosition.TabIndex = 4;
            // 
            // FrmPosition
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1009, 675);
            Controls.Add(dgvPosition);
            Controls.Add(pnlInput);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(820, 560);
            Name = "FrmPosition";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý chức vụ";
            pnlHeader.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPosition).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlInput;
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
        private DataGridView dgvPosition;
    }
}