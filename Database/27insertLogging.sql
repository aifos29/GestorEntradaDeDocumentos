USE [procedureDB]
GO
Create PROCEDURE insertLogging
(
	@email nvarchar(50),
	@password nvarchar(300)
)
AS
BEGIN

    Declare @message varchar(100);
    
    BEGIN TRY
		INSERT INTO [procedureDB].[dbo].[logging]
           ([email]
           ,[password])
     VALUES
           (
           @email
           , ENCRYPTBYPASSPHRASE('password',@password))
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END
GO