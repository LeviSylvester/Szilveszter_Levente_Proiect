USE [Szilveszter_Levente_Proiect.Data]
GO
/****** Object:  Table [dbo].[Caller]    Script Date: 1/15/2023 9:14:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CallerName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Caller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/15/2023 9:14:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sender]    Script Date: 1/15/2023 9:14:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sender](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 1/15/2023 9:14:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Recipient] [nvarchar](150) NOT NULL,
	[SenderID] [int] NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[BookingDateTime] [datetime2](7) NOT NULL,
	[CallerID] [int] NOT NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipmentCategory]    Script Date: 1/15/2023 9:14:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipmentCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_ShipmentCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Caller] ON 

INSERT [dbo].[Caller] ([ID], [CallerName]) VALUES (1, N'Dr. Almas Alexandru Str. Almas Nr. 1/1 Tel. 0744123123')
INSERT [dbo].[Caller] ([ID], [CallerName]) VALUES (2, N'Dr. Balog Baltazar Str. Branelor Nr. 2/2 0742123123')
INSERT [dbo].[Caller] ([ID], [CallerName]) VALUES (3, N'Carol Cristian Str. Conrad Nr. 3/3 0743123123')
SET IDENTITY_INSERT [dbo].[Caller] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (1, N'Standard')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (2, N'Dental')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (4, N'Food')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (5, N'Fragile')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (6, N'Urgent')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Sender] ON 

INSERT [dbo].[Sender] ([ID], [FirstName], [LastName], [Address], [Phone]) VALUES (1, N'Alexandru', N'Almas', N'Str. Albac Nr. 1/1', N'0741123123')
INSERT [dbo].[Sender] ([ID], [FirstName], [LastName], [Address], [Phone]) VALUES (2, N'Baltazar', N'Balog', N'Str. Branei Nr. 2/2', N'0742123123')
SET IDENTITY_INSERT [dbo].[Sender] OFF
GO
SET IDENTITY_INSERT [dbo].[Shipment] ON 

INSERT [dbo].[Shipment] ([ID], [Recipient], [SenderID], [Price], [BookingDateTime], [CallerID]) VALUES (2, N'Str. Albac Nr. 4/4 0744123123', 2, CAST(15.00 AS Decimal(6, 2)), CAST(N'2023-01-14T18:50:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Shipment] ([ID], [Recipient], [SenderID], [Price], [BookingDateTime], [CallerID]) VALUES (3, N'Str. Albac Nr. 4/4 0744123123', 2, CAST(10.00 AS Decimal(6, 2)), CAST(N'2023-01-14T18:53:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Shipment] ([ID], [Recipient], [SenderID], [Price], [BookingDateTime], [CallerID]) VALUES (4, N'Str. Cezar Nr. 5/5', 2, CAST(9.00 AS Decimal(6, 2)), CAST(N'2023-01-14T18:54:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Shipment] ([ID], [Recipient], [SenderID], [Price], [BookingDateTime], [CallerID]) VALUES (6, N'Str. Cezar Nr. 5/5', 1, CAST(15.00 AS Decimal(6, 2)), CAST(N'2023-01-14T19:29:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Shipment] ([ID], [Recipient], [SenderID], [Price], [BookingDateTime], [CallerID]) VALUES (7, N'Str. Republicii Nr. 3/3 Tel. 0745123123', 2, CAST(25.00 AS Decimal(6, 2)), CAST(N'2023-01-14T19:57:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Shipment] OFF
GO
SET IDENTITY_INSERT [dbo].[ShipmentCategory] ON 

INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (2, 2, 4)
INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (3, 3, 1)
INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (5, 6, 6)
INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (6, 7, 2)
INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (7, 7, 5)
INSERT [dbo].[ShipmentCategory] ([ID], [ShipmentID], [CategoryID]) VALUES (8, 7, 6)
SET IDENTITY_INSERT [dbo].[ShipmentCategory] OFF
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Caller_CallerID] FOREIGN KEY([CallerID])
REFERENCES [dbo].[Caller] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_Caller_CallerID]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Sender_SenderID] FOREIGN KEY([SenderID])
REFERENCES [dbo].[Sender] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_Sender_SenderID]
GO
ALTER TABLE [dbo].[ShipmentCategory]  WITH CHECK ADD  CONSTRAINT [FK_ShipmentCategory_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShipmentCategory] CHECK CONSTRAINT [FK_ShipmentCategory_Category_CategoryID]
GO
ALTER TABLE [dbo].[ShipmentCategory]  WITH CHECK ADD  CONSTRAINT [FK_ShipmentCategory_Shipment_ShipmentID] FOREIGN KEY([ShipmentID])
REFERENCES [dbo].[Shipment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShipmentCategory] CHECK CONSTRAINT [FK_ShipmentCategory_Shipment_ShipmentID]
GO
