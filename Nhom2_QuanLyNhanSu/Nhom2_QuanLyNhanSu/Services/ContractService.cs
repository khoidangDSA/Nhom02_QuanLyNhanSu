using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services
{
    public class ContractService : IContractService
    {
        public DataTable GetAll()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
        SELECT c.Id, 
               c.ContractNo, 
               c.EmployeeId,
               e.Code AS EmployeeCode, 
               e.FullName AS EmployeeName,
               CASE c.Type 
                   WHEN 0 THEN N'Thử việc'
                   WHEN 1 THEN N'Có thời hạn'
                   WHEN 2 THEN N'Không thời hạn'
                   ELSE N'Khác'
               END AS ContractTypeStr,
               c.Type,
               c.StartDate, 
               c.EndDate, 
               c.BaseSalary, 
               c.Note
        FROM Contract c
        LEFT JOIN Employee e ON e.Id = c.EmployeeId
        ORDER BY c.StartDate DESC", conn);

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
        SELECT c.Id, 
               c.ContractNo, 
               c.EmployeeId,
               e.Code AS EmployeeCode, 
               e.FullName AS EmployeeName,
               CASE c.Type 
                   WHEN 0 THEN N'Thử việc'
                   WHEN 1 THEN N'Có thời hạn'
                   WHEN 2 THEN N'Không thời hạn'
                   ELSE N'Khác'
               END AS ContractTypeStr,
               c.Type,
               c.StartDate, 
               c.EndDate, 
               c.BaseSalary, 
               c.Note
        FROM Contract c
        LEFT JOIN Employee e ON e.Id = c.EmployeeId
        WHERE c.ContractNo LIKE @kw 
           OR e.Code LIKE @kw 
           OR e.FullName LIKE @kw
        ORDER BY c.StartDate DESC", conn);

            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public bool Add(string contractNo, int employeeId, int type,
                        DateTime startDate, DateTime? endDate, decimal baseSalary,
                        string note)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                INSERT INTO Contract (ContractNo, EmployeeId, Type, StartDate, EndDate, BaseSalary, Note)
                VALUES (@ContractNo, @EmployeeId, @Type, @StartDate, @EndDate, @BaseSalary, @Note)", conn);

            cmd.Parameters.AddWithValue("@ContractNo", contractNo.Trim());
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
            cmd.Parameters.AddWithValue("@EndDate", endDate.HasValue ? endDate.Value.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
            cmd.Parameters.AddWithValue("@Note", string.IsNullOrWhiteSpace(note) ? DBNull.Value : note.Trim());

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(int id, string contractNo, int employeeId, int type,
                           DateTime startDate, DateTime? endDate, decimal baseSalary,
                           string note)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                UPDATE Contract
                SET ContractNo = @ContractNo,
                    EmployeeId = @EmployeeId,
                    Type = @Type,
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    BaseSalary = @BaseSalary,
                    Note = @Note
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@ContractNo", contractNo.Trim());
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
            cmd.Parameters.AddWithValue("@EndDate", endDate.HasValue ? endDate.Value.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
            cmd.Parameters.AddWithValue("@Note", string.IsNullOrWhiteSpace(note) ? DBNull.Value : note.Trim());

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("DELETE FROM Contract WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public DataTable GetEmployeeLookup()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("SELECT Id, Code + ' - ' + FullName AS DisplayName FROM Employee ORDER BY Code", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}