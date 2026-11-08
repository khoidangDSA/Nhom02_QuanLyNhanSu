using System.Collections.Generic;
using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetBySearchValue(string searchValue);
        void Add(Account account);
        void Edit(Account account);
        void Delete(string username);
        void UpdatePassword(string username, string newPassword);
        bool CheckExists(string username);
        Account GetByUsername(string username);
        int Count();
    }
}