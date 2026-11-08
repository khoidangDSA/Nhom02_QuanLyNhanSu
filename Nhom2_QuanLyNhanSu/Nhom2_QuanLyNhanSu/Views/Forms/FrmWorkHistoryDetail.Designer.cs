namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmWorkHistoryDetail
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDepartment = new System.Windows.Forms.Label();
            this.cmbFromDepartment = new System.Windows.Forms.ComboBox();
            this.lblToDepartment = new System.Windows.Forms.Label();
            this.cmbToDepartment = new System.Windows.Forms.ComboBox();
            this.lblFromPosition = new System.Windows.Forms.Label();
            this.cmbFromPosition = new System.Windows.Forms.ComboBox();
            this.lblToPosition = new System.Windows.Forms.Label();
            this.cmbToPosition = new System.Windows.Forms.ComboBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUÁ TRÌNH CÔNG TÁC";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblEmployee);
            this.pnlCard.Controls.Add(this.cmbEmployee);
            this.pnlCard.Controls.Add(this.lblEventType);
            this.pnlCard.Controls.Add(this.cmbEventType);
            this.pnlCard.Controls.Add(this.lblEventDate);
            this.pnlCard.Controls.Add(this.dtpEventDate);
            this.pnlCard.Controls.Add(this.lblFromDepartment);
            this.pnlCard.Controls.Add(this.cmbFromDepartment);
            this.pnlCard.Controls.Add(this.lblToDepartment);
            this.pnlCard.Controls.Add(this.cmbToDepartment);
            this.pnlCard.Controls.Add(this.lblFromPosition);
            this.pnlCard.Controls.Add(this.cmbFromPosition);
            this.pnlCard.Controls.Add(this.lblToPosition);
            this.pnlCard.Controls.Add(this.cmbToPosition);
            this.pnlCard.Controls.Add(this.lblNote);
            this.pnlCard.Controls.Add(this.txtNote);
            this.pnlCard.Location = new System.Drawing.Point(25, 65);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(610, 370);
            this.pnlCard.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmployee.Location = new System.Drawing.Point(25, 18);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(91, 17);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Nhân viên (*):";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmployee.Location = new System.Drawing.Point(25, 42);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(260, 25);
            this.cmbEmployee.TabIndex = 1;
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEventType.Location = new System.Drawing.Point(320, 18);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(100, 17);
            this.lblEventType.TabIndex = 2;
            this.lblEventType.Text = "Loại sự kiện (*):";
            // 
            // cmbEventType
            // 
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEventType.Items.AddRange(new object[] {
            "Tuyển dụng (0)",
            "Điều chuyển (1)",
            "Bổ nhiệm (2)",
            "Khen thưởng / Kỷ luật (3)"});
            this.cmbEventType.Location = new System.Drawing.Point(320, 42);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(260, 25);
            this.cmbEventType.TabIndex = 3;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEventDate.Location = new System.Drawing.Point(25, 80);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(120, 17);
            this.lblEventDate.TabIndex = 4;
            this.lblEventDate.Text = "Ngày thực hiện (*):";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(25, 104);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(260, 25);
            this.dtpEventDate.TabIndex = 5;
            // 
            // lblFromDepartment
            // 
            this.lblFromDepartment.AutoSize = true;
            this.lblFromDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFromDepartment.Location = new System.Drawing.Point(25, 145);
            this.lblFromDepartment.Name = "lblFromDepartment";
            this.lblFromDepartment.Size = new System.Drawing.Size(89, 17);
            this.lblFromDepartment.TabIndex = 6;
            this.lblFromDepartment.Text = "Phòng ban cũ:";
            // 
            // cmbFromDepartment
            // 
            this.cmbFromDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromDepartment.Location = new System.Drawing.Point(25, 169);
            this.cmbFromDepartment.Name = "cmbFromDepartment";
            this.cmbFromDepartment.Size = new System.Drawing.Size(260, 25);
            this.cmbFromDepartment.TabIndex = 7;
            // 
            // lblToDepartment
            // 
            this.lblToDepartment.AutoSize = true;
            this.lblToDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblToDepartment.Location = new System.Drawing.Point(320, 145);
            this.lblToDepartment.Name = "lblToDepartment";
            this.lblToDepartment.Size = new System.Drawing.Size(99, 17);
            this.lblToDepartment.TabIndex = 8;
            this.lblToDepartment.Text = "Phòng ban mới:";
            // 
            // cmbToDepartment
            // 
            this.cmbToDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToDepartment.Location = new System.Drawing.Point(320, 169);
            this.cmbToDepartment.Name = "cmbToDepartment";
            this.cmbToDepartment.Size = new System.Drawing.Size(260, 25);
            this.cmbToDepartment.TabIndex = 9;
            // 
            // lblFromPosition
            // 
            this.lblFromPosition.AutoSize = true;
            this.lblFromPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFromPosition.Location = new System.Drawing.Point(25, 210);
            this.lblFromPosition.Name = "lblFromPosition";
            this.lblFromPosition.Size = new System.Drawing.Size(76, 17);
            this.lblFromPosition.TabIndex = 10;
            this.lblFromPosition.Text = "Chức vụ cũ:";
            // 
            // cmbFromPosition
            // 
            this.cmbFromPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromPosition.Location = new System.Drawing.Point(25, 234);
            this.cmbFromPosition.Name = "cmbFromPosition";
            this.cmbFromPosition.Size = new System.Drawing.Size(260, 25);
            this.cmbFromPosition.TabIndex = 11;
            // 
            // lblToPosition
            // 
            this.lblToPosition.AutoSize = true;
            this.lblToPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblToPosition.Location = new System.Drawing.Point(320, 210);
            this.lblToPosition.Name = "lblToPosition";
            this.lblToPosition.Size = new System.Drawing.Size(86, 17);
            this.lblToPosition.TabIndex = 12;
            this.lblToPosition.Text = "Chức vụ mới:";
            // 
            // cmbToPosition
            // 
            this.cmbToPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToPosition.Location = new System.Drawing.Point(320, 234);
            this.cmbToPosition.Name = "cmbToPosition";
            this.cmbToPosition.Size = new System.Drawing.Size(260, 25);
            this.cmbToPosition.TabIndex = 13;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNote.Location = new System.Drawing.Point(25, 275);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(54, 17);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Location = new System.Drawing.Point(25, 299);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(555, 50);
            this.txtNote.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(395, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "LƯU";
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
            this.btnCancel.Location = new System.Drawing.Point(520, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmWorkHistoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(660, 515);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkHistoryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Quá trình Công tác";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnlCard;
        public System.Windows.Forms.Label lblEmployee;
        public System.Windows.Forms.ComboBox cmbEmployee;
        public System.Windows.Forms.Label lblEventType;
        public System.Windows.Forms.ComboBox cmbEventType;
        public System.Windows.Forms.Label lblEventDate;
        public System.Windows.Forms.DateTimePicker dtpEventDate;
        public System.Windows.Forms.Label lblFromDepartment;
        public System.Windows.Forms.ComboBox cmbFromDepartment;
        public System.Windows.Forms.Label lblToDepartment;
        public System.Windows.Forms.ComboBox cmbToDepartment;
        public System.Windows.Forms.Label lblFromPosition;
        public System.Windows.Forms.ComboBox cmbFromPosition;
        public System.Windows.Forms.Label lblToPosition;
        public System.Windows.Forms.ComboBox cmbToPosition;
        public System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
    }
}