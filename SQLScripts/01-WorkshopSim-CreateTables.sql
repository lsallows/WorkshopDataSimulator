
GO
/****** Object:  Table [dbo].[BinClassRequest]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinClassRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[TimeStamp] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinClassResponse]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinClassResponse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[BinClass] [varchar](25) NOT NULL,
	[TimeStampRequested] [datetime] NOT NULL,
	[TimeStampResponded] [datetime] NOT NULL,
	[CodeVersion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoaterData]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoaterData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[CoaterData] [nvarchar](max) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastIndex]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastIndex](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [int] NOT NULL,
	[Index] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProducedEvent]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProducedEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ProductStatus] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScrapEvent]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScrapEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ScrapCode] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SimData]    Script Date: 6/10/2019 4:12:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubId] [varchar](25) NOT NULL,
	[SimData] [nvarchar](max) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
