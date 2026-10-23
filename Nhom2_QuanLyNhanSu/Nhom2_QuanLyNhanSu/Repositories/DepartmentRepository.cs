using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;

namespace Nhom2_QuanLyNhanSu.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private const string SelectSql = @"
        SELECT d.Id, d.Code, d.Name, d.ManagerId, d.Description,
               ISNULL(m.FullName, N'') AS ManagerName,
               (SELECT COUNT(*) FROM Employee e WHERE e.DepartmentId = d.Id) AS EmployeeCount
        FROM Department d
        LEFT JOIN Employee m ON m.Id = d.ManagerId";

    public List<Department> GetAll() => Query(SelectSql + " ORDER BY d.Name");

    public List<Department> Search(string keyword)
    {
        var list = new List<Department>();
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(
            SelectSql + " WHERE d.Code LIKE @kw OR d.Name LIKE @kw ORDER BY d.Name", conn);
        cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
        conn.Open();
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) list.Add(Map(rd));
        return list;
    }

    public bool Add(Department d)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(@"
            INSERT INTO Department(Code, Name, ManagerId, Description)
            VALUES(@code, @name, @mgr, @desc)", conn);
        Fill(cmd, d);
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Update(Department d)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(@"
            UPDATE Department
            SET Code=@code, Name=@name, ManagerId=@mgr, Description=@desc
            WHERE Id=@id", conn);
        Fill(cmd, d);
        cmd.Parameters.AddWithValue("@id", d.Id);
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand("DELETE FROM Department WHERE Id=@id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }

    // hàm kt trùng mã
    public bool IsCodeExists(string code, int excludeId = 0)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(
            "SELECT COUNT(*) FROM Department WHERE Code=@code AND Id<>@id", conn);
        cmd.Parameters.AddWithValue("@code", code);
        cmd.Parameters.AddWithValue("@id", excludeId);
        conn.Open();
        return (int)cmd.ExecuteScalar() > 0;
    }

    // ===== Hàm phụ =====

    private static List<Department> Query(string sql)
    {
        var list = new List<Department>();
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(sql, conn);
        conn.Open();
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) list.Add(Map(rd));
        return list;
    }

    private static void Fill(SqlCommand cmd, Department d)
    {
        cmd.Parameters.AddWithValue("@code", d.Code);
        cmd.Parameters.AddWithValue("@name", d.Name);
        cmd.Parameters.AddWithValue("@mgr", (object?)d.ManagerId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@desc", d.Description ?? string.Empty);
    }

    private static Department Map(SqlDataReader rd) => new()
    {
        Id = rd.GetInt32(rd.GetOrdinal("Id")),
        Code = rd.GetString(rd.GetOrdinal("Code")),
        Name = rd.GetString(rd.GetOrdinal("Name")),
        ManagerId = rd.IsDBNull(rd.GetOrdinal("ManagerId")) ? null : rd.GetInt32(rd.GetOrdinal("ManagerId")),
        Description = rd.IsDBNull(rd.GetOrdinal("Description")) ? "" : rd.GetString(rd.GetOrdinal("Description")),
        ManagerName = rd.GetString(rd.GetOrdinal("ManagerName")),
        EmployeeCount = rd.GetInt32(rd.GetOrdinal("EmployeeCount"))
    };
}