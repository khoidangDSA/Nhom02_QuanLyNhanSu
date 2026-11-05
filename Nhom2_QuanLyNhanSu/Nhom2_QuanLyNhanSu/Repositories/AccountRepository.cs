using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Models.Enums;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;

namespace Nhom2_QuanLyNhanSu.Repositories;

public class AccountRepository : IAccountRepository
{
    public Account? GetByUsername(string username)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(
            "SELECT Id, Username, PasswordHash, Role, EmployeeId, IsActive FROM Account WHERE Username=@u", conn);
        cmd.Parameters.AddWithValue("@u", username);
        conn.Open();
        using var rd = cmd.ExecuteReader();
        if (!rd.Read()) return null;

        return new Account
        {
            Id = rd.GetInt32(0),
            Username = rd.GetString(1),
            PasswordHash = rd.GetString(2),
            Role = (AccountRole)rd.GetInt32(3),
            EmployeeId = rd.IsDBNull(4) ? null : rd.GetInt32(4),
            IsActive = rd.GetBoolean(5)
        };
    }

    public int Count()
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand("SELECT COUNT(*) FROM Account", conn);
        conn.Open();
        return (int)cmd.ExecuteScalar();
    }

    public bool Add(Account a)
    {
        using var conn = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(@"
            INSERT INTO Account(Username, PasswordHash, Role, EmployeeId, IsActive)
            VALUES(@u, @p, @r, @e, @a)", conn);
        cmd.Parameters.AddWithValue("@u", a.Username);
        cmd.Parameters.AddWithValue("@p", a.PasswordHash);
        cmd.Parameters.AddWithValue("@r", (int)a.Role);
        cmd.Parameters.AddWithValue("@e", (object?)a.EmployeeId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@a", a.IsActive);
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }
}