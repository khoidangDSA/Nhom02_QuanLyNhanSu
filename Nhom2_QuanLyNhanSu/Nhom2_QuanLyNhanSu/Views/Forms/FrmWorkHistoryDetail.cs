using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmWorkHistoryDetail : Form
    {
        public int HistoryId { get; set; }
        public bool IsEdit { get; set; }

        public int EmployeeId => cmbEmployee.SelectedValue != null ? Convert.ToInt32(cmbEmployee.SelectedValue) : 0;
        public int EventType => cmbEventType.SelectedIndex >= 0 ? cmbEventType.SelectedIndex : 0;
        public DateTime EventDate => dtpEventDate.Value.Date;
        public int? FromDepartmentId => cmbFromDepartment.SelectedValue != null && Convert.ToInt32(cmbFromDepartment.SelectedValue) > 0 ? Convert.ToInt32(cmbFromDepartment.SelectedValue) : null;
        public int? ToDepartmentId => cmbToDepartment.SelectedValue != null && Convert.ToInt32(cmbToDepartment.SelectedValue) > 0 ? Convert.ToInt32(cmbToDepartment.SelectedValue) : null;
        public int? FromPositionId => cmbFromPosition.SelectedValue != null && Convert.ToInt32(cmbFromPosition.SelectedValue) > 0 ? Convert.ToInt32(cmbFromPosition.SelectedValue) : null;
        public int? ToPositionId => cmbToPosition.SelectedValue != null && Convert.ToInt32(cmbToPosition.SelectedValue) > 0 ? Convert.ToInt32(cmbToPosition.SelectedValue) : null;
        public string Note => txtNote.Text.Trim();

        public event EventHandler SaveEvent;

        public FrmWorkHistoryDetail()
        {
            InitializeComponent();

            btnSave.Click += (s, e) =>
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveEvent?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        public void LoadLookups(DataTable dtEmployees, DataTable dtDepartments, DataTable dtPositions)
        {
            // Nhân viên
            cmbEmployee.DataSource = dtEmployees;
            cmbEmployee.DisplayMember = "DisplayName";
            cmbEmployee.ValueMember = "Id";

            // Phòng ban cũ
            var dtDeptFrom = dtDepartments.Copy();
            cmbFromDepartment.DataSource = dtDeptFrom;
            cmbFromDepartment.DisplayMember = "Name";
            cmbFromDepartment.ValueMember = "Id";

            // Phòng ban mới
            var dtDeptTo = dtDepartments.Copy();
            cmbToDepartment.DataSource = dtDeptTo;
            cmbToDepartment.DisplayMember = "Name";
            cmbToDepartment.ValueMember = "Id";

            // Chức vụ cũ
            var dtPosFrom = dtPositions.Copy();
            cmbFromPosition.DataSource = dtPosFrom;
            cmbFromPosition.DisplayMember = "Name";
            cmbFromPosition.ValueMember = "Id";

            // Chức vụ mới
            var dtPosTo = dtPositions.Copy();
            cmbToPosition.DataSource = dtPosTo;
            cmbToPosition.DisplayMember = "Name";
            cmbToPosition.ValueMember = "Id";
        }
    }
}