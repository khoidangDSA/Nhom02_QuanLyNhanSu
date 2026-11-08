namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    partial class FrmPrintPreview
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblZoom = new System.Windows.Forms.Label();
            this.printPreviewControl = new System.Windows.Forms.PrintPreviewControl();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlToolbar.Controls.Add(this.lblZoom);
            this.pnlToolbar.Controls.Add(this.btnZoomOut);
            this.pnlToolbar.Controls.Add(this.btnZoomIn);
            this.pnlToolbar.Controls.Add(this.btnPrint);
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(900, 60);
            this.pnlToolbar.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(20, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 36);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "🖨️ In ngay";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnZoomIn.Location = new System.Drawing.Point(150, 12);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(40, 36);
            this.btnZoomIn.TabIndex = 1;
            this.btnZoomIn.Text = "➕";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnZoomOut.Location = new System.Drawing.Point(260, 12);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 36);
            this.btnZoomOut.TabIndex = 2;
            this.btnZoomOut.Text = "➖";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblZoom.Location = new System.Drawing.Point(198, 19);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(53, 23);
            this.lblZoom.TabIndex = 3;
            this.lblZoom.Text = "100%";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(770, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // printPreviewControl
            // 
            this.printPreviewControl.AutoZoom = false;
            this.printPreviewControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.printPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl.Location = new System.Drawing.Point(0, 60);
            this.printPreviewControl.Name = "printPreviewControl";
            this.printPreviewControl.Size = new System.Drawing.Size(900, 640);
            this.printPreviewControl.TabIndex = 1;
            this.printPreviewControl.Zoom = 1D;
            // 
            // FrmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.printPreviewControl);
            this.Controls.Add(this.pnlToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "FrmPrintPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem Trước Bản In";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl;
    }
}