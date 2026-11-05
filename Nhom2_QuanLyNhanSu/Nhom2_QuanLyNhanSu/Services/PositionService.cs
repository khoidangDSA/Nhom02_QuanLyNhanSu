using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repo;

        public PositionService(IPositionRepository repo)
        {
            _repo = repo;
        }

        public List<Position> Search(string keyword) =>
            string.IsNullOrWhiteSpace(keyword) ? _repo.GetAll() : _repo.Search(keyword.Trim());

        public void Add(Position p)
        {
            Normalize(p);
            Validate(p);
            if (_repo.IsCodeExists(p.Code))
                throw new InvalidOperationException($"Mã chức vụ \"{p.Code}\" đã tồn tại.");
            _repo.Add(p);
        }

        public void Update(Position p)
        {
            Normalize(p);
            Validate(p);
            if (_repo.IsCodeExists(p.Code, p.Id))
                throw new InvalidOperationException($"Mã chức vụ \"{p.Code}\" đã được chức vụ khác sử dụng.");
            _repo.Update(p);
        }

        public void Delete(int id)
        {
            var p = _repo.GetAll().FirstOrDefault(x => x.Id == id)
                    ?? throw new InvalidOperationException("Không tìm thấy chức vụ cần xóa.");

            if (p.EmployeeCount > 0)
                throw new InvalidOperationException(
                    $"Chức vụ \"{p.Name}\" đang có {p.EmployeeCount} nhân viên, không thể xóa.");

            _repo.Delete(id);
        }

        private static void Normalize(Position p)
        {
            p.Code = p.Code.Trim().ToUpper();
            p.Name = p.Name.Trim();
            p.Description = p.Description.Trim();
        }

        private static void Validate(Position p)
        {
            if (string.IsNullOrWhiteSpace(p.Code))
                throw new InvalidOperationException("Mã chức vụ không được để trống.");
            if (p.Code.Length > 20)
                throw new InvalidOperationException("Mã chức vụ tối đa 20 ký tự.");
            if (string.IsNullOrWhiteSpace(p.Name))
                throw new InvalidOperationException("Tên chức vụ không được để trống.");
            if (p.Name.Length > 100)
                throw new InvalidOperationException("Tên chức vụ tối đa 100 ký tự.");
            if (p.Allowance < 0)
                throw new InvalidOperationException("Phụ cấp không được âm.");
        }
    }
}

