using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces;

public interface IAuthService
{
    Account Login(string username, string password);
    void EnsureDefaultAccounts();
}