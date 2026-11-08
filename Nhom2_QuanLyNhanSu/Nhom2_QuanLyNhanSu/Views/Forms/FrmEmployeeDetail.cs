using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmEmployeeDetail : Form, IEmployeeDetailView
    {
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private bool _isSuccessful;
        private string _message;

        public FrmEmployeeDetail()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            InitDefaultValues();
        }

        private void InitDefaultValues()
        {
            // Thiết lập giá trị mặc định cho ComboBox Giới tính
            if (cmbGioiTinh.Items.Count == 0)
            {
                cmbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            }
            if (cmbGioiTinh.SelectedIndex < 0) cmbGioiTinh.SelectedIndex = 0;

            // Thiết lập trạng thái nếu có cmbTrangThai trên Designer
            // (0: Đang làm việc, 1: Đã nghỉ việc, 2: Nghỉ dài hạn)
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Nút Lưu: Chỉ đóng khi Presenter lưu thành công
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (_isSuccessful)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            // Nút Hủy
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            // Tải ảnh đại diện
            btnUploadImage.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        picAvatar.Image = Image.FromFile(ofd.FileName);
                        AvatarPath = ofd.FileName;
                    }
                }
            };
        }

        // --- CÁC THUỘC TÍNH (PROPERTIES) CHUẨN CSDL ---

        public int Id { get; set; } // Dùng để xác định bản ghi khi Sửa

        public bool IsEdit { get; set; } // True: Sửa, False: Thêm mới

        public string MaNV
        {
            get => txtMaNV.Text.Trim();
            set
            {
                txtMaNV.Text = value;
                if (IsEdit) txtMaNV.ReadOnly = true; // Khóa mã nhân viên khi sửa
            }
        }

        public string HoTen
        {
            get => txtHoTen.Text.Trim();
            set => txtHoTen.Text = value;
        }

        public int GioiTinh
        {
            get => cmbGioiTinh.SelectedIndex == 1 ? 1 : 0; // 0 = Nam, 1 = Nữ
            set => cmbGioiTinh.SelectedIndex = (value == 1) ? 1 : 0;
        }

        public DateTime NgaySinh
        {
            get => dtpNgaySinh.Value;
            set => dtpNgaySinh.Value = value;
        }

        public string CCCD
        {
            get => txtCCCD.Text.Trim();
            set => txtCCCD.Text = value;
        }

        public string DienThoai
        {
            get => txtDienThoai.Text.Trim();
            set => txtDienThoai.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text.Trim();
            set => txtEmail.Text = value;
        }

        public string DiaChi
        {
            get => txtDiaChi.Text.Trim();
            set => txtDiaChi.Text = value;
        }

        public DateTime NgayVaoLam
        {
            get => dtpNgayVaoLam.Value;
            set => dtpNgayVaoLam.Value = value;
        }

        public int TrangThai
        {
            get => cmbTrangThai != null && cmbTrangThai.SelectedIndex >= 0 ? cmbTrangThai.SelectedIndex : 0;
            set
            {
                if (cmbTrangThai != null && value >= 0 && value < cmbTrangThai.Items.Count)
                    cmbTrangThai.SelectedIndex = value;
            }
        }

        public int PhongBanId
        {
            get => cmbPhongBan.SelectedValue != null && int.TryParse(cmbPhongBan.SelectedValue.ToString(), out int id) ? id : 0;
            set => cmbPhongBan.SelectedValue = value;
        }

        public int ChucVuId
        {
            get => cmbChucVu.SelectedValue != null && int.TryParse(cmbChucVu.SelectedValue.ToString(), out int id) ? id : 0;
            set => cmbChucVu.SelectedValue = value;
        }

        public string AvatarPath { get; set; }

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

        // Danh sách nạp vào ComboBox
        public void SetPhongBanList(object dataSource, string displayMember, string valueMember)
        {
            cmbPhongBan.DataSource = dataSource;
            cmbPhongBan.DisplayMember = displayMember;
            cmbPhongBan.ValueMember = valueMember;
        }

        public void SetChucVuList(object dataSource, string displayMember, string valueMember)
        {
            cmbChucVu.DataSource = dataSource;
            cmbChucVu.DisplayMember = displayMember;
            cmbChucVu.ValueMember = valueMember;
        }
    }
}