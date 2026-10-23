using Nhom2_QuanLyNhanSu.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;   // KHÔNG lưu mật khẩu thô
        public AccountRole Role { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
