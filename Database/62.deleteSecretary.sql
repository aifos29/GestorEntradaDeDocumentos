USE [procedureDB]
GO

/****** Object:  StoredProcedure [dbo].[updateSecretary]    Script Date: 01/23/2017 10:53:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[deleteSecretary]
(
	@idlog int
)
AS
BEGIN
    BEGIN TRY
		DELETE FROM [procedureDB].[dbo].[Secretary]
      WHERE dbo.Secretary.idLogging = @idlog
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END


GO


