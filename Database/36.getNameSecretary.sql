CREATE FUNCTION [dbo].[getNameSecretary](@id int)
RETURNS nvarchar (50)
AS
Begin
	Declare @result as nvarchar(50)
	
	Select @result = name from dbo.Secretary where idSecretary =  @id
	
	RETURN @result
END
GO