using System;
using System.Data;

namespace QuanLyNhanSu.Views
{
    public interface IHopDongView
    {
        string MaHopDong { get; set; }
        string MaNhanVien { get; set; }
        string LoaiHopDong { get; set; }
        DateTime NgayKy { get; set; }
        DateTime NgayBatDau { get; set; }
        DateTime NgayKetThuc { get; set; }
        decimal MucLuong { get; set; }
        decimal PhuCap { get; set; }

        void DisplayHopDongList(DataTable data);
        void ShowMessage(string message);
        void ShowCanhBaoPopup(DataTable dtCanhBao);
    }
}
