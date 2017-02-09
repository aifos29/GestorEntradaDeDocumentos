USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Secretary_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[Secretary]'))
ALTER TABLE [dbo].[Secretary] DROP CONSTRAINT [FK_Secretary_Department]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Secretary_logging]') AND parent_object_id = OBJECT_ID(N'[dbo].[Secretary]'))
ALTER TABLE [dbo].[Secretary] DROP CONSTRAINT [FK_Secretary_logging]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[Secretary]    Script Date: 01/14/2017 17:07:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Secretary]') AND type in (N'U'))
DROP TABLE [dbo].[Secretary]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[Secretary]    Script Date: 01/14/2017 17:07:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Secretary](
	[idSecretary] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[idLogging] [int] NOT NULL,
	[idDepartment] [int] NOT NULL,
 CONSTRAINT [PK_Secretary] PRIMARY KEY CLUSTERED 
(
	[idSecretary] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Secretary]  WITH CHECK ADD  CONSTRAINT [FK_Secretary_Department] FOREIGN KEY([idDepartment])
REFERENCES [dbo].[Department] ([idDepartment])
GO

ALTER TABLE [dbo].[Secretary] CHECK CONSTRAINT [FK_Secretary_Department]
GO

ALTER TABLE [dbo].[Secretary]  WITH CHECK ADD  CONSTRAINT [FK_Secretary_logging] FOREIGN KEY([idLogging])
REFERENCES [dbo].[logging] ([idLogging])
GO

ALTER TABLE [dbo].[Secretary] CHECK CONSTRAINT [FK_Secretary_logging]
GO


