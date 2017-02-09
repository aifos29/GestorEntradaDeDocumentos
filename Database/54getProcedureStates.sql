USE [procedureDB]
GO
/****** Object:  UserDefinedFunction [dbo].[getDepartments]    Script Date: 01/15/2017 12:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[getStates]()
RETURNS table AS
RETURN(
	Select * from [dbo].[status]
)