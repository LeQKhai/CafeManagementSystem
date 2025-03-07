USE [master]
GO
/****** Object:  Database [C:\USERS\PC\DOCUMENTS\CAFE.MDF]    Script Date: 3/6/2025 11:27:34 PM ******/
CREATE DATABASE cafe
GO
USE cafe
GO
/****** Object:  Table [dbo].[users]    Script Date: 3/6/2025 11:27:34 PM ******/
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NULL,
	[password] [varchar](max) NULL,
	[profile_image] [varchar](max) NULL,
	[role] [varchar](max) NULL,
	[status] [varchar](max) NULL,
	[date_reg] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [password], [profile_image], [role], [status], [date_reg]) VALUES (1, N'admin', N'admin123', N'', N'Admin', N'Active', CAST(N'2024-03-04' AS Date))
SET IDENTITY_INSERT [dbo].[users] OFF
GO