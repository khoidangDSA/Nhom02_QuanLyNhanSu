using System.Data;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IAccountService
    {
        DataTable GetAll();
        DataTable GetByValue(string keyword);
        bool Add(string username, string password, int role, int? employeeId, bool isActive);
        bool Update(int id, int role, int? employeeId, bool isActive);
        bool ResetPassword(int id, string newPassword);
        bool Delete(int id);
        DataTable GetEmployeeLookup();
    }
}