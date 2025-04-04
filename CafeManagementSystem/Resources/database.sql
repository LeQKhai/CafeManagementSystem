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
GO
CREATE TABLE products
(
	id INT PRIMARY KEY IDENTITY(1,1),
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	prod_type VARCHAR(MAX) NULL,
	prod_stock VARCHAR(MAX) NULL,
	prod_price VARCHAR(MAX) NULL,
	prod_status VARCHAR(MAX) NULL,
	prod_image VARCHAR(MAX) NULL,
	date_insert DATE NULL,
	date_update DATE NULL,
	date_delete DATE NULL
)
GO

INSERT [dbo].[users] ([id], [username], [password], [profile_image], [role], [status], [date_reg]) VALUES (1, N'admin', N'admin123', N'', N'Admin', N'Active', CAST(N'2024-03-04' AS Date))
SET IDENTITY_INSERT [dbo].[users] OFF
GO


-- Orders
CREATE TABLE order_details
(
	id INT PRIMARY KEY IDENTITY(1,1),
	order_id INT NULL,
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	prod_type VARCHAR(MAX) NULL,
	prod_price FLOAT NULL,
	qty INT NULL,
	order_date DATE NULL,
	delete_order DATE NULL
)



-- customers
CREATE TABLE orders
(
	id INT PRIMARY KEY IDENTITY(1,1),
	order_id INT NULL,
	total_price FLOAT NULL,
	date DATE NULL,
	amount FLOAT NULL,
	change FLOAT NULL
)



