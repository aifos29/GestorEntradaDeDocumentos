USE [procedureDB]
GO

/****** Object:  Table [dbo].[consecutive]    Script Date: 01/01/2017 17:20:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[consecutive](
	[consecutiveId] [int]IDENTITY(1,1) NOT NULL,
	[consecutiveNumber] [int] NOT NULL,
	[consecutiveYear] [int] NOT NULL,
 CONSTRAINT [PK_consecutive] PRIMARY KEY CLUSTERED 
(
	[consecutiveId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


