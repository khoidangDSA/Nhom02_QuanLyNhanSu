using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmPrintPreview : Form
    {
        // Constructor bắt buộc phải truyền vào một tài liệu in (PrintDocument)
        public FrmPrintPreview(PrintDocument documentToPrint)
        {
            InitializeComponent();

            // Gán tài liệu in vào bộ điều khiển Preview
            printPreviewControl.Document = documentToPrint;

            // Mặc định thu phóng vừa màn hình khi mới mở
            printPreviewControl.AutoZoom = true;
            UpdateZoomLabel();

            AssociateEvents();
        }

        private void AssociateEvents()
        {
            // Nút In: Gọi lệnh in thực tế ra máy in
            btnPrint.Click += (s, e) =>
            {
                if (printPreviewControl.Document != null)
                {
                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        printDialog.Document = printPreviewControl.Document;
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            printPreviewControl.Document.Print();
                        }
                    }
                }
            };

            // Nút Phóng to
            btnZoomIn.Click += (s, e) =>
            {
                printPreviewControl.AutoZoom = false;
                printPreviewControl.Zoom += 0.25; // Tăng 25%
                UpdateZoomLabel();
            };

            // Nút Thu nhỏ
            btnZoomOut.Click += (s, e) =>
            {
                printPreviewControl.AutoZoom = false;
                if (printPreviewControl.Zoom > 0.25)
                {
                    printPreviewControl.Zoom -= 0.25; // Giảm 25%
                }
                UpdateZoomLabel();
            };

            // Nút Đóng
            btnClose.Click += (s, e) =>
            {
                this.Close();
            };
        }

        // Cập nhật chữ hiển thị phần trăm thu phóng
        private void UpdateZoomLabel()
        {
            if (printPreviewControl.AutoZoom)
            {
                lblZoom.Text = "Auto";
            }
            else
            {
                lblZoom.Text = $"{(int)(printPreviewControl.Zoom * 100)}%";
            }
        }
    }
}