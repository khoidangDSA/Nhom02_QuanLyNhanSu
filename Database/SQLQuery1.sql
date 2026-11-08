USE QuanLyNhanSu_Nhom2;
GO

SELECT 'Department' AS Bang, COUNT(*) AS SoLuong FROM Department
UNION ALL
SELECT 'Position', COUNT(*) FROM Position
UNION ALL
SELECT 'Employee', COUNT(*) FROM Employee;