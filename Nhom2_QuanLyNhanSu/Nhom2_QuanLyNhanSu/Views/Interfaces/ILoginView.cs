namespace Nhom2_QuanLyNhanSu.Views.Interfaces;

public interface ILoginView
{
    string Username { get; }
    string Password { get; }

    event EventHandler LoginRequested;

    void ShowError(string message);
    void CloseWithSuccess();
}