USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_procedure_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[procedure]'))
ALTER TABLE [dbo].[procedure] DROP CONSTRAINT [FK_procedure_Department]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_procedure_Plataformers]') AND parent_object_id = OBJECT_ID(N'[dbo].[procedure]'))
ALTER TABLE [dbo].[procedure] DROP CONSTRAINT [FK_procedure_Plataformers]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_procedure_status]') AND parent_object_id = OBJECT_ID(N'[dbo].[procedure]'))
ALTER TABLE [dbo].[procedure] DROP CONSTRAINT [FK_procedure_status]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_procedure_typeOfIdentify]') AND parent_object_id = OBJECT_ID(N'[dbo].[procedure]'))
ALTER TABLE [dbo].[procedure] DROP CONSTRAINT [FK_procedure_typeOfIdentify]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_procedure_typeOfProcedure]') AND parent_object_id = OBJECT_ID(N'[dbo].[procedure]'))
ALTER TABLE [dbo].[procedure] DROP CONSTRAINT [FK_procedure_typeOfProcedure]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[procedure]    Script Date: 01/14/2017 17:11:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procedure]') AND type in (N'U'))
DROP TABLE [dbo].[procedure]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[procedure]    Script Date: 01/14/2017 17:11:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[procedure](
	[idProcedure] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[code] [nvarchar](50) NOT NULL,
	[details] [nvarchar](300) NOT NULL,
	[identifyCode] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[contact] [nvarchar](50) NOT NULL,
	[idStatus] [int] NOT NULL,
	[idDepartment] [int] NOT NULL,
	[idTypeOfProcedure] [int] NOT NULL,
	[idTypeOfIdentify] [int] NOT NULL,
	[idPlatformers] [int] NOT NULL,
 CONSTRAINT [PK_procedure] PRIMARY KEY CLUSTERED 
(
	[idProcedure] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[procedure]  WITH CHECK ADD  CONSTRAINT [FK_procedure_Department] FOREIGN KEY([idDepartment])
REFERENCES [dbo].[Department] ([idDepartment])
GO

ALTER TABLE [dbo].[procedure] CHECK CONSTRAINT [FK_procedure_Department]
GO

ALTER TABLE [dbo].[procedure]  WITH CHECK ADD  CONSTRAINT [FK_procedure_Plataformers] FOREIGN KEY([idPlatformers])
REFERENCES [dbo].[Plataformers] ([idPlataformers])
GO

ALTER TABLE [dbo].[procedure] CHECK CONSTRAINT [FK_procedure_Plataformers]
GO

ALTER TABLE [dbo].[procedure]  WITH CHECK ADD  CONSTRAINT [FK_procedure_status] FOREIGN KEY([idStatus])
REFERENCES [dbo].[status] ([idStatus])
GO

ALTER TABLE [dbo].[procedure] CHECK CONSTRAINT [FK_procedure_status]
GO

ALTER TABLE [dbo].[procedure]  WITH CHECK ADD  CONSTRAINT [FK_procedure_typeOfIdentify] FOREIGN KEY([idTypeOfIdentify])
REFERENCES [dbo].[typeOfIdentify] ([idTypeOfIdentify])
GO

ALTER TABLE [dbo].[procedure] CHECK CONSTRAINT [FK_procedure_typeOfIdentify]
GO

ALTER TABLE [dbo].[procedure]  WITH CHECK ADD  CONSTRAINT [FK_procedure_typeOfProcedure] FOREIGN KEY([idTypeOfProcedure])
REFERENCES [dbo].[typeOfProcedure] ([idTypeOfProcedure])
GO

ALTER TABLE [dbo].[procedure] CHECK CONSTRAINT [FK_procedure_typeOfProcedure]
GO


