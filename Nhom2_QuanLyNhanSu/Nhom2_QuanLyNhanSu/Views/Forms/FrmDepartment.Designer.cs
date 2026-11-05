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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartment));
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
            errorProvider1 = new ErrorProvider(components);
            pnlSearch = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).BeginInit();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(5, 21);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(88, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(122, 18);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hoặc tên phòng ban...";
            txtSearch.Size = new Size(427, 31);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 192, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Image = Properties.Resources.search1;
            btnSearch.Location = new Point(601, 11);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 45);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvDepartment
            // 
            dgvDepartment.AllowUserToAddRows = false;
            dgvDepartment.AllowUserToDeleteRows = false;
            dgvDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDepartment.BackgroundColor = SystemColors.Window;
            dgvDepartment.ColumnHeadersHeight = 34;
            dgvDepartment.Location = new Point(13, 98);
            dgvDepartment.Margin = new Padding(4, 5, 4, 5);
            dgvDepartment.MultiSelect = false;
            dgvDepartment.Name = "dgvDepartment";
            dgvDepartment.ReadOnly = true;
            dgvDepartment.RowHeadersVisible = false;
            dgvDepartment.RowHeadersWidth = 62;
            dgvDepartment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartment.Size = new Size(1114, 460);
            dgvDepartment.TabIndex = 3;
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.BackColor = Color.White;
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
            grpInfo.Location = new Point(13, 587);
            grpInfo.Margin = new Padding(4, 5, 4, 5);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(4, 5, 4, 5);
            grpInfo.Size = new Size(1118, 263);
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
            txtCode.Location = new Point(182, 47);
            txtCode.Margin = new Padding(4, 5, 4, 5);
            txtCode.MaxLength = 20;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(213, 31);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(418, 53);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(135, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Tên phòng ban:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(586, 47);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(433, 31);
            txtName.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(21, 114);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(63, 25);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(157, 114);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.MaxLength = 255;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(862, 31);
            txtDescription.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Image = Properties.Resources.circle_plus1;
            btnAdd.Location = new Point(182, 176);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 50);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(245, 158, 11);
            btnUpdate.BackgroundImageLayout = ImageLayout.None;
            btnUpdate.Image = Properties.Resources.pencil3;
            btnUpdate.Location = new Point(356, 176);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(129, 50);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.Image = Properties.Resources.trash1;
            btnDelete.Location = new Point(531, 176);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.refresh_cw1;
            btnClear.Location = new Point(700, 176);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 50);
            btnClear.TabIndex = 9;
            btnClear.Text = "Làm mới";
            btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Location = new Point(17, 12);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(735, 63);
            pnlSearch.TabIndex = 5;
            // 
            // FrmDepartment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1149, 868);
            Controls.Add(pnlSearch);
            Controls.Add(dgvDepartment);
            Controls.Add(grpInfo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1162, 896);
            Name = "FrmDepartment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng ban";
            Load += FrmDepartment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
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
        private ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private Panel pnlSearch;
    }
}