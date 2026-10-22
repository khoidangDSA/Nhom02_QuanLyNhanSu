using Nhom2_QuanLyNhanSu.Presenters;
using Nhom2_QuanLyNhanSu.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Forms
{
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
            ApplyHalloweenTheme();

            //var repo = new DepartmentRepository();
            //new DepartmentPresenter(this, repo);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ApplyHalloweenTheme()
        {
            // 1. Đổi màu nền Form & Các Panel
            this.BackColor = ColorTranslator.FromHtml("#18122B"); // Tím u ám

            // Giả sử ông có pnlInput và pnlSearch
          //  if (pnlInput != null) pnlInput.BackColor = ColorTranslator.FromHtml("#251B37");
            //if (pnlSearch != null) pnlSearch.BackColor = ColorTranslator.FromHtml("#251B37");

            // 2. Đổi màu chữ Label
            foreach (Control c in this.Controls)
            {
                ApplyControlTheme(c);
            }

            // 3. Trang trí Bảng DataGridView kiểu Đêm Ma Cà Rồng
            dgvDepartment.EnableHeadersVisualStyles = false;
            dgvDepartment.BackgroundColor = ColorTranslator.FromHtml("#18122B");
            dgvDepartment.GridColor = ColorTranslator.FromHtml("#393053");

            // Tiêu đề bảng (Header) màu Tím đậm + chữ Cam Bí Ngô
            dgvDepartment.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#443C68");
            dgvDepartment.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FF7518");
            dgvDepartment.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Dòng dữ liệu
            dgvDepartment.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#251B37");
            dgvDepartment.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#F8FAFC");
            dgvDepartment.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FF7518"); // Bôi đen ra màu cam bí ngô
            dgvDepartment.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 4. Phối màu Nút bấm
            btnAdd.BackColor = ColorTranslator.FromHtml("#FF7518");     // Cam Bí ngô
            btnAdd.ForeColor = Color.Black;

            btnUpdate.BackColor = ColorTranslator.FromHtml("#8B5CF6");    // Tím Phù thủy
            btnUpdate.ForeColor = Color.White;

            btnDelete.BackColor = ColorTranslator.FromHtml("#DC2626");  // Đỏ Độc dược
            btnDelete.ForeColor = Color.White;

            btnClear.BackColor = ColorTranslator.FromHtml("#475569"); // Xám Bóng đêm
            btnClear.ForeColor = Color.White;

            btnSearch.BackColor = ColorTranslator.FromHtml("#FF7518");  // Cam
            btnSearch.ForeColor = Color.Black;
        }
        private void ApplyControlTheme(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = ColorTranslator.FromHtml("#F8FAFC");
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = ColorTranslator.FromHtml("#FF7518");
                    ApplyControlTheme(gb); // Gọi đệ quy để đổi màu con bên trong GroupBox
                }
                else if (c.HasChildren)
                {
                    ApplyControlTheme(c);
                }
            }
        }
    }
}
