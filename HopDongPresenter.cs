using System;
using System.Data;
using System.IO;
using ClosedXML.Excel;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Views;

namespace QuanLyNhanSu.Presenters
{
    public class HopDongPresenter
    {
        private readonly IHopDongView _view;
        private readonly HopDongModel _model;

        public HopDongPresenter(IHopDongView view)
        {
            _view = view;
            _model = new HopDongModel();
        }

        public void LoadDanhSachHopDong()
        {
            DataTable dt = _model.GetAllHopDong();
            _view.DisplayHopDongList(dt);
        }

        public void KiemTraCanhBaoHetHan()
        {
            DataTable dtCanhBao = _model.GetHopDongSapHetHan(15, 30);
            if (dtCanhBao != null && dtCanhBao.Rows.Count > 0)
            {
                _view.ShowCanhBaoPopup(dtCanhBao);
            }
        }

        public void LuuHopDong()
        {
            HopDong hd = new HopDong
            {
                MaHopDong = _view.MaHopDong,
                MaNhanVien = _view.MaNhanVien,
                LoaiHopDong = _view.LoaiHopDong,
                NgayKy = _view.NgayKy,
                NgayBatDau = _view.NgayBatDau,
                NgayKetThuc = _view.NgayKetThuc,
                MucLuongBase = _view.MucLuong,
                PhuCap = _view.PhuCap,
                TrangThai = "Hiệu lực"
            };

            if (_model.ThemHopDong(hd))
            {
                _view.ShowMessage("Thêm hợp đồng mới thành công!");
                LoadDanhSachHopDong();
            }
            else
            {
                _view.ShowMessage("Lỗi: Không thể lưu thông tin hợp đồng.");
            }
        }

        public void XuatExcel(string filePath)
        {
            try
            {
                DataTable dt = _model.GetAllHopDong();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "BaoCaoHopDong");
                    wb.SaveAs(filePath);
                }
                _view.ShowMessage("Xuất báo cáo Excel thành công tại: " + filePath);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Lỗi khi xuất file Excel: " + ex.Message);
            }
        }
    }
}
