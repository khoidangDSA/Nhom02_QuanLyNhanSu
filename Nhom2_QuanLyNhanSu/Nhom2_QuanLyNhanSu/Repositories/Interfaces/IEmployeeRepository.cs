using Nhom2_QuanLyNhanSu.Models;
using System.Collections.Generic;

namespace Nhom2_QuanLyNhanSu.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}