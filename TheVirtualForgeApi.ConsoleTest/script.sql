USE [TheForgeDB]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 08/06/2021 12:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[ArtistName] [nvarchar](70) NOT NULL,
	[AlbumTypeID] [int] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumTypes]    Script Date: 08/06/2021 12:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_AlbumType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 
GO
INSERT [dbo].[Album] ([Id], [Title], [ArtistName], [AlbumTypeID], [Stock]) VALUES (1, N'Morning love', N'David Bowie', 1, 4)
GO
INSERT [dbo].[Album] ([Id], [Title], [ArtistName], [AlbumTypeID], [Stock]) VALUES (2, N'Heroes', N'David Bowie', 2, 3)
GO
INSERT [dbo].[Album] ([Id], [Title], [ArtistName], [AlbumTypeID], [Stock]) VALUES (3, N'Goodness of God', N'Cece Winans', 1, 4)
GO
INSERT [dbo].[Album] ([Id], [Title], [ArtistName], [AlbumTypeID], [Stock]) VALUES (4, N'Burning love', N'Elvis Presley', 2, 6)
GO
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumTypes] ON 
GO
INSERT [dbo].[AlbumTypes] ([Id], [Name]) VALUES (2, N'CD')
GO
INSERT [dbo].[AlbumTypes] ([Id], [Name]) VALUES (1, N'Vinyl')
GO
SET IDENTITY_INSERT [dbo].[AlbumTypes] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__AlbumName]    Script Date: 08/06/2021 12:29:32 ******/
ALTER TABLE [dbo].[AlbumTypes] ADD  CONSTRAINT [UQ__AlbumName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
