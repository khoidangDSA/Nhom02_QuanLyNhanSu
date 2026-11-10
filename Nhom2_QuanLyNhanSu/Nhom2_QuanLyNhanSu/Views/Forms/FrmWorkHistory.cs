using System;
using System.Drawing;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmWorkHistory : Form, IWorkHistoryView
    {
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        private string _currentRole;
        private string _message;
        private bool _isSuccessful;

        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }
        public bool IsSuccessful { get => _isSuccessful; set => _isSuccessful = value; }
        public string Message { get => _message; set => _message = value; }

        public FrmWorkHistory() : this("hr") { }

        public FrmWorkHistory(string role)
        {
            InitializeComponent();
            _currentRole = role;

            if (_currentRole == "hr")
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.LightGray;
            }

            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            dgvWorkHistory.DoubleClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };

            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi quá trình công tác này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
        }

        public void SetWorkHistoryListBindingSource(BindingSource source)
        {
            dgvWorkHistory.DataSource = source;

            // Ẩn các cột khóa nội bộ
            if (dgvWorkHistory.Columns.Contains("Id")) dgvWorkHistory.Columns["Id"].Visible = false;
            if (dgvWorkHistory.Columns.Contains("EmployeeId")) dgvWorkHistory.Columns["EmployeeId"].Visible = false;
            if (dgvWorkHistory.Columns.Contains("EventType")) dgvWorkHistory.Columns["EventType"].Visible = false;

            // Đổi tiêu đề tiếng Việt
            if (dgvWorkHistory.Columns.Contains("EmployeeCode"))
                dgvWorkHistory.Columns["EmployeeCode"].HeaderText = "Mã NV";
            if (dgvWorkHistory.Columns.Contains("EmployeeName"))
                dgvWorkHistory.Columns["EmployeeName"].HeaderText = "Họ và tên";
            if (dgvWorkHistory.Columns.Contains("EventTypeName"))
                dgvWorkHistory.Columns["EventTypeName"].HeaderText = "Loại sự kiện";
            if (dgvWorkHistory.Columns.Contains("EventDate"))
            {
                dgvWorkHistory.Columns["EventDate"].HeaderText = "Ngày thực hiện";
                dgvWorkHistory.Columns["EventDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvWorkHistory.Columns.Contains("FromDepartmentName"))
                dgvWorkHistory.Columns["FromDepartmentName"].HeaderText = "Phòng ban cũ";
            if (dgvWorkHistory.Columns.Contains("ToDepartmentName"))
                dgvWorkHistory.Columns["ToDepartmentName"].HeaderText = "Phòng ban mới";
            if (dgvWorkHistory.Columns.Contains("FromPositionName"))
                dgvWorkHistory.Columns["FromPositionName"].HeaderText = "Chức vụ cũ";
            if (dgvWorkHistory.Columns.Contains("ToPositionName"))
                dgvWorkHistory.Columns["ToPositionName"].HeaderText = "Chức vụ mới";
            if (dgvWorkHistory.Columns.Contains("Note"))
                dgvWorkHistory.Columns["Note"].HeaderText = "Ghi chú";
            string[] hiddenColumns = {
                "FromDepartmentId", "FromDepartment",
                "ToDepartmentId", "ToDepartment",
                "FromPositionId", "FromPosition",
                "ToPositionId", "ToPosition"
            };

            foreach (var colName in hiddenColumns)
            {
                if (dgvWorkHistory.Columns.Contains(colName))
                {
                    dgvWorkHistory.Columns[colName].Visible = false;
                }
            }
        }
    }
}