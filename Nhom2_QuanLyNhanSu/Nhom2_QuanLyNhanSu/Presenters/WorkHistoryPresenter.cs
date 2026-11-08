using System;
using System.Data;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Services.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using Nhom2_QuanLyNhanSu.Views.Forms;

namespace Nhom2_QuanLyNhanSu.Presenters
{
    public class WorkHistoryPresenter
    {
        private readonly IWorkHistoryView _view;
        private readonly IWorkHistoryService _service;
        private readonly BindingSource _workHistoryBindingSource;

        public WorkHistoryPresenter(IWorkHistoryView view, IWorkHistoryService service)
        {
            _view = view;
            _service = service;
            _workHistoryBindingSource = new BindingSource();

            _view.SearchEvent += SearchWorkHistory;
            _view.AddNewEvent += AddNewWorkHistory;
            _view.EditEvent += EditWorkHistory;
            _view.DeleteEvent += DeleteWorkHistory;

            LoadAllWorkHistoryList();
        }

        private void LoadAllWorkHistoryList()
        {
            try
            {
                var list = _service.GetAll();
                _workHistoryBindingSource.DataSource = list;
                _workHistoryBindingSource.ResetBindings(false);
                _view.SetWorkHistoryListBindingSource(_workHistoryBindingSource);
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi tải quá trình công tác: " + ex.Message;
                MessageBox.Show(_view.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchWorkHistory(object sender, EventArgs e)
        {
            bool isDefaultSearch = string.IsNullOrWhiteSpace(_view.SearchValue) ||
                                   _view.SearchValue.Contains("Tìm kiếm");

            if (isDefaultSearch)
            {
                LoadAllWorkHistoryList();
            }
            else
            {
                try
                {
                    var list = _service.GetByValue(_view.SearchValue.Trim());
                    _workHistoryBindingSource.DataSource = list;
                    _view.SetWorkHistoryListBindingSource(_workHistoryBindingSource);
                }
                catch (Exception ex)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Lỗi tìm kiếm: " + ex.Message;
                    MessageBox.Show(_view.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AddNewWorkHistory(object sender, EventArgs e)
        {
            var detailForm = new FrmWorkHistoryDetail();
            detailForm.IsEdit = false;
            detailForm.Text = "Thêm quá trình công tác";
            detailForm.lblTitle.Text = "THÊM QUÁ TRÌNH CÔNG TÁC";

            detailForm.LoadLookups(_service.GetEmployeeLookup(), _service.GetDepartmentLookup(), _service.GetPositionLookup());
            detailForm.cmbEventType.SelectedIndex = 1; // Mặc định là Điều chuyển

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Add(detailForm.EmployeeId, detailForm.EventType, detailForm.EventDate,
                                                detailForm.FromDepartmentId, detailForm.ToDepartmentId,
                                                detailForm.FromPositionId, detailForm.ToPositionId,
                                                detailForm.Note);
                    if (success)
                    {
                        MessageBox.Show("Thêm mới quá trình công tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm bản ghi này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllWorkHistoryList();
            }
        }

        private void EditContract(object sender, EventArgs e) => EditWorkHistory(sender, e);

        private void EditWorkHistory(object sender, EventArgs e)
        {
            if (_workHistoryBindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn dòng công tác cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (DataRowView)_workHistoryBindingSource.Current;
            var detailForm = new FrmWorkHistoryDetail();
            detailForm.IsEdit = true;
            detailForm.Text = "Cập nhật quá trình công tác";
            detailForm.lblTitle.Text = "CẬP NHẬT QUÁ TRÌNH CÔNG TÁC";

            detailForm.LoadLookups(_service.GetEmployeeLookup(), _service.GetDepartmentLookup(), _service.GetPositionLookup());

            detailForm.HistoryId = Convert.ToInt32(row["Id"]);
            detailForm.cmbEmployee.SelectedValue = Convert.ToInt32(row["EmployeeId"]);
            detailForm.cmbEventType.SelectedIndex = Convert.ToInt32(row["EventType"]);
            detailForm.dtpEventDate.Value = Convert.ToDateTime(row["EventDate"]);

            detailForm.cmbFromDepartment.SelectedValue = row["FromDepartmentId"] != DBNull.Value ? Convert.ToInt32(row["FromDepartmentId"]) : 0;
            detailForm.cmbToDepartment.SelectedValue = row["ToDepartmentId"] != DBNull.Value ? Convert.ToInt32(row["ToDepartmentId"]) : 0;
            detailForm.cmbFromPosition.SelectedValue = row["FromPositionId"] != DBNull.Value ? Convert.ToInt32(row["FromPositionId"]) : 0;
            detailForm.cmbToPosition.SelectedValue = row["ToPositionId"] != DBNull.Value ? Convert.ToInt32(row["ToPositionId"]) : 0;

            detailForm.txtNote.Text = row["Note"] != DBNull.Value ? row["Note"].ToString() : string.Empty;

            detailForm.SaveEvent += (s, ev) =>
            {
                try
                {
                    bool success = _service.Update(detailForm.HistoryId, detailForm.EmployeeId, detailForm.EventType,
                                                   detailForm.EventDate, detailForm.FromDepartmentId, detailForm.ToDepartmentId,
                                                   detailForm.FromPositionId, detailForm.ToPositionId, detailForm.Note);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        detailForm.DialogResult = DialogResult.OK;
                        detailForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật bản ghi này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllWorkHistoryList();
            }
        }

        private void DeleteWorkHistory(object sender, EventArgs e)
        {
            if (_workHistoryBindingSource.Current == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Vui lòng chọn bản ghi cần xóa!";
                return;
            }

            try
            {
                var row = (DataRowView)_workHistoryBindingSource.Current;
                int id = Convert.ToInt32(row["Id"]);

                bool success = _service.Delete(id);
                _view.IsSuccessful = success;

                if (success)
                {
                    _view.Message = "Đã xóa bản ghi công tác thành công!";
                    LoadAllWorkHistoryList();
                }
                else
                {
                    _view.Message = "Không thể xóa bản ghi này.";
                }
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "Lỗi khi xóa: " + ex.Message;
            }
        }
    }
}