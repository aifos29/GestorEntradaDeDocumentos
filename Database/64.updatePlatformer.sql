USE [procedureDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[updatePlatformer]
(
	@idlog int,
	@name nvarchar(50),
	@isABoss int
)
AS
BEGIN
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[Plataformers]
		SET [name] = @name
		,[isABoss] = @isABoss
		WHERE dbo.Plataformers.idLogging = @idlog
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END



GO


