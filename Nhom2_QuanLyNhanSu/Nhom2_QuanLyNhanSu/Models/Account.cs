using System;
using Nhom2_QuanLyNhanSu.Models.Enums;

namespace Nhom2_QuanLyNhanSu.Models
{
    public class Account
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Thuộc tính tương thích ngược với code cũ gọi .Password
        public string Password
        {
            get => PasswordHash;
            set => PasswordHash = value;
        }

        // Kiểu Enum chuẩn của nhóm
        public AccountRole Role { get; set; }

        // Thuộc tính phụ giúp tương thích với các đoạn code so sánh chuỗi cũ
        public string RoleString
        {
            get => Role.ToString().ToLower();
            set
            {
                if (Enum.TryParse<AccountRole>(value, true, out var parsedRole))
                {
                    Role = parsedRole;
                }
            }
        }

        public string MaNV { get; set; }
        public bool IsActive { get; set; } = true;
    }
}