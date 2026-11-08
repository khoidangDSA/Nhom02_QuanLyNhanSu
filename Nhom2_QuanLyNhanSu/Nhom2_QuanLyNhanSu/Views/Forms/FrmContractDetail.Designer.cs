namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmContractDetail
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
            this.lblContractNo = new System.Windows.Forms.Label();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.chkNoEndDate = new System.Windows.Forms.CheckBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Size = new System.Drawing.Size(273, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỢP ĐỒNG LAO ĐỘNG";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblContractNo);
            this.pnlCard.Controls.Add(this.txtContractNo);
            this.pnlCard.Controls.Add(this.lblEmployee);
            this.pnlCard.Controls.Add(this.cmbEmployee);
            this.pnlCard.Controls.Add(this.lblType);
            this.pnlCard.Controls.Add(this.cmbType);
            this.pnlCard.Controls.Add(this.lblStartDate);
            this.pnlCard.Controls.Add(this.dtpStartDate);
            this.pnlCard.Controls.Add(this.lblEndDate);
            this.pnlCard.Controls.Add(this.dtpEndDate);
            this.pnlCard.Controls.Add(this.chkNoEndDate);
            this.pnlCard.Controls.Add(this.lblSalary);
            this.pnlCard.Controls.Add(this.txtSalary);
            this.pnlCard.Controls.Add(this.lblNote);
            this.pnlCard.Controls.Add(this.txtNote);
            this.pnlCard.Location = new System.Drawing.Point(25, 65);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(590, 310);
            this.pnlCard.TabIndex = 1;
            // 
            // lblContractNo
            // 
            this.lblContractNo.AutoSize = true;
            this.lblContractNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblContractNo.Location = new System.Drawing.Point(25, 18);
            this.lblContractNo.Name = "lblContractNo";
            this.lblContractNo.Size = new System.Drawing.Size(109, 17);
            this.lblContractNo.TabIndex = 0;
            this.lblContractNo.Text = "Số hợp đồng (*):";
            // 
            // txtContractNo
            // 
            this.txtContractNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractNo.Location = new System.Drawing.Point(25, 42);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.Size = new System.Drawing.Size(250, 25);
            this.txtContractNo.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmployee.Location = new System.Drawing.Point(310, 18);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(91, 17);
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Nhân viên (*):";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmployee.Location = new System.Drawing.Point(310, 42);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(250, 25);
            this.cmbEmployee.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblType.Location = new System.Drawing.Point(25, 80);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(95, 17);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Loại hợp đồng:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Items.AddRange(new object[] {
            "Thử việc",
            "Có thời hạn",
            "Không thời hạn"});
            this.cmbType.Location = new System.Drawing.Point(25, 104);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(250, 25);
            this.cmbType.TabIndex = 5;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSalary.Location = new System.Drawing.Point(310, 80);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(112, 17);
            this.lblSalary.TabIndex = 6;
            this.lblSalary.Text = "Lương cơ bản (*):";
            // 
            // txtSalary
            // 
            this.txtSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalary.Location = new System.Drawing.Point(310, 104);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.PlaceholderText = "VD: 15000000";
            this.txtSalary.Size = new System.Drawing.Size(250, 25);
            this.txtSalary.TabIndex = 7;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStartDate.Location = new System.Drawing.Point(25, 145);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(90, 17);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(25, 169);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(250, 25);
            this.dtpStartDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEndDate.Location = new System.Drawing.Point(310, 145);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(90, 17);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "Ngày kết thúc:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(310, 169);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 25);
            this.dtpEndDate.TabIndex = 11;
            // 
            // chkNoEndDate
            // 
            this.chkNoEndDate.AutoSize = true;
            this.chkNoEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkNoEndDate.Location = new System.Drawing.Point(470, 171);
            this.chkNoEndDate.Name = "chkNoEndDate";
            this.chkNoEndDate.Size = new System.Drawing.Size(95, 21);
            this.chkNoEndDate.TabIndex = 12;
            this.chkNoEndDate.Text = "Vô thời hạn";
            this.chkNoEndDate.UseVisualStyleBackColor = true;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNote.Location = new System.Drawing.Point(25, 210);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(54, 17);
            this.lblNote.TabIndex = 13;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Location = new System.Drawing.Point(25, 234);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(535, 55);
            this.txtNote.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(375, 395);
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
            this.btnCancel.Location = new System.Drawing.Point(500, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmContractDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(640, 455);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContractDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Hợp đồng";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnlCard;
        public System.Windows.Forms.Label lblContractNo;
        public System.Windows.Forms.TextBox txtContractNo;
        public System.Windows.Forms.Label lblEmployee;
        public System.Windows.Forms.ComboBox cmbEmployee;
        public System.Windows.Forms.Label lblType;
        public System.Windows.Forms.ComboBox cmbType;
        public System.Windows.Forms.Label lblStartDate;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        public System.Windows.Forms.Label lblEndDate;
        public System.Windows.Forms.DateTimePicker dtpEndDate;
        public System.Windows.Forms.CheckBox chkNoEndDate;
        public System.Windows.Forms.Label lblSalary;
        public System.Windows.Forms.TextBox txtSalary;
        public System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
    }
}