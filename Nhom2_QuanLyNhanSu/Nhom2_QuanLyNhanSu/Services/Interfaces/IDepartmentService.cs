using Nhom2_QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        List<Department> SearchDepartments(string keyword);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
        bool IsDepartmentCodeExists(string code, int excludeId = 0);
    }
}
