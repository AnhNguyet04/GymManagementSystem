IF DB_ID('QLGym') IS NULL 
	CREATE DATABASE QLGym
GO
USE QLGym
GO
--====================BẢNG USERS==================================
CREATE TABLE [dbo].[Users]
(
	[User_id] [int] IDENTITY(1,1),
	[Username] [varchar](50) UNIQUE NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Full_name] [nvarchar](100) NOT NULL,
	[DOB] [datetime],
	[Phone] [varchar](20),
	[Email] [varchar](100) UNIQUE NOT NULL,
	[Address] [nvarchar](100),
	[Role] [nvarchar](50) NOT NULL,
	PRIMARY KEY (User_id),
	CONSTRAINT CHK_Role CHECK ([Role] IN (N'Admin',N'Lễ tân',N'Huấn luyện viên')),
)
GO

SELECT * FROM [dbo].[Users];
--======================================================
INSERT INTO [dbo].[Users] ([Username], [Password], [Full_name], [DOB], [Phone], [Email], [Address], [Role])
VALUES
('Admin1','123456',N'Nguyễn Văn Hùng','1985-01-15','0123456789','admin1@gmail.com',N'Quận 7, TP.HCM',N'Admin'),
('ThiAnh','1235',N'Trần Thị Anh','1990-02-20','0987654321','receptionist1@gmail.com',N'Nhà Bè, TP.HCM',N'Lễ tân'),
('MinhHuy','6789',N'Lê Minh Huy','2000-09-05','0912345678','hlvso1@gmail.com',N'Nhà Bè, TP.HCM',N'Huấn luyện viên')
--===================BẢNG PHÂN LOẠI================================
CREATE TABLE [dbo].[Categories] 
(
    [Category_id] INT IDENTITY(1,1) PRIMARY KEY,
    [Category_name] VARCHAR(50) UNIQUE NOT NULL
);
SELECT * FROM [dbo].[Categories];
--======================================================
INSERT INTO [dbo].[Categories] ([Category_name]) 
VALUES ('Bums and Tums'), ('Cycling'), ('Dance'), ('Group'), ('Yoga'), ('Personal Trainer')
--===================BẢNG LỚP HỌC===================================
CREATE TABLE [dbo].[Classes]
(
	[Class_id] [int] IDENTITY(1,1),
	[Class_name] [nvarchar](100) NOT NULL,
	[Category] [int] NOT NULL,
	[Trainer_id] [int] NOT NULL,
	[Schedule] [nvarchar](255) NOT NULL,
	[Max_Student] [int] NOT NULL CHECK ([Max_Student]>0),
	[Price] [decimal](10,2) NOT NULL CHECK ([Price]>=0),
	[Start_date] [datetime] NOT NULL,
	[End_date] [datetime] NOT NULL,
	[Description] [nvarchar](255),
	PRIMARY KEY (Class_id),
	CONSTRAINT FK_Classes_Trainer FOREIGN KEY ([Trainer_id]) REFERENCES [dbo].[Users]([User_id]),
	CONSTRAINT FK_Classes_Categories FOREIGN KEY ([Category]) REFERENCES [dbo].[Categories]([Category_id])
)
GO
SELECT * FROM [dbo].[Classes];
--======================================================
INSERT INTO [dbo].[Classes] ([Class_name], [Category], [Trainer_id], [Schedule], [Max_Student], [Price], [Start_date], [End_date], [Description])
VALUES
    (N'Yoga Buổi Sáng', 5, 3, N'Mon 08:00-10:00; Wed 08:00-10:00', 20, 150000, '2025-05-01', '2025-06-30', N'Lớp yoga dành cho mọi cấp độ.'),
    (N'HLV Cá Nhân 1 Kèm 1', 6, 3, N'Tue 18:00-19:30; Thu 18:00-19:30', 1, 500000, '2025-05-01', '2025-07-15', N'Chương trình tập luyện riêng biệt.')
--===================BẢNG HỌC VIÊN===================================
CREATE TABLE [dbo].[Students]
(
	[Student_id] [int] IDENTITY(1,1),
	[Full_name] [nvarchar](100) NOT NULL,
	[DOB] [datetime],
	[Gender] [nvarchar](10),
	[Phone] [varchar](20),
	[Email] [varchar](100) UNIQUE NOT NULL,
	[Address] [nvarchar](100),
	[RegisteredDate] [datetime] DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (Student_id)
)
SELECT * FROM [dbo].[Students];
--======================================================
INSERT INTO [dbo].[Students] ([Full_name], [DOB], [Gender], [Phone], [Email], [Address], [RegisteredDate])
VALUES
	(N'Phan Thị Cẩm Huyền','1995-08-30',N'Nữ','0901234567','camhuyen95@gmail.com',N'Quận 4, TP.HCM','2024-03-05 06:00:00'),
	(N'Ngô Văn Úy','1997-11-05',N'Nam', '0934567890','vanuytanphu@gmail.com',N'Tân Phú, TP.HCM','2024-02-06 08:00:00')
--===================BẢNG ĐĂNG KÝ LỚP HỌC===================================
CREATE TABLE [dbo].[Student_Classes]
(
	[Student_id] [int],
	[Class_id] [int] NOT NULL,
	[Registered] [datetime] DEFAULT CURRENT_TIMESTAMP,
	[Status] [nvarchar](20) NOT NULL DEFAULT N'Đang hoạt động',
	PRIMARY KEY (Student_id, Class_id),
	CONSTRAINT CHK_Status CHECK ([Status] IN (N'Đang hoạt động', N'Đã bị hủy')),
    CONSTRAINT FK_Students_Classes_Students FOREIGN KEY ([Student_id]) REFERENCES [dbo].[Students]([Student_id]) ON DELETE CASCADE,
    CONSTRAINT FK_Students_Classes_Classes FOREIGN KEY ([Class_id]) REFERENCES [dbo].[Classes]([Class_id]) ON DELETE CASCADE,
	CONSTRAINT UQ_Student_Class UNIQUE ([Student_id], [Class_id]) -- Ngăn chặn đăng ký trùng lớp
)
GO
SELECT * FROM [dbo].[Student_Classes];
--======================================================
INSERT INTO [dbo].[Student_Classes] ([Student_id], [Class_id], [Registered], [Status])
VALUES 
    (1, 1, GETDATE(), N'Đang hoạt động'),
    (2, 2, GETDATE(), N'Đang hoạt động')
GO
--===================BẢNG GÓI TẬP ===================================
CREATE TABLE [dbo].[Memberships]
(
	[Membership_id] [int] IDENTITY(1,1),
	[Student_id] [int] NOT NULL,
	[Package_type] [nvarchar](50) NOT NULL,
	[Start_date] [date] NOT NULL,
	[End_date] [date] NOT NULL,
	[Price] [decimal](10,2) NOT NULL CHECK ([Price]>=0),
	PRIMARY KEY (Membership_id),
	CONSTRAINT CHK_PackageType CHECK ([Package_type] IN (N'Tháng', N'Quý', N'Năm')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho package_type
    CONSTRAINT CHK_MembershipDates CHECK ([End_date] > [Start_date]),  -- Đảm bảo ngày kết thúc lớn hơn ngày bắt đầu
	CONSTRAINT FK_Memberships_Students FOREIGN KEY ([Student_id]) REFERENCES [dbo].[Students]([Student_id]) ON DELETE CASCADE
)
GO
SELECT * FROM [dbo].[Memberships];
--======================================================
INSERT INTO [dbo].[Memberships] ([Student_id], [Package_type], [Start_date], [End_date], [Price])
VALUES
(1, N'Tháng', '2025-04-01', '2025-04-30', 500000),
(2, N'Năm', '2025-04-01', '2026-04-1', 5000000)
--===================BẢNG THANH TOÁN ===================================
CREATE TABLE [dbo].[Payment]
(
	[Payment_id] [int] IDENTITY(1,1),
	[Student_id] [int] NOT NULL,
	[Amount] [decimal](10,2) NOT NULL,
	[Payment_method] [nvarchar](50) NOT NULL,
	[Payment_Type] [varchar](50) NOT NULL,
	[Reference_id] [int],                    --Liên kết với Student_Classes
	[Transaction_date] [datetime] DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (Payment_id),
	CONSTRAINT CHK_PaymentMethod CHECK ([Payment_method] IN (N'Tiền mặt', N'Thẻ', N'Ví điện tử')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho payment_method
    CONSTRAINT CHK_PaymentType CHECK ([Payment_type] IN ('Membership', 'Class')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho payment_type
    CONSTRAINT FK_Payments_Students FOREIGN KEY ([Student_id]) REFERENCES [dbo].[Students]([Student_id]) ON DELETE CASCADE
)
GO
SELECT * FROM [dbo].[Payment];
--======================================================
INSERT INTO [dbo].[Payment] ([Student_id], [Amount], [Payment_method], [Payment_Type], [Reference_id])
VALUES
(1, 150000, N'Tiền mặt', N'Class',1),
(2, 5000000, N'Thẻ', N'Membership', NULL)
--===================BẢNG NHÂN VIÊN===================================
CREATE TABLE [dbo].[Employees]
(
	[Employee_id] [int] IDENTITY(1,1),
	[User_id] [int] UNIQUE NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	PRIMARY KEY (Employee_id),
	CONSTRAINT CK_Role CHECK ([Role] IN (N'Lễ tân', N'Huấn luyện viên',N'Admin')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho role
    CONSTRAINT FK_Employees_Users FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users]([user_id]) ON DELETE CASCADE
)
GO
SELECT * FROM [dbo].[Employees];
--======================================================
INSERT INTO [dbo].[Employees] ([User_id],[Role])
VALUES 
(1, N'Admin'),
(2, N'Lễ tân'),
(3, N'Huấn luyện viên')
--===================BẢNG PHÒNG TẬP===================================
CREATE TABLE [dbo].[Gyms]
(
	[Gym_id] [int] IDENTITY(1,1),
	[Gym_name] [nvarchar](100) UNIQUE NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Status] [nvarchar](50) DEFAULT N'Đang hoạt động',
	PRIMARY KEY (Gym_id),
	CONSTRAINT CHK_GymStatus CHECK ([Status] IN (N'Đang hoạt động', N'Đã đóng cửa', N'Đang bảo trì')) -- Ràng buộc giá trị hợp lệ
)
GO
SELECT * FROM [dbo].[Gyms];
--======================================================
INSERT INTO [dbo].[Gyms] ([Gym_name],[Address],[Status])
VALUES
(N'Cơ sở 1: EVOGYM Nguyễn Chí Thanh ',N'Nguyễn Chí Thanh, Phường 9, Quận 5, TP.HCM',N'Đang hoạt động'),
(N'Cơ sở 2: EVOGYM Him Lam ',N'Đường số 18, Khu dân cư Him Lam, Bình Chánh, TP.HCM',N'Đang hoạt động'),
(N'Cơ sở 3: EVOGYM Nguyễn Thị Thập ',N'Nguyễn Thị Thập, Tân Phú, Quận 7, TP.HCM',N'Đang bảo trì')
--===================BẢNG THIẾT BỊ===================================
CREATE TABLE [dbo].[Equipment]
(
	[Equipment_id] [int] IDENTITY(1,1),
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Purchase_date] [date] NOT NULL,
	[Status] [nvarchar](100) DEFAULT N'Tốt',
	[Gym_id] [int] NOT NULL,
	PRIMARY KEY (Equipment_id),
	CONSTRAINT CHK_EquipmentType CHECK ([Type] IN (N'Thiết bị tập tim mạch',N'Thiết bị tập sức mạnh',N'Thiết bị tập chức năng',N'Thiết bị tập cơ bụng',N'Thiết bị tập nhóm cơ',N'Thiết bị hỗ trợ tập luyện',N'Thiết bị tập nhóm thể hình')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho type
    CONSTRAINT CHK_EquipmentStatus CHECK ([Status] IN (N'Tốt', N'Cần bảo trì', N'Hư hỏng')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho status
	CONSTRAINT FK_Equipment_Gym FOREIGN KEY ([Gym_id]) REFERENCES [dbo].[Gyms]([Gym_id]) ON DELETE CASCADE
)
GO
SELECT * FROM [dbo].[Equipment];
--======================================================
INSERT INTO [dbo].[Equipment] ([Name],[Type],[Purchase_date],[Status],[Gym_id])
VALUES
(N'Máy chạy bộ', N'Thiết bị tập tim mạch', '2023-01-15', N'Tốt', 1),
(N'Tạ đơn 10kg', N'Thiết bị tập sức mạnh', '2022-08-10', N'Tốt', 1),
(N'Máy kéo xô', N'Thiết bị tập nhóm cơ', '2021-05-20', N'Cần bảo trì', 2),
(N'Xe đạp tập thể dục', N'Thiết bị tập tim mạch', '2023-06-01', N'Tốt', 3),
(N'Ab Bench', N'Thiết bị tập cơ bụng', '2020-12-12', N'Hư hỏng', 2)
--===================BẢNG BẢO TRÌ THIẾT BỊ===================================
CREATE TABLE [dbo].[Maintenance]
(
	[Maintenance_id] [int] IDENTITY(1,1),
	[Equipment_id] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Status] [nvarchar](50) DEFAULT N'Đang bảo trì',
	PRIMARY KEY ([Maintenance_id]),
	CONSTRAINT CHK_MaintenanceStatus CHECK ([Status] IN (N'Đang bảo trì', N'Đã hoàn thành')),  -- Ràng buộc kiểm tra giá trị hợp lệ cho status
    CONSTRAINT FK_Maintenance_Equipment FOREIGN KEY ([Equipment_id]) REFERENCES [dbo].[Equipment]([Equipment_id])
)
GO
SELECT * FROM [dbo].[Maintenance];

--======================================================
INSERT INTO [dbo].[Maintenance] ([Equipment_id],[Date],[Status])
VALUES
(3, '2021-06-01', N'Đang bảo trì')

ALTER TABLE [dbo].[Maintenance]
ADD 
    [ActualMaintenanceDate] [date] NULL,
    [NextMaintenanceDate] [date] NULL;