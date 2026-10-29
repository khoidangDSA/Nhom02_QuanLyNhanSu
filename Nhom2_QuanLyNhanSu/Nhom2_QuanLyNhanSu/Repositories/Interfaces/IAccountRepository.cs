using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Repositories.Interfaces;

public interface IAccountRepository
{
    Account? GetByUsername(string username);
    int Count();
    bool Add(Account account);
}