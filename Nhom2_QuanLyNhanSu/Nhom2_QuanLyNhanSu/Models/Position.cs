using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Allowance { get; set; }       // Phụ cấp chức vụ
        public string Description { get; set; } = string.Empty;

        // Cột phụ đếm số lượng nhân viên giữ chức vụ này
        public int EmployeeCount { get; set; }
    }
}
