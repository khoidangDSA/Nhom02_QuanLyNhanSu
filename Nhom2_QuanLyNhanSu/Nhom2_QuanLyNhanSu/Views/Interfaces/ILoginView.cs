namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        // 🔥 Bổ sung thêm dòng này để interface nhận diện UserRole
        string UserRole { get; set; }

        void ShowError(string message);
        void CloseWithSuccess();

        event EventHandler LoginRequested;
    }
}