using System;
using System.Collections.Generic;
using System.Linq; // Fix lỗi FirstOrDefault
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class PositionPresenter
    {
        private readonly IPositionView _view;
        private readonly IPositionService _service;
        private List<Position> _positions = new();

        public PositionPresenter(IPositionView view, IPositionService service)
        {
            _view = view;
            _service = service;

            _view.LoadData += (s, e) => Run(Refresh);
            _view.SearchRequested += (s, e) => Run(Refresh);
            _view.AddRequested += (s, e) => Run(Add);
            _view.UpdateRequested += (s, e) => Run(Update);
            _view.DeleteRequested += (s, e) => Run(Delete);
            _view.ClearRequested += (s, e) => _view.ClearInput();
            _view.SelectionChanged += (s, e) => OnSelectionChanged();
        }

        private void Refresh()
        {
            // Gọi đúng tên hàm SearchPositions trong Service
            _positions = _service.Search(_view.SearchKeyword);
            _view.ShowPositions(_positions);
        }

        private void OnSelectionChanged()
        {
            var p = _positions.FirstOrDefault(x => x.Id == _view.SelectedId);
            if (p == null) return;

            _view.PositionCode = p.Code;
            _view.PositionName = p.Name;
            _view.Allowance = p.Allowance; // Gán thẳng decimal, không gán string
            _view.Description = p.Description ?? "";
        }

        private void Add()
        {
            var p = new Position
            {
                Code = _view.PositionCode,
                Name = _view.PositionName,
                Allowance = _view.Allowance, // Lấy trực tiếp decimal từ View
                Description = _view.Description
            };

            // Gọi đúng tên hàm AddPosition
            _service.Add(p);
            Refresh();
            _view.ClearInput();
            _view.ShowMessage("Thêm chức vụ thành công.");
        }

        private void Update()
        {
            var current = _positions.FirstOrDefault(x => x.Id == _view.SelectedId);
            if (current == null)
            {
                _view.ShowError("Vui lòng chọn chức vụ cần sửa.");
                return;
            }

            var p = new Position
            {
                Id = current.Id,
                Code = _view.PositionCode,
                Name = _view.PositionName,
                Allowance = _view.Allowance, // Lấy trực tiếp decimal từ View
                Description = _view.Description
            };

            // Gọi đúng tên hàm UpdatePosition
            _service.Update(p);
            Refresh();
            _view.ClearInput();
            _view.ShowMessage("Cập nhật chức vụ thành công.");
        }

        private void Delete()
        {
            var current = _positions.FirstOrDefault(x => x.Id == _view.SelectedId);
            if (current == null)
            {
                _view.ShowError("Vui lòng chọn chức vụ cần xóa.");
                return;
            }

            if (!_view.Confirm($"Bạn có chắc muốn xóa chức vụ \"{current.Name}\"?")) return;

            // Gọi đúng tên hàm DeletePosition
            _service.Delete(current.Id);
            Refresh();
            _view.ClearInput();
            _view.ShowMessage("Đã xóa chức vụ.");
        }

        private void Run(Action action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException ex)
            {
                _view.ShowError(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowError("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}