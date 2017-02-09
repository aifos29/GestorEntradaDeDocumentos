USE [procedureDB]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_transferredDocuments_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[transferredDocuments]'))
ALTER TABLE [dbo].[transferredDocuments] DROP CONSTRAINT [FK_transferredDocuments_Department]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_transferredDocuments_procedure]') AND parent_object_id = OBJECT_ID(N'[dbo].[transferredDocuments]'))
ALTER TABLE [dbo].[transferredDocuments] DROP CONSTRAINT [FK_transferredDocuments_procedure]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_transferredDocuments_Secretary]') AND parent_object_id = OBJECT_ID(N'[dbo].[transferredDocuments]'))
ALTER TABLE [dbo].[transferredDocuments] DROP CONSTRAINT [FK_transferredDocuments_Secretary]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[transferredDocuments]    Script Date: 12/28/2016 23:03:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[transferredDocuments]') AND type in (N'U'))
DROP TABLE [dbo].[transferredDocuments]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[transferredDocuments]    Script Date: 12/28/2016 23:03:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[transferredDocuments](
	[idTransferredDocuments] [int] IDENTITY(1,1) NOT NULL,
	[justification] [nvarchar](50) NOT NULL,
	[idSender_Secretary] [int] NOT NULL,
	[idReceiver_Department] [int] NOT NULL,
	[idProcedure] [int] NOT NULL,
 CONSTRAINT [PK_transferredDocuments] PRIMARY KEY CLUSTERED 
(
	[idTransferredDocuments] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[transferredDocuments]  WITH CHECK ADD  CONSTRAINT [FK_transferredDocuments_Department] FOREIGN KEY([idReceiver_Department])
REFERENCES [dbo].[Department] ([idDepartment])
GO

ALTER TABLE [dbo].[transferredDocuments] CHECK CONSTRAINT [FK_transferredDocuments_Department]
GO

ALTER TABLE [dbo].[transferredDocuments]  WITH CHECK ADD  CONSTRAINT [FK_transferredDocuments_procedure] FOREIGN KEY([idProcedure])
REFERENCES [dbo].[procedure] ([idProcedure])
GO

ALTER TABLE [dbo].[transferredDocuments] CHECK CONSTRAINT [FK_transferredDocuments_procedure]
GO

ALTER TABLE [dbo].[transferredDocuments]  WITH CHECK ADD  CONSTRAINT [FK_transferredDocuments_Secretary] FOREIGN KEY([idSender_Secretary])
REFERENCES [dbo].[Secretary] ([idSecretary])
GO

ALTER TABLE [dbo].[transferredDocuments] CHECK CONSTRAINT [FK_transferredDocuments_Secretary]
GO


