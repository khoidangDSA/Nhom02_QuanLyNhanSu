using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services
{
    public class AccountService : IAccountService
    {
        public DataTable GetAll()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                SELECT a.Id, 
                       a.Username, 
                       a.Role, 
                       a.EmployeeId,
                       e.Code AS EmployeeCode, 
                       e.FullName AS EmployeeName,
                       a.IsActive,
                       CASE WHEN a.IsActive = 1 THEN N'Hoạt động' ELSE N'Bị khóa' END AS StatusStr
                FROM Account a
                LEFT JOIN Employee e ON e.Id = a.EmployeeId
                ORDER BY a.Id DESC", conn);

            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetByValue(string keyword)
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                SELECT a.Id, 
                       a.Username, 
                       a.Role, 
                       a.EmployeeId,
                       e.Code AS EmployeeCode, 
                       e.FullName AS EmployeeName,
                       a.IsActive,
                       CASE WHEN a.IsActive = 1 THEN N'Hoạt động' ELSE N'Bị khóa' END AS StatusStr
                FROM Account a
                LEFT JOIN Employee e ON e.Id = a.EmployeeId
                WHERE a.Username LIKE @kw OR e.Code LIKE @kw OR e.FullName LIKE @kw
                ORDER BY a.Id DESC", conn);

            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public bool Add(string username, string password, int role, int? employeeId, bool isActive)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
        INSERT INTO Account (Username, PasswordHash, Role, EmployeeId, IsActive)
        VALUES (@Username, @PasswordHash, @Role, @EmployeeId, @IsActive)", conn);

            cmd.Parameters.AddWithValue("@Username", username.Trim());
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId.HasValue ? employeeId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(int id, int role, int? employeeId, bool isActive)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
        UPDATE Account 
        SET Role = @Role, 
            EmployeeId = @EmployeeId, 
            IsActive = @IsActive
        WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId.HasValue ? employeeId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public DataTable GetEmployeeLookup()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
        SELECT 0 AS Id, N'-- Không liên kết --' AS DisplayName
        UNION ALL
        SELECT Id, Code + ' - ' + FullName AS DisplayName 
        FROM Employee 
        ORDER BY Id", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public bool ResetPassword(int id, string newPassword)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("UPDATE Account SET PasswordHash = @PasswordHash WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@PasswordHash", newPassword);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("DELETE FROM Account WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        
    }
}