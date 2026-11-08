USE QuanLyNhanSu_Nhom2;
GO

-- 1. Tài khoản admin (Role = 0)
IF NOT EXISTS (SELECT 1 FROM Account WHERE Username = 'admin')
BEGIN
    INSERT INTO Account (Username, PasswordHash, Role, EmployeeId, IsActive)
    VALUES ('admin', '123456', 0, NULL, 1);
END

-- 2. Tài khoản nhân sự hr gán cho NV001 (Role = 1)
IF NOT EXISTS (SELECT 1 FROM Account WHERE Username = 'hr')
BEGIN
    INSERT INTO Account (Username, PasswordHash, Role, EmployeeId, IsActive)
    SELECT 'hr', '123456', 1, Id, 1
    FROM Employee 
    WHERE Code = N'NV001';
END

-- 3. Tài khoản nhân viên gán cho NV002 (Role = 2)
IF NOT EXISTS (SELECT 1 FROM Account WHERE Username = 'bich.tran')
BEGIN
    INSERT INTO Account (Username, PasswordHash, Role, EmployeeId, IsActive)
    SELECT 'bich.tran', '123456', 2, Id, 1
    FROM Employee 
    WHERE Code = N'NV002';
END
GO

-- Kiểm tra kết quả
SELECT a.Id, a.Username, a.Role, a.EmployeeId, e.FullName, a.IsActive 
FROM Account a
LEFT JOIN Employee e ON e.Id = a.EmployeeId;
GO