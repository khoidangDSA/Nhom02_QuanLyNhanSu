using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmContract : Form, IContractView
    {
        // --- CÁC SỰ KIỆN MVP ---
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent; // Sự kiện riêng cho Hợp đồng

        private string _currentRole;
        private string _message;
        private bool _isSuccessful;

        public FrmContract(string role)
        {
            InitializeComponent();
            _currentRole = role;

            ApplyRolePermissions();
            AssociateAndRaiseViewEvents();
        }

        // Xử lý phân quyền (Khóa nút Xóa với tài khoản HR)
        private void ApplyRolePermissions()
        {
            if (_currentRole == "hr")
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.LightGray;
            }
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Tìm kiếm
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Thêm mới
            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };

            // Chỉnh sửa
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            dgvContracts.DoubleClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };

            // Xóa
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message);
                }
            };

            // In Hợp đồng
            btnPrint.Click += delegate { PrintEvent?.Invoke(this, EventArgs.Empty); };
        }

        // --- CÁC THUỘC TÍNH (PROPERTIES) CHO PRESENTER ---

        public string SearchValue
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public bool IsSuccessful
        {
            get => _isSuccessful;
            set => _isSuccessful = value;
        }

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        // Đổ dữ liệu Hợp đồng từ Database vào DataGridView
        public void SetContractListBindingSource(BindingSource contractList)
        {
            dgvContracts.DataSource = contractList;

            // 1. Ẩn các cột ID và mã số nội bộ để giao diện gọn gàng
            if (dgvContracts.Columns.Contains("Id")) dgvContracts.Columns["Id"].Visible = false;
            if (dgvContracts.Columns.Contains("EmployeeId")) dgvContracts.Columns["EmployeeId"].Visible = false;
            if (dgvContracts.Columns.Contains("Type")) dgvContracts.Columns["Type"].Visible = false;

            // 2. Đổi Header hiển thị sang tiếng Việt
            if (dgvContracts.Columns.Contains("ContractNo"))
                dgvContracts.Columns["ContractNo"].HeaderText = "Số HĐ";

            if (dgvContracts.Columns.Contains("EmployeeCode"))
                dgvContracts.Columns["EmployeeCode"].HeaderText = "Mã NV";

            if (dgvContracts.Columns.Contains("EmployeeName"))
                dgvContracts.Columns["EmployeeName"].HeaderText = "Họ và tên";

            if (dgvContracts.Columns.Contains("ContractTypeStr"))
                dgvContracts.Columns["ContractTypeStr"].HeaderText = "Loại hợp đồng";

            if (dgvContracts.Columns.Contains("StartDate"))
            {
                dgvContracts.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
                dgvContracts.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvContracts.Columns.Contains("EndDate"))
            {
                dgvContracts.Columns["EndDate"].HeaderText = "Ngày kết thúc";
                dgvContracts.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvContracts.Columns.Contains("BaseSalary"))
            {
                dgvContracts.Columns["BaseSalary"].HeaderText = "Lương cơ bản";
                dgvContracts.Columns["BaseSalary"].DefaultCellStyle.Format = "N0";
            }

            if (dgvContracts.Columns.Contains("Note"))
                dgvContracts.Columns["Note"].HeaderText = "Ghi chú";
        }
    }
}