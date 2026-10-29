using Nhom2_QuanLyNhanSu.Common.Session;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Presenters;

public class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly IAuthService _service;

    public LoginPresenter(ILoginView view, IAuthService service)
    {
        _view = view;
        _service = service;
        _view.LoginRequested += (s, e) => Login();
    }

    private void Login()
    {
        try
        {
            var account = _service.Login(_view.Username, _view.Password);
            CurrentUser.Set(account);
            _view.CloseWithSuccess();
        }
        catch (InvalidOperationException ex)
        {
            _view.ShowError(ex.Message);
        }
        catch (Exception ex)
        {
            _view.ShowError("Không thể đăng nhập: " + ex.Message);
        }
    }
}