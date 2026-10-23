using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Presenters;

public class DepartmentPresenter
{
    private readonly IDepartmentView _view;
    private readonly IDepartmentService _service;
    private List<Department> _departments = new();

    public DepartmentPresenter(IDepartmentView view, IDepartmentService service)
    {
        _view = view;
        _service = service;

        // Bắt các sự kiện từ View
        _view.LoadData += OnLoadData;
        _view.SearchRequested += OnSearchRequested;
        _view.AddRequested += OnAddRequested;
        _view.UpdateRequested += OnUpdateRequested;
        _view.DeleteRequested += OnDeleteRequested;
        _view.ClearRequested += OnClearRequested;
        _view.SelectionChanged += OnSelectionChanged;
    }

    private void OnLoadData(object? sender, EventArgs e) => LoadAll();

    private void LoadAll()
    {
        try
        {
            _departments = _service.GetAllDepartments();
            _view.ShowDepartments(_departments);
        }
        catch (Exception ex)
        {
            _view.ShowError($"Lỗi tải dữ liệu: {ex.Message}");
        }
    }

    private void OnSearchRequested(object? sender, EventArgs e)
    {
        try
        {
            _departments = _service.SearchDepartments(_view.SearchKeyword);
            _view.ShowDepartments(_departments);
        }
        catch (Exception ex)
        {
            _view.ShowError($"Lỗi tìm kiếm: {ex.Message}");
        }
    }

    private void OnAddRequested(object? sender, EventArgs e)
    {
        try
        {
            var dept = new Department
            {
                Code = _view.DepartmentCode,
                Name = _view.DepartmentName,
                Description = _view.Description
            };

            _service.AddDepartment(dept);
            _view.ShowMessage("Thêm phòng ban thành công!");
            _view.ClearInput();
            LoadAll();
        }
        catch (Exception ex)
        {
            _view.ShowError(ex.Message);
        }
    }

    private void OnUpdateRequested(object? sender, EventArgs e)
    {
        try
        {
            var dept = new Department
            {
                Id = _view.SelectedId,
                Code = _view.DepartmentCode,
                Name = _view.DepartmentName,
                Description = _view.Description
            };

            _service.UpdateDepartment(dept);
            _view.ShowMessage("Cập nhật phòng ban thành công!");
            _view.ClearInput();
            LoadAll();
        }
        catch (Exception ex)
        {
            _view.ShowError(ex.Message);
        }
    }

    private void OnDeleteRequested(object? sender, EventArgs e)
    {
        if (_view.SelectedId <= 0) return;

        if (_view.Confirm("Bạn có chắc chắn muốn xóa phòng ban này không?"))
        {
            try
            {
                _service.DeleteDepartment(_view.SelectedId);
                _view.ShowMessage("Xóa phòng ban thành công!");
                _view.ClearInput();
                LoadAll();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }

    private void OnClearRequested(object? sender, EventArgs e) => _view.ClearInput();

    private void OnSelectionChanged(object? sender, EventArgs e)
    {
        if (_view.SelectedId <= 0) return;

        var selected = _departments.FirstOrDefault(d => d.Id == _view.SelectedId);
        if (selected != null)
        {
            _view.DepartmentCode = selected.Code;
            _view.DepartmentName = selected.Name;
            _view.Description = selected.Description ?? "";
        }
    }
}