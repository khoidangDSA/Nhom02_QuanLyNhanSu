using System;
using System.Data;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IContractService
    {
        DataTable GetAll();
        DataTable GetByValue(string keyword);
        bool Add(string contractNo, int employeeId, int type, DateTime startDate, DateTime? endDate, decimal baseSalary, string note);
        bool Update(int id, string contractNo, int employeeId, int type, DateTime startDate, DateTime? endDate, decimal baseSalary, string note);
        bool Delete(int id);
        DataTable GetEmployeeLookup();
    }
}