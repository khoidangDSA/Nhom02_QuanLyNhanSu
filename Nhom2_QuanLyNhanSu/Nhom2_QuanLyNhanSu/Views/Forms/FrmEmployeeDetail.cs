using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmEmployeeDetail : Form, IEmployeeDetailView
    {
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private bool _isSuccessful;
        private string _message;

        // Lưu đường dẫn file ảnh gốc được người dùng chọn từ máy tính
        private string _selectedSourceImagePath = string.Empty;
        private string _avatarPath = string.Empty;

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
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Nút Lưu: Xử lý lưu ảnh vào thư mục Images trước, rồi mới bắn SaveEvent để Presenter lưu vào CSDL
            btnSave.Click += delegate
            {
                SaveAvatarImage();

                // KIỂM TRA TẠM: Nếu hiện ra chuỗi rỗng tức là SaveAvatarImage() chưa chạy thành công
                MessageBox.Show("AvatarPath hiện tại: [" + AvatarPath + "]", "Kiểm tra View");

                SaveEvent?.Invoke(this, EventArgs.Empty);

                if (_isSuccessful)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (!string.IsNullOrEmpty(_message))
                {
                    MessageBox.Show(_message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            // Nút Hủy
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            // Nút Tải ảnh lên
            btnUploadImage.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Chọn ảnh đại diện nhân viên";
                    ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _selectedSourceImagePath = ofd.FileName;

                            // Đọc dữ liệu ra MemoryStream để giải phóng ngay file gốc trên đĩa cứng
                            byte[] imageBytes = File.ReadAllBytes(_selectedSourceImagePath);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                if (picAvatar.Image != null)
                                {
                                    picAvatar.Image.Dispose();
                                    picAvatar.Image = null;
                                }
                                picAvatar.Image = Image.FromStream(ms);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Sao chép tệp ảnh đã chọn vào thư mục Images của ứng dụng và cập nhật lại AvatarPath
        /// </summary>
        private void SaveAvatarImage()
        {
            // Nếu không chọn ảnh mới từ máy tính thì không làm gì cả
            if (string.IsNullOrEmpty(_selectedSourceImagePath) || !File.Exists(_selectedSourceImagePath))
            {
                return;
            }

            try
            {
                // Tạo thư mục Images trong thư mục build chạy ứng dụng
                string folderImages = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(folderImages))
                {
                    Directory.CreateDirectory(folderImages);
                }

                // Tạo tên file: ví dụ NV001_20261110.png để tránh trùng và tránh bị khóa file
                string extension = Path.GetExtension(_selectedSourceImagePath);
                string safeCode = string.IsNullOrWhiteSpace(MaNV) ? "EMP" : MaNV;
                string newFileName = $"{safeCode}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                string destinationPath = Path.Combine(folderImages, newFileName);

                // Copy file ảnh mới sang thư mục đích
                File.Copy(_selectedSourceImagePath, destinationPath, true);

                // Cập nhật lại AvatarPath để Presenter lấy giá trị này lưu xuống Database
                this.AvatarPath = newFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao chép tệp ảnh: " + ex.Message, "Lỗi lưu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public string AvatarPath
        {
            get => _avatarPath;
            set
            {
                _avatarPath = value;

                if (!string.IsNullOrEmpty(_avatarPath))
                {
                    // Kiểm tra đường dẫn tuyệt đối hoặc tương đối trong thư mục Images
                    string fullPath = Path.IsPathRooted(_avatarPath)
                        ? _avatarPath
                        : Path.Combine(Application.StartupPath, "Images", _avatarPath);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            if (picAvatar.Image != null)
                            {
                                picAvatar.Image.Dispose();
                                picAvatar.Image = null;
                            }

                            // Đọc qua byte array để không lock file
                            byte[] bytes = File.ReadAllBytes(fullPath);
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                picAvatar.Image = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            picAvatar.Image = null;
                        }
                        return;
                    }
                }

                // Nếu không có ảnh hoặc đường dẫn không tồn tại
                if (picAvatar.Image != null)
                {
                    picAvatar.Image.Dispose();
                    picAvatar.Image = null;
                }
            }
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