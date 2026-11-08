using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Nhom2_QuanLyNhanSu.Utils
{
    public static class ExcelExporter
    {
        // Hàm dùng chung để xuất bất kỳ danh sách nào (List<T>) ra file Excel
        public static void ExportToExcel<T>(IEnumerable<T> dataList, string sheetName, string defaultFileName)
        {
            // 1. Mở hộp thoại chọn nơi lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = defaultFileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            // 2. Tạo worksheet và đổ dữ liệu
                            var worksheet = workbook.Worksheets.Add(sheetName);

                            // Đổ dữ liệu từ danh sách vào, bắt đầu từ ô A1, tự động tạo Header (tên cột)
                            worksheet.Cell(1, 1).InsertData(dataList);

                            // 3. Định dạng giao diện file Excel cho đẹp mắt (Chuyên nghiệp)
                            var headerRange = worksheet.Range(1, 1, 1, worksheet.LastColumnUsed().ColumnNumber());
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Font.FontColor = XLColor.White;
                            headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(37, 99, 235); // Xanh dương chủ đạo
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Tự động căn chỉnh độ rộng các cột cho vừa khít nội dung
                            worksheet.Columns().AdjustToContents();

                            // 4. Lưu file xuống ổ cứng
                            workbook.SaveAs(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}