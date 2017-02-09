USE [procedureDB]
GO

/****** Object:  StoredProcedure [dbo].[initializeProcedure]    Script Date: 01/23/2017 00:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[initializeProcedure]
( @code nvarchar(50))
AS
BEGIN
    Declare @statusId int;
    Select @statusId = s.idStatus from [dbo].[status] as s 
		where s.status = 'En proceso';
    BEGIN TRY
		UPDATE [procedureDB].[dbo].[procedure]
			SET [idStatus] = @statusId
			WHERE dbo.[procedure].code = @code
		
	END TRY
	BEGIN CATCH
		Select ERROR_MESSAGE() as messageError;
	END CATCH;
END


GO


