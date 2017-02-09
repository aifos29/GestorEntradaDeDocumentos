USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_closed_procedure]') AND parent_object_id = OBJECT_ID(N'[dbo].[closed]'))
ALTER TABLE [dbo].[closed] DROP CONSTRAINT [FK_closed_procedure]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[closed]    Script Date: 01/14/2017 17:15:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[closed]') AND type in (N'U'))
DROP TABLE [dbo].[closed]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[closed]    Script Date: 01/14/2017 17:15:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[closed](
	[idClosed] [int] IDENTITY(1,1) NOT NULL, 
	[details] [nvarchar](300) NOT NULL,
	[date] [date] NOT NULL,
	[idProcedure] [int] NOT NULL,
 CONSTRAINT [PK_closed] PRIMARY KEY CLUSTERED 
(
	[idClosed] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[closed]  WITH CHECK ADD  CONSTRAINT [FK_closed_procedure] FOREIGN KEY([idProcedure])
REFERENCES [dbo].[procedure] ([idProcedure])
GO

ALTER TABLE [dbo].[closed] CHECK CONSTRAINT [FK_closed_procedure]
GO


