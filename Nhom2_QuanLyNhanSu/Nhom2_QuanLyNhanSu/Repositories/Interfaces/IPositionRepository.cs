using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        List<Position> GetAll();
        List<Position> Search(string keyword);
        bool Add(Position position);
        bool Update(Position position);
        bool Delete(int id);
        bool IsCodeExists(string code, int excludeId = 0);
    }
}

