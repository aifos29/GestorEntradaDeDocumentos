USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_logging_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[logging] DROP CONSTRAINT [DF_logging_isActive]
END

GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[logging]    Script Date: 01/14/2017 17:03:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logging]') AND type in (N'U'))
DROP TABLE [dbo].[logging]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[logging]    Script Date: 01/14/2017 17:03:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[logging](
	[idLogging] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](300) NOT NULL,
	[isActive] [int] NOT NULL,
 CONSTRAINT [PK_logging] PRIMARY KEY CLUSTERED 
(
	[idLogging] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[logging] ADD  CONSTRAINT [DF_logging_isActive]  DEFAULT ((1)) FOR [isActive]
GO


