namespace Nhom2_QuanLyNhanSu.Models.Filters
{
    public class EmployeeSearchCriteria
    {
        public string? Keyword { get; set; } // Tìm theo mã, họ tên, SĐT, CCCD
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public Gender? Gender { get; set; }
        public EmployeeStatus? Status { get; set; }
        public DateTime? HireDateFrom { get; set; }
        public DateTime? HireDateTo { get; set; }
        // dấu ? là có thể để trống
    }
}

