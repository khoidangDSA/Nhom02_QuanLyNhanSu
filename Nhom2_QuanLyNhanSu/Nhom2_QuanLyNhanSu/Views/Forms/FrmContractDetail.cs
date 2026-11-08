using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmContractDetail : Form
    {
        public int ContractId { get; set; }
        public bool IsEdit { get; set; }

        public string ContractNo => txtContractNo.Text.Trim();
        public int EmployeeId => cmbEmployee.SelectedValue != null ? Convert.ToInt32(cmbEmployee.SelectedValue) : 0;
        public int ContractType => cmbType.SelectedIndex >= 0 ? cmbType.SelectedIndex : 1;
        public DateTime StartDate => dtpStartDate.Value.Date;
        public DateTime? EndDate => chkNoEndDate.Checked ? null : dtpEndDate.Value.Date;
        public decimal BaseSalary => decimal.TryParse(txtSalary.Text.Replace(".", "").Replace(",", "").Trim(), out decimal s) ? s : 0;
        public string Note => txtNote.Text.Trim();

        public event EventHandler SaveEvent;

        public FrmContractDetail()
        {
            InitializeComponent();

            chkNoEndDate.CheckedChanged += (s, e) =>
            {
                dtpEndDate.Enabled = !chkNoEndDate.Checked;
            };

            cmbType.SelectedIndexChanged += (s, e) =>
            {
                // Nếu chọn loại 2: "Không thời hạn" -> Tự tích vô thời hạn
                if (cmbType.SelectedIndex == 2)
                    chkNoEndDate.Checked = true;
            };

            txtSalary.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtContractNo.Text))
                {
                    MessageBox.Show("Vui lòng nhập số hợp đồng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContractNo.Focus();
                    return;
                }

                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (BaseSalary <= 0)
                {
                    MessageBox.Show("Vui lòng nhập mức lương cơ bản hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalary.Focus();
                    return;
                }

                SaveEvent?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        public void LoadEmployeeLookup(DataTable dt)
        {
            cmbEmployee.DataSource = dt;
            cmbEmployee.DisplayMember = "DisplayName";
            cmbEmployee.ValueMember = "Id";
        }
    }
}