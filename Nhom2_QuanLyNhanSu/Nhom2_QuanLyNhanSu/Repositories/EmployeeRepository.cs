using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // hoặc System.Data.SqlClient

namespace Nhom2_QuanLyNhanSu.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Employee employee)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO Employees (Code, FullName, Gender, BirthDate, IdCard, Phone, Email, Address, HireDate, Status, DepartmentId, PositionId, PhotoPath)
                VALUES (@Code, @FullName, @Gender, @BirthDate, @IdCard, @Phone, @Email, @Address, @HireDate, @Status, @DepartmentId, @PositionId, @PhotoPath)", conn))
            {
                cmd.Parameters.AddWithValue("@Code", employee.Code);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Gender", (int)employee.Gender);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@IdCard", employee.IdCard);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Status", (int)employee.Status);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@PositionId", employee.PositionId);
                cmd.Parameters.AddWithValue("@PhotoPath", (object)employee.PhotoPath ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee employee)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE Employees 
                SET FullName = @FullName,
                    Gender = @Gender,
                    BirthDate = @BirthDate,
                    IdCard = @IdCard,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address,
                    HireDate = @HireDate,
                    Status = @Status,
                    DepartmentId = @DepartmentId,
                    PositionId = @PositionId,
                    PhotoPath = @PhotoPath
                WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Gender", (int)employee.Gender);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@IdCard", employee.IdCard);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Status", (int)employee.Status);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@PositionId", employee.PositionId);
                cmd.Parameters.AddWithValue("@PhotoPath", (object)employee.PhotoPath ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id) { /* ... */ }
        public Employee GetById(int id) { return null; }
        public IEnumerable<Employee> GetAll() { return new List<Employee>(); }
    }
}