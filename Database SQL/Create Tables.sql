USE [UWAdventure]
GO

CREATE SCHEMA [production]
GO
CREATE SCHEMA [sales]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [production].[brands](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand_name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [production].[categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [production].[inventory](
	[store_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[store_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [production].[products](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [varchar](255) NOT NULL,
	[brand_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[model_year] [smallint] NOT NULL,
	[list_price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sales].[customers]    Script Date: 11/25/2018 7:23:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sales].[customers](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NOT NULL,
	[last_name] [varchar](255) NOT NULL,
	[phone] [varchar](25) NULL,
	[email] [varchar](255) NOT NULL,
	[street] [varchar](255) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](25) NULL,
	[zip_code] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sales].[order_items]    Script Date: 11/25/2018 7:23:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sales].[order_items](
	[order_number] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK__order_it__837942D45E55C41C] PRIMARY KEY CLUSTERED 
(
	[order_number] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sales].[orders]    Script Date: 11/25/2018 7:23:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sales].[orders](
	[order_number] [int] IDENTITY(10000,1) NOT NULL,
	[customer_id] [int] NULL,
	[order_status] [tinyint] NOT NULL,
	[order_date] [date] NOT NULL,
	[shipped_date] [date] NULL,
	[store_id] [int] NOT NULL,
	[staff_id] [int] NOT NULL,
 CONSTRAINT [PK__orders__46596229C749AB08] PRIMARY KEY CLUSTERED 
(
	[order_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sales].[staffs]    Script Date: 11/25/2018 7:23:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sales].[staffs](
	[staff_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone] [varchar](25) NULL,
	[active] [tinyint] NOT NULL,
	[store_id] [int] NOT NULL,
	[manager_id] [int] NULL,
	[pin] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[staff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sales].[stores]    Script Date: 11/25/2018 7:23:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sales].[stores](
	[store_id] [int] IDENTITY(1,1) NOT NULL,
	[store_name] [varchar](255) NOT NULL,
	[phone] [varchar](25) NULL,
	[email] [varchar](255) NULL,
	[street] [varchar](255) NULL,
	[city] [varchar](255) NULL,
	[state] [varchar](10) NULL,
	[zip_code] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[store_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [sales].[staffs] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [production].[inventory]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [production].[products] ([product_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [production].[inventory]  WITH CHECK ADD FOREIGN KEY([store_id])
REFERENCES [sales].[stores] ([store_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [production].[products]  WITH CHECK ADD FOREIGN KEY([brand_id])
REFERENCES [production].[brands] ([brand_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [production].[products]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [production].[categories] ([category_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [sales].[order_items]  WITH CHECK ADD  CONSTRAINT [FK__order_ite__order__114A936A] FOREIGN KEY([order_number])
REFERENCES [sales].[orders] ([order_number])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [sales].[order_items] CHECK CONSTRAINT [FK__order_ite__order__114A936A]
GO
ALTER TABLE [sales].[order_items]  WITH CHECK ADD  CONSTRAINT [FK__order_ite__produ__123EB7A3] FOREIGN KEY([product_id])
REFERENCES [production].[products] ([product_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [sales].[order_items] CHECK CONSTRAINT [FK__order_ite__produ__123EB7A3]
GO
ALTER TABLE [sales].[orders]  WITH CHECK ADD  CONSTRAINT [FK__orders__customer__0B91BA14] FOREIGN KEY([customer_id])
REFERENCES [sales].[customers] ([customer_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [sales].[orders] CHECK CONSTRAINT [FK__orders__customer__0B91BA14]
GO
ALTER TABLE [sales].[orders]  WITH CHECK ADD  CONSTRAINT [FK__orders__staff_id__0D7A0286] FOREIGN KEY([staff_id])
REFERENCES [sales].[staffs] ([staff_id])
GO
ALTER TABLE [sales].[orders] CHECK CONSTRAINT [FK__orders__staff_id__0D7A0286]
GO
ALTER TABLE [sales].[orders]  WITH CHECK ADD  CONSTRAINT [FK__orders__store_id__0C85DE4D] FOREIGN KEY([store_id])
REFERENCES [sales].[stores] ([store_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [sales].[orders] CHECK CONSTRAINT [FK__orders__store_id__0C85DE4D]
GO
ALTER TABLE [sales].[staffs]  WITH CHECK ADD FOREIGN KEY([manager_id])
REFERENCES [sales].[staffs] ([staff_id])
GO
ALTER TABLE [sales].[staffs]  WITH CHECK ADD FOREIGN KEY([store_id])
REFERENCES [sales].[stores] ([store_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
