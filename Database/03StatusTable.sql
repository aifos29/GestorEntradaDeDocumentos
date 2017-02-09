USE [procedureDB]
GO

/****** Object:  Table [dbo].[status]    Script Date: 12/28/2016 21:47:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[status]') AND type in (N'U'))
DROP TABLE [dbo].[status]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[status]    Script Date: 12/28/2016 21:47:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[status](
	[idStatus] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[idStatus] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


