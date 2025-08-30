USE QLGym
GO

--LỚP
CREATE PROC uspAddClass
	@class_name nvarchar(100),
	@category int,
	@trainer_id int,
	@schedule nvarchar,
	@max_student int,
	@price decimal(10,2),
	@startdate datetime,
	@enddate datetime,
	@mota nvarchar(255)
AS
BEGIN
	INSERT INTO Classes (Class_name, Category, Trainer_id, Schedule, Max_Student, Price, Start_date, End_date, Description)
	VALUES (@class_name, @category, @trainer_id, @schedule, @max_student, @price, @startdate, @enddate, @mota)
END
GO

ALTER PROC uspAddClass
	@class_name nvarchar(100),
	@category int,
	@trainer_id int,
	@schedule nvarchar(255), -- cập nhật tại đây
	@max_student int,
	@price decimal(10,2),
	@startdate datetime,
	@enddate datetime,
	@mota nvarchar(255)
AS
BEGIN
	INSERT INTO Classes (Class_name, Category, Trainer_id, Schedule, Max_Student, Price, Start_date, End_date, Description)
	VALUES (@class_name, @category, @trainer_id, @schedule, @max_student, @price, @startdate, @enddate, @mota)
END
GO

CREATE PROC uspUpdateClass
	@class_id INT,
	@class_name nvarchar(100),
	@category int,
	@trainer_id int,
	@schedule nvarchar(255),
	@max_student int,
	@price decimal(10,2),
	@startdate datetime,
	@enddate datetime,
	@mota nvarchar(255)
AS
BEGIN
	UPDATE Classes
	SET
		Class_name = @class_name,
        Category = @category,
        Trainer_id = @trainer_id,
        Schedule = @schedule,
        Max_Student = @max_student,
        Price = @price,
        Start_date = @startdate,
        End_date = @enddate,
        Description = @mota
    WHERE Class_id = @class_id;
END
GO

CREATE PROC uspDeleteClass
	@class_id int
AS
BEGIN
	DELETE FROM Classes
	WHERE Class_id = @class_id;
END
GO

--HỌC VIÊN
CREATE PROC uspAddStudent
    @FullName NVARCHAR(100),
    @DOB DATE,
    @Gender NVARCHAR(10),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Students (Full_name, DOB, Gender, Phone, Email, Address, RegisteredDate)
    VALUES (@FullName, @DOB, @Gender, @Phone, @Email, @Address, GETDATE())
END
GO

CREATE PROC uspUpdateStudent
    @StudentId INT,
    @FullName NVARCHAR(100),
    @DOB DATE,
    @Gender NVARCHAR(10),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255)
AS
BEGIN
    UPDATE Students
    SET Full_name = @FullName,
        DOB = @DOB,
        Gender = @Gender,
        Phone = @Phone,
        Email = @Email,
        Address = @Address
    WHERE Student_id = @StudentId
END
GO

CREATE PROC uspDeleteStudent
    @StudentId INT
AS
BEGIN
    DELETE FROM Students WHERE Student_id = @StudentId
END
GO

--MEMBERSHIP
CREATE PROC uspAddMembership
    @StudentId INT,
    @PackageType NVARCHAR(50),
    @StartDate DATE,
    @EndDate DATE,
    @Price DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Memberships (Student_id, Package_type, Start_date, End_date, Price)
    VALUES (@StudentId, @PackageType, @StartDate, @EndDate, @Price)
END
GO

CREATE PROC uspDeleteMembershipByStudent
    @StudentId INT
AS
BEGIN
    DELETE FROM Memberships WHERE Student_id = @StudentId
END
GO
--Lấy gói tập hiện tại
CREATE PROC uspGetLatestMembershipByStudent
    @StudentId INT
AS
BEGIN
    SELECT TOP 1 * 
    FROM Memberships 
    WHERE Student_id = @StudentId 
    ORDER BY End_date DESC
END
GO
--Kiểm tra học viên có gói tập
CREATE OR ALTER PROC uspHasValidMembership
    @StudentId INT
AS
BEGIN
    SELECT COUNT(*) AS SoLuong
    FROM Memberships
    WHERE Student_id = @StudentId AND End_date >= GETDATE()
END
GO

--Kiểm tra trùng
CREATE OR ALTER PROC uspCheckStudentExists
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(15)
AS
BEGIN
    SELECT COUNT(*) AS SoLuong
    FROM Students
    WHERE Full_name = @FullName OR Email = @Email OR Phone = @Phone
END
GO
--Tìm kiếm học viên 
CREATE OR ALTER PROC uspSearchStudentsByName
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Students WHERE Full_name LIKE '%' + @TuKhoa + '%'
END
GO

CREATE OR ALTER PROC uspSearchStudentsByPhone
    @TuKhoa NVARCHAR(15)
AS
BEGIN
    SELECT * FROM Students WHERE Phone LIKE '%' + @TuKhoa + '%'
END
GO

CREATE OR ALTER PROC uspSearchStudentsByClassName
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT DISTINCT s.Student_id, s.Full_name, s.DOB, s.Gender, s.Phone, s.Email, s.Address, s.RegisteredDate
    FROM Students s
    INNER JOIN Student_Classes sc ON s.Student_id = sc.Student_id
    INNER JOIN Classes c ON sc.Class_id = c.Class_id
    WHERE c.Class_name LIKE '%' + @TuKhoa + '%'
END
GO

CREATE OR ALTER PROC uspGetPackageTypeList
AS
BEGIN
    SELECT DISTINCT Package_type, MIN(Price) AS Price 
    FROM Memberships 
    GROUP BY Package_type
END
GO

--NHÂN VIÊN
CREATE PROC uspAddNhanVien
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @FullName NVARCHAR(100),
    @DOB DATE,
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
    @Role NVARCHAR(50)
AS
BEGIN
    DECLARE @NewUserId INT;

    -- Thêm vào bảng Users
    INSERT INTO Users (Username, Password, Full_name, DOB, Phone, Email, Address, Role)
    VALUES (@Username, @Password, @FullName, @DOB, @Phone, @Email, @Address, @Role);

    -- Lấy ID vừa thêm
    SET @NewUserId = SCOPE_IDENTITY();
    -- Nếu không phải học viên thì thêm vào Employees
    BEGIN
    INSERT INTO Employees (User_id, Role)
    VALUES (@NewUserId, @Role);
    END
END
GO
CREATE OR ALTER PROC uspAddNhanVien 
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @FullName NVARCHAR(100),
    @DOB DATE,
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
    @Role NVARCHAR(50),
    @NewUserId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    --DECLARE @NewUserId INT;

    -- Thêm vào bảng Users
    INSERT INTO Users (Username, Password, Full_name, DOB, Phone, Email, Address, Role)
    VALUES (@Username, @Password, @FullName, @DOB, @Phone, @Email, @Address, @Role);

    -- Lấy ID vừa thêm
    SET @NewUserId = SCOPE_IDENTITY();

   
    BEGIN
        INSERT INTO Employees (User_id, Role)
        VALUES (@NewUserId, @Role);
    END
END
GO

CREATE PROC uspUpdateNhanVien
    @UserId INT,
     @Username NVARCHAR(50),
    @FullName NVARCHAR(100),
    @DOB DATE,
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255), 
    @Role NVARCHAR(50)
AS
BEGIN
    UPDATE Users
    SET
        Username=@Username,
        Full_name = @FullName,
        DOB = @DOB,
        Phone = @Phone,
        Email = @Email,
        Address = @Address,
        Role = @Role
    WHERE User_id = @UserId;
END
GO

CREATE PROC uspDeleteNhanVien
    @UserId INT
AS
BEGIN
    DELETE FROM Employees WHERE User_id = @UserId;
    DELETE FROM Users WHERE User_id = @UserId;
END
GO

ALTER PROC uspDeleteNhanVien
    @UserId INT
AS
BEGIN
    -- Nếu nhân viên đang là huấn luyện viên có lớp dạy thì không xóa
    IF EXISTS (SELECT 1 FROM Classes WHERE Trainer_id = @UserId)
    BEGIN
        RAISERROR(N'Không thể xóa vì nhân viên này đang phụ trách lớp học.', 16, 1);
        RETURN;
    END

    DELETE FROM Employees WHERE User_id = @UserId;
    DELETE FROM Users WHERE User_id = @UserId;
END
GO
--Kiểm tra trùng 
CREATE PROC uspKiemTraTrung
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @Count INT OUTPUT
AS
BEGIN
    SELECT @Count = COUNT(*) 
    FROM Users 
    WHERE Username = @Username OR Email = @Email;
END
GO
--Thêm vào Employees
CREATE PROC uspThemVaoEmployees
    @UserId INT,
    @Role NVARCHAR(50)
AS
BEGIN
    INSERT INTO Employees (User_id, Role)
    VALUES (@UserId, @Role);
END
GO
ALTER PROC uspThemVaoEmployees
    @UserId INT,
    @Role NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Employees WHERE User_id = @UserId)
    BEGIN
         INSERT INTO Employees (User_id, Role)
        VALUES (@UserId, @Role);
    END
    -- Luôn trả về một hàng được ảnh hưởng (để tránh ExecuteNonQuery trả 0)
    SELECT 1;
END
GO

CREATE OR ALTER PROC uspSearchNhanVienByName
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT u.User_id, u.Username, u.Full_name, u.DOB, u.Phone, u.Email, u.Address, e.Role
    FROM Users u
    INNER JOIN Employees e ON u.User_id = e.User_id
    WHERE u.Full_name LIKE '%' + @TuKhoa + '%'
END
GO

-- Tìm kiếm nhân viên theo số điện thoại
CREATE OR ALTER PROC uspSearchNhanVienByPhone
    @TuKhoa NVARCHAR(20)
AS
BEGIN
    SELECT u.User_id, u.Username, u.Full_name, u.DOB, u.Phone, u.Email, u.Address, e.Role
    FROM Users u
    INNER JOIN Employees e ON u.User_id = e.User_id
    WHERE u.Phone LIKE '%' + @TuKhoa + '%'
END
GO

--THIẾT BỊ
CREATE PROCEDURE uspAddEquipment
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @PurchaseDate DATETIME,
    @Status NVARCHAR(50),
    @GymId INT
AS
BEGIN
    INSERT INTO Equipment (Name, Type, Purchase_date, Status, Gym_id)
    VALUES (@Name, @Type, @PurchaseDate, @Status, @GymId)
END
GO

CREATE PROCEDURE uspUpdateEquipment
    @EquipmentId INT,
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @PurchaseDate DATETIME,
    @Status NVARCHAR(50),
    @GymId INT
AS
BEGIN
    UPDATE Equipment
    SET Name = @Name, Type = @Type, Purchase_date = @PurchaseDate, Status = @Status, Gym_id = @GymId
    WHERE Equipment_id = @EquipmentId
END
GO

CREATE PROCEDURE uspDeleteEquipment
    @EquipmentId INT
AS
BEGIN
    DELETE FROM Equipment WHERE Equipment_id = @EquipmentId
END
GO

--Cập nhật tình trạng thiết bị
CREATE PROCEDURE uspCapNhatTinhTrangThietBi
    @EquipmentId INT,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Equipment
    SET Status = @Status
    WHERE Equipment_id = @EquipmentId
END
GO
