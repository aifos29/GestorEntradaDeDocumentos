USE [procedureDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[updateEmail]
(
	@id int,
	@email nvarchar(50)
)
AS
BEGIN
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[logging]
		SET [email] = @email
		WHERE dbo.logging.idLogging = @id
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END

GO


