using System;
using System.Data;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IEmployeeService
    {
        DataTable GetAll();
        DataTable GetByValue(string keyword);
        bool Add(string code, string fullName, int gender, DateTime birthDate, string idCard,
                 string phone, string email, string address, int departmentId, int positionId,
                 DateTime hireDate, int status);
        bool Update(int id, string code, string fullName, int gender, DateTime birthDate, string idCard,
                    string phone, string email, string address, int departmentId, int positionId,
                    DateTime hireDate, int status);
        bool Delete(int id);
        DataTable GetDepartments();
        DataTable GetPositions();
    }
}