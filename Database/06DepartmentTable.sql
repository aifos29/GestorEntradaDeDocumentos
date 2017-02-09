USE [procedureDB]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 12/28/2016 21:56:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
DROP TABLE [dbo].[Department]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 12/28/2016 21:56:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[idDepartment] [int] IDENTITY(1,1) NOT NULL,
	[department] [nvarchar](50) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[idDepartment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


