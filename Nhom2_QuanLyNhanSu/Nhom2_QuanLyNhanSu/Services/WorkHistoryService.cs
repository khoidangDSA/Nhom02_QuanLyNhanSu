using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services
{
    public class WorkHistoryService : IWorkHistoryService
    {
        public DataTable GetAll()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                SELECT w.Id,
                       w.EmployeeId,
                       e.Code AS EmployeeCode,
                       e.FullName AS EmployeeName,
                       CASE w.EventType
                           WHEN 0 THEN N'Tuyển dụng'
                           WHEN 1 THEN N'Điều chuyển'
                           WHEN 2 THEN N'Bổ nhiệm'
                           WHEN 3 THEN N'Khen thưởng / Kỷ luật'
                           ELSE N'Khác'
                       END AS EventTypeName,
                       w.EventType,
                       w.EventDate,
                       w.FromDepartmentId,
                       dFrom.Name AS FromDepartmentName,
                       w.ToDepartmentId,
                       dTo.Name AS ToDepartmentName,
                       w.FromPositionId,
                       pFrom.Name AS FromPositionName,
                       w.ToPositionId,
                       pTo.Name AS ToPositionName,
                       w.Note
                FROM WorkHistory w
                LEFT JOIN Employee e ON e.Id = w.EmployeeId
                LEFT JOIN Department dFrom ON dFrom.Id = w.FromDepartmentId
                LEFT JOIN Department dTo ON dTo.Id = w.ToDepartmentId
                LEFT JOIN Position pFrom ON pFrom.Id = w.FromPositionId
                LEFT JOIN Position pTo ON pTo.Id = w.ToPositionId
                ORDER BY w.EventDate DESC", conn);

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
                SELECT w.Id,
                       w.EmployeeId,
                       e.Code AS EmployeeCode,
                       e.FullName AS EmployeeName,
                       CASE w.EventType
                           WHEN 0 THEN N'Tuyển dụng'
                           WHEN 1 THEN N'Điều chuyển'
                           WHEN 2 THEN N'Bổ nhiệm'
                           WHEN 3 THEN N'Khen thưởng / Kỷ luật'
                           ELSE N'Khác'
                       END AS EventTypeName,
                       w.EventType,
                       w.EventDate,
                       w.FromDepartmentId,
                       dFrom.Name AS FromDepartmentName,
                       w.ToDepartmentId,
                       dTo.Name AS ToDepartmentName,
                       w.FromPositionId,
                       pFrom.Name AS FromPositionName,
                       w.ToPositionId,
                       pTo.Name AS ToPositionName,
                       w.Note
                FROM WorkHistory w
                LEFT JOIN Employee e ON e.Id = w.EmployeeId
                LEFT JOIN Department dFrom ON dFrom.Id = w.FromDepartmentId
                LEFT JOIN Department dTo ON dTo.Id = w.ToDepartmentId
                LEFT JOIN Position pFrom ON pFrom.Id = w.FromPositionId
                LEFT JOIN Position pTo ON pTo.Id = w.ToPositionId
                WHERE e.Code LIKE @kw 
                   OR e.FullName LIKE @kw 
                   OR dTo.Name LIKE @kw 
                   OR pTo.Name LIKE @kw
                ORDER BY w.EventDate DESC", conn);

            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public bool Add(int employeeId, int eventType, DateTime eventDate, int? fromDeptId, int? toDeptId, int? fromPosId, int? toPosId, string note)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                INSERT INTO WorkHistory (EmployeeId, EventType, EventDate, FromDepartmentId, ToDepartmentId, FromPositionId, ToPositionId, Note)
                VALUES (@EmployeeId, @EventType, @EventDate, @FromDept, @ToDept, @FromPos, @ToPos, @Note)", conn);

            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@EventType", eventType);
            cmd.Parameters.AddWithValue("@EventDate", eventDate.Date);
            cmd.Parameters.AddWithValue("@FromDept", fromDeptId.HasValue ? fromDeptId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDept", toDeptId.HasValue ? toDeptId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@FromPos", fromPosId.HasValue ? fromPosId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ToPos", toPosId.HasValue ? toPosId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Note", string.IsNullOrWhiteSpace(note) ? DBNull.Value : note.Trim());

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(int id, int employeeId, int eventType, DateTime eventDate, int? fromDeptId, int? toDeptId, int? fromPosId, int? toPosId, string note)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                UPDATE WorkHistory
                SET EmployeeId = @EmployeeId,
                    EventType = @EventType,
                    EventDate = @EventDate,
                    FromDepartmentId = @FromDept,
                    ToDepartmentId = @ToDept,
                    FromPositionId = @FromPos,
                    ToPositionId = @ToPos,
                    Note = @Note
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@EventType", eventType);
            cmd.Parameters.AddWithValue("@EventDate", eventDate.Date);
            cmd.Parameters.AddWithValue("@FromDept", fromDeptId.HasValue ? fromDeptId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDept", toDeptId.HasValue ? toDeptId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@FromPos", fromPosId.HasValue ? fromPosId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ToPos", toPosId.HasValue ? toPosId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Note", string.IsNullOrWhiteSpace(note) ? DBNull.Value : note.Trim());

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("DELETE FROM WorkHistory WHERE Id = @Id", conn);
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

        public DataTable GetDepartmentLookup()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("SELECT 0 AS Id, N'-- Không chọn --' AS Name UNION ALL SELECT Id, Name FROM Department", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetPositionLookup()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("SELECT 0 AS Id, N'-- Không chọn --' AS Name UNION ALL SELECT Id, Name FROM Position", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}