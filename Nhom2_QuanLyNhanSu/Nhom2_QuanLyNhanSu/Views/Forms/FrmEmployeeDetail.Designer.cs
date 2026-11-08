namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmEmployeeDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cmbGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.cmbPhongBan = new System.Windows.Forms.ComboBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cmbChucVu = new System.Windows.Forms.ComboBox();
            this.lblNgayVaoLam = new System.Windows.Forms.Label();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hồ Sơ Nhân Viên";
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.White;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(30, 80);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(160, 200);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnUploadImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadImage.FlatAppearance.BorderSize = 0;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUploadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnUploadImage.Location = new System.Drawing.Point(30, 295);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(160, 38);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Tải ảnh lên";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblMaNV);
            this.pnlCard.Controls.Add(this.txtMaNV);
            this.pnlCard.Controls.Add(this.lblHoTen);
            this.pnlCard.Controls.Add(this.txtHoTen);
            this.pnlCard.Controls.Add(this.lblNgaySinh);
            this.pnlCard.Controls.Add(this.dtpNgaySinh);
            this.pnlCard.Controls.Add(this.lblGioiTinh);
            this.pnlCard.Controls.Add(this.cmbGioiTinh);
            this.pnlCard.Controls.Add(this.lblCCCD);
            this.pnlCard.Controls.Add(this.txtCCCD);
            this.pnlCard.Controls.Add(this.lblDienThoai);
            this.pnlCard.Controls.Add(this.txtDienThoai);
            this.pnlCard.Controls.Add(this.lblEmail);
            this.pnlCard.Controls.Add(this.txtEmail);
            this.pnlCard.Controls.Add(this.lblDiaChi);
            this.pnlCard.Controls.Add(this.txtDiaChi);
            this.pnlCard.Controls.Add(this.lblPhongBan);
            this.pnlCard.Controls.Add(this.cmbPhongBan);
            this.pnlCard.Controls.Add(this.lblChucVu);
            this.pnlCard.Controls.Add(this.cmbChucVu);
            this.pnlCard.Controls.Add(this.lblTrangThai);
            this.pnlCard.Controls.Add(this.cmbTrangThai);
            this.pnlCard.Controls.Add(this.lblNgayVaoLam);
            this.pnlCard.Controls.Add(this.dtpNgayVaoLam);
            this.pnlCard.Location = new System.Drawing.Point(220, 80);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(590, 420);
            this.pnlCard.TabIndex = 3;
            // 
            // Dòng 1: Mã NV & Họ Tên
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMaNV.Location = new System.Drawing.Point(25, 20);
            this.lblMaNV.Text = "Mã nhân viên (*)";

            this.txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaNV.Location = new System.Drawing.Point(25, 45);
            this.txtMaNV.Size = new System.Drawing.Size(250, 25);

            this.lblHoTen.AutoSize = true;
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblHoTen.Location = new System.Drawing.Point(310, 20);
            this.lblHoTen.Text = "Họ và tên (*)";

            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Location = new System.Drawing.Point(310, 45);
            this.txtHoTen.Size = new System.Drawing.Size(250, 25);
            // 
            // Dòng 2: Ngày sinh & Giới tính
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNgaySinh.Location = new System.Drawing.Point(25, 85);
            this.lblNgaySinh.Text = "Ngày sinh";

            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(25, 110);
            this.dtpNgaySinh.Size = new System.Drawing.Size(250, 25);

            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(310, 85);
            this.lblGioiTinh.Text = "Giới tính";

            this.cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGioiTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGioiTinh.Location = new System.Drawing.Point(310, 110);
            this.cmbGioiTinh.Size = new System.Drawing.Size(250, 25);
            // 
            // Dòng 3: CCCD & Điện thoại
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCCCD.Location = new System.Drawing.Point(25, 150);
            this.lblCCCD.Text = "Số CCCD / CMND";

            this.txtCCCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCCD.Location = new System.Drawing.Point(25, 175);
            this.txtCCCD.Size = new System.Drawing.Size(250, 25);

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDienThoai.Location = new System.Drawing.Point(310, 150);
            this.lblDienThoai.Text = "Số điện thoại";

            this.txtDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDienThoai.Location = new System.Drawing.Point(310, 175);
            this.txtDienThoai.Size = new System.Drawing.Size(250, 25);
            // 
            // Dòng 4: Email & Địa chỉ
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmail.Location = new System.Drawing.Point(25, 215);
            this.lblEmail.Text = "Email";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(25, 240);
            this.txtEmail.Size = new System.Drawing.Size(250, 25);

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDiaChi.Location = new System.Drawing.Point(310, 215);
            this.lblDiaChi.Text = "Địa chỉ liên hệ";

            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Location = new System.Drawing.Point(310, 240);
            this.txtDiaChi.Size = new System.Drawing.Size(250, 25);
            // 
            // Dòng 5: Phòng Ban, Chức vụ & Trạng thái
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPhongBan.Location = new System.Drawing.Point(25, 280);
            this.lblPhongBan.Text = "Phòng ban";

            this.cmbPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPhongBan.Location = new System.Drawing.Point(25, 305);
            this.cmbPhongBan.Size = new System.Drawing.Size(170, 25);

            this.lblChucVu.AutoSize = true;
            this.lblChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblChucVu.Location = new System.Drawing.Point(215, 280);
            this.lblChucVu.Text = "Chức vụ";

            this.cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChucVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbChucVu.Location = new System.Drawing.Point(215, 305);
            this.cmbChucVu.Size = new System.Drawing.Size(170, 25);

            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTrangThai.Location = new System.Drawing.Point(405, 305);
            this.cmbTrangThai.Size = new System.Drawing.Size(155, 25);
            // 
            // Dòng 6: Ngày vào làm
            // 
            this.lblNgayVaoLam.AutoSize = true;
            this.lblNgayVaoLam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNgayVaoLam.Location = new System.Drawing.Point(25, 345);
            this.lblNgayVaoLam.Text = "Ngày vào làm";

            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(25, 370);
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(250, 25);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(540, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "LƯU HỒ SƠ";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCancel.Location = new System.Drawing.Point(670, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "HỦY BỎ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmEmployeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(840, 590);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmployeeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật hồ sơ";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Panel pnlCard;

        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.ComboBox cmbPhongBan;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cmbChucVu;
        private System.Windows.Forms.Label lblNgayVaoLam;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cmbTrangThai;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}