USE [SuperZapatos]
GO
/****** Object:  Table [dbo].[stores]    Script Date: 01/30/2017 09:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 01/30/2017 09:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](200) NULL,
	[price] [money] NOT NULL,
	[total_in_shelf] [int] NOT NULL,
	[total_in_vault] [int] NOT NULL,
	[store_id] [int] NOT NULL,
 CONSTRAINT [PK_articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_articles_stores]    Script Date: 01/30/2017 09:18:55 ******/
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_articles_stores] FOREIGN KEY([store_id])
REFERENCES [dbo].[stores] ([id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_articles_stores]
GO
