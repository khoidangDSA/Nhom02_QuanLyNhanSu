using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Presenters;
using Nhom2_QuanLyNhanSu.Repositories;
using Nhom2_QuanLyNhanSu.Services;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmDepartment : Form, IDepartmentView
    {
        private int _selectedId = 0;

        // MÀU CHỦ ĐẠO
        private readonly Color navy = Color.FromArgb(25, 59, 96);
        private readonly Color teal = Color.FromArgb(0, 153, 136);
        private readonly Color blue = Color.FromArgb(30, 126, 210);
        private readonly Color red = Color.FromArgb(220, 65, 65);
        private readonly Color background = Color.FromArgb(241, 246, 251);

        public FrmDepartment()
        {
            InitializeComponent();

            ApplyModernStyle();
            LayoutControls();

            // Đăng ký sự kiện Click nút bấm
            btnAdd.Click += (s, e) => AddRequested?.Invoke(this, EventArgs.Empty);
            btnUpdate.Click += (s, e) => UpdateRequested?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearRequested?.Invoke(this, EventArgs.Empty);
            btnSearch.Click += (s, e) => SearchRequested?.Invoke(this, EventArgs.Empty);

            // Bắt sự kiện chọn dòng trên DataGridView
            dgvDepartment.SelectionChanged += (s, e) =>
            {
                if (dgvDepartment.SelectedRows.Count > 0 &&
                    dgvDepartment.SelectedRows[0].DataBoundItem is Department d)
                {
                    _selectedId = d.Id;
                }
                else
                {
                    _selectedId = 0;
                }
                SelectionChanged?.Invoke(this, EventArgs.Empty);
            };


        }

        #region TRIỂN KHAI IDEPARTMENTVIEW 


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DepartmentCode { get => txtCode.Text.Trim(); set => txtCode.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DepartmentName { get => txtName.Text.Trim(); set => txtName.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description { get => txtDescription.Text.Trim(); set => txtDescription.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchKeyword => txtSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedId => _selectedId;

        // Liên kết sự kiện từ Presenter
        public event EventHandler? LoadData;
        public event EventHandler? SearchRequested;
        public event EventHandler? AddRequested;
        public event EventHandler? UpdateRequested;
        public event EventHandler? DeleteRequested;
        public event EventHandler? ClearRequested;
        public event EventHandler? SelectionChanged;

        public void ClearInput()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            _selectedId = 0;
            dgvDepartment.ClearSelection();
            txtCode.Focus();
        }

        public void ShowMessage(string message) =>
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void ShowError(string message) =>
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public bool Confirm(string message) =>
            MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        #endregion

        #region GIAO DIỆN & LAYOUT

        private void ApplyModernStyle()
        {
            Text = "Quản lý phòng ban";
            BackColor = background;
            ForeColor = navy;
            Font = new Font("Segoe UI", 10F);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1000, 720);
            ClientSize = new Size(1200, 850);

            // Thanh tim kiem
            pnlSearch.BackColor = Color.White;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = navy;

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.BackColor = Color.White;

            StyleButton(btnSearch, teal);

            // Bang du lieu
            dgvDepartment.BackgroundColor = Color.White;
            dgvDepartment.BorderStyle = BorderStyle.None;
            dgvDepartment.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDepartment.GridColor = Color.FromArgb(224, 233, 242);
            dgvDepartment.EnableHeadersVisualStyles = false;

            dgvDepartment.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvDepartment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDepartment.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDepartment.ColumnHeadersDefaultCellStyle.SelectionBackColor = navy;

            dgvDepartment.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDepartment.DefaultCellStyle.ForeColor = Color.FromArgb(40, 55, 75);
            dgvDepartment.DefaultCellStyle.BackColor = Color.White;
            dgvDepartment.DefaultCellStyle.SelectionBackColor = Color.FromArgb(211, 244, 241);
            dgvDepartment.DefaultCellStyle.SelectionForeColor = navy;

            dgvDepartment.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 253);
            dgvDepartment.ColumnHeadersHeight = 42;
            dgvDepartment.RowTemplate.Height = 38;
            dgvDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Khung thong tin
            grpInfo.BackColor = Color.White;
            grpInfo.ForeColor = navy;
            grpInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblCode.ForeColor = navy;
            lblName.ForeColor = navy;
            lblDescription.ForeColor = navy;

            StyleTextBox(txtCode);
            StyleTextBox(txtName);
            StyleTextBox(txtDescription);

            // Cac nut thao tac
            StyleButton(btnAdd, teal);
            StyleButton(btnUpdate, blue);
            StyleButton(btnDelete, red);
            StyleButton(btnClear, Color.FromArgb(235, 241, 248), navy);
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.FromArgb(40, 55, 75);
        }

        private void StyleButton(Button button, Color backColor, Color foreColor = default)
        {
            if (foreColor == default)
                foreColor = Color.White;

            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        private void LayoutControls()
        {
            int padding = 20;
            int width = ClientSize.Width - padding * 2;

            pnlSearch.Location = new Point(padding, 15);
            pnlSearch.Size = new Size(width, 70);
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblSearch.Location = new Point(20, 24);
            txtSearch.Location = new Point(145, 17);
            txtSearch.Size = new Size(Math.Max(250, Math.Min(500, width - 600)), 36);

            btnSearch.Location = new Point(txtSearch.Right + 20, 12);
            btnSearch.Size = new Size(120, 45);

            dgvDepartment.Location = new Point(padding, 100);
            dgvDepartment.Size = new Size(width, Math.Max(220, ClientSize.Height - 430));
            dgvDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            grpInfo.Location = new Point(padding, dgvDepartment.Bottom + 20);
            grpInfo.Size = new Size(width, ClientSize.Height - grpInfo.Top - padding);
            grpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblCode.Location = new Point(25, 50);
            txtCode.Location = new Point(180, 44);
            txtCode.Size = new Size(220, 35);

            lblName.Location = new Point(425, 50);
            txtName.Location = new Point(585, 44);
            txtName.Size = new Size(Math.Max(180, grpInfo.ClientSize.Width - 625), 35);
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblDescription.Location = new Point(25, 105);
            txtDescription.Location = new Point(155, 99);
            txtDescription.Size = new Size(grpInfo.ClientSize.Width - 185, 55);
            txtDescription.Multiline = true;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            int buttonWidth = 145;
            int buttonHeight = 44;
            int gap = 22;
            int totalWidth = buttonWidth * 4 + gap * 3;

            int startX = Math.Max(20, (grpInfo.ClientSize.Width - totalWidth) / 2);
            int buttonY = Math.Max(165, grpInfo.ClientSize.Height - 65);

            btnAdd.Location = new Point(startX, buttonY);
            btnUpdate.Location = new Point(startX + buttonWidth + gap, buttonY);
            btnDelete.Location = new Point(startX + (buttonWidth + gap) * 2, buttonY);
            btnClear.Location = new Point(startX + (buttonWidth + gap) * 3, buttonY);

            btnAdd.Size = new Size(buttonWidth, buttonHeight);
            btnUpdate.Size = new Size(buttonWidth, buttonHeight);
            btnDelete.Size = new Size(buttonWidth, buttonHeight);
            btnClear.Size = new Size(buttonWidth, buttonHeight);
        }

        #endregion

        private void FrmDepartment_Load(object sender, EventArgs e)
        {

            LoadData?.Invoke(this, EventArgs.Empty);
        }
        public void ShowDepartments(List<Department> departments)
        {
            dgvDepartment.DataSource = null;
            dgvDepartment.DataSource = departments;

            // --- Định dạng cột Tiếng Việt & Ẩn Id trực tiếp ---
            if (dgvDepartment.Columns["Id"] != null) dgvDepartment.Columns["Id"].Visible = false;
            if (dgvDepartment.Columns["ManagerId"] != null) dgvDepartment.Columns["ManagerId"].Visible = false;

            if (dgvDepartment.Columns["Code"] != null)
            {
                dgvDepartment.Columns["Code"].HeaderText = "Mã phòng";
                dgvDepartment.Columns["Code"].FillWeight = 15;
            }
            if (dgvDepartment.Columns["Name"] != null)
            {
                dgvDepartment.Columns["Name"].HeaderText = "Tên phòng ban";
                dgvDepartment.Columns["Name"].FillWeight = 30;
            }
            if (dgvDepartment.Columns["ManagerName"] != null)
            {
                dgvDepartment.Columns["ManagerName"].HeaderText = "Trưởng phòng";
                dgvDepartment.Columns["ManagerName"].FillWeight = 20;
            }
            if (dgvDepartment.Columns["Description"] != null)
            {
                dgvDepartment.Columns["Description"].HeaderText = "Mô tả";
                dgvDepartment.Columns["Description"].FillWeight = 23;
            }
            if (dgvDepartment.Columns["EmployeeCount"] != null)
            {
                dgvDepartment.Columns["EmployeeCount"].HeaderText = "Số nhân viên";
                dgvDepartment.Columns["EmployeeCount"].FillWeight = 12;
            }
            // --------------------------------------------------

            dgvDepartment.ClearSelection();
            _selectedId = 0;
        }

    }
}