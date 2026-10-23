USE HRManagerDB;
GO

-- Lấy Id phòng ban và chức vụ theo mã (không phụ thuộc số thứ tự)
DECLARE @KT INT = (SELECT Id FROM Department WHERE Code = N'KT');
DECLARE @NS INT = (SELECT Id FROM Department WHERE Code = N'NS');
DECLARE @IT INT = (SELECT Id FROM Department WHERE Code = N'IT');

DECLARE @NV INT = (SELECT Id FROM Position WHERE Code = N'NV');
DECLARE @TP INT = (SELECT Id FROM Position WHERE Code = N'TP');
DECLARE @GD INT = (SELECT Id FROM Position WHERE Code = N'GD');

-- Gender: 0 = Nam, 1 = Nữ | Status: 0 = Đang làm việc, 1 = Đã nghỉ việc, 2 = Nghỉ dài hạn
INSERT INTO Employee (Code, FullName, Gender, BirthDate, IdCard, Phone, Email, Address,
                      PhotoPath, DepartmentId, PositionId, HireDate, Status)
SELECT v.Code, v.FullName, v.Gender, v.BirthDate, v.IdCard, v.Phone, v.Email, v.Address,
       NULL, v.DepartmentId, v.PositionId, v.HireDate, v.Status
FROM (VALUES
    (N'NV001', N'Nguyễn Văn An',     0, '1985-03-12', N'079085001234', N'0901234567', N'an.nguyen@company.vn',    N'12 Lê Lợi, Quận 1, TP.HCM',          @NS, @GD, '2015-01-05', 0),
    (N'NV002', N'Trần Thị Bích',     1, '1990-07-25', N'079190002345', N'0912345678', N'bich.tran@company.vn',    N'45 Nguyễn Huệ, Quận 1, TP.HCM',      @KT, @TP, '2017-03-20', 0),
    (N'NV003', N'Lê Hoàng Cường',    0, '1992-11-02', N'079092003456', N'0923456789', N'cuong.le@company.vn',     N'78 Trần Hưng Đạo, Quận 5, TP.HCM',   @IT, @TP, '2018-06-15', 0),
    (N'NV004', N'Phạm Thu Dung',     1, '1995-01-18', N'079195004567', N'0934567890', N'dung.pham@company.vn',    N'23 Võ Văn Tần, Quận 3, TP.HCM',      @KT, @NV, '2020-02-10', 0),
    (N'NV005', N'Võ Minh Đức',       0, '1996-09-30', N'079096005678', N'0945678901', N'duc.vo@company.vn',       N'56 Cách Mạng Tháng 8, Quận 10, TP.HCM', @IT, @NV, '2021-08-01', 0),
    (N'NV006', N'Đặng Ngọc Hà',      1, '1998-04-08', N'079198006789', N'0956789012', N'ha.dang@company.vn',      N'89 Phan Xích Long, Phú Nhuận, TP.HCM', @NS, @NV, '2022-05-16', 0),
    (N'NV007', N'Bùi Quốc Huy',      0, '1993-12-21', N'079093007890', N'0967890123', N'huy.bui@company.vn',      N'34 Điện Biên Phủ, Bình Thạnh, TP.HCM', @IT, @NV, '2019-10-07', 0),
    (N'NV008', N'Hoàng Thị Lan',     1, '1994-06-14', N'079194008901', N'0978901234', N'lan.hoang@company.vn',    N'67 Lý Thường Kiệt, Quận 11, TP.HCM', @KT, @NV, '2019-04-22', 1),
    (N'NV009', N'Ngô Thanh Phong',   0, '1991-02-27', N'079091009012', N'0989012345', N'phong.ngo@company.vn',    N'101 Nguyễn Trãi, Quận 5, TP.HCM',    @IT, @NV, '2020-11-30', 0),
    (N'NV010', N'Dương Mỹ Linh',     1, '1999-08-05', N'079199010123', N'0990123456', N'linh.duong@company.vn',   N'15 Hai Bà Trưng, Quận 3, TP.HCM',    @NS, @NV, '2023-01-09', 2)
) AS v(Code, FullName, Gender, BirthDate, IdCard, Phone, Email, Address,
       DepartmentId, PositionId, HireDate, Status)
WHERE NOT EXISTS (SELECT 1 FROM Employee e WHERE e.Code = v.Code);
GO

-- Gán trưởng phòng
UPDATE Department SET ManagerId = (SELECT Id FROM Employee WHERE Code = N'NV002') WHERE Code = N'KT';
UPDATE Department SET ManagerId = (SELECT Id FROM Employee WHERE Code = N'NV001') WHERE Code = N'NS';
UPDATE Department SET ManagerId = (SELECT Id FROM Employee WHERE Code = N'NV003') WHERE Code = N'IT';
GO

-- Hợp đồng mẫu (có cái sắp hết hạn để thử chức năng nhắc)
INSERT INTO Contract (EmployeeId, ContractNo, Type, StartDate, EndDate, BaseSalary, Note)
SELECT e.Id, v.ContractNo, v.Type, v.StartDate, v.EndDate, v.BaseSalary, v.Note
FROM (VALUES
    (N'NV001', N'HD001', 2, '2015-01-05', NULL,                              45000000, N'Hợp đồng không thời hạn'),
    (N'NV002', N'HD002', 2, '2017-03-20', NULL,                              30000000, N'Hợp đồng không thời hạn'),
    (N'NV003', N'HD003', 2, '2018-06-15', NULL,                              32000000, N'Hợp đồng không thời hạn'),
    (N'NV004', N'HD004', 1, '2024-02-10', DATEADD(DAY, 20,  CAST(GETDATE() AS DATE)), 15000000, N'Sắp hết hạn, cần gia hạn'),
    (N'NV005', N'HD005', 1, '2025-08-01', DATEADD(DAY, 200, CAST(GETDATE() AS DATE)), 14000000, N'Hợp đồng 2 năm'),
    (N'NV006', N'HD006', 0, '2026-08-16', DATEADD(DAY, 10,  CAST(GETDATE() AS DATE)), 9000000,  N'Thử việc, sắp hết hạn'),
    (N'NV007', N'HD007', 1, '2025-10-07', DATEADD(DAY, 90,  CAST(GETDATE() AS DATE)), 16000000, N'Hợp đồng 1 năm')
) AS v(Code, ContractNo, Type, StartDate, EndDate, BaseSalary, Note)
JOIN Employee e ON e.Code = v.Code
WHERE NOT EXISTS (SELECT 1 FROM Contract c WHERE c.ContractNo = v.ContractNo);
GO

-- Quá trình công tác mẫu
INSERT INTO WorkHistory (EmployeeId, EventType, EventDate, FromDepartmentId, ToDepartmentId,
                         FromPositionId, ToPositionId, Note)
SELECT e.Id, v.EventType, v.EventDate, NULL, e.DepartmentId, NULL, e.PositionId, v.Note
FROM (VALUES
    (N'NV001', 0, '2015-01-05', N'Tuyển dụng'),
    (N'NV002', 0, '2017-03-20', N'Tuyển dụng'),
    (N'NV003', 0, '2018-06-15', N'Tuyển dụng'),
    (N'NV004', 0, '2020-02-10', N'Tuyển dụng')
) AS v(Code, EventType, EventDate, Note)
JOIN Employee e ON e.Code = v.Code
WHERE NOT EXISTS (SELECT 1 FROM WorkHistory w WHERE w.EmployeeId = e.Id AND w.EventType = v.EventType);
GO

-- Kiểm tra
SELECT e.Code, e.FullName, d.Name AS PhongBan, p.Name AS ChucVu, e.Status
FROM Employee e
JOIN Department d ON d.Id = e.DepartmentId
JOIN Position p ON p.Id = e.PositionId
ORDER BY e.Code;
