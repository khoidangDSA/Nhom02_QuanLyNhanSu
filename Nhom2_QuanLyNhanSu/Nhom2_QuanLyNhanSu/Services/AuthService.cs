using Nhom2_QuanLyNhanSu.Common.Helpers;
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Models.Enums;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services;

public class AuthService : IAuthService
{
    private readonly IAccountRepository _repo;

    public AuthService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public Account Login(string username, string password)
    {
        username = username.Trim();
        if (username.Length == 0)
            throw new InvalidOperationException("Vui lòng nhập tên đăng nhập.");
        if (password.Length == 0)
            throw new InvalidOperationException("Vui lòng nhập mật khẩu.");

        var acc = _repo.GetByUsername(username);
        if (acc == null || !PasswordHasher.Verify(password, acc.PasswordHash))
            throw new InvalidOperationException("Tên đăng nhập hoặc mật khẩu không đúng.");

        if (!acc.IsActive)
            throw new InvalidOperationException("Tài khoản đã bị khóa.");

        return acc;
    }

    public void EnsureDefaultAccounts()
    {
        if (_repo.Count() > 0) return;

        _repo.Add(new Account
        {
            Username = "admin",
            PasswordHash = PasswordHasher.Hash("admin123"),
            Role = AccountRole.Admin
        });
        _repo.Add(new Account
        {
            Username = "hr",
            PasswordHash = PasswordHasher.Hash("hr123"),
            Role = AccountRole.HRStaff
        });
    }
}