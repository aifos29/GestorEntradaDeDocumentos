USE [procedureDB]
GO

/****** Object:  Table [dbo].[typeOfProcedure]    Script Date: 12/28/2016 21:49:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[typeOfProcedure]') AND type in (N'U'))
DROP TABLE [dbo].[typeOfProcedure]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[typeOfProcedure]    Script Date: 12/28/2016 21:49:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[typeOfProcedure](
	[idTypeOfProcedure] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfProcedure] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_typeOfProcedure] PRIMARY KEY CLUSTERED 
(
	[idTypeOfProcedure] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


