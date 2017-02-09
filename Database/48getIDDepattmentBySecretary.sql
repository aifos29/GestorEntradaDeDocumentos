USE [procedureDB]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[getIDDepartmentBySec](@id int)
RETURNS int
AS
Begin
	Declare @result as int
	
	Select @result = idDepartment from dbo.Secretary where idSecretary = @id
	
	RETURN @result
END

GO


