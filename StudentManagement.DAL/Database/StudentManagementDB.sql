
CREATE DATABASE StudentManagementDB;
GO

USE StudentManagementDB;
GO

-- 1. Bảng Khoa
CREATE TABLE Departments
(
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);
GO

-- 2. Bảng Lớp
CREATE TABLE Classes
(
    ClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(50) NOT NULL UNIQUE,
    DepartmentID INT NOT NULL,
    AcademicYear NVARCHAR(20),

    CONSTRAINT FK_Classes_Departments
    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);
GO

-- 3. Bảng Sinh viên
CREATE TABLE Students
(
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentCode VARCHAR(20) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Phone VARCHAR(15),
    Email VARCHAR(100),
    Address NVARCHAR(255),
    ClassID INT NOT NULL,

    CONSTRAINT FK_Students_Classes
    FOREIGN KEY (ClassID)
    REFERENCES Classes(ClassID)
);
GO

-- 4. Bảng Môn học
CREATE TABLE Subjects
(
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectCode VARCHAR(20) NOT NULL UNIQUE,
    SubjectName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL CHECK (Credits > 0)
);
GO

-- 5. Bảng Điểm
CREATE TABLE Grades
(
    GradeID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    SubjectID INT NOT NULL,
    Semester INT NOT NULL CHECK (Semester BETWEEN 1 AND 3),
    SchoolYear NVARCHAR(20) NOT NULL,
    MidtermScore DECIMAL(4,2) CHECK (MidtermScore BETWEEN 0 AND 10),
    FinalScore DECIMAL(4,2) CHECK (FinalScore BETWEEN 0 AND 10),
    TotalScore DECIMAL(4,2) CHECK (TotalScore BETWEEN 0 AND 10),

    CONSTRAINT FK_Grades_Students
    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),

    CONSTRAINT FK_Grades_Subjects
    FOREIGN KEY (SubjectID)
    REFERENCES Subjects(SubjectID),

    CONSTRAINT UQ_Grades_Student_Subject
    UNIQUE (StudentID, SubjectID, Semester, SchoolYear)
);
GO


USE StudentManagementDB;
GO

INSERT INTO Departments (DepartmentName, Description)
VALUES
(N'Công nghệ thông tin', N'Đào tạo CNTT'),
(N'Quản trị kinh doanh', N'Đào tạo kinh doanh'),
(N'Kế toán', N'Đào tạo kế toán');

INSERT INTO Classes (ClassName, DepartmentID, AcademicYear)
VALUES
('CNTT01', 1, '2024-2028'),
('CNTT02', 1, '2024-2028'),
('QTKD01', 2, '2024-2028'),
('KT01', 3, '2024-2028');

INSERT INTO Students
(StudentCode, FullName, DateOfBirth, Gender, Phone, Email, Address, ClassID)
VALUES
('SV001', N'Nguyễn Văn An', '2005-01-15', N'Nam', '0901234567', 'an@gmail.com', N'TP.HCM', 1),
('SV002', N'Trần Thị Bình', '2005-03-20', N'Nữ', '0901234568', 'binh@gmail.com', N'TP.HCM', 1),
('SV003', N'Lê Văn Cường', '2004-07-10', N'Nam', '0901234569', 'cuong@gmail.com', N'Đồng Nai', 2),
('SV004', N'Phạm Thị Dung', '2005-11-05', N'Nữ', '0901234570', 'dung@gmail.com', N'Bình Dương', 3);

INSERT INTO Subjects (SubjectCode, SubjectName, Credits)
VALUES
('CS101', N'Lập trình C#', 3),
('DB101', N'Cơ sở dữ liệu', 3),
('AI101', N'Trí tuệ nhân tạo', 3);

INSERT INTO Grades
(StudentID, SubjectID, Semester, SchoolYear, MidtermScore, FinalScore, TotalScore)
VALUES
(1, 1, 1, '2025-2026', 8.0, 9.0, 8.6),
(1, 2, 1, '2025-2026', 7.5, 8.0, 7.8),
(2, 1, 1, '2025-2026', 9.0, 9.5, 9.3),
(3, 2, 1, '2025-2026', 6.5, 7.0, 6.8),
(4, 3, 1, '2025-2026', 8.0, 8.5, 8.3);
GO

SELECT * FROM Departments;
SELECT * FROM Classes;
SELECT * FROM Students;
SELECT * FROM Subjects;
SELECT * FROM Grades;