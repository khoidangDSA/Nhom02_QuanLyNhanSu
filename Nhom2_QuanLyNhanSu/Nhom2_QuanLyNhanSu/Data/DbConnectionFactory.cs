using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Nhom2_QuanLyNhanSu.Data;

public static class DbConnectionFactory
{
    private static readonly string _connStr =
        ConfigurationManager.ConnectionStrings["HRDb"].ConnectionString;

    public static SqlConnection Create() => new SqlConnection(_connStr);
}