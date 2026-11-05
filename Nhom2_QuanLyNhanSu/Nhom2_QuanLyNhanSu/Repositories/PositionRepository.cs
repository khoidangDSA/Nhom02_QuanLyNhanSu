using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private const string SelectSql = @"
        SELECT p.Id, p.Code, p.Name, p.Allowance, p.Description,
               (SELECT COUNT(*) FROM Employee e WHERE e.PositionId = p.Id) AS EmployeeCount
        FROM Position p";

        public List<Position> GetAll()
        {
            var list = new List<Position>();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(SelectSql + " ORDER BY p.Allowance DESC, p.Name", conn);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read()) list.Add(Map(rd));
            return list;
        }

        public List<Position> Search(string keyword)
        {
            var list = new List<Position>();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(
                SelectSql + " WHERE p.Code LIKE @kw OR p.Name LIKE @kw ORDER BY p.Allowance DESC, p.Name", conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read()) list.Add(Map(rd));
            return list;
        }

        public bool Add(Position p)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
            INSERT INTO Position(Code, Name, Allowance, Description)
            VALUES(@code, @name, @allow, @desc)", conn);
            Fill(cmd, p);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Position p)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
            UPDATE Position
            SET Code=@code, Name=@name, Allowance=@allow, Description=@desc
            WHERE Id=@id", conn);
            Fill(cmd, p);
            cmd.Parameters.AddWithValue("@id", p.Id);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("DELETE FROM Position WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Position WHERE Code=@code AND Id<>@id", conn);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@id", excludeId);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        private static void Fill(SqlCommand cmd, Position p)
        {
            cmd.Parameters.AddWithValue("@code", p.Code);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@allow", p.Allowance);
            cmd.Parameters.AddWithValue("@desc", p.Description ?? string.Empty);
        }

        private static Position Map(SqlDataReader rd) => new()
        {
            Id = rd.GetInt32(rd.GetOrdinal("Id")),
            Code = rd.GetString(rd.GetOrdinal("Code")),
            Name = rd.GetString(rd.GetOrdinal("Name")),
            Allowance = rd.GetDecimal(rd.GetOrdinal("Allowance")),
            Description = rd.IsDBNull(rd.GetOrdinal("Description")) ? "" : rd.GetString(rd.GetOrdinal("Description")),
            EmployeeCount = rd.GetInt32(rd.GetOrdinal("EmployeeCount"))
        };
    }
}
