CREATE FUNCTION getNamePlatforme(@id int)
RETURNS nvarchar (50)
AS
Begin
	Declare @result as nvarchar(50)
	
	Select @result = name from dbo.Plataformers where idPlataformers =  @id
	
	RETURN @result
END