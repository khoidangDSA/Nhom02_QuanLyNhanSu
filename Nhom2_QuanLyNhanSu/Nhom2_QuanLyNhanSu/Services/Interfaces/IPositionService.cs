using Nhom2_QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IPositionService
    {
        List<Position> Search(string keyword);
        void Add(Position position);
        void Update(Position position);
        void Delete(int id);
    }
}
