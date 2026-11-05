using System;
using System.Collections.Generic;
using System.ComponentModel; // Thư viện chứa Browsable & DesignerSerializationVisibility
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Views.Interfaces;
using Nhom2_QuanLyNhanSu.Common.Helpers;

namespace Nhom2_QuanLyNhanSu.Views.Forms;

public partial class FrmPosition : Form, IPositionView
{
    private readonly Dictionary<Button, Image> _originalIcons = new();
    private static readonly Color IconDisabled = Color.FromArgb(148, 163, 184);
    private static readonly Color ColSearch = Color.FromArgb(37, 99, 235);
    private static readonly Color ColAdd = Color.FromArgb(16, 185, 129);
    private static readonly Color ColUpdate = Color.FromArgb(245, 158, 11);
    private static readonly Color ColDelete = Color.FromArgb(239, 68, 68);
    private static readonly Color ColClear = Color.FromArgb(100, 116, 139);
    private static readonly Color ColDisabled = Color.FromArgb(203, 213, 225);

    private bool _binding;
    private int _selectedId;

    public FrmPosition()
    {
        InitializeComponent();
        SetupGrid();

        StyleBtn(btnSearch, ColSearch);
        StyleBtn(btnAdd, ColAdd);
        StyleBtn(btnUpdate, ColUpdate);
        StyleBtn(btnDelete, ColDelete);
        StyleBtn(btnClear, ColClear);

        Load += (s, e) => LoadData?.Invoke(this, EventArgs.Empty);
        btnSearch.Click += (s, e) => SearchRequested?.Invoke(this, EventArgs.Empty);
        btnAdd.Click += (s, e) => AddRequested?.Invoke(this, EventArgs.Empty);
        btnUpdate.Click += (s, e) => UpdateRequested?.Invoke(this, EventArgs.Empty);
        btnDelete.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);
        btnClear.Click += (s, e) => ClearRequested?.Invoke(this, EventArgs.Empty);

        txtSearch.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchRequested?.Invoke(this, EventArgs.Empty);
            }
        };

        // Chỉ cho gõ số vào ô phụ cấp
        txtAllowance.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        };

        dgvPosition.SelectionChanged += (s, e) =>
        {
            if (_binding) return;
            _selectedId = dgvPosition.SelectedRows.Count > 0 &&
                          dgvPosition.SelectedRows[0].DataBoundItem is Position p ? p.Id : 0;
            UpdateButtons();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        };

        UpdateButtons();
    }

    // ===== IPOSITIONVIEW IMPLEMENTATION (ĐÃ THÊM ATTRIBUTE CHUẨN) =====

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string PositionCode { get => txtCode.Text.Trim(); set => txtCode.Text = value; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string PositionName { get => txtName.Text.Trim(); set => txtName.Text = value; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public decimal Allowance
    {
        get => decimal.TryParse(txtAllowance.Text.Replace(".", "").Replace(",", "").Trim(), out decimal val) ? val : 0;
        set => txtAllowance.Text = value.ToString("N0", new CultureInfo("vi-VN"));
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Description { get => txtDescription.Text.Trim(); set => txtDescription.Text = value; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string SearchKeyword => txtSearch.Text.Trim();

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedId => _selectedId;

    // ===== EVENT HANLDERS =====

    public event EventHandler? LoadData;
    public event EventHandler? SearchRequested;
    public event EventHandler? AddRequested;
    public event EventHandler? UpdateRequested;
    public event EventHandler? DeleteRequested;
    public event EventHandler? ClearRequested;
    public event EventHandler? SelectionChanged;

    public void ShowPositions(List<Position> positions)
    {
        _binding = true;
        dgvPosition.DataSource = null;
        dgvPosition.DataSource = positions;
        dgvPosition.ClearSelection();
        _selectedId = 0;
        _binding = false;
        UpdateButtons();
        Shown += (s, e) =>
        {
            dgvPosition.ClearSelection();
            _selectedId = 0;
            UpdateButtons();
        };
    }

    public void ClearInput()
    {
        txtCode.Clear();
        txtName.Clear();
        txtAllowance.Clear();
        txtDescription.Clear();

        _binding = true;
        dgvPosition.ClearSelection();
        _binding = false;

        _selectedId = 0;
        UpdateButtons();
        txtCode.Focus();
    }

    public void ShowMessage(string message) =>
        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

    public void ShowError(string message) =>
        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public bool Confirm(string message) =>
        MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    // ===== HÀM PHỤ GIAO DIỆN =====

    private void StyleBtn(Button b, Color color)
    {
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.BackColor = color;
        b.ForeColor = Color.White;
        b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
        b.TextImageRelation = TextImageRelation.ImageBeforeText;

        if (b.Image != null && !_originalIcons.ContainsKey(b))
            _originalIcons[b] = new Bitmap(b.Image);   // bản sao gốc, không bị ảnh hưởng khi b.Image đổi
    }

    private void UpdateButtons()
    {
        bool hasSelection = _selectedId != 0;
        btnAdd.Enabled = !hasSelection;
        btnUpdate.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;

        SetState(btnAdd, ColAdd);
        SetState(btnUpdate, ColUpdate);
        SetState(btnDelete, ColDelete);
        SetState(btnClear, ColClear);
        SetState(btnSearch, ColSearch);
    }

    private void SetState(Button b, Color activeColor)
    {
        b.BackColor = b.Enabled ? activeColor : ColDisabled;
        b.ForeColor = b.Enabled ? Color.White : Color.FromArgb(100, 116, 139);
        b.Cursor = b.Enabled ? Cursors.Hand : Cursors.Default;

        if (_originalIcons.TryGetValue(b, out var icon))
        {
            var old = b.Image;
            b.Image = IconHelper.Tint(icon, b.Enabled ? Color.White : IconDisabled);
            old?.Dispose();
        }
    }

    private void SetupGrid()
    {
        var dgv = dgvPosition;
        dgv.AutoGenerateColumns = false;
        dgv.Columns.Clear();
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.RowHeadersVisible = false;
        dgv.BackgroundColor = Color.White;

        AddColumn("Code", "Mã", 10);
        AddColumn("Name", "Tên chức vụ", 25);
        AddColumn("Allowance", "Phụ cấp (VNĐ)", 18, "N0");
        AddColumn("EmployeeCount", "Số nhân viên", 14);
        AddColumn("Description", "Mô tả", 33);
    }

    private void AddColumn(string property, string header, float weight, string? format = null)
    {
        var col = new DataGridViewTextBoxColumn
        {
            DataPropertyName = property,
            HeaderText = header,
            FillWeight = weight,
            MinimumWidth = 80
        };
        if (format != null) col.DefaultCellStyle.Format = format;
        dgvPosition.Columns.Add(col);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {

    }

    private void dgvPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}