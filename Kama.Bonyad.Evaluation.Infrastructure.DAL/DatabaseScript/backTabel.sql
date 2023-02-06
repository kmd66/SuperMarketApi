USE [Kama.Sm]
GO

/****** Object:  Table [prd].[Product]    Script Date: 2/6/2023 10:56:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [prd].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GuID] [uniqueidentifier] NOT NULL,
	[ParentID] [bigint] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Comment] [nvarchar](1000) NULL,
	[Price] [bigint] NOT NULL,
	[Discount] [bigint] NOT NULL,
	[Information] [nvarchar](max) NULL,
	[Removed] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UnitOfMeasure] [tinyint] NULL,
	[MinimumToAlert] [int] NULL,
	[BrandID] [bigint] NULL,
	[ExpiredToAlert] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [prd].[Product] ADD  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [prd].[Product] ADD  CONSTRAINT [DF_Product_Removed]  DEFAULT ((0)) FOR [Removed]
GO

