USE [procedureDB]
GO

/****** Object:  Table [dbo].[typeOfIdentify]    Script Date: 12/28/2016 21:53:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[typeOfIdentify]') AND type in (N'U'))
DROP TABLE [dbo].[typeOfIdentify]
GO

USE [procedureDB]
GO

/****** Object:  Table [dbo].[typeOfIdentify]    Script Date: 12/28/2016 21:53:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[typeOfIdentify](
	[idTypeOfIdentify] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfIdentify] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_typeOfIdentify] PRIMARY KEY CLUSTERED 
(
	[idTypeOfIdentify] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


