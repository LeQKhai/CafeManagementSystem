USE [master]
GO

/****** Object:  Database [cafe]    Script Date: 3/6/2025 11:27:34 PM ******/
CREATE DATABASE cafe
GO

USE cafe
GO

/****** Object:  Table [dbo].[users]    Script Date: 3/6/2025 11:27:34 PM ******/
CREATE TABLE [dbo].[users] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [username] [nvarchar](50) NULL,
    [password] [nvarchar](50) NULL,
    [profile_image] [nvarchar](255) NULL,
    [role] [nvarchar](20) NULL,
    [status] [nvarchar](20) NULL,
    [date_reg] [datetime] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([id], [username], [password], [profile_image], [role], [status], [date_reg]) 
VALUES (1, N'admin', N'admin123', N'', N'Admin', N'Active', CAST(N'2024-03-04' AS DateTime))
SET IDENTITY_INSERT [dbo].[users] OFF
GO

/****** Object:  Table [dbo].[products]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[products] (
    [prod_id] [nvarchar](50) NOT NULL,
    [prod_name] [nvarchar](100) NULL,
    [prod_type] [nvarchar](50) NULL,
    [prod_stock] [int] NULL,
    [prod_price] [float] NULL,
    [prod_status] [nvarchar](20) NULL,
    [prod_image] [nvarchar](255) NULL,
    [date_insert] [datetime] NULL,
    [date_update] [datetime] NULL,
    [date_delete] [datetime] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [prod_id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[customers]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[customers] (
    [cus_id] [int] IDENTITY(1,1) NOT NULL,
    [full_name] [nvarchar](50) NULL,
    [phone] [nvarchar](12) NOT NULL UNIQUE,
    [email] [nvarchar](100) NULL,
    [address] [nvarchar](255) NULL,
    [date_registered] [datetime] NOT NULL DEFAULT GETDATE(),
    [points] [int] DEFAULT 0,
    PRIMARY KEY CLUSTERED 
    (
        [cus_id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[promotions]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[promotions] (
    [code] [nvarchar](50) NOT NULL,
    [discount_percent] [int] NULL,
    [description] [nvarchar](255) NULL,
    [start_date] [date] NULL,
    [end_date] [date] NULL,
    [is_active] [bit] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [code] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[promotions] ([code], [discount_percent], [description], [start_date], [end_date], [is_active])
VALUES (N'KM10', 10, N'Giảm 10% cho tất cả đơn hàng', '2025-05-01', '2025-05-31', 1),
       (N'KM20', 20, N'Khuyến mãi mùa hè', '2024-06-01', '2024-08-31', 0)
GO

/****** Object:  Table [dbo].[orders]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[orders] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [cus_id] [int] NULL,
    [total_price] [float] NULL,
    [order_date] [datetime] NULL,
    [amount] [float] NULL,
    [change] [float] NULL,
    [promotion_code] [nvarchar](50) NULL,
    PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    FOREIGN KEY ([cus_id]) REFERENCES [dbo].[customers]([cus_id]),
    FOREIGN KEY ([promotion_code]) REFERENCES [dbo].[promotions]([code])
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[order_details]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[order_details] (
    [order_id] [int] NOT NULL,
    [prod_id] [nvarchar](50) NOT NULL,
    [qty] [int] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [order_id] ASC,
        [prod_id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    FOREIGN KEY ([order_id]) REFERENCES [dbo].[orders]([id]),
    FOREIGN KEY ([prod_id]) REFERENCES [dbo].[products]([prod_id])
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pagers]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[pagers] (
    [PagerID] [int] NOT NULL,
    [Status] [int] DEFAULT 0, -- 0: Chưa có đơn, 1: Đang xử lý, 2: Đã sẵn sàng
    PRIMARY KEY CLUSTERED 
    (
        [PagerID] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pager_orders]    Script Date: 3/6/2025 ******/
CREATE TABLE [dbo].[pager_orders] (
    [pager_id] [int] NOT NULL,
    [order_id] [int] NOT NULL,
    PRIMARY KEY CLUSTERED 
    (
        [pager_id] ASC,
        [order_id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    FOREIGN KEY ([pager_id]) REFERENCES [dbo].[pagers]([PagerID]),
    FOREIGN KEY ([order_id]) REFERENCES [dbo].[orders]([id]),
    CONSTRAINT UQ_pager_orders_order_id UNIQUE ([order_id]) -- Đảm bảo 1 đơn hàng chỉ gán 1 pager
) ON [PRIMARY]
GO