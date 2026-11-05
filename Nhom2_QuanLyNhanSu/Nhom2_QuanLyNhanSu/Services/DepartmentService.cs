using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public List<Department> GetAllDepartments() => _repository.GetAll();

    public List<Department> SearchDepartments(string keyword) =>
        string.IsNullOrWhiteSpace(keyword) ? _repository.GetAll() : _repository.Search(keyword);

    public bool IsDepartmentCodeExists(string code, int excludeId = 0) => _repository.IsCodeExists(code, excludeId);

    public void AddDepartment(Department department)
    {
        ValidateDepartment(department);

        if (_repository.IsCodeExists(department.Code))
            throw new InvalidOperationException($"Mã phòng ban '{department.Code}' đã tồn tại!");

        if (!_repository.Add(department))
            throw new Exception("Thêm phòng ban thất bại!");
    }

    public void UpdateDepartment(Department department)
    {
        if (department.Id <= 0)
            throw new ArgumentException("Vui lòng chọn phòng ban cần cập nhật!");

        ValidateDepartment(department);

        if (_repository.IsCodeExists(department.Code, department.Id))
            throw new InvalidOperationException($"Mã phòng ban '{department.Code}' đã trùng với phòng ban khác!");

        if (!_repository.Update(department))
            throw new Exception("Cập nhật phòng ban thất bại!");
    }

    public void DeleteDepartment(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Vui lòng chọn phòng ban cần xóa!");

        if (!_repository.Delete(id))
            throw new Exception("Xóa phòng ban thất bại!");
    }

    private static void ValidateDepartment(Department department)
    {
        if (string.IsNullOrWhiteSpace(department.Code))
            throw new ArgumentException("Mã phòng ban không được để trống!");

        if (string.IsNullOrWhiteSpace(department.Name))
            throw new ArgumentException("Tên phòng ban không được để trống!");
    }
}