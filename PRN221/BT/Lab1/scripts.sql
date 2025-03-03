USE [MyStock]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 9/11/2024 1:32:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [varchar](100) NOT NULL,
	[Manufacturer] [varchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[ReleasedYear] [int] NOT NULL,
 CONSTRAINT [PK__cars__68A0340E78B54AAF] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (1, N'Mitsubishi Xpander', N'Mitsubishi', 300000.0000, 2022)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (2, N'Hyundai Accent', N'Hyundai', 23000.0000, 2024)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (3, N'Mazda CX-5', N'Mazda', 20000.0000, 2022)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (4, N'88', N'88', 88.0000, 8888)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (5, N'123', N'123', 1322.0000, 1234)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (6, N'Mec400', N'Mec', 10000000.0000, 2026)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (14, N'Mec S600', N'Mec', 9000000000.0000, 2021)
INSERT [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (15, N'Mec S600', N'Mec', 9000000000.0000, 2021)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
