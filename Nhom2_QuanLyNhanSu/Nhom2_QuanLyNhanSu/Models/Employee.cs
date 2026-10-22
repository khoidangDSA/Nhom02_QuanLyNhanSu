using Nhom2_QuanLyNhanSu.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;       // Mã nhân viên
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Today.AddYears(-20);
        public string IdCard { get; set; } = string.Empty;     // CCCD
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? PhotoPath { get; set; }                 // Đường dẫn ảnh (có thể null)

        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Today;
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Working;

        // Chỉ để hiển thị trên DataGridView (lấy từ JOIN)
        public string DepartmentName { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
    }
}
