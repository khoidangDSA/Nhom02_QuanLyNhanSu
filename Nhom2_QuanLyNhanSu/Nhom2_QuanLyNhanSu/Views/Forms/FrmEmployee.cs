using System;
using System.Drawing;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Views.Interfaces;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmEmployee : Form, IEmployeeView
    {
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;

        private string _currentRole;
        private string _message;
        private bool _isSuccessful;

        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }
        public bool IsSuccessful { get => _isSuccessful; set => _isSuccessful = value; }
        public string Message { get => _message; set => _message = value; }

        public FrmEmployee() : this("hr") { }

        public FrmEmployee(string role)
        {
            InitializeComponent();
            _currentRole = role;

            if (_currentRole == "hr")
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.LightGray;
            }

            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            dgvEmployees.DoubleClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };

            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnPrint.Click += delegate { PrintEvent?.Invoke(this, EventArgs.Empty); };
        }

        public void SetEmployeeListBindingSource(BindingSource employeeList)
        {
            dgvEmployees.DataSource = employeeList;

            // Ẩn các ID kỹ thuật
            if (dgvEmployees.Columns.Contains("Id")) dgvEmployees.Columns["Id"].Visible = false;
            if (dgvEmployees.Columns.Contains("DepartmentId")) dgvEmployees.Columns["DepartmentId"].Visible = false;
            if (dgvEmployees.Columns.Contains("PositionId")) dgvEmployees.Columns["PositionId"].Visible = false;
            if (dgvEmployees.Columns.Contains("PhotoPath")) dgvEmployees.Columns["PhotoPath"].Visible = false;
            if (dgvEmployees.Columns.Contains("Status") && dgvEmployees.Columns.Contains("StatusStr"))
                dgvEmployees.Columns["Status"].Visible = false;

            // Đổi tiêu đề tiếng Việt
            if (dgvEmployees.Columns.Contains("Code")) dgvEmployees.Columns["Code"].HeaderText = "Mã NV";
            if (dgvEmployees.Columns.Contains("FullName")) dgvEmployees.Columns["FullName"].HeaderText = "Họ và tên";
            if (dgvEmployees.Columns.Contains("GenderStr")) dgvEmployees.Columns["GenderStr"].HeaderText = "Giới tính";
            else if (dgvEmployees.Columns.Contains("Gender")) dgvEmployees.Columns["Gender"].HeaderText = "Giới tính";

            if (dgvEmployees.Columns.Contains("BirthDate"))
            {
                dgvEmployees.Columns["BirthDate"].HeaderText = "Ngày sinh";
                dgvEmployees.Columns["BirthDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvEmployees.Columns.Contains("IdCard")) dgvEmployees.Columns["IdCard"].HeaderText = "CCCD/CMND";
            if (dgvEmployees.Columns.Contains("Phone")) dgvEmployees.Columns["Phone"].HeaderText = "Số ĐT";
            if (dgvEmployees.Columns.Contains("Email")) dgvEmployees.Columns["Email"].HeaderText = "Email";
            if (dgvEmployees.Columns.Contains("Address")) dgvEmployees.Columns["Address"].HeaderText = "Địa chỉ";
            if (dgvEmployees.Columns.Contains("DepartmentName")) dgvEmployees.Columns["DepartmentName"].HeaderText = "Phòng ban";
            if (dgvEmployees.Columns.Contains("PositionName")) dgvEmployees.Columns["PositionName"].HeaderText = "Chức vụ";

            if (dgvEmployees.Columns.Contains("HireDate"))
            {
                dgvEmployees.Columns["HireDate"].HeaderText = "Ngày vào làm";
                dgvEmployees.Columns["HireDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvEmployees.Columns.Contains("StatusStr")) dgvEmployees.Columns["StatusStr"].HeaderText = "Trạng thái";
            else if (dgvEmployees.Columns.Contains("Status")) dgvEmployees.Columns["Status"].HeaderText = "Trạng thái";
        }
    }
}