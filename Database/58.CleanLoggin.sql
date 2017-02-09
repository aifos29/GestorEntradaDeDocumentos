USE [procedureDB]
GO

/****** Object:  StoredProcedure [dbo].[cleanLogin]    Script Date: 01/21/2017 23:36:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[cleanLogin]
(
	@id int
)
AS
BEGIN
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[logging]
		SET [email] = ' '
		,[password] = ' '
		 ,[isActive] = 0
		WHERE dbo.logging.idLogging =@id
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END


GO


