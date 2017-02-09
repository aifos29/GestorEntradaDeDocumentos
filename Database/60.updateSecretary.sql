USE [procedureDB]
GO

/****** Object:  StoredProcedure [dbo].[updateSecretary]    Script Date: 01/23/2017 11:38:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[updateSecretary]
(
	@idDep int,
	@idlog int,
	@name nvarchar(50)
)
AS
BEGIN
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[Secretary]
		   SET [name] = @name
				,[idDepartment] = @idDep
		WHERE dbo.Secretary.idLogging = @idlog
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END


GO


