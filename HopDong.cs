using System;

namespace QuanLyNhanSu.Models
{
    public class HopDong
    {
        public string MaHopDong { get; set; }
        public string MaNhanVien { get; set; }
        public string LoaiHopDong { get; set; } // Thử việc, Xác định thời hạn, Ko xác định thời hạn
        public DateTime NgayKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal MucLuongBase { get; set; }
        public decimal PhuCap { get; set; }
        public string TrangThai { get; set; } // Hiệu lực, Hết hạn, Đã chấm dứt
    }
}
