using Nhom2_QuanLyNhanSu.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    internal class Contract
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ContractNo { get; set; } = string.Empty;
        public ContractType Type { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime? EndDate { get; set; }                 // null nếu không thời hạn
        public decimal BaseSalary { get; set; }
        public string Note { get; set; } = string.Empty;

        // Chỉ để hiển thị
        public string EmployeeName { get; set; } = string.Empty;

        // Thuộc tính tính toán, không lưu CSDL (dùng cho phần "nhắc hợp đồng sắp hết hạn")
        public int? DaysRemaining =>
            EndDate.HasValue ? (EndDate.Value.Date - DateTime.Today).Days : null;

        public bool IsExpiringSoon(int withinDays = 30) =>
            DaysRemaining is >= 0 && DaysRemaining <= withinDays;
    }
}
