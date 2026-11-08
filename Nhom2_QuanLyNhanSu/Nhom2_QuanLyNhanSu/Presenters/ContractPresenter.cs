using System;
using System.Data;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Forms;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class ContractPresenter
    {
        private readonly IContractView _view;
        private readonly IContractService _service;
        private readonly BindingSource _contractBindingSource;

        public ContractPresenter(IContractView view, IContractService service)
        {
            _view = view;
            _service = service;
            _contractBindingSource = new BindingSource();

            _view.SearchEvent += SearchContract;
            _view.AddNewEvent += AddNewContract;
            _view.EditEvent += EditContract;
            _view.DeleteEvent += DeleteContract;
            _view.PrintEvent += PrintContract;

            LoadAllContractList();
        }

        private void LoadAllContractList()
        {
            try
            {
                var contractList = _service.GetAll();
                _contractBindingSource.DataSource = contractList;
                _contractBindingSource.ResetBindings(false);
                _view.SetContractListBindingSource(_contractBindingSource);
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi tải danh sách hợp đồng: " + ex.Message;
                MessageBox.Show(_view.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchContract(object sender, EventArgs e)
        {
            bool isDefaultSearch = string.IsNullOrWhiteSpace(_view.SearchValue) ||
                                   _view.SearchValue.Contains("Tìm kiếm");

            if (isDefaultSearch)
            {
                LoadAllContractList();
            }
            else
            {
                try
                {
                    var contractList = _service.GetByValue(_view.SearchValue.Trim());
                    _contractBindingSource.DataSource = contractList;
                    _view.SetContractListBindingSource(_contractBindingSource);
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
        // 1. THÊM MỚI HỢP ĐỒNG (ADD)
        // ==========================================
        private void AddNewContract(object sender, EventArgs e)
        {
            var detailForm = new FrmContractDetail();
            detailForm.IsEdit = false;
            detailForm.Text = "Thêm mới hợp đồng";
            detailForm.lblTitle.Text = "THÊM HỢP ĐỒNG LAO ĐỘNG";

            // Nạp danh sách nhân viên vào ComboBox
            detailForm.LoadEmployeeLookup(_service.GetEmployeeLookup());
            detailForm.cmbType.SelectedIndex = 1; // Mặc định là Có thời hạn

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Add(detailForm.ContractNo, detailForm.EmployeeId, detailForm.ContractType,
                                                detailForm.StartDate, detailForm.EndDate, detailForm.BaseSalary,
                                                detailForm.Note);
                    if (success)
                    {
                        MessageBox.Show("Thêm mới hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm hợp đồng. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllContractList();
            }
        }

        // ==========================================
        // 2. CHỈNH SỬA HỢP ĐỒNG (EDIT)
        // ==========================================
        private void EditContract(object sender, EventArgs e)
        {
            if (_contractBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)_contractBindingSource.Current;
            var detailForm = new FrmContractDetail();
            detailForm.IsEdit = true;
            detailForm.Text = "Cập nhật hợp đồng";
            detailForm.lblTitle.Text = "CẬP NHẬT HỢP ĐỒNG LAO ĐỘNG";

            detailForm.LoadEmployeeLookup(_service.GetEmployeeLookup());

            // Đổ dữ liệu từ hàng được chọn vào form chi tiết
            detailForm.ContractId = Convert.ToInt32(row["Id"]);
            detailForm.txtContractNo.Text = row["ContractNo"].ToString();
            detailForm.cmbEmployee.SelectedValue = Convert.ToInt32(row["EmployeeId"]);
            detailForm.cmbType.SelectedIndex = Convert.ToInt32(row["Type"]);
            detailForm.dtpStartDate.Value = Convert.ToDateTime(row["StartDate"]);

            if (row["EndDate"] == DBNull.Value || row["EndDate"] == null)
            {
                detailForm.chkNoEndDate.Checked = true;
            }
            else
            {
                detailForm.chkNoEndDate.Checked = false;
                detailForm.dtpEndDate.Value = Convert.ToDateTime(row["EndDate"]);
            }

            detailForm.txtSalary.Text = Convert.ToDecimal(row["BaseSalary"]).ToString("N0");
            detailForm.txtNote.Text = row["Note"] != DBNull.Value ? row["Note"].ToString() : string.Empty;

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Update(detailForm.ContractId, detailForm.ContractNo, detailForm.EmployeeId,
                                                   detailForm.ContractType, detailForm.StartDate, detailForm.EndDate,
                                                   detailForm.BaseSalary, detailForm.Note);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật hợp đồng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllContractList();
            }
        }

        // ==========================================
        // 3. XÓA HỢP ĐỒNG (DELETE)
        // ==========================================
        private void DeleteContract(object sender, EventArgs e)
        {
            if (_contractBindingSource.Current == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Vui lòng chọn hợp đồng cần xóa!";
                return;
            }

            try
            {
                var row = (DataRowView)_contractBindingSource.Current;
                int contractId = Convert.ToInt32(row["Id"]);
                string contractNo = row["ContractNo"].ToString();

                bool success = _service.Delete(contractId);
                _view.IsSuccessful = success;

                if (success)
                {
                    _view.Message = $"Đã xóa thành công hợp đồng số: {contractNo}";
                    LoadAllContractList();
                }
                else
                {
                    _view.Message = "Không thể xóa hợp đồng này.";
                }
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi khi xóa hợp đồng: " + ex.Message;
            }
        }

        private void PrintContract(object sender, EventArgs e)
        {
            if (_contractBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xuất in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)_contractBindingSource.Current;
            string contractNo = row["ContractNo"]?.ToString() ?? "HD";
            MessageBox.Show($"Đang chuẩn bị file in hợp đồng số {contractNo}...", "In hợp đồng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}