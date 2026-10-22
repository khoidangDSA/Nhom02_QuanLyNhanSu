using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? ManagerId { get; set; }          // Trưởng phòng (có thể chưa có)
        public string Description { get; set; } = string.Empty;

        // Chỉ để hiển thị (lấy từ JOIN)
        public string ManagerName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
    }
}
