USE [procedureDB]
GO

/****** Object:  UserDefinedFunction [dbo].[getNameAdministrator]    Script Date: 01/15/2017 17:07:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[getNameDepartment](@id int)
RETURNS nvarchar (50)
AS
Begin
	Declare @result as nvarchar(50)
	
	Select @result =  department from dbo.Department where idDepartment =  @id
	
	RETURN @result
END

GO


