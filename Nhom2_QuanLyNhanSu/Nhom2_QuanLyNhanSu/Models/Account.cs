using Nhom2_QuanLyNhanSu.Models.Enums;

namespace Nhom2_QuanLyNhanSu.Models;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public AccountRole Role { get; set; }
    public int? EmployeeId { get; set; }
    public bool IsActive { get; set; } = true;
}