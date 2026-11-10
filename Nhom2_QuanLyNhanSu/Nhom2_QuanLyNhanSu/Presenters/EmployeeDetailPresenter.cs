using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Models.Filters;
using Nhom2_QuanLyNhanSu.Repositories;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class EmployeeDetailPresenter
    {
        private readonly IEmployeeDetailView _view;
        private readonly IEmployeeRepository _repository;

        public EmployeeDetailPresenter(IEmployeeDetailView view, IEmployeeRepository repository)
        {
            _view = view;
            _repository = repository;

            // Đăng ký nhận sự kiện Lưu từ Form
            _view.SaveEvent += OnSaveEmployee;
        }

        private void OnSaveEmployee(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra tính hợp lệ cơ bản
                if (string.IsNullOrWhiteSpace(_view.MaNV))
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Mã nhân viên không được để trống!";
                    return;
                }

                if (string.IsNullOrWhiteSpace(_view.HoTen))
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Họ và tên nhân viên không được để trống!";
                    return;
                }

                // 2. Map dữ liệu từ View sang đúng model Employee
                var employee = new Employee
                {
                    Id = _view.Id,
                    Code = _view.MaNV,
                    FullName = _view.HoTen,
                    Gender = (Gender)_view.GioiTinh,
                    BirthDate = _view.NgaySinh,
                    IdCard = _view.CCCD,
                    Phone = _view.DienThoai,
                    Email = _view.Email,
                    Address = _view.DiaChi,
                    HireDate = _view.NgayVaoLam,
                    Status = (EmployeeStatus)_view.TrangThai,
                    DepartmentId = _view.PhongBanId,
                    PositionId = _view.ChucVuId,

                    // Lưu tên file ảnh vào PhotoPath của Employee
                    PhotoPath = _view.AvatarPath
                };

                // 3. Thực hiện Thêm mới hoặc Cập nhật
                if (_view.IsEdit)
                {
                    _repository.Update(employee);
                    _view.Message = "Cập nhật hồ sơ nhân viên thành công!";
                }
                else
                {
                    _repository.Add(employee);
                    _view.Message = "Thêm mới nhân viên thành công!";
                }

                _view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi khi lưu nhân viên: " + ex.Message;
            }
        }
    }
}