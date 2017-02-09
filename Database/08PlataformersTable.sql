USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Plataformers_logging]') AND parent_object_id = OBJECT_ID(N'[dbo].[Plataformers]'))
ALTER TABLE [dbo].[Plataformers] DROP CONSTRAINT [FK_Plataformers_logging]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[Plataformers]    Script Date: 01/14/2017 17:06:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plataformers]') AND type in (N'U'))
DROP TABLE [dbo].[Plataformers]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[Plataformers]    Script Date: 01/14/2017 17:06:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Plataformers](
	[idPlataformers] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[isABoss] [int] NOT NULL,
	[idLogging] [int] NOT NULL,
 CONSTRAINT [PK_Plataformers] PRIMARY KEY CLUSTERED 
(
	[idPlataformers] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Plataformers]  WITH CHECK ADD  CONSTRAINT [FK_Plataformers_logging] FOREIGN KEY([idLogging])
REFERENCES [dbo].[logging] ([idLogging])
GO

ALTER TABLE [dbo].[Plataformers] CHECK CONSTRAINT [FK_Plataformers_logging]
GO


