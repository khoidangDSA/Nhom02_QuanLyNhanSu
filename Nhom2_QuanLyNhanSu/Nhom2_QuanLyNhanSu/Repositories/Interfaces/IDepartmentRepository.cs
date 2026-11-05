using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Repositories.Interfaces;

public interface IDepartmentRepository
{
    List<Department> GetAll();
    List<Department> Search(string keyword);
    bool Add(Department department);
    bool Update(Department department);
    bool Delete(int id);
    bool IsCodeExists(string code, int excludeId = 0);
}