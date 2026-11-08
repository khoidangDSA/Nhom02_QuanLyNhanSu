using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; 
using Nhom2_QuanLyNhanSu.Models.Enums;
using Nhom2_QuanLyNhanSu.Models;

namespace Nhom2_QuanLyNhanSu.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString = @"Server=localhost;Database=QuanLyNhanSu_Nhom2;Trusted_Connection=True;TrustServerCertificate=True;";

        public IEnumerable<Account> GetAll()
        {
            var list = new List<Account>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Username, PasswordHash, Role, MaNV, IsActive FROM Accounts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Account
                            {
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Role = (AccountRole)Convert.ToInt32(reader["Role"]),
                                MaNV = reader["MaNV"] != DBNull.Value ? reader["MaNV"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public IEnumerable<Account> GetBySearchValue(string searchValue)
        {
            var list = new List<Account>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Username, PasswordHash, Role, MaNV, IsActive FROM Accounts WHERE Username LIKE @search OR MaNV LIKE @search";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{searchValue}%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Account
                            {
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Role = (AccountRole)Convert.ToInt32(reader["Role"]),
                                MaNV = reader["MaNV"] != DBNull.Value ? reader["MaNV"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Account account) // Kiểu trả về phải là void để khớp với interface
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Accounts (Username, PasswordHash, Role, MaNV, IsActive) VALUES (@user, @pass, @role, @manv, @active)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", account.Username);
                    cmd.Parameters.AddWithValue("@pass", account.PasswordHash);
                    cmd.Parameters.AddWithValue("@role", (int)account.Role);
                    cmd.Parameters.AddWithValue("@manv", (object)account.MaNV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@active", account.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Edit(Account account)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Accounts SET Role = @role, MaNV = @manv, IsActive = @active WHERE Username = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", account.Username);
                    cmd.Parameters.AddWithValue("@role", (int)account.Role);
                    cmd.Parameters.AddWithValue("@manv", (object)account.MaNV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@active", account.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string username)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Accounts WHERE Username = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePassword(string username, string newPasswordHash)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Accounts SET PasswordHash = @pass WHERE Username = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pass", newPasswordHash);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Accounts WHERE Username = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public Account GetByUsername(string username)
        {
            Account account = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Username, PasswordHash, Role, MaNV, IsActive FROM Accounts WHERE Username = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new Account
                            {
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Role = (AccountRole)Convert.ToInt32(reader["Role"]),
                                MaNV = reader["MaNV"] != DBNull.Value ? reader["MaNV"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return account;
        }

        public int Count()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Accounts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}