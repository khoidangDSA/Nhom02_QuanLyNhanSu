using Nhom2_QuanLyNhanSu.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    public class WorkHistory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public WorkHistoryType EventType { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Today;

        public int? FromDepartmentId { get; set; }
        public int? ToDepartmentId { get; set; }
        public int? FromPositionId { get; set; }
        public int? ToPositionId { get; set; }
        public string Note { get; set; } = string.Empty;

        // Chỉ để hiển thị
        public string FromDepartmentName { get; set; } = string.Empty;
        public string ToDepartmentName { get; set; } = string.Empty;
        public string FromPositionName { get; set; } = string.Empty;
        public string ToPositionName { get; set; } = string.Empty;
    }
}
