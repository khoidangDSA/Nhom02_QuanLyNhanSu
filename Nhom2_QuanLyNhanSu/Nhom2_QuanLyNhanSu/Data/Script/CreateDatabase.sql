CREATE DATABASE HRManagerDB;
GO
USE HRManagerDB;
GO

CREATE TABLE Department (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Code        NVARCHAR(20)  NOT NULL UNIQUE,
    Name        NVARCHAR(100) NOT NULL,
    ManagerId   INT NULL,
    Description NVARCHAR(255) NULL
);

CREATE TABLE Position (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Code        NVARCHAR(20)  NOT NULL UNIQUE,
    Name        NVARCHAR(100) NOT NULL,
    Allowance   DECIMAL(18,2) NOT NULL DEFAULT 0,
    Description NVARCHAR(255) NULL
);

CREATE TABLE Employee (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Code         NVARCHAR(20)  NOT NULL UNIQUE,
    FullName     NVARCHAR(100) NOT NULL,
    Gender       INT NOT NULL,
    BirthDate    DATE NOT NULL,
    IdCard       NVARCHAR(20)  NULL,
    Phone        NVARCHAR(20)  NULL,
    Email        NVARCHAR(100) NULL,
    Address      NVARCHAR(255) NULL,
    PhotoPath    NVARCHAR(255) NULL,
    DepartmentId INT NOT NULL REFERENCES Department(Id),
    PositionId   INT NOT NULL REFERENCES Position(Id),
    HireDate     DATE NOT NULL,
    Status       INT NOT NULL DEFAULT 0
);

ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (ManagerId) REFERENCES Employee(Id);

CREATE TABLE Contract (
    Id         INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL REFERENCES Employee(Id),
    ContractNo NVARCHAR(30) NOT NULL UNIQUE,
    Type       INT NOT NULL,
    StartDate  DATE NOT NULL,
    EndDate    DATE NULL,
    BaseSalary DECIMAL(18,2) NOT NULL,
    Note       NVARCHAR(255) NULL
);

CREATE TABLE WorkHistory (
    Id               INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId       INT NOT NULL REFERENCES Employee(Id),
    EventType        INT NOT NULL,
    EventDate        DATE NOT NULL,
    FromDepartmentId INT NULL REFERENCES Department(Id),
    ToDepartmentId   INT NULL REFERENCES Department(Id),
    FromPositionId   INT NULL REFERENCES Position(Id),
    ToPositionId     INT NULL REFERENCES Position(Id),
    Note             NVARCHAR(255) NULL
);

CREATE TABLE Account (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role         INT NOT NULL,
    EmployeeId   INT NULL REFERENCES Employee(Id),
    IsActive     BIT NOT NULL DEFAULT 1
);
GO

-- Dữ liệu mẫu
INSERT INTO Department(Code, Name, Description) VALUES
(N'KT',  N'Kế toán',             N'Phòng kế toán'),
(N'NS',  N'Nhân sự',             N'Phòng nhân sự'),
(N'IT',  N'Công nghệ thông tin', N'Phòng IT');

INSERT INTO Position(Code, Name, Allowance) VALUES
(N'NV',  N'Nhân viên',    0),
(N'TP',  N'Trưởng phòng', 3000000),
(N'GD',  N'Giám đốc',     8000000);
GO