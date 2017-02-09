CREATE FUNCTION [dbo].[getNameAdministrator](@id int)
RETURNS nvarchar (50)
AS
Begin
	Declare @result as nvarchar(50)
	
	Select @result = name from dbo.Administrator where idAdministrator =  @id
	
	RETURN @result
END
GO