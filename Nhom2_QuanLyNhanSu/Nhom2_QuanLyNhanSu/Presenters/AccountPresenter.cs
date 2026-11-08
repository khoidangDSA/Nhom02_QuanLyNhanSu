using System;
using System.Data;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Forms;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class AccountPresenter
    {
        private readonly IAccountView _view;
        private readonly IAccountService _service;
        private readonly BindingSource _accountBindingSource;

        public AccountPresenter(IAccountView view, IAccountService service)
        {
            _view = view;
            _service = service;
            _accountBindingSource = new BindingSource();

            _view.SearchEvent += SearchAccount;
            _view.AddNewEvent += AddNewAccount;
            _view.EditEvent += EditAccount;
            _view.DeleteEvent += DeleteAccount;
            _view.ResetPasswordEvent += ResetPassword;

            LoadAllAccountList();
        }

        private void LoadAllAccountList()
        {
            try
            {
                var list = _service.GetAll();
                _accountBindingSource.DataSource = list;
                _accountBindingSource.ResetBindings(false);
                _view.SetAccountListBindingSource(_accountBindingSource);
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi tải tài khoản: " + ex.Message;
                MessageBox.Show(_view.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchAccount(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SearchValue) || _view.SearchValue.Contains("Tìm kiếm"))
            {
                LoadAllAccountList();
            }
            else
            {
                try
                {
                    var list = _service.GetByValue(_view.SearchValue.Trim());
                    _accountBindingSource.DataSource = list;
                    _view.SetAccountListBindingSource(_accountBindingSource);
                }
                catch (Exception ex)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Lỗi tìm kiếm: " + ex.Message;
                    MessageBox.Show(_view.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ==========================================
        // 1. THÊM TÀI KHOẢN MỚI
        // ==========================================
        private void AddNewAccount(object sender, EventArgs e)
        {
            var detailForm = new FrmAccountDetail();
            detailForm.IsEdit = false;
            detailForm.Text = "Thêm tài khoản mới";
            detailForm.lblTitle.Text = "TẠO TÀI KHOẢN HỆ THỐNG";

            detailForm.LoadEmployeeLookup(_service.GetEmployeeLookup());
            detailForm.cmbRole.SelectedIndex = 1; // Mặc định là HR

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Add(detailForm.Username, detailForm.Password,
                                                detailForm.Role, detailForm.EmployeeId,
                                                detailForm.IsActive);
                    if (success)
                    {
                        MessageBox.Show("Thêm mới tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể tạo tài khoản. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllAccountList();
            }
        }

        // ==========================================
        // 2. CHỈNH SỬA TÀI KHOẢN
        // ==========================================
        private void EditAccount(object sender, EventArgs e)
        {
            if (_accountBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)_accountBindingSource.Current;
            var detailForm = new FrmAccountDetail();
            detailForm.IsEdit = true;
            detailForm.Text = "Cập nhật tài khoản";
            detailForm.lblTitle.Text = "CẬP NHẬT TÀI KHOẢN";

            detailForm.LoadEmployeeLookup(_service.GetEmployeeLookup());

            detailForm.AccountId = Convert.ToInt32(row["Id"]);
            detailForm.txtUsername.Text = row["Username"].ToString();
            detailForm.txtUsername.Enabled = false; // Không cho phép đổi tên đăng nhập

            // Ẩn trường mật khẩu khi sửa (dùng nút Đặt lại mật khẩu riêng)
            detailForm.txtPassword.Enabled = false;
            detailForm.txtPassword.Text = "********";

            detailForm.cmbRole.SelectedIndex = Convert.ToInt32(row["Role"]);
            detailForm.cmbEmployee.SelectedValue = row["EmployeeId"] != DBNull.Value ? Convert.ToInt32(row["EmployeeId"]) : 0;
            detailForm.chkIsActive.Checked = Convert.ToBoolean(row["IsActive"]);

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Update(detailForm.AccountId, detailForm.Role,
                                                   detailForm.EmployeeId, detailForm.IsActive);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllAccountList();
            }
        }

        // ==========================================
        // 3. XÓA TÀI KHOẢN
        // ==========================================
        private void DeleteAccount(object sender, EventArgs e)
        {
            if (_accountBindingSource.Current == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Vui lòng chọn tài khoản cần xóa!";
                return;
            }

            try
            {
                var row = (DataRowView)_accountBindingSource.Current;
                int id = Convert.ToInt32(row["Id"]);
                string username = row["Username"].ToString();

                if (username.ToLower() == "admin")
                {
                    MessageBox.Show("Không được phép xóa tài khoản quản trị tối cao (Admin)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = _service.Delete(id);
                _view.IsSuccessful = success;

                if (success)
                {
                    _view.Message = $"Đã xóa tài khoản '{username}' thành công!";
                    LoadAllAccountList();
                }
                else
                {
                    _view.Message = "Không thể xóa tài khoản này.";
                }
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi khi xóa: " + ex.Message;
            }
        }

        // ==========================================
        // 4. KHÔI PHỤC MẬT KHẨU
        // ==========================================
        private void ResetPassword(object sender, EventArgs e)
        {
            if (_accountBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khôi phục mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)_accountBindingSource.Current;
            int accountId = Convert.ToInt32(row["Id"]);
            string username = row["Username"].ToString();

            var confirm = MessageBox.Show($"Bạn có chắc muốn đặt lại mật khẩu cho tài khoản '{username}' về mặc định là '123456' không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = _service.ResetPassword(accountId, "123456");
                if (success)
                    MessageBox.Show($"Đặt lại mật khẩu cho tài khoản '{username}' thành công! (Mật khẩu mới: 123456)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không thể đặt lại mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}