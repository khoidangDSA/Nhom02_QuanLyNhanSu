using System;
using Microsoft.Data.SqlClient;

namespace Nhom2_QuanLyNhanSu.Data
{
    public static class DatabaseInitializer
    {
        private static readonly string _connectionString = @"Server=localhost;Database=QuanLyNhanSu_Nhom2;Trusted_Connection=True;TrustServerCertificate=True;";

        public static void Initialize()
        {
            try
            {
                CreateTablesIfNotExists();
                
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu SQL Server chưa bật hoặc sai chuỗi kết nối
                System.Windows.Forms.MessageBox.Show(
                    $"Lỗi khởi tạo Database: {ex.Message}\n\nVui lòng kiểm tra lại Connection String!",
                    "Lỗi Hệ Thống",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static void CreateTablesIfNotExists()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // 1. Tạo bảng Accounts (Khớp với Model Account bạn vừa làm)
                string createAccountsTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' AND xtype='U')
                    BEGIN
                        CREATE TABLE Accounts (
                            Username NVARCHAR(50) PRIMARY KEY,
                            PasswordHash NVARCHAR(255) NOT NULL,
                            Role INT NOT NULL, -- Dùng số nguyên cho Enum AccountRole (0: Admin, 1: HR,...)
                            MaNV NVARCHAR(50) NULL,
                            IsActive BIT DEFAULT 1
                        )
                    END";

                // 2. Tạo bảng Employees (Ví dụ mẫu cho Thành viên khác)
                string createEmployeesTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
                    BEGIN
                        CREATE TABLE Employees (
                            MaNV NVARCHAR(50) PRIMARY KEY,
                            HoTen NVARCHAR(100) NOT NULL,
                            NgaySinh DATE NULL,
                            GioiTinh NVARCHAR(10) NULL,
                            DienThoai NVARCHAR(20) NULL,
                            Email NVARCHAR(100) NULL,
                            DiaChi NVARCHAR(255) NULL,
                            PhongBanId NVARCHAR(50) NULL,
                            ChucVuId NVARCHAR(50) NULL,
                            AvatarPath NVARCHAR(MAX) NULL
                        )
                    END";

                // 3. Thực thi các lệnh SQL
                using (SqlCommand cmd = new SqlCommand(createAccountsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(createEmployeesTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}