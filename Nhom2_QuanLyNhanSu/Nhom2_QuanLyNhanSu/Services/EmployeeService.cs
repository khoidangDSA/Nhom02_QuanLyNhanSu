using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Nhom2_QuanLyNhanSu.Data;
using Nhom2_QuanLyNhanSu.Services.Interfaces;

namespace Nhom2_QuanLyNhanSu.Services
{
    public class EmployeeService : IEmployeeService
    {
        public DataTable GetAll()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                SELECT e.Id, e.Code, e.FullName, 
                       CASE WHEN e.Gender = 0 THEN N'Nam' ELSE N'Nữ' END AS GenderStr, 
                       e.BirthDate, e.IdCard, e.Phone, e.Email, e.Address,
                       d.Name AS DepartmentName, p.Name AS PositionName, 
                       e.DepartmentId, e.PositionId, e.HireDate, e.Status,
                       e.PhotoPath,
                       CASE e.Status
                           WHEN 0 THEN N'Đang làm việc'
                           WHEN 1 THEN N'Đã nghỉ việc'
                           WHEN 2 THEN N'Nghỉ dài hạn'
                           ELSE N'Khác'
                       END AS StatusStr
                FROM Employee e
                LEFT JOIN Department d ON d.Id = e.DepartmentId
                LEFT JOIN Position p ON p.Id = e.PositionId
                ORDER BY e.Code", conn);

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
                SELECT e.Id, e.Code, e.FullName, 
                       CASE WHEN e.Gender = 0 THEN N'Nam' ELSE N'Nữ' END AS GenderStr, 
                       e.BirthDate, e.IdCard, e.Phone, e.Email, e.Address,
                       d.Name AS DepartmentName, p.Name AS PositionName, 
                       e.DepartmentId, e.PositionId, e.HireDate, e.Status,
                       e.PhotoPath,
                       CASE e.Status
                           WHEN 0 THEN N'Đang làm việc'
                           WHEN 1 THEN N'Đã nghỉ việc'
                           WHEN 2 THEN N'Nghỉ dài hạn'
                           ELSE N'Khác'
                       END AS StatusStr
                FROM Employee e
                LEFT JOIN Department d ON d.Id = e.DepartmentId
                LEFT JOIN Position p ON p.Id = e.PositionId
                WHERE e.Code LIKE @kw OR e.FullName LIKE @kw OR d.Name LIKE @kw
                ORDER BY e.Code", conn);

            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public bool Add(string code, string fullName, int gender, DateTime birthDate, string idCard,
                        string phone, string email, string address, int departmentId, int positionId,
                        DateTime hireDate, int status, string photoPath)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                INSERT INTO Employee (Code, FullName, Gender, BirthDate, IdCard, Phone, Email, Address, 
                                      DepartmentId, PositionId, HireDate, Status, PhotoPath)
                VALUES (@Code, @FullName, @Gender, @BirthDate, @IdCard, @Phone, @Email, @Address, 
                        @DepartmentId, @PositionId, @HireDate, @Status, @PhotoPath)", conn);

            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@BirthDate", birthDate.Date);
            cmd.Parameters.AddWithValue("@IdCard", string.IsNullOrWhiteSpace(idCard) ? DBNull.Value : idCard);
            cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : phone);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : email);
            cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(address) ? DBNull.Value : address);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
            cmd.Parameters.AddWithValue("@PositionId", positionId);
            cmd.Parameters.AddWithValue("@HireDate", hireDate.Date);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@PhotoPath", string.IsNullOrWhiteSpace(photoPath) ? DBNull.Value : photoPath);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(int id, string code, string fullName, int gender, DateTime birthDate, string idCard,
                           string phone, string email, string address, int departmentId, int positionId,
                           DateTime hireDate, int status, string photoPath)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                UPDATE Employee
                SET Code = @Code,
                    FullName = @FullName,
                    Gender = @Gender,
                    BirthDate = @BirthDate,
                    IdCard = @IdCard,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address,
                    DepartmentId = @DepartmentId,
                    PositionId = @PositionId,
                    HireDate = @HireDate,
                    Status = @Status,
                    PhotoPath = @PhotoPath
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@BirthDate", birthDate.Date);
            cmd.Parameters.AddWithValue("@IdCard", string.IsNullOrWhiteSpace(idCard) ? DBNull.Value : idCard);
            cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : phone);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : email);
            cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(address) ? DBNull.Value : address);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
            cmd.Parameters.AddWithValue("@PositionId", positionId);
            cmd.Parameters.AddWithValue("@HireDate", hireDate.Date);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@PhotoPath", string.IsNullOrWhiteSpace(photoPath) ? DBNull.Value : photoPath);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand(@"
                DELETE FROM WorkHistory WHERE EmployeeId = @Id;
                DELETE FROM Contract WHERE EmployeeId = @Id;
                DELETE FROM Account WHERE EmployeeId = @Id;
                DELETE FROM Employee WHERE Id = @Id;", conn);

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public DataTable GetDepartments()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("SELECT Id, Name FROM Department ORDER BY Name", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetPositions()
        {
            var dt = new DataTable();
            using var conn = DbConnectionFactory.Create();
            using var cmd = new SqlCommand("SELECT Id, Name FROM Position ORDER BY Name", conn);
            conn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}