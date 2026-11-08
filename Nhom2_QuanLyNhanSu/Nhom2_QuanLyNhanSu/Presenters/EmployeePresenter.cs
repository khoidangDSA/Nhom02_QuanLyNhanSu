using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Forms;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class EmployeePresenter
    {
        private readonly IEmployeeView _view;
        private readonly IEmployeeService _service;
        private readonly BindingSource _employeeBindingSource;

        private int _currentRowIndex = 0;
        private int _pageNumber = 1;

        public EmployeePresenter(IEmployeeView view, IEmployeeService service)
        {
            _view = view;
            _service = service;
            _employeeBindingSource = new BindingSource();

            _view.SearchEvent += SearchEmployee;
            _view.AddNewEvent += AddNewEmployee;
            _view.EditEvent += EditEmployee;
            _view.DeleteEvent += DeleteEmployee;
            _view.PrintEvent += PrintEmployeeList;

            LoadAllEmployeeList();
        }

        private void LoadAllEmployeeList()
        {
            try
            {
                var list = _service.GetAll();
                _employeeBindingSource.DataSource = list;
                _employeeBindingSource.ResetBindings(false);
                _view.SetEmployeeListBindingSource(_employeeBindingSource);
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi tải danh sách nhân viên: " + ex.Message;
                MessageBox.Show(_view.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchEmployee(object sender, EventArgs e)
        {
            bool isDefaultSearch = string.IsNullOrWhiteSpace(_view.SearchValue) ||
                                   _view.SearchValue.Contains("Tìm kiếm");

            if (isDefaultSearch)
            {
                LoadAllEmployeeList();
            }
            else
            {
                try
                {
                    var list = _service.GetByValue(_view.SearchValue.Trim());
                    _employeeBindingSource.DataSource = list;
                    _view.SetEmployeeListBindingSource(_employeeBindingSource);
                }
                catch (Exception ex)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Lỗi tìm kiếm: " + ex.Message;
                    MessageBox.Show(_view.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AddNewEmployee(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form thêm mới nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditEmployee(object sender, EventArgs e)
        {
            if (_employeeBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Mở form chỉnh sửa nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteEmployee(object sender, EventArgs e)
        {
            if (_employeeBindingSource.Current == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Vui lòng chọn nhân viên cần xóa!";
                return;
            }

            try
            {
                var row = (DataRowView)_employeeBindingSource.Current;
                int id = Convert.ToInt32(row["Id"]);

                bool success = _service.Delete(id);
                _view.IsSuccessful = success;

                if (success)
                {
                    _view.Message = "Đã xóa nhân viên thành công!";
                    LoadAllEmployeeList();
                }
                else
                {
                    _view.Message = "Không thể xóa nhân viên này.";
                }
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi khi xóa: " + ex.Message;
            }
        }

        private void PrintEmployeeList(object sender, EventArgs e)
        {
            if (_employeeBindingSource.DataSource == null || _employeeBindingSource.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.DocumentName = "Danh_Sach_Nhan_Vien";

            _currentRowIndex = 0;
            _pageNumber = 1;

            printDoc.PrintPage += PrintDocument_PrintPage;

            using (var previewForm = new FrmPrintPreview(printDoc))
            {
                previewForm.ShowDialog();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var dt = (DataTable)_employeeBindingSource.DataSource;
            var g = e.Graphics;

            var titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            var headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            var bodyFont = new Font("Segoe UI", 9, FontStyle.Regular);
            var footerFont = new Font("Segoe UI", 8, FontStyle.Italic);

            var brush = Brushes.Black;
            var headerBrush = new SolidBrush(Color.FromArgb(240, 243, 246));
            var borderPen = new Pen(Color.FromArgb(203, 213, 225));

            int startX = 40;
            int startY = 40;
            int rowHeight = 28;

            if (_pageNumber == 1)
            {
                g.DrawString("CÔNG TY CỔ PHẦN CÔNG NGHỆ VÀ NHÂN LỰC", new Font("Segoe UI", 9, FontStyle.Bold), brush, startX, startY);
                startY += 20;
                g.DrawString("HỆ THỐNG QUẢN LÝ NHÂN SỰ", footerFont, brush, startX, startY);

                startY += 25;
                string titleText = "DANH SÁCH HỒ SƠ NHÂN VIÊN";
                var titleSize = g.MeasureString(titleText, titleFont);
                g.DrawString(titleText, titleFont, brush, (e.PageBounds.Width - titleSize.Width) / 2, startY);

                startY += 30;
                string printDate = $"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}";
                g.DrawString(printDate, footerFont, brush, startX, startY);
                startY += 25;
            }

            int[] colWidths = { 40, 80, 150, 70, 85, 95, 150, 120, 110, 85 };
            string[] headers = { "STT", "Mã NV", "Họ và tên", "Giới tính", "Ngày sinh", "SĐT", "Email", "Phòng ban", "Chức vụ", "Trạng thái" };

            int currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                var rect = new Rectangle(currentX, startY, colWidths[i], rowHeight);
                g.FillRectangle(headerBrush, rect);
                g.DrawRectangle(borderPen, rect);

                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(headers[i], headerFont, brush, rect, sf);
                currentX += colWidths[i];
            }

            startY += rowHeight;

            while (_currentRowIndex < dt.Rows.Count)
            {
                var row = dt.Rows[_currentRowIndex];
                currentX = startX;

                string stt = (_currentRowIndex + 1).ToString();
                string code = row["Code"]?.ToString() ?? "";
                string name = row["FullName"]?.ToString() ?? "";
                string gender = row.Table.Columns.Contains("GenderStr") ? row["GenderStr"].ToString() : (row["Gender"].ToString() == "0" ? "Nam" : "Nữ");
                string birth = row["BirthDate"] != DBNull.Value ? Convert.ToDateTime(row["BirthDate"]).ToString("dd/MM/yyyy") : "";
                string phone = row["Phone"]?.ToString() ?? "";
                string email = row["Email"]?.ToString() ?? "";
                string dept = row["DepartmentName"]?.ToString() ?? "";
                string pos = row["PositionName"]?.ToString() ?? "";
                string status = row.Table.Columns.Contains("StatusStr") ? row["StatusStr"].ToString() : "Đang làm việc";

                string[] values = { stt, code, name, gender, birth, phone, email, dept, pos, status };

                for (int i = 0; i < values.Length; i++)
                {
                    var rect = new Rectangle(currentX, startY, colWidths[i], rowHeight);
                    g.DrawRectangle(borderPen, rect);

                    var sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter,
                        FormatFlags = StringFormatFlags.NoWrap,
                        Alignment = (i == 0 || i == 1 || i == 3 || i == 4 || i == 9) ? StringAlignment.Center : StringAlignment.Near
                    };

                    var textRect = new Rectangle(rect.X + 4, rect.Y, rect.Width - 8, rect.Height);
                    g.DrawString(values[i], bodyFont, brush, textRect, sf);

                    currentX += colWidths[i];
                }

                startY += rowHeight;
                _currentRowIndex++;

                if (startY + rowHeight > e.PageBounds.Height - 60)
                {
                    e.HasMorePages = true;
                    _pageNumber++;
                    return;
                }
            }

            string pageText = $"Trang {_pageNumber}";
            g.DrawString(pageText, footerFont, brush, e.PageBounds.Width - 100, e.PageBounds.Height - 40);

            e.HasMorePages = false;
        }
    }
}