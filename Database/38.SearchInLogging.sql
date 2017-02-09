USE [procedureDB]
GO

Create Function [dbo].[searchInLogging]
(
	@email nvarchar(50),
	@password nvarchar(300)
)
RETURNS INT AS
BEGIN

    Declare @id INT
    
        Select @id = idLogging from dbo.logging where email = @email 
						
		IF @id is NULL
		set @id = 0
	RETURN @id

END

GO


