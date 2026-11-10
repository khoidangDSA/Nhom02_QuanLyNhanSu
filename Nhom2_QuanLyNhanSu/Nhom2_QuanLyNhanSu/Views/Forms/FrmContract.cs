using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmContract : Form, IContractView
    {
        // --- CÁC SỰ KIỆN MVP ---
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent; // Sự kiện riêng cho Hợp đồng

        private string _currentRole;
        private string _message;
        private bool _isSuccessful;

        // Biến lưu dòng hợp đồng đang được chọn để in
        private DataGridViewRow _selectedRowForPrint;

        public FrmContract(string role)
        {
            InitializeComponent();
            _currentRole = role;

            ApplyRolePermissions();
            AssociateAndRaiseViewEvents();
        }

        // Xử lý phân quyền (Khóa nút Xóa với tài khoản HR)
        private void ApplyRolePermissions()
        {
            if (_currentRole == "hr")
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.LightGray;
            }
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Tìm kiếm
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Thêm mới
            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };

            // Chỉnh sửa
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            dgvContracts.DoubleClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };

            // Xóa
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message);
                }
            };

            // In Hợp đồng: Bắn sự kiện MVP và trực tiếp kích hoạt Form Print Preview
            btnPrint.Click += (s, e) =>
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
                ExecutePrintContract();
            };
        }

        // --- XỬ LÝ IN HỢP ĐỒNG ---

        private void ExecutePrintContract()
        {
            if (dgvContracts.CurrentRow == null || dgvContracts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng trong danh sách để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedRowForPrint = dgvContracts.CurrentRow;

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // Khổ giấy A4 tiêu chuẩn
                printDoc.PrintPage += PrintDocument_PrintContractPage;

                using (FrmPrintPreview previewForm = new FrmPrintPreview(printDoc))
                {
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo tài liệu in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintContractPage(object sender, PrintPageEventArgs e)
        {
            if (_selectedRowForPrint == null) return;

            Graphics g = e.Graphics;

            // Thiết lập font chữ chuẩn văn bản hành chính
            Font fontHeader = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fontMotto = new Font("Times New Roman", 12, FontStyle.Bold);
            Font fontTitle = new Font("Times New Roman", 19, FontStyle.Bold);
            Font fontSection = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fontNormal = new Font("Times New Roman", 12, FontStyle.Regular);
            Font fontItalic = new Font("Times New Roman", 11, FontStyle.Italic);

            Brush brush = Brushes.Black;
            StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center };

            float left = 90;
            float y = 70;
            float center = e.PageBounds.Width / 2f;

            // 1. Quốc hiệu - Tiêu ngữ
            g.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeader, brush, center, y, sfCenter);
            y += 30; // Giãn cách dòng quốc hiệu
            g.DrawString("Độc lập - Tự do - Hạnh phúc", fontMotto, brush, center, y, sfCenter);
            y += 24;

            // Đường gạch chân tiêu ngữ
            g.DrawLine(new Pen(Color.Black, 1.2f), center - 90, y, center + 90, y);
            y += 50; // Tạo khoảng cách thoáng xuống tiêu đề chính

            // 2. Tiêu đề Hợp đồng
            g.DrawString("HỢP ĐỒNG LAO ĐỘNG", fontTitle, brush, center, y, sfCenter);
            y += 35;

            // Đọc dữ liệu từ dòng đang chọn
            string soHD = GetCellValue("ContractNo");
            string maNV = GetCellValue("EmployeeCode");
            string hoTen = GetCellValue("EmployeeName");
            string loaiHD = GetCellValue("ContractTypeStr");
            string ngayBD = FormatDateValue("StartDate");
            string ngayKT = FormatDateValue("EndDate");
            if (string.IsNullOrEmpty(ngayKT)) ngayKT = "Không thời hạn";
            string luongCB = FormatCurrencyValue("BaseSalary");
            string ghiChu = GetCellValue("Note");

            g.DrawString($"Số: {soHD} / HĐLĐ", fontItalic, brush, center, y, sfCenter);
            y += 50; // Khoảng cách từ số hợp đồng xuống bên A

            // 3. Bên A
            g.DrawString("ĐẠI DIỆN NGƯỜI SỬ DỤNG LAO ĐỘNG (BÊN A):", fontSection, brush, left, y);
            y += 30;
            g.DrawString("• Công ty: CÔNG TY QUẢN LÝ NHÂN SỰ", fontNormal, brush, left + 20, y);
            y += 28;
            g.DrawString("• Đại diện: Ban Giám Đốc", fontNormal, brush, left + 20, y);
            y += 40;

            // 4. Bên B
            g.DrawString("NGƯỜI LAO ĐỘNG (BÊN B):", fontSection, brush, left, y);
            y += 30;
            g.DrawString($"• Họ và tên: {hoTen}", fontNormal, brush, left + 20, y);
            y += 28;
            g.DrawString($"• Mã nhân viên: {maNV}", fontNormal, brush, left + 20, y);
            y += 40;

            // 5. Điều khoản
            g.DrawString("ĐIỀU KHOẢN HỢP ĐỒNG:", fontSection, brush, left, y);
            y += 30;
            g.DrawString($"• Loại hợp đồng: {loaiHD}", fontNormal, brush, left + 20, y);
            y += 28;
            g.DrawString($"• Thời hạn hợp đồng: Từ ngày {ngayBD} đến ngày {ngayKT}", fontNormal, brush, left + 20, y);
            y += 28;
            g.DrawString($"• Mức lương cơ bản: {luongCB} VNĐ", fontNormal, brush, left + 20, y);
            y += 28;
            if (!string.IsNullOrEmpty(ghiChu))
            {
                g.DrawString($"• Ghi chú: {ghiChu}", fontNormal, brush, left + 20, y);
                y += 28;
            }
            y += 60; // Khoảng cách xuống chữ ký

            // 6. Chữ ký hai bên
            float rightSign = e.PageBounds.Width - left - 190;
            g.DrawString("ĐẠI DIỆN BÊN A", fontSection, brush, left + 40, y);
            g.DrawString("NGƯỜI LAO ĐỘNG (BÊN B)", fontSection, brush, rightSign, y);
            y += 26;
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brush, left + 45, y);
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brush, rightSign + 20, y);

            e.HasMorePages = false;
        }

        // Phương thức hỗ trợ đọc ô an toàn
        private string GetCellValue(string columnName)
        {
            if (_selectedRowForPrint.DataGridView.Columns.Contains(columnName))
            {
                var val = _selectedRowForPrint.Cells[columnName].Value;
                return val != null ? val.ToString() : string.Empty;
            }
            return string.Empty;
        }

        private string FormatDateValue(string columnName)
        {
            string raw = GetCellValue(columnName);
            if (DateTime.TryParse(raw, out DateTime date))
            {
                return date.ToString("dd/MM/yyyy");
            }
            return raw;
        }

        private string FormatCurrencyValue(string columnName)
        {
            string raw = GetCellValue(columnName);
            if (decimal.TryParse(raw, out decimal val))
            {
                return val.ToString("N0");
            }
            return raw;
        }

        // --- CÁC THUỘC TÍNH (PROPERTIES) CHO PRESENTER ---

        public string SearchValue
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public bool IsSuccessful
        {
            get => _isSuccessful;
            set => _isSuccessful = value;
        }

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        // Đổ dữ liệu Hợp đồng từ Database vào DataGridView
        public void SetContractListBindingSource(BindingSource contractList)
        {
            dgvContracts.DataSource = contractList;

            // 1. Ẩn các cột ID và mã số nội bộ để giao diện gọn gàng
            if (dgvContracts.Columns.Contains("Id")) dgvContracts.Columns["Id"].Visible = false;
            if (dgvContracts.Columns.Contains("EmployeeId")) dgvContracts.Columns["EmployeeId"].Visible = false;
            if (dgvContracts.Columns.Contains("Type")) dgvContracts.Columns["Type"].Visible = false;

            // 2. Đổi Header hiển thị sang tiếng Việt
            if (dgvContracts.Columns.Contains("ContractNo"))
                dgvContracts.Columns["ContractNo"].HeaderText = "Số HĐ";

            if (dgvContracts.Columns.Contains("EmployeeCode"))
                dgvContracts.Columns["EmployeeCode"].HeaderText = "Mã NV";

            if (dgvContracts.Columns.Contains("EmployeeName"))
                dgvContracts.Columns["EmployeeName"].HeaderText = "Họ và tên";

            if (dgvContracts.Columns.Contains("ContractTypeStr"))
                dgvContracts.Columns["ContractTypeStr"].HeaderText = "Loại hợp đồng";

            if (dgvContracts.Columns.Contains("StartDate"))
            {
                dgvContracts.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
                dgvContracts.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvContracts.Columns.Contains("EndDate"))
            {
                dgvContracts.Columns["EndDate"].HeaderText = "Ngày kết thúc";
                dgvContracts.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvContracts.Columns.Contains("BaseSalary"))
            {
                dgvContracts.Columns["BaseSalary"].HeaderText = "Lương cơ bản";
                dgvContracts.Columns["BaseSalary"].DefaultCellStyle.Format = "N0";
            }

            if (dgvContracts.Columns.Contains("Note"))
                dgvContracts.Columns["Note"].HeaderText = "Ghi chú";
        }
    }
}