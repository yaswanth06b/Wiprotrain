?USE [master]
GO
/****** Object:  Database [lms]    Script Date: 02-08-2025 14:27:40 ******/
CREATE DATABASE [lms]
GO
USE [lms]
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] NOT NULL Primary Key,
	[EmployName] [varchar](30) NULL,
	[MgrId] [int] NULL,
	[LeaveAvail] [int] NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [varchar](30) NULL,
	[Mobile] [varchar](30) NULL
)
GO
CREATE TABLE [dbo].[LeaveHistory](
	[LeaveId] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[LeaveStartDate] [datetime] NULL,
	[LeaveEndDate] [datetime] NULL,
	[noOfDays] [int] NULL,
	[LeaveStatus] [varchar](30) NULL,
	[LeaveReason] [varchar](30) NULL,
	[ManagerComments] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([EmpId], [EmployName], [MgrId], [LeaveAvail], [DateOfBirth], [Email], [Mobile]) VALUES (1000, N'Muskan', NULL, 20, CAST(N'2002-12-12T00:00:00.000' AS DateTime), N'muskan@gmail.com', N'992445552')
INSERT [dbo].[Employee] ([EmpId], [EmployName], [MgrId], [LeaveAvail], [DateOfBirth], [Email], [Mobile]) VALUES (2000, N'Aadithian', 1000, 22, CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'aadi@gmail.com', N'99293444')
INSERT [dbo].[Employee] ([EmpId], [EmployName], [MgrId], [LeaveAvail], [DateOfBirth], [Email], [Mobile]) VALUES (3000, N'Avinash', 1000, 28, CAST(N'2001-11-11T00:00:00.000' AS DateTime), N'Avin@gmail.com', N'9922445')
INSERT [dbo].[Employee] ([EmpId], [EmployName], [MgrId], [LeaveAvail], [DateOfBirth], [Email], [Mobile]) VALUES (4000, N'Prashanth', 2000, 18, CAST(N'2002-11-12T00:00:00.000' AS DateTime), N'prash@gmail.com', N'99234544')
INSERT [dbo].[Employee] ([EmpId], [EmployName], [MgrId], [LeaveAvail], [DateOfBirth], [Email], [Mobile]) VALUES (5000, N'Anjali', 3000, 18, CAST(N'2002-12-12T00:00:00.000' AS DateTime), N'anjali@gmail.com', N'9994222')
GO
SET IDENTITY_INSERT [dbo].[LeaveHistory] ON 

INSERT [dbo].[LeaveHistory] ([LeaveId], [EmpId], [LeaveStartDate], [LeaveEndDate], [noOfDays], [LeaveStatus], [LeaveReason], [ManagerComments]) VALUES (1, 2000, CAST(N'2025-10-10T00:00:00.000' AS DateTime), CAST(N'2025-10-11T00:00:00.000' AS DateTime), NULL, N'PENDING', N'Going Home', NULL)
INSERT [dbo].[LeaveHistory] ([LeaveId], [EmpId], [LeaveStartDate], [LeaveEndDate], [noOfDays], [LeaveStatus], [LeaveReason], [ManagerComments]) VALUES (2, 2000, CAST(N'2025-11-11T00:00:00.000' AS DateTime), CAST(N'2025-11-14T00:00:00.000' AS DateTime), NULL, N'PENDING', N'Marriage', NULL)
INSERT [dbo].[LeaveHistory] ([LeaveId], [EmpId], [LeaveStartDate], [LeaveEndDate], [noOfDays], [LeaveStatus], [LeaveReason], [ManagerComments]) VALUES (3, 3000, CAST(N'2025-12-12T00:00:00.000' AS DateTime), CAST(N'2025-12-14T00:00:00.000' AS DateTime), NULL, N'PENDING', N'Convocation', NULL)
SET IDENTITY_INSERT [dbo].[LeaveHistory] OFF
GO
ALTER TABLE [dbo].[LeaveHistory] ADD  DEFAULT ('PENDING') FOR [LeaveStatus]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([MgrId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([MgrId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
ALTER TABLE [dbo].[LeaveHistory]  WITH CHECK ADD FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
USE [master]
GO
ALTER DATABASE [lms] SET  READ_WRITE 
GO