#nullable disable
namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmDepartment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvDepartment = new DataGridView();
            grpInfo = new GroupBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).BeginInit();
            grpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(17, 27);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(88, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(114, 22);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hoặc tên phòng ban...";
            txtSearch.Size = new Size(427, 31);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(557, 18);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 45);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            // 
            // dgvDepartment
            // 
            dgvDepartment.AllowUserToAddRows = false;
            dgvDepartment.AllowUserToDeleteRows = false;
            dgvDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDepartment.BackgroundColor = SystemColors.Window;
            dgvDepartment.ColumnHeadersHeight = 34;
            dgvDepartment.Location = new Point(17, 83);
            dgvDepartment.Margin = new Padding(4, 5, 4, 5);
            dgvDepartment.MultiSelect = false;
            dgvDepartment.Name = "dgvDepartment";
            dgvDepartment.ReadOnly = true;
            dgvDepartment.RowHeadersVisible = false;
            dgvDepartment.RowHeadersWidth = 62;
            dgvDepartment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartment.Size = new Size(1114, 475);
            dgvDepartment.TabIndex = 3;
            dgvDepartment.CellContentClick += dgv_CellContentClick;
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Controls.Add(lblCode);
            grpInfo.Controls.Add(txtCode);
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnClear);
            grpInfo.Location = new Point(17, 583);
            grpInfo.Margin = new Padding(4, 5, 4, 5);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(4, 5, 4, 5);
            grpInfo.Size = new Size(1114, 267);
            grpInfo.TabIndex = 4;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin phòng ban";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(21, 53);
            lblCode.Margin = new Padding(4, 0, 4, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(134, 25);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã phòng ban:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(157, 47);
            txtCode.Margin = new Padding(4, 5, 4, 5);
            txtCode.MaxLength = 20;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(213, 31);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(414, 53);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(135, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Tên phòng ban:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(557, 47);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(527, 31);
            txtName.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(21, 120);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(63, 25);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(157, 113);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.MaxLength = 255;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(927, 31);
            txtDescription.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(157, 187);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 50);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(300, 187);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(129, 50);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(443, 187);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(586, 187);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 50);
            btnClear.TabIndex = 9;
            btnClear.Text = "Làm mới";
            // 
            // FrmDepartment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 868);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvDepartment);
            Controls.Add(grpInfo);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1162, 896);
            Name = "FrmDepartment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng ban";
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvDepartment;
        private GroupBox grpInfo;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}